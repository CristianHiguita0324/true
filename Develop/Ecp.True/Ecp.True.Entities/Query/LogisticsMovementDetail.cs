﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogisticsMovementDetail.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Entities.Query
{
    using System;
    using System.ComponentModel;
    using Constants = Ecp.True.Entities.Constants;

    /// <summary>
    /// The LogisticsDetail.
    /// </summary>
    [DisplayName("Movimientos")]
    public class LogisticsMovementDetail : QueryEntity
    {
        /// <summary>
        /// Gets or sets the movement.
        /// </summary>
        /// <value>
        /// The movement.
        /// </value>
        [DisplayName("MOVIMIENTO")]
        public string Movement { get; set; }

        /// <summary>
        /// Gets or sets the storage source.
        /// </summary>
        /// <value>
        /// The storage source.
        /// </value>
        [DisplayName("ALMACEN-ORIGEN")]
        public string StorageSource { get; set; }

        /// <summary>
        /// Gets or sets the product origin.
        /// </summary>
        /// <value>
        /// The product origin.
        /// </value>
        [DisplayName("PRODUCTO-ORIGEN")]
        public string ProductOrigin { get; set; }

        /// <summary>
        /// Gets or sets the storage destination.
        /// </summary>
        /// <value>
        /// The storage destination.
        /// </value>
        [DisplayName("ALMACEN-DESTINO")]
        public string StorageDestination { get; set; }

        /// <summary>
        /// Gets or sets the prioduct destination.
        /// </summary>
        /// <value>
        /// The prioduct destination.
        /// </value>
        [DisplayName("PRODUCTO-DESTINO")]
        public string ProductDestination { get; set; }

        /// <summary>
        /// Gets or sets the order purchase.
        /// </summary>
        /// <value>
        /// The order purchase.
        /// </value>
        [DisplayName("ORDEN-COMPRA")]
        public int? OrderPurchase { get; set; }

        /// <summary>
        /// Gets or sets the position purchase.
        /// </summary>
        /// <value>
        /// The position purchase.
        /// </value>
        [DisplayName("POS-COMPRA")]
        public int? PosPurchase { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DisplayName("VALOR")]
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the uom.
        /// </summary>
        /// <value>
        /// The uom.
        /// </value>
        [DisplayName("UOM")]
        public string Uom { get; set; }

        /// <summary>
        /// Gets or sets the finding.
        /// </summary>
        /// <value>
        /// The finding.
        /// </value>
        [DisplayName("HALLAZGO")]
        public string Finding { get; set; }

        /// <summary>
        /// Gets or sets the diagnostic.
        /// </summary>
        /// <value>
        /// The diagnostic.
        /// </value>
        [DisplayName("DIAGNÓSTICO")]
        public string Diagnostic { get; set; }

        /// <summary>
        /// Gets or sets the impact.
        /// </summary>
        /// <value>
        /// The impact.
        /// </value>
        [DisplayName("IMPACTO")]
        public string Impact { get; set; }

        /// <summary>
        /// Gets or sets the solution.
        /// </summary>
        /// <value>
        /// The solution.
        /// </value>
        [DisplayName("SOLUCIÓN")]
        public string Solution { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [DisplayName("ESTADO")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [DisplayName("ORDEN")]
        public string Order { get; set; }

        /// <summary>
        /// Gets or sets the date operation.
        /// </summary>
        /// <value>
        /// The date operation.
        /// </value>
        [DisplayName("FECHA-OPERATIVA")]
        public DateTime? DateOperation { get; set; }

        /// <summary>
        /// Gets or sets the SourceNodeId.
        /// </summary>
        /// <value>
        /// The SourceNodeId.
        /// </value>
        public int SourceNodeId { get; set; }

        /// <summary>
        /// Gets or sets the SourceNode.
        /// </summary>
        /// <value>
        /// The SourceNode.
        /// </value>
        public string SourceNode { get; set; }

        /// <summary>
        /// Gets or sets the DestinationNodeId.
        /// </summary>
        /// <value>
        /// The DestinationNodeId.
        /// </value>
        public int DestinationNodeId { get; set; }

        /// <summary>
        /// Gets or sets the DestinationNode.
        /// </summary>
        /// <value>
        /// The DestinationNode.
        /// </value>
        public string DestinationNode { get; set; }

        /// <summary>
        /// Gets or sets the SourceProductId.
        /// </summary>
        /// <value>
        /// The SourceProductId.
        /// </value>
        public int SourceProductId { get; set; }

        /// <summary>
        /// Gets or sets the DestinationProductId.
        /// </summary>
        /// <value>
        /// The DestinationProductId.
        /// </value>
        public int DestinationProductId { get; set; }

        /// <summary>
        /// Gets or sets the SrcStorageLocationId.
        /// </summary>
        /// <value>
        /// The SrcStorageLocationId.
        /// </value>
        public int SrcStorageLocationId { get; set; }

        /// <summary>
        /// Gets or sets the DestStorageLocationId.
        /// </summary>
        /// <value>
        /// The DestStorageLocationId.
        /// </value>
        public int DestStorageLocationId { get; set; }

        /// <summary>
        /// Gets or sets the SrcLogisticCenterId.
        /// </summary>
        /// <value>
        /// The SrcLogisticCenterId.
        /// </value>
        public int SrcLogisticCenterId { get; set; }

        /// <summary>
        /// Gets or sets the SourceLogisticCenter.
        /// </summary>
        /// <value>
        /// The SourceLogisticCenter.
        /// </value>
        public string SourceLogisticCenter { get; set; }

        /// <summary>
        /// Gets or sets the DestLogisticCenterId.
        /// </summary>
        /// <value>
        /// The DestLogisticCenterId.
        /// </value>
        public int DestLogisticCenterId { get; set; }

        /// <summary>
        /// Gets or sets the DestinationLogisticCenter.
        /// </summary>
        /// <value>
        /// The DestinationLogisticCenter.
        /// </value>
        public string DestinationLogisticCenter { get; set; }

        /// <summary>
        /// Gets or sets the MovementTypeId.
        /// </summary>
        /// <value>
        /// The MovementTypeId.
        /// </value>
        public int MovementTypeId { get; set; }

        /// <summary>
        /// Gets or sets the NetVolume.
        /// </summary>
        /// <value>
        /// The NetVolume.
        /// </value>
        public decimal NetVolume { get; set; }

        /// <summary>
        /// Gets or sets the OperationDate.
        /// </summary>
        /// <value>
        /// The OperationDate.
        /// </value>
        public DateTime? OperationDate { get; set; }

        /// <summary>
        /// Gets or sets the OwnershipValue.
        /// </summary>
        /// <value>
        /// The OwnershipValue.
        /// </value>
        public decimal OwnershipValue { get; set; }

        /// <summary>
        /// Gets or sets the OwnershipValueUnit.
        /// </summary>
        /// <value>
        /// The OwnershipValueUnit.
        /// </value>
        public string OwnershipValueUnit { get; set; }

        /// <summary>
        /// Gets or sets the StartDate.
        /// </summary>
        /// <value>
        /// The StartDate.
        /// </value>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the EndDate.
        /// </summary>
        /// <value>
        /// The EndDate.
        /// </value>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the DestinationNodeOrder.
        /// </summary>
        /// <value>
        /// The DestinationNodeOrder.
        /// </value>
        public int? DestinationNodeOrder { get; set; }

        /// <summary>
        /// Gets or sets the SourceNodeOrder.
        /// </summary>
        /// <value>
        /// The SourceNodeOrder.
        /// </value>
        public string SourceNodeOrder { get; set; }

        /// <summary>
        /// Gets or sets the MovementTypeName.
        /// </summary>
        /// <value>
        /// The MovementTypeName.
        /// </value>
        public string MovementTypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this the DestinationNodeExportation.
        /// </summary>
        /// <value>
        /// The DestinationNodeExportation.
        /// </value>
        public bool DestinationNodeExportation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this the SourceNodeExportation.
        /// </summary>
        /// <value>
        /// The SourceNodeExportation.
        /// </value>
        public bool SourceNodeExportation { get; set; }

        /// <summary>
        /// Gets or sets the Classification.
        /// </summary>
        /// <value>
        /// The Classification.
        /// </value>
        public string Classification { get; set; }

        /// <summary>
        /// Sets the default values.
        /// </summary>
        public void SetDefaultValues()
        {
            this.Finding = Constants.LogisticFileStaticMessage;
            this.Impact = Constants.LogisticFileStaticMessage;
            this.Diagnostic = Constants.LogisticFileStaticMessage;
            this.Solution = Constants.LogisticFileStaticMessage;
        }
    }
}