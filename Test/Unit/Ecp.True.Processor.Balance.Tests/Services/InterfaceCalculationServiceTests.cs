﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterfaceCalculationServiceTests.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Processor.Balance.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ecp.True.DataAccess.Interfaces;
    using Ecp.True.Entities.Admin;
    using Ecp.True.Entities.Registration;
    using Ecp.True.Entities.TransportBalance;
    using Ecp.True.Processors.Balance.Calculation;
    using Ecp.True.Processors.Balance.Calculation.Input;
    using Ecp.True.Processors.Balance.Calculation.Interfaces;
    using Ecp.True.Processors.Balance.Calculation.Output;
    using Ecp.True.Processors.Balance.Operation.Input;
    using Ecp.True.Processors.Balance.Operation.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// The interface movement generator tests.
    /// </summary>
    [TestClass]
    public class InterfaceCalculationServiceTests
    {
        /// <summary>
        /// The balance tolerance movement generator.
        /// </summary>
        private Mock<IInterfaceMovementGenerator> interfaceMovementGenerator;

        /// <summary>
        /// The logger.
        /// </summary>
        private Mock<IUnitOfWork> unitOfWorkMock;

        /// <summary>
        /// The balance communicator.
        /// </summary>
        private Mock<IInterfaceCalculator> interfaceCalculator;

        /// <summary>
        /// The unbalance repository mock.
        /// </summary>
        private Mock<IRepository<Unbalance>> unbalanceRepositoryMock;

        /// <summary>
        /// The mock balance service.
        /// </summary>
        private InterfaceCalculationService interfaceCalculationService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.interfaceMovementGenerator = new Mock<IInterfaceMovementGenerator>();
            this.interfaceCalculator = new Mock<IInterfaceCalculator>();
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.unbalanceRepositoryMock = new Mock<IRepository<Unbalance>>();
            this.unbalanceRepositoryMock.Setup(s => s.Insert(It.IsAny<Unbalance>()));
            this.unitOfWorkMock.Setup(s => s.CreateRepository<Unbalance>()).Returns(this.unbalanceRepositoryMock.Object);
            this.interfaceCalculationService = new InterfaceCalculationService(this.interfaceCalculator.Object, this.interfaceMovementGenerator.Object);
        }

        /// <summary>
        /// Unidentified Loss MovementGenerator.
        /// </summary>
        /// <returns>The Task.</returns>
        [TestMethod]
        public async Task InterfaceCalculationService_ShouldGenerateMovementAndInsertUnbalance_WithSuccessAsync()
        {
            var nodes = new List<NodeInput>();
            var movements = new List<MovementCalculationInput>();
            var initialInventories = new List<InventoryInput>();
            var finalInventories = new List<InventoryInput>();
            var interfaceInfo = new List<InterfaceInfo>();
            var interface1 = new InterfaceInfo();
            var movementsGenerated = new List<Movement>();
            interface1.NodeId = 1;
            interface1.Unbalance = 1.0m;
            interfaceInfo.Add(interface1);
            nodes.Add(new NodeInput
            {
                NodeId = 1,
                Name = "Test 1",
                AcceptableBalancePercentage = 10,
                CalculationDate = new DateTime(2019, 02, 12),
                ControlLimit = 1,
            });

            movements.Add(new MovementCalculationInput
            {
                MovementId = "1",
                MeasurementUnit = "9",
                DestinationNodeId = 1,
                DestinationProductId = "1",
                DestinationProductName = "Test 2",
                MessageTypeId = 1,
                NetStandardVolume = 10,
                SourceNodeId = 2,
                SourceProductId = "2",
                SourceProductName = "Test 3",
                OperationalDate = new DateTime(2019, 02, 12),
                UncertaintyPercentage = 9,
            });

            initialInventories.Add(new InventoryInput
            {
                NodeId = 1,
                ProductId = "1",
                MeasurementUnit = "Bbl",
                ProductName = "Test 4",
                ProductVolume = 8,
                UncertaintyPercentage = 9,
                InventoryId = "1",
                InventoryDate = new DateTime(2019, 02, 11),
            });

            finalInventories.Add(new InventoryInput
            {
                NodeId = 1,
                ProductId = "1",
                MeasurementUnit = "Bbl",
                ProductName = "Test 4",
                ProductVolume = 8,
                UncertaintyPercentage = 9,
                InventoryId = "1",
                InventoryDate = new DateTime(2019, 02, 12),
            });

            movementsGenerated.Add(new Movement
            {
                MovementId = "1",
                NetStandardVolume = 10,
            });

            var balanceInputInfo = new BalanceInputInfo
            {
                CalculationDate = DateTime.Now,
                InitialInventories = initialInventories,
                FinalInventories = finalInventories,
                Movements = movements,
                Nodes = nodes,
                InterfaceNodes = nodes,
            };

            this.interfaceCalculator.Setup(x => x.CalculateAsync(It.IsAny<CalculationInput>())).Returns(Task.FromResult<IEnumerable<IOutput>>(interfaceInfo));
            this.interfaceMovementGenerator.Setup(x => x.GenerateAsync(It.IsAny<MovementInput>())).Returns(Task.FromResult((IEnumerable<Movement>)movementsGenerated));
            var ticket = new Ticket { TicketId = 23678, CategoryElementId = 2, StartDate = new DateTime(2019, 02, 12), EndDate = new DateTime(2019, 02, 16), Status = 0, CreatedBy = "System", CreatedDate = new DateTime(2019, 02, 18), LastModifiedBy = null, LastModifiedDate = null };

            // Act
            var result = await this.interfaceCalculationService.ProcessAsync(balanceInputInfo, ticket, this.unitOfWorkMock.Object).ConfigureAwait(false);

            // Assert or Verify
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Movements.ToList().Count);
            Assert.AreEqual("1", result.Movements.ToList()[0].MovementId);
            this.unbalanceRepositoryMock.Verify(x => x.Insert(It.IsAny<Unbalance>()), Times.Never);
        }
    }
}
