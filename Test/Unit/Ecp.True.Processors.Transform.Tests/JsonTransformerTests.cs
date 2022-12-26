﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonTransformerTests.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
// <auto-generated>
namespace Ecp.True.Processors.Transform.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Ecp.True.Entities.Dto;
    using Ecp.True.Processors.Transform.Services.Json;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The Json Transform Processor Tests.
    /// </summary>
    [TestClass]
    public class JsonTransformerTests
    {
        /// <summary>
        /// The json transformer.
        /// </summary>
        private JsonTransformer jsonTransformer;

        /// <summary>
        /// The inventory json.
        /// </summary>
        private JToken inventoryJson;

        /// <summary>
        /// The inventory json.
        /// </summary>
        private JToken movementJson;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.jsonTransformer = new JsonTransformer();
            this.inventoryJson = GetInventoryJson();
            this.movementJson = GetMovementJson();
        }

        /// <summary>
        /// Transforms the json asynchronous should transform json when invoked asynchronous.
        /// </summary>
        /// <returns>The task.</returns>
        [TestMethod]
        public async Task TransformJsonAsync_Should_TransformJson_WhenInvokedAsync()
        {
            var res = JArray.FromObject(this.inventoryJson);
            var message = new TrueMessage();
            message.Message = Entities.Core.MessageType.Inventory;
            var result = await this.jsonTransformer.TransformJsonAsync(this.inventoryJson, message).ConfigureAwait(false);

            var inventoryProducts = JArray.Parse(result.ToString());
            Assert.IsNotNull(inventoryProducts);
            Assert.AreEqual(2, inventoryProducts.Count);
            Assert.AreEqual("920200221", inventoryProducts[0]["InventoryId"].ToString());
            Assert.AreEqual("920200220", inventoryProducts[1]["InventoryId"].ToString());
            Assert.AreEqual("CRUDO CAMPO MAMBO", inventoryProducts[0]["ProductId"].ToString());
            Assert.AreEqual("CRUDO CAMPO MAMBO", inventoryProducts[1]["ProductId"].ToString());
        }

        /// <summary>
        /// Transforms the movements json asynchronous should transform json when invoked asynchronous.
        /// </summary>
        /// <returns>The task.</returns>
        [TestMethod]
        public async Task TransformMovementJsonAsync_Should_TransformJson_WhenInvokedAsync()
        {
            var message = new TrueMessage();
            message.Message = Entities.Core.MessageType.Movement;
            var result = await this.jsonTransformer.TransformJsonAsync(this.movementJson, message).ConfigureAwait(false);
            var movements = JArray.Parse(result.ToString());
            Assert.IsNotNull(movements);
            Assert.AreEqual(1, movements.Count);
            Assert.AreEqual(123, movements[0]["MovementId"]);
            Assert.AreEqual(25, movements[0]["MovementTypeId"]);
            Assert.AreEqual(2, movements[0]["MovementDestination"]["DestinationProductId"]);
        }

        /// <summary>
        /// Transforms the movements json asynchronous should transform official information json when invoked asynchronous.
        /// </summary>
        /// <returns>The task.</returns>
        [TestMethod]
        public async Task TransformMovementJsonAsync_Should_TransformJsonOfficialInformation_WhenInvokedAsync()
        {
            this.movementJson = GetMovementOfficialInformationJson();
            var message = new TrueMessage();
            message.Message = Entities.Core.MessageType.Movement;
            var result = await this.jsonTransformer.TransformJsonAsync(this.movementJson, message).ConfigureAwait(false);
            var movements = JArray.Parse(result.ToString());
            Assert.IsNotNull(movements);
            Assert.AreEqual(1, movements.Count);
            Assert.AreEqual(true, movements[0]["OfficialInformation"]["IsOfficial"]);
            Assert.AreEqual(1, movements[0]["OfficialInformation"]["BackupMovementId"]);
            Assert.AreEqual(2, movements[0]["OfficialInformation"]["GlobalMovementId"]);
        }

        /// <summary>
        /// Transforms the movements json asynchronous should transform json when invoked asynchronous.
        /// </summary>
        /// <returns>The task.</returns>
        [TestMethod]
        public void TransformMovementJsonAsync_Should_ThrowException_WhenInvoked()
        {
            var res = JArray.FromObject(this.movementJson);
            this.movementJson = GetMovementJsonWhenMovementSourceIsNull();
            var message = new TrueMessage();
            message.Message = Entities.Core.MessageType.Movement;
            Assert.ThrowsExceptionAsync<InvalidDataException>(async () => await this.jsonTransformer.TransformJsonAsync(this.movementJson, message).ConfigureAwait(false));
        }

        /// <summary>
        /// Transforms the movements json asynchronous should transform json when invoked asynchronous.
        /// </summary>
        /// <returns>The task.</returns>
        [TestMethod]
        public async Task TransformMovementJsonAsync_ShouldAutoCompleteDestinationProductId_WhenInvokedAsync()
        {
            var message = new TrueMessage();
            message.Message = Entities.Core.MessageType.Movement;
            var movementJson = GetMovementJsonWhenDestinationProductIdIsNull();
            var result = await this.jsonTransformer.TransformJsonAsync(movementJson, message).ConfigureAwait(false);
            var movements = JArray.Parse(result.ToString());
            message.Message = Entities.Core.MessageType.Movement;
            Assert.IsNotNull(movements);
            Assert.AreEqual(2, movements[0]["MovementDestination"]["DestinationProductId"]);
        }

        /// <summary>
        /// Transforms the movements json asynchronous should transform json when invoked asynchronous.
        /// </summary>
        /// <returns>The task.</returns>
        [TestMethod]
        public async Task TransformMovementJsonAsync_ShouldThrowDestinationProductIdMandatoryError_WhenInvokedAsync()
        {
            var message = new TrueMessage();
            message.Message = Entities.Core.MessageType.Movement;
            var movementJson = GetMovementJsonWhenDestinationProductIdIsNull();
            var result = await this.jsonTransformer.TransformJsonAsync(movementJson, message).ConfigureAwait(false);
            var movements = JArray.Parse(result.ToString());
            message.Message = Entities.Core.MessageType.Movement;
            Assert.IsNotNull(movements);
            Assert.AreEqual(2, movements[0]["MovementDestination"]["DestinationProductId"]);
        }

        /// <summary>
        /// Gets the inventory json.
        /// </summary>
        /// <returns>Returns JToken.</returns>
        private static JToken GetInventoryJson()
        {
            var inventory = "[{\"SourceSystem\": \"SINOPER\", \"DestinationSystem\": \"TRUE\",\"EventType\": \"DELETE\", \"InventoryId\": \"920200220\"," +
                "\"InventoryDate\": \"2020-04-12T00:00:00\", \"NodeId\": \"AYACUCHO\",  \"Tank\": null,\"Products\": [{ \"ProductId\": \"CRUDO CAMPO MAMBO\"," +
                " \"ProductType\": \"CRUDO\",\"ProductVolume\": 43.0,\"MeasurementUnit\": \"Bbl\",\"Attributes\": [{\"AttributeId\": \"Mayorista\"," +
                "\"AttributeType\": \"General\",\"AttributeValue\": \"ECOPETROL S.A.\",\"ValueAttributeUnit\": \"Bbl\",\"AttributeDescription\": \"Mayorista\" } ]," +
                "\"Owners\": [{\"OwnerId\": \"ECOPETROL\",\"OwnershipValue\": \"100\",\"OwnershipValueUnit\": \"%\"}]}],\"Observations\": \"Observaciones inventario\"," +
                "\"Operator\": \"ECOPETROL\",\"Tolerance\": null,\"Segment\": \"Test\",\"Scenario\": \"Operativo\"},{\"SourceSystem\": \"SINOPER\",\"DestinationSystem\": \"TRUE\"," +
                "\"EventType\": \"INSERT\",\"InventoryId\": \"920200221\",\"InventoryDate\": \"2020-04-12T00:00:00\",\"NodeId\": \"AYACUCHO\",\"Tank\": null,\"Products\": " +
                "[{\"ProductId\": \"CRUDO CAMPO MAMBO\",\"ProductType\": \"CRUDO\",\"ProductVolume\": 9343.0,\"MeasurementUnit\": \"Bbl\",\"Attributes\": [{\"AttributeId\": \"Mayorista\"," +
                " \"AttributeType\": \"General\",\"AttributeValue\": \"ECOPETROL S.A.\",\"ValueAttributeUnit\": \"Bbl\",\"AttributeDescription\": \"Mayorista\"}],\"Owners\": [{" +
                "\"OwnerId\": \"ECOPETROL\",\"OwnershipValue\": \"100\",\"OwnershipValueUnit\": \"%\"}]}],\"Observations\": \"Observaciones inventario\",\"Operator\": \"ECOPETROL\"," +
                "\"Tolerance\": null, \"Segment\": \"Test\", \"ScenarioId\": 2 }]";

            return JToken.Parse(inventory);
        }

        /// <summary>
        /// Gets the movement json.
        /// </summary>
        /// <returns>Returns JToken.</returns>
        private static JToken GetMovementJson()
        {
            var movement = "[{\"SourceSystem\": \"SINOPER\", \"EventType\": \"Insert\", \"SystemTypeId\":  2, \"MovementId\": 123, \"MovementTypeId\": 25, \"OperationalDate\": \"2019-08-24T15:59:00.36\"," +
                    " \"Period\": { \"StartTime\": \"2019-08-24T04:59:00.36\", \"EndTime\": \"2019-08-24T08:59:00.36\", \"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"MovementSource\": { \"SourceNodeId\": 2,\"SourceStorageLocationId\": 1,\"SourceProductId\": 2, \"SourceProductTypeId\": 2,\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"MovementDestination\": {\"DestinationNodeId\": 3,\"DestinationStorageLocationId\": 2,\"DestinationProductId\": null,\"DestinationProductTypeId\": 2,\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    "\"GrossStandardVolume\": 10,\"NetStandardVolume\": 9,\"MeasurementUnit\": \"Volume\", \"Scenario\": \"test\",\"Observations\": \"observations_123\",\"Classification\": \"Movement\",\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\",\"MessageTypeId\": 2," +
                    " \"Owners\": [{\"OwnerId\": \"10\",\"OwnershipValue\": \"12\",\"OwnershipValueUnit\": \"Volume\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"      }]," +
                    "\"Attributes\": [{\"AttributeId\": 1,\"AttributeValue\": 12,\"ValueAttributeUnit\": 30,\"AttributeDescription\": \"desc\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"}] } ]";

            return JToken.Parse(movement);
        }

        /// <summary>
        /// Gets the movement official information json.
        /// </summary>
        /// <returns>Returns JToken.</returns>
        private static JToken GetMovementOfficialInformationJson()
        {
            var movement = "[{\"SourceSystem\": \"SINOPER\", \"EventType\": \"Insert\", \"SystemTypeId\":  2, \"MovementId\": 123, \"MovementTypeId\": 25, \"OperationalDate\": \"2019-08-24T15:59:00.36\"," +
                    " \"Period\": { \"StartTime\": \"2019-08-24T04:59:00.36\", \"EndTime\": \"2019-08-24T08:59:00.36\", \"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"MovementSource\": { \"SourceNodeId\": 2,\"SourceStorageLocationId\": 1,\"SourceProductId\": 2, \"SourceProductTypeId\": 2,\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"MovementDestination\": {\"DestinationNodeId\": 3,\"DestinationStorageLocationId\": 2,\"DestinationProductId\": null,\"DestinationProductTypeId\": 2,\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"OfficialInformation\": { \"IsOfficial\": true,\"BackupMovementId\": 1,\"GlobalMovementId\": 2}," +
                    "\"GrossStandardVolume\": 10,\"NetStandardVolume\": 9,\"MeasurementUnit\": \"Volume\", \"Scenario\": \"test\",\"Observations\": \"observations_123\",\"Classification\": \"Movement\",\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\",\"MessageTypeId\": 2," +
                    " \"Owners\": [{\"OwnerId\": \"10\",\"OwnershipValue\": \"12\",\"OwnershipValueUnit\": \"Volume\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"      }]," +
                    "\"Attributes\": [{\"AttributeId\": 1,\"AttributeValue\": 12,\"ValueAttributeUnit\": 30,\"AttributeDescription\": \"desc\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"}] } ]";

            return JToken.Parse(movement);
        }

        /// <summary>
        /// Gets the movement json.
        /// </summary>
        /// <returns>Returns JToken.</returns>
        private static JToken GetMovementJsonWhenMovementSourceIsNull()
        {
            var movement = "[{\"SourceSystem\": \"SINOPER\", \"EventType\": \"Insert\", \"SystemTypeId\":  2, \"MovementId\": 123, \"MovementTypeId\": 25, \"OperationalDate\": \"2019-08-24T15:59:00.36\"," +
                    " \"Period\": { \"StartTime\": \"2019-08-24T04:59:00.36\", \"EndTime\": \"2019-08-24T08:59:00.36\", \"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"MovementSource\": null," +
                    " \"MovementDestination\": {\"DestinationNodeId\": 3,\"DestinationStorageLocationId\": 2,\"DestinationProductId\": null,\"DestinationProductTypeId\": 2,\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    "\"GrossStandardVolume\": 10,\"NetStandardVolume\": 9,\"MeasurementUnit\": \"Volume\", \"Scenario\": \"test\",\"Observations\": \"observations_123\",\"Classification\": \"Movement\",\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\",\"MessageTypeId\": 2," +
                    " \"Owners\": [{\"OwnerId\": \"10\",\"OwnershipValue\": \"12\",\"OwnershipValueUnit\": \"Volume\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"      }]," +
                    "\"Attributes\": [{\"AttributeId\": 1,\"AttributeValue\": 12,\"ValueAttributeUnit\": 30,\"AttributeDescription\": \"desc\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"}] } ]";

            return JToken.Parse(movement);
        }

        /// <summary>
        /// Gets the movement json.
        /// </summary>
        /// <returns>Returns JToken.</returns>
        private static JToken GetMovementJsonWhenDestinationProductIdIsNull()
        {
            var movement = "[{\"SourceSystem\": \"SINOPER\", \"EventType\": \"Insert\", \"SystemTypeId\":  2, \"MovementId\": 123, \"MovementTypeId\": 25, \"OperationalDate\": \"2019-08-24T15:59:00.36\"," +
                    " \"Period\": { \"StartTime\": \"2019-08-24T04:59:00.36\", \"EndTime\": \"2019-08-24T08:59:00.36\", \"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"MovementSource\": { \"SourceNodeId\": 2,\"SourceStorageLocationId\": 1,\"SourceProductId\": 2, \"SourceProductTypeId\": 2,\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    " \"MovementDestination\": {\"DestinationNodeId\": 3,\"DestinationStorageLocationId\": 2,\"DestinationProductId\": null,\"DestinationProductTypeId\": 2,\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\"}," +
                    "\"GrossStandardVolume\": 10,\"NetStandardVolume\": 9,\"MeasurementUnit\": \"Volume\", \"Scenario\": \"test\",\"Observations\": \"observations_123\",\"Classification\": \"Movement\",\"CreatedBy\": \"user1\",\"CreatedDate\": \"2019-08-24T15:59:00.36\",\"MessageTypeId\": 2," +
                    " \"Owners\": [{\"OwnerId\": \"10\",\"OwnershipValue\": \"12\",\"OwnershipValueUnit\": \"Volume\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"      }]," +
                    "\"Attributes\": [{\"AttributeId\": 1,\"AttributeValue\": 12,\"ValueAttributeUnit\": 30,\"AttributeDescription\": \"desc\",\"CreatedDate\": \"2019-08-24T14:59:00.36\",\"CreatedBy\": \"user1\"}] } ]";

            return JToken.Parse(movement);
        }
    }
}
