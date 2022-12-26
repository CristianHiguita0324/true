﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemOwnershipCalculationProperties.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.DataAccess.Sql.Configuration
{
    using Ecp.True.Core;
    using Ecp.True.Entities.Admin;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// the system ownership calculation properties.
    /// </summary>
    public static class SystemOwnershipCalculationProperties
    {
        /// <summary>
        /// Configures the properties for system ownership calculations.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void Configure(EntityTypeBuilder<SystemOwnershipCalculation> builder)
        {
            ArgumentValidators.ThrowIfNull(builder, nameof(builder));

            builder.Property(x => x.InitialInventoryVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.InitialInventoryPercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.FinalInventoryVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.FinalInventoryPercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.InputVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.InputPercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.OutputVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.OutputPercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.IdentifiedLossesVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.IdentifiedLossesPercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.UnbalanceVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.UnbalancePercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.InterfaceVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.InterfacePercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.ToleranceVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.TolerancePercentage).HasColumnType("decimal(5,2)").IsRequired(false);
            builder.Property(x => x.UnidentifiedLossesVolume).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.UnidentifiedLossesPercentage).HasColumnType("decimal(5,2)").IsRequired(false);
        }
    }
}
