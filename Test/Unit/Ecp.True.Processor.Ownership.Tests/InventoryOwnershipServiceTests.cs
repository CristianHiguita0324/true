﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryOwnershipServiceTests.cs" company="Microsoft">
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

namespace Ecp.True.Processor.Ownership.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Ecp.True.DataAccess.Interfaces;
    using Ecp.True.Entities.Registration;
    using Ecp.True.Processors.Ownership.Services;
    using Ecp.True.Proxies.OwnershipRules.Response;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// The InventoryOwnershipServiceTests.
    /// </summary>
    [TestClass]
    public class InventoryOwnershipServiceTests
    {
        /// <summary>
        /// The inventory ownership service.
        /// </summary>
        private InventoryOwnershipService inventoryOwnershipService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.inventoryOwnershipService = new InventoryOwnershipService();
        }

        /// <summary>
        /// Gets the inventory ownerships should process.
        /// </summary>
        /// <returns>The task.</returns>
        [TestMethod]
        public void GetInventoryOwnerships_ShouldProcess()
        {
            var ownershipResultInventory = new OwnershipResultInventory
            {
                AppliedRule = "Rule One",
                ResponseInventoryId = "1",
                OwnerId = 1,
                OwnershipPercentage = 12.4M,
                OwnershipVolume = 15.5M,
                RuleVersion = 1,
                ResponseTicket = "12",
            };

            var inventoryList = new List<OwnershipResultInventory> { ownershipResultInventory };

            // Act
            var result = this.inventoryOwnershipService.GetInventoryOwnerships(inventoryList);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
