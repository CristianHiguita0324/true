﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogisticsFailureHandler.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Processors.Core.HandleFailure
{
    using System.Threading;
    using System.Threading.Tasks;
    using Ecp.True.Core;
    using Ecp.True.DataAccess.Interfaces;
    using Ecp.True.Entities.Core;
    using Ecp.True.Entities.Enumeration;
    using Ecp.True.Entities.TransportBalance;
    using Ecp.True.Logging;

    /// <summary>
    /// The logistics failure handler.
    /// </summary>
    /// <seealso cref="Ecp.True.Processors.Core.FailureHandler.FailureHandlerBase" />
    public class LogisticsFailureHandler : FailureHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogisticsFailureHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public LogisticsFailureHandler(
                  ITrueLogger<LogisticsFailureHandler> logger)
                  : base(logger)
        {
        }

        /// <inheritdoc/>
        public override TicketType TicketType => TicketType.Logistics;

        /// <inheritdoc/>
        public override async Task HandleFailureAsync(IUnitOfWork unitOfWork, FailureInfo failureInfo)
        {
            ArgumentValidators.ThrowIfNull(failureInfo, nameof(failureInfo));
            ArgumentValidators.ThrowIfNull(unitOfWork, nameof(unitOfWork));
            this.Logger.LogInformation($"Handling failure for ticket:  {failureInfo.TicketId}", $"{failureInfo.TicketId}");
            var ticketRepository = unitOfWork.CreateRepository<Ticket>();
            var ticket = await ticketRepository.GetByIdAsync(failureInfo.TicketId).ConfigureAwait(false);
            ticket.Status = StatusType.ERROR;
            ticket.ErrorMessage = failureInfo.ErrorMessage;
            ticketRepository.Update(ticket);
            await unitOfWork.SaveAsync(CancellationToken.None).ConfigureAwait(false);
        }
    }
}
