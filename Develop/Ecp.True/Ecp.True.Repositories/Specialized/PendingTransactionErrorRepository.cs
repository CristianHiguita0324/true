﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PendingTransactionErrorRepository.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
// <auto-generated />
namespace Ecp.True.Repositories.Specialized
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Ecp.True.DataAccess.Interfaces;
    using Ecp.True.DataAccess.Sql;
    using Ecp.True.Entities.Admin;
    using Ecp.True.Entities.Core;
    using Ecp.True.Entities.Dto;
    using Ecp.True.Entities.Enumeration;
    using Ecp.True.Entities.Registration;
    using Ecp.True.Entities.TransportBalance;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// PendingTransactionError Repository.
    /// </summary>
    public class PendingTransactionErrorRepository : Repository<PendingTransactionError>, IPendingTransactionErrorRepository
    {
        /// <summary>
        /// The sql data access.
        /// </summary>
        private readonly ISqlDataAccess<PendingTransactionError> sqlDataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingTransactionErrorRepository"/> class.
        /// </summary>
        /// <param name="sqlDataAccess">The sql data access.</param>
        public PendingTransactionErrorRepository(ISqlDataAccess<PendingTransactionError> sqlDataAccess)
            : base(sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }

        /// <summary>
        /// Gets the PendingTransactionErrors.
        /// </summary>
        /// <value>
        /// The PendingTransactionErrors.
        /// </value>
        private DbSet<PendingTransactionError> PendingTransactionErrors => this.sqlDataAccess.EntitySet();

        /// <summary>
        /// Gets the PendingTransactions.
        /// </summary>
        /// <value>
        /// The PendingTransactions.
        /// </value>
        private DbSet<PendingTransaction> PendingTransactions => this.sqlDataAccess.Set<PendingTransaction>();

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        private DbSet<Node> Nodes => this.sqlDataAccess.Set<Node>();

        /// <summary>
        /// Gets the Products.
        /// </summary>
        /// <value>
        /// The Products.
        /// </value>
        private DbSet<Product> Products => this.sqlDataAccess.Set<Product>();

        /// <summary>
        /// Gets the Category Elements.
        /// </summary>
        /// <value>
        /// The category Elements.
        /// </value>
        private DbSet<CategoryElement> CategoryElements => this.sqlDataAccess.Set<CategoryElement>();

        /// <summary>
        /// Gets the file registration transactions.
        /// </summary>
        /// <value>
        /// The file registration transactions.
        /// </value>
        private DbSet<FileRegistrationTransaction> FileRegistrationTransactions => this.sqlDataAccess.Set<FileRegistrationTransaction>();

        /// <summary>
        /// Gets the system types.
        /// </summary>
        /// <value>
        /// The system types.
        /// </value>
        private DbSet<SystemTypeEntity> SystemTypes => this.sqlDataAccess.Set<SystemTypeEntity>();

        /// <summary>
        /// Gets the pending transaction errors.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns>
        /// Returns the pensing transaction errors.
        /// </returns>
        public async Task<IEnumerable<PendingTransactionErrorDto>> GetPendingTransactionErrorsAsync(Ticket ticket)
        {
            var applyElements = from ad in this.ApplyDestination(this.ApplySource(this.FilterItems(ticket)))
                                join ce in this.CategoryElements
                                on ad.pt.SystemName equals ce.ElementId into elementGrouping
                                from ce in elementGrouping.DefaultIfEmpty()
                                join categoryElements in this.CategoryElements
                                on ad.pt.Units equals categoryElements.ElementId into grouping
                                from categoryElements in grouping.DefaultIfEmpty()
                                join fileRegistrationTransaction in this.FileRegistrationTransactions
                                on ad.pte.RecordId equals fileRegistrationTransaction.RecordId into transactionGrouping
                                from transaction in transactionGrouping.DefaultIfEmpty()
                                where (ad.pt.MessageTypeId == Entities.Core.MessageType.Movement || ad.pt.MessageTypeId == Entities.Core.MessageType.Loss ||
                                ad.pt.MessageTypeId == Entities.Core.MessageType.SpecialMovement || ad.pt.MessageTypeId == Entities.Core.MessageType.Inventory)
                                && (ad.pte.Comment == null || (ad.pte.Comment != null && ad.pte.SessionId != null))
                                && (ad.pte.RecordId == null || (ad.pte.RecordId != null && transaction.StatusTypeId == StatusType.FAILED))
                                select new PendingTransactionErrorDto
                                {
                                    Comment = ad.pte.Comment,
                                    CreatedBy = ad.pte.CreatedBy,
                                    CreatedDate = ad.pte.CreatedDate,
                                    ErrorId = ad.pte.ErrorId,
                                    ErrorMessage = ad.pte.ErrorMessage,
                                    LastModifiedBy = ad.pte.LastModifiedBy,
                                    LastModifiedDate = ad.pte.LastModifiedDate,
                                    PendingTransaction = ad.pt,
                                    TransactionId = ad.pte.TransactionId,
                                    SourceNode = ad.sourceNode != null ? ad.sourceNode.Name : ad.pt.SourceNode,
                                    DestinationNode = ad.destinationNode != null ? ad.destinationNode.Name : ad.pt.DestinationNode,
                                    SourceProduct = ad.sourceProduct != null ? ad.sourceProduct.Name : ad.pt.SourceProduct,
                                    DestinationProduct = ad.destinationProduct != null ? ad.destinationProduct.Name : ad.pt.DestinationProduct,
                                    Units = categoryElements != null ? categoryElements.Name : Convert.ToString(ad.pt.Units, CultureInfo.InvariantCulture),
                                    SystemName = ce.Name,
                                    SystemTypeId = (int)ad.pt.SystemTypeId,
                                    MessageType = ad.pt.MessageTypeId == MessageType.Inventory ? "Inventario" : "Movimiento",
                                    ActionType = ad.pt.ActionTypeId == FileRegistrationActionType.Insert ? "Insertar" : (ad.pt.ActionTypeId == FileRegistrationActionType.Delete ? "Eliminar" : "Actualizar")
                                };

            var result = await applyElements.ToListAsync().ConfigureAwait(false);
            var systemTypeIds = result.Select(x => x.SystemTypeId);
            var systemNames = await this.SystemTypes.Where(x => systemTypeIds.Contains(x.SystemTypeId)).ToListAsync().ConfigureAwait(false);
            foreach (var pendingTransaction in result)
            {
                pendingTransaction.SystemTypeName = systemNames.FirstOrDefault(x => x.SystemTypeId == pendingTransaction.SystemTypeId)?.Name;
                if (string.IsNullOrEmpty(pendingTransaction.SystemName))
                {
                    pendingTransaction.SystemName = pendingTransaction.SystemTypeName;
                }
            }
            return result;
        }

        private IQueryable<(PendingTransactionError pte, PendingTransaction pt, Node sourceNode, Product sourceProduct, Node destinationNode, Product destinationProduct)> ApplyDestination(
            IQueryable<(PendingTransactionError pte, PendingTransaction pt, Node sourceNode, Product sourceProduct)> applySource)
        {
            return from u in applySource
                   join destinationNode in this.Nodes
                   on u.pt.DestinationNode equals destinationNode.NodeId.ToString(CultureInfo.InvariantCulture) into grouping
                   from destinationNode in grouping.DefaultIfEmpty()
                   join destinationProduct in this.Products
                   on u.pt.DestinationProduct equals destinationProduct.ProductId into productGrouping
                   from destinationProduct in productGrouping.DefaultIfEmpty()
                   select ValueTuple.Create(u.pte, u.pt, u.sourceNode, u.sourceProduct, destinationNode, destinationProduct);
        }

        private IQueryable<(PendingTransactionError pte, PendingTransaction pt, Node sourceNode, Product sourceProduct)> ApplySource(
            IQueryable<(PendingTransactionError pte, PendingTransaction pt)> filterItems)
        {
            return from x in filterItems
                   join sourceNode in this.Nodes
                   on x.pt.SourceNode equals sourceNode.NodeId.ToString(CultureInfo.InvariantCulture) into grouping
                   from sourceNode in grouping.DefaultIfEmpty()
                   join sourceProduct in this.Products
                   on x.pt.SourceProduct equals sourceProduct.ProductId into productGrouping
                   from sourceProduct in productGrouping.DefaultIfEmpty()
                   select ValueTuple.Create(x.pte, x.pt, sourceNode, sourceProduct);
        }

        private IQueryable<(PendingTransactionError pte, PendingTransaction pt)> FilterItems(Ticket ticket)
        {
            return from pte in this.PendingTransactionErrors
                   join pt in this.PendingTransactions
                    on pte.TransactionId equals pt.TransactionId
                   where pt.StartDate == null ||
                   (((pt.MessageTypeId == MessageType.Inventory && pt.StartDate.Value.Date >= ticket.StartDate.AddDays(-1).Date)
                   || (pt.MessageTypeId != MessageType.Inventory && pt.StartDate.Value.Date >= ticket.StartDate.Date)) &&
                   pt.StartDate.Value.Date <= ticket.EndDate.Date && (pt.ScenarioId == null || pt.ScenarioId == ScenarioType.OPERATIONAL) &&
                   pt.TicketId == null)
                   select ValueTuple.Create(pte, pt);
        }
    }
}
