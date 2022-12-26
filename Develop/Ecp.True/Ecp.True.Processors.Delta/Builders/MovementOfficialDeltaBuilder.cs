﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovementOfficialDeltaBuilder.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Processors.Delta.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ecp.True.Core;
    using Ecp.True.Entities.Admin;
    using Ecp.True.Entities.Core;
    using Ecp.True.Entities.Enumeration;
    using Ecp.True.Entities.Query;
    using Ecp.True.Entities.Registration;
    using Ecp.True.Logging;
    using Ecp.True.Processors.Delta.Entities;
    using Ecp.True.Processors.Delta.Entities.OfficialDelta;
    using Ecp.True.Processors.Delta.Interfaces;

    /// <summary>
    /// The error movement builder.
    /// </summary>
    public class MovementOfficialDeltaBuilder : OfficialDeltaBuilderBase<OfficialResultMovement>, IOfficialDeltaBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovementOfficialDeltaBuilder"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public MovementOfficialDeltaBuilder(ITrueLogger<MovementOfficialDeltaBuilder> logger)
                : base(logger)
        {
        }

        /// <inheritdoc/>
        public override Task<IEnumerable<DeltaNodeError>> BuildErrorsAsync(OfficialDeltaData deltaData)
        {
            ArgumentValidators.ThrowIfNull(deltaData, nameof(deltaData));

            this.Logger.LogInformation($"{nameof(MovementOfficialDeltaBuilder)}: Building DeltaNodeErrors for ticket {deltaData.Ticket.TicketId}", deltaData.Ticket.TicketId);

            var deltaErrors = new List<DeltaNodeError>();
            var officialMovementErrors = deltaData.MovementErrors.Where(x => x.Origin == True.Entities.Enumeration.OriginType.OFICIAL);

            foreach (var deltaMovementError in officialMovementErrors)
            {
                var movementNodeIds = GetMovementNodeIds(deltaMovementError, deltaData);
                foreach (var nodeId in movementNodeIds)
                {
                    var movementError = new DeltaNodeError
                    {
                        ErrorMessage = deltaMovementError.Description,
                        DeltaNodeId = deltaData.DeltaNodes.FirstOrDefault(x => x.NodeId == nodeId).DeltaNodeId,
                    };

                    movementError.MovementTransactionId = deltaMovementError.MovementTransactionId;
                    deltaErrors.Add(movementError);
                }
            }

            return Task.FromResult(deltaErrors as IEnumerable<DeltaNodeError>);
        }

        /// <inheritdoc/>
        public override async Task<IEnumerable<Movement>> BuildMovementsAsync(OfficialDeltaData deltaData)
        {
            ArgumentValidators.ThrowIfNull(deltaData, nameof(deltaData));

            this.Logger.LogInformation($"{nameof(MovementOfficialDeltaBuilder)}: Building Movements for ticket {deltaData.Ticket.TicketId}", deltaData.Ticket.TicketId);
            return await this.DoBuildAsync(deltaData).ConfigureAwait(false);
        }

        private static IEnumerable<int> GetMovementNodeIds(OfficialErrorMovement officialErrorMovement, OfficialDeltaData deltaData)
        {
            var nodeIds = new List<int>();
            var officialMovement = deltaData.PendingOfficialMovements.FirstOrDefault(x => x.MovementTransactionId == officialErrorMovement.MovementTransactionId);
            if (officialMovement.SourceNodeId.HasValue)
            {
                nodeIds.Add(officialMovement.SourceNodeId.Value);
            }

            if (officialMovement.DestinationNodeId.HasValue)
            {
                nodeIds.Add(officialMovement.DestinationNodeId.Value);
            }

            return nodeIds.Where(x => deltaData.DeltaNodes.Any(y => y.NodeId == x)).Distinct();
        }

        private static PendingOfficialMovement GetOfficialTolerance(PendingOfficialMovement officialUnidentifiedLoss)
        {
            var officialTolerance = officialUnidentifiedLoss.ShallowCopy();
            officialTolerance.MovementTypeID = (int)MovementType.Tolerance;
            return officialTolerance;
        }

        private static PendingOfficialMovement GetOfficialUnidentifiedLoss(OfficialDeltaData deltaData, ConsolidatedMovement consolidatedMovement)
        {
            return deltaData.PendingOfficialMovements.FirstOrDefault(
                m => m.SourceNodeId == consolidatedMovement.SourceNodeId
                     && m.DestinationNodeId == consolidatedMovement.DestinationNodeId
                     && m.SourceProductId == consolidatedMovement.SourceProductId
                     && m.DestinationProductId == consolidatedMovement.DestinationProductId
                     && m.MovementTypeID == (int)MovementType.UnidentifiedLoss);
        }

        private async Task<IEnumerable<Movement>> DoBuildAsync(OfficialDeltaData deltaData)
        {
            ArgumentValidators.ThrowIfNull(deltaData, nameof(deltaData));
            var movements = new List<Movement>();
            var tasks = new List<Task<Movement>>();
            var officialResultMovements = deltaData.OfficialResultMovements.Where(x => x.Origin == True.Entities.Enumeration.OriginType.OFICIAL);

            officialResultMovements.ForEach(officialResultMovement =>
            {
                tasks.Add(this.GetMovementAsync(officialResultMovement, deltaData, officialResultMovement.Sign));
            });

            await Task.WhenAll(tasks).ConfigureAwait(false);
            tasks.ForEach(r => movements.Add(r.Result));

            return movements;
        }

        private Task<Movement> GetMovementAsync(
            OfficialResultMovement officialResultMovement,
            OfficialDeltaData deltaData,
            bool isPositive)
        {
            var originalMovement = deltaData.PendingOfficialMovements.FirstOrDefault(x => x.MovementTransactionId == officialResultMovement.MovementTransactionId);

            if (originalMovement is { })
            {
                return this.BuildMovementAsync(officialResultMovement, originalMovement, deltaData, isPositive);
            }

            return this.BuildMovementForToleranceAsync(officialResultMovement, deltaData, isPositive);
        }

        private Task<Movement> BuildMovementForToleranceAsync(OfficialResultMovement officialResultMovement, OfficialDeltaData deltaData, bool isPositive)
        {
            var consolidatedMovement = deltaData.ConsolidationMovements.FirstOrDefault(m =>
                m.ConsolidatedMovementId == officialResultMovement.MovementTransactionId);

            var officialUnidentifiedLoss = GetOfficialUnidentifiedLoss(deltaData, consolidatedMovement);

            var officialTolerance = GetOfficialTolerance(officialUnidentifiedLoss);

            officialResultMovement.MovementTransactionId = officialUnidentifiedLoss.MovementTransactionId;
            return this.BuildMovementAsync(officialResultMovement, officialTolerance, deltaData, isPositive);
        }

        /// <summary>
        /// CreateSourceDestinationMovement.
        /// </summary>
        /// <param name="officialResultMovement">The officialResultMovement.</param>
        /// <param name="officialMovement">The officialMovement.</param>
        /// <param name="deltaData">The deltaData.</param>
        /// <param  name="isPositive">The positive.</param>
        /// <returns>movement.</returns>
        private Task<Movement> BuildMovementAsync(
            OfficialResultMovement officialResultMovement,
            PendingOfficialMovement officialMovement,
            OfficialDeltaData deltaData,
            bool isPositive)
        {
            var movement = this.CreateMovement(deltaData.Ticket.TicketId);
            movement.NetStandardVolume = isPositive ? officialResultMovement.OfficialDelta : -1 * officialResultMovement.OfficialDelta;
            movement.SourceMovementTransactionId = officialResultMovement.MovementTransactionId;
            movement.MeasurementUnit = officialMovement.MeasurementUnit;
            movement.SegmentId = officialMovement.SegmentId;
            movement.Period = new MovementPeriod { StartTime = officialMovement.StartDate, EndTime = officialMovement.EndDate };
            movement.OperationalDate = officialMovement.OperationalDate.Date;
            movement.OfficialDeltaMessageTypeId = OfficialDeltaMessageType.OfficialMovementDelta;
            movement.MovementTypeId = !isPositive ? deltaData.CancellationTypes.FirstOrDefault(
                x => x.SourceMovementTypeId == officialMovement.MovementTypeID)
                .AnnulationMovementTypeId : officialMovement.MovementTypeID;

            if (officialMovement.SourceNodeId.HasValue)
            {
                movement.MovementSource = new MovementSource
                {
                    SourceNodeId = officialMovement.SourceNodeId,
                    SourceProductId = officialMovement.SourceProductId,
                    SourceProductTypeId = officialMovement.SourceProductTypeId,
                };
            }

            if (officialMovement.DestinationNodeId.HasValue)
            {
                movement.MovementDestination = new MovementDestination
                {
                    DestinationNodeId = officialMovement.DestinationNodeId,
                    DestinationProductId = officialMovement.DestinationProductId,
                    DestinationProductTypeId = officialMovement.DestinationProductTypeId,
                };
            }

            movement.Owners.AddRange(this.CalculateOwners(officialResultMovement, true));
            return Task.FromResult(movement);
        }
    }
}
