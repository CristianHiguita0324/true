﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SapTrackingErrorConfiguration.cs" company="Microsoft">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ecp.True.DataAccess.Sql
{
    using Ecp.True.Core;
    using Ecp.True.DataAccess.Sql.Configuration;
    using Ecp.True.Entities.Admin;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The DeltaError Configuration.
    /// </summary>
    /// <seealso cref="EntityConfiguration{SapTrackingError}" />
    public class SapTrackingErrorConfiguration : EntityConfiguration<SapTrackingError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SapTrackingErrorConfiguration" /> class.
        /// </summary>
        public SapTrackingErrorConfiguration()
                : base(x => x.SapTrackingErrorId, Sql.Constants.AdminSchema, true)
        {
        }

        /// <summary>
        /// Does the configure.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void DoConfigure(EntityTypeBuilder<SapTrackingError> builder)
        {
            ArgumentValidators.ThrowIfNull(builder, nameof(builder));

            builder.Property(x => x.ErrorDescription).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(x => x.ErrorCode).IsRequired().HasColumnType("nvarchar(5)");
            builder.HasOne(s => s.SapTracking).WithMany(p => p.SapTrackingErrors).HasForeignKey(d => d.SapTrackingId).IsRequired();
        }
    }
}
