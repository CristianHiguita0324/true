﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BalanceBootstrapperTests.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Host.Functions.Tests
{
    using Ecp.True.Host.Functions.Balance.Bootstrap;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The ownership bootstrapper tests.
    /// </summary>
    [TestClass]
    public class BalanceBootstrapperTests
    {
        /// <summary>
        /// The service collection.
        /// </summary>
        private IServiceCollection serviceCollection;

        /// <summary>
        /// The function bootstrapper.
        /// </summary>
        private FunctionBootstrapper functionBootstrapper;

        /// <summary>
        /// The calculation bootstrapper.
        /// </summary>
        private CalculationBootstrapper calculationBootstrapper;

        /// <summary>
        /// The movement bootstrapper.
        /// </summary>
        private MovementBootstrapper movementBootstrapper;

        [TestInitialize]
        public void Initialize()
        {
            this.serviceCollection = new ServiceCollection();
            this.functionBootstrapper = new FunctionBootstrapper(this.serviceCollection);
            this.calculationBootstrapper = new CalculationBootstrapper(this.serviceCollection);
            this.movementBootstrapper = new MovementBootstrapper(this.serviceCollection);
        }

        /// <summary>
        /// Bootstraps the should bootstrap di registration when invoked.
        /// </summary>
        [TestMethod]
        public void Bootstrap_ShouldBootstrapDIRegistration_WhenInvoked()
        {
            this.functionBootstrapper.RegisterDependencies();
            this.calculationBootstrapper.Bootstrap();
            this.movementBootstrapper.Bootstrap();

            Assert.IsNotNull(this.serviceCollection);
            Assert.IsTrue(this.serviceCollection.Count > 0);
        }
    }
}
