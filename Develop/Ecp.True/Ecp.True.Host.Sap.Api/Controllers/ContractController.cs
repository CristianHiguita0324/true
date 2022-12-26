﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractController.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Host.Sap.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Ecp.True.Core;
    using Ecp.True.Core.Interfaces;
    using Ecp.True.Entities.Core;
    using Ecp.True.Entities.Dto;
    using Ecp.True.Entities.Enumeration;
    using Ecp.True.Entities.Sap;
    using Ecp.True.Entities.Sap.Purchases;
    using Ecp.True.Host.Core.Result;
    using Ecp.True.Host.Sap.Api.Filter;
    using Ecp.True.Processors.Transform.Input.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The Sales controller.
    /// </summary>
    [ApiVersion("1")]
    [CLSCompliant(false)]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "Sap")]
    public class ContractController : ControllerBase
    {
        /// <summary>
        /// The business context.
        /// </summary>
        private readonly IBusinessContext businessContext;

        /// <summary>
        /// The processor.
        /// </summary>
        private readonly IInputFactory processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractController" /> class.
        /// </summary>
        /// <param name="businessContext">The business context.</param>
        /// <param name="processor">The processor.</param>
        public ContractController(IBusinessContext businessContext, IInputFactory processor)
        {
            this.businessContext = businessContext;
            this.processor = processor;
        }

        /// <summary>
        /// Creates new sales.
        /// </summary>
        /// <param name="sales">The sales array.</param>
        /// <returns>Returns the status.</returns>
        [HttpPost]
        [Route("api/v{version:apiVersion}/sales")]
        [ValidateSapRequestFilter("sales")]
        public Task<IActionResult> CreateSaleAsync([FromBody] Sale sales)
        {
            return this.SaveAsync(JObject.Parse(JsonConvert.SerializeObject(sales)), MessageType.Sale);
        }

        /// <summary>
        /// Creates new inventories.
        /// </summary>
        /// <param name="purchase">The inventories array.</param>
        /// <returns>Returns the status.</returns>
        [HttpPost]
        [Route("api/v{version:apiVersion}/purchases")]
        [ValidateSapRequestFilter("purchase")]
        public Task<IActionResult> CreatePurchasesAsync([FromBody] SapPurchase purchase)
        {
            return this.SaveAsync(JObject.Parse(JsonConvert.SerializeObject(purchase)), MessageType.Purchase);
        }

        /// <summary>
        /// Saves the SAP input.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="type">The type.</param>
        /// <param name="isOfficial">The isOfficial.</param>
        /// <returns>Returns the status.</returns>
        private async Task<IActionResult> SaveAsync(JObject item, MessageType type, bool isOfficial = false)
        {
            ArgumentValidators.ThrowIfNull(item, nameof(item));

            var uploadId = Guid.NewGuid().ToString();

            var blobPath = $"{SystemType.SAP.ToString().ToLowerCase()}/{type}/{uploadId}";
            var trueMessage = new TrueMessage(SystemType.SAP, type, uploadId, blobPath, this.businessContext.ActivityId, isOfficial, IntegrationType.REQUEST);
            await this.processor.SaveSapJsonAsync(item, trueMessage).ConfigureAwait(false);

            return isOfficial ? new EntityResult() : new EntityResult(new Guid(trueMessage.MessageId));
        }
    }
}
