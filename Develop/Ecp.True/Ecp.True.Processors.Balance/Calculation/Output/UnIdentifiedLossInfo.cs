﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnIdentifiedLossInfo.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.Processors.Balance.Calculation.Output
{
    /// <summary>
    /// The unidentified loss.
    /// </summary>
    public class UnIdentifiedLossInfo : OutputBase
    {
        /// <summary>
        /// Gets or sets the unidentified loss.
        /// </summary>
        /// <value>
        /// The unbalance unidentified loss.
        /// </value>
        public decimal UnIdentifiedLoss { get; set; }
    }
}
