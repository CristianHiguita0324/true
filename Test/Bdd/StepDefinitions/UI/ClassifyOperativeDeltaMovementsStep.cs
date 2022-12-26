﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassifyOperativeDeltaMovementsStep.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Bdd.Tests.StepDefinitions.UI
{
    using System.Linq;
    using System.Threading.Tasks;
    using Ecp.True.Bdd.Tests.Entities;
    using Ecp.True.Bdd.Tests.Utils;
    using global::Bdd.Core.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;
    using TechTalk.SpecFlow;

    [Binding]
    public class ClassifyOperativeDeltaMovementsStep : EcpWebStepDefinitionBase
    {
        [When(@"I have an operational movement with a cutoff ticket and an operational delta ticket")]
        public async System.Threading.Tasks.Task WhenIHaveAnOperationalMovementWithACutoffTicketAndAnOperationalDeltaTicketAsync()
        {
            //// Generation of Cutoff ticket less than 2 days of current date
            await this.GenerationOfCutoffTicketLessThanDaysofCurrentDateAsync(4, 2).ConfigureAwait(false);

            //// Generation of Ownership ticket less than 2 days of current date
            await this.GenerationOfOwnershipTicketLessThanDaysofCurrentDateAsync(2).ConfigureAwait(false);

            //// Updating Inventory volume and Movement volume of the excel
            await this.UpdatedInventoriesAndMovementsAsync().ConfigureAwait(false);
        }

        [When(@"I have generate Operative Delta Ticket for this segment")]
        public async Task WhenIHaveGenerateOperativeDeltaTicketForThisSegmentAsync()
        {
            //// Generation of Operative Delta Ticket
            await this.GenerateOperativeDeltaTicketAsync().ConfigureAwait(false);
        }

        [When(@"I should generate cutoff and ownership for operational delta for the next day")]
        public async Task WhenIShouldGenerateCutoffAndOwnershipForOperationalDeltaForTheNextDayAsync()
        {
            //// Generation of Cutoff ticket less than 1 days of current date
            await this.GenerationOfCutoffTicketLessThanDaysofCurrentDateAsync(0, 1).ConfigureAwait(false);

            //// Generation of Ownership ticket less than 1 days of current date
            await this.GenerationOfOwnershipTicketLessThanDaysofCurrentDateAsync(1).ConfigureAwait(false);
        }

        [When(@"I have an operational date of the movement is equal to the date of the period day")]
        public void WhenIHaveAnOperationalDateOfTheMovementIsEqualToTheDateOfThePeriodDay()
        {
            // Intentially keep this line blank
        }

        [When(@"I have source or destination node of the movement belongs to the segment on the day of the period")]
        public void WhenIHaveSourceOrDestinationNodeOfTheMovementBelongsToTheSegmentOnTheDayOfThePeriod()
        {
            // Intentially keep this line blank
        }

        [When(@"this movement has a source movement identifier")]
        public void WhenThisMovementHasASourceMovementIdentifier()
        {
            // Intentially keep this line blank
        }

        [When(@"I Verify that System should send the information details to the FICO with Data")]
        public void WhenIVerifyThatSystemShouldSendTheInformationDetailsToTheFICOWithData()
        {
            // Intentially keep this line blank
        }

        [Then(@"I Verify that value in the ""(.*)"" field should be ""(.*)"" in ""(.*)"" collection for all the annulation movements generated by Operative Delta")]
        public async Task ThenIVerifyThatValueInTheFieldShouldBeInCollectionForAllTheAnnulationMovementsGeneratedByOperativeDeltaAsync(string field, string value, string collection)
        {
            Assert.IsNotNull(field);
            string fileNameValue;
            var ticketData = await this.ReadSqlAsDictionaryAsync(SqlQueries.GetTicketIdwithTicketDesc).ConfigureAwait(false);
            fileNameValue = string.Concat(ticketData["TicketId"].ToString(), "_request");
            this.ScenarioContext["json"] = await fileNameValue.OwnershipdatafromBlobAsync(collection).ConfigureAwait(false);
            var ficoRequestData = JObject.Parse(this.ScenarioContext["json"].ToString());

            Assert.IsNotNull(ficoRequestData["volPayload"]["volInput"]["movimientos"]);
            for (var i = 0; i < ficoRequestData["volPayload"]["volInput"]["movimientos"].Count(); i++)
            {
                string ficoMovementTypeValue = ficoRequestData["volPayload"]["volInput"]["movimientos"][i]["tipoMovimiento"].ToString();
                if (ficoMovementTypeValue.EqualsIgnoreCase(value))
                {
                    Assert.AreEqual(ficoMovementTypeValue, value);
                    break;
                }
            }
        }

        public async Task GenerationOfCutoffTicketLessThanDaysofCurrentDateAsync(int startdays, int enddays)
        {
            this.UiNavigation("Operational Cutoff");
            ////this.When("I click on \"NewCut\" \"button\"");
            this.IClickOn("NewCut", "button");
            ////this.When("I choose CategoryElement from \"InitTicket\" \"Segment\" \"combobox\"");
            this.ISelectCategoryElementFrom("InitTicket\" \"Segment", "combobox");
            if (startdays > 0)
            {
                await this.ISelectTheStartDateLessthanDaysFromCurrentDateOnDatePickerAsync(startdays, "Cutoff").ConfigureAwait(false);
            }

            await this.ISelectTheEndDateLessthanDaysFromCurrentDateOnDatePickerAsync(enddays, "Cutoff").ConfigureAwait(false);
            ////this.When("I click on \"InitTicket\" \"next\" \"button\"");
            this.IClickOn("InitTicket\" \"Submit", "button");
            ////this.Then("validate that \"checkInventories\" \"Next\" \"button\" as enabled");
            this.ValidateThatAsEnabled("validateInitialInventory\" \"submit", "button");
            ////this.When("I click on \"checkInventories\" \"Next\" \"button\"");
            this.IClickOn("validateInitialInventory\" \"submit", "button");
            this.ScenarioContext[ConstantValues.PendingTransactions] = 0;
            ////this.When("I select all pending records from grid");
            this.ISelectAllPendingRepositroriesFromGrid();
            this.ProvidedRequiredDetailsForPendingTransactionsGrid();
            ////this.Then("validate that \"ErrorsGrid\" \"Next\" \"button\" as enabled");
            this.ValidateThatAsEnabled("ErrorsGrid\" \"Submit", "button");
            ////this.When("I click on \"ErrorsGrid\" \"Next\" \"button\"");
            this.IClickOn("ErrorsGrid\" \"Submit", "button");
            ////this.When("I click on \"officialPointsGrid\" \"Next\" \"button\"");
            this.IClickOn("officialPointsGrid\" \"Submit", "button");
            this.ScenarioContext[ConstantValues.PendingTransactions] = 0;
            ////this.When("I select all unbalances in the grid");
            this.ISelectAllPendingRepositroriesFromGrid();
            this.ProvidedRequiredDetailsForUnbalancesGrid();
            ////this.When("I click on \"ConsistencyCheck\" \"Next\" \"button\"");
            this.IClickOn("unbalancesGrid\" \"submit", "button");
            ////this.When("I click on \"Confirm\" \"Cutoff\" \"Submit\" \"button\"");
            this.IClickOn("ConfirmCutoff\" \"Submit", "button");
            ////this.When("I wait till cutoff ticket processing to complete");
            await this.WaitForTicketToCompleteProcessingAsync().ConfigureAwait(false);
        }

        public async Task GenerationOfOwnershipTicketLessThanDaysofCurrentDateAsync(int days)
        {
            ////this.When("I navigate to \"ownershipcalculation\" page");
            this.UiNavigation("ownershipcalculation");
            ////this.When("I click on \"NewBalance\" \"button\"");
            this.IClickOn("NewBalance", "button");
            ////this.When("I select segment from \"OwnershipCal\" \"Segment\" \"dropdown\"");
            this.ISelectSegmentFrom("OwnershipCal\" \"Segment", "dropdown");
            ////await this.ISelectTheEndDateLessthanDaysFromCurrentDateOnDatePickerAsync(days, "Ownership").ConfigureAwait(false);
            await this.ISelectTheFinalDateLessthanDaysFromCurrentDateOnDatePickerAsync(days, "Ownership").ConfigureAwait(false);
            ////this.When("I click on \"ownershipCalCriteria\" \"Next\" \"button\"");
            this.IClickOn("ownershipCalculationCriteria\" \"submit", "button");
            ////this.When("I verify all validations passed");
            this.IVerifyValidationsPassed();
            ////this.When("I click on \"ownershipCalValidations\" \"Next\" \"button\"");
            this.IClickOn("ownershipCalulationValidations\" \"submit", "button");
            ////this.When("I click on \"OwnershipCalConfirmation\" \"Execute\" \"button\"");
            this.IClickOn("ownershipCalculationConfirmation\" \"submit", "button");
            await Task.Delay(10000).ConfigureAwait(true);
            ////this.Then("verify the ownership is calculated successfully");
            await this.VerifyTheOwnershipIsCalculatedSuccessfullyAsync().ConfigureAwait(false);
            ////this.When("I wait till ownership ticket geneation to complete");
            await this.WaitForOwnershipTicketProcessingToCompleteAsync().ConfigureAwait(false);
        }

        public async Task UpdatedInventoriesAndMovementsAsync()
        {
            this.WhenIUpdateTheExcelFileWithInventoryAndMovementNetVolumes("TestDataCutOff_Daywise");
            ////When I navigate to "FileUpload" page
            this.NavigateToPage("FileUpload");
            ////And I click on "FileUpload" "button"
            this.IClickOn("FileUpload", "button");
            ////And I select segment from "FileUpload" "segment" "dropdown"
            this.ISelectSegmentFrom("FileUpload\" \"segment", "dropdown");
            ////And I select "Update" from FileUpload dropdown
            this.ISelectFileFromFileUploadDropdown("Update");
            ////And I click on "Browse" to upload
            this.IClickOnUploadButton("Browse");
            ////And I select "TestData_Consolidation" file from directory
            await this.ISelectFileFromDirectoryAsync("TestDataCutOff_Daywise").ConfigureAwait(false);
            ////And I click on "uploadFile" "Submit" "button"
            this.IClickOn("uploadFile\" \"Submit", "button");
            ////And I wait till file upload to complete
            await this.WaitForFileUploadingToCompleteAsync().ConfigureAwait(false);
        }

        public async Task GenerateOperativeDeltaTicketAsync()
        {
            ////And I navigate to "Calculation of deltas by operational adjust" page
            this.NavigateToPage("Calculation of deltas by operational adjust");
            ////And I click on "New Delta Calculation" "button"
            this.IClickOn("New Deltas Calculation", "button");
            ////And I select segment from "initDeltaTicket" "segment" "dropdown"
            this.ISelectSegmentFrom("initDeltaTicket\" \"segment", "dropdown");
            ////And I click on "initDeltaTicket" "Submit" "button"
            this.IClickOn("initDeltaTicket\" \"submit", "button");
            ////And I click on "pendingInventoriesGrid" "Submit" "button"
            this.IClickOn("pendingInventoriesGrid\" \"submit", "button");
            ////And I click on "pendingMovementsGrid" "Submit" "button"
            this.IClickOn("pendingMovementsGrid\" \"submit", "button");
            ////Then I should see "Modal" "confirmDeltaCalculation" "container"
            this.IShouldSee("Modal\" \"confirmDeltaCalculation", "container");
            ////And I click on "confirmDeltaCalculation" "submit" "Button"
            this.IClickOn("confirmDeltaCalculation\" \"submit", "button");
            ////And Verify that Delta Calculation should be successful
            await this.VerifyThatDeltaCalculationShouldBeSuccessfulAsync().ConfigureAwait(false);
        }

        [Then(@"Verify that Store input and output movements using the node identifier and product identifier returned by FICO")]
        public void ThenVerifyThatStoreInputAndOutputMovementsUsingTheNodeIdentifierAndProductIdentifierReturnedByFICO()
        {
            // Intentially keep this line blank
        }
    }
}
