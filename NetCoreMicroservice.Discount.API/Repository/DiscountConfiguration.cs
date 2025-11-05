using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using NetCoreMicroservice.Discount.API.Features.Discount;

namespace NetCoreMicroservice.Discount.API.Repository
{
    public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DiscountEntity> builder)
        {
            builder.ToCollection("discounts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Code).HasElementName("code").HasMaxLength(10);
            builder.Property(x => x.Rate).HasElementName("rate");
            builder.Property(x => x.Created).HasElementName("created");
            builder.Property(x => x.UserId).HasElementName("userId");
            builder.Property(x => x.Updated).HasElementName("updated");
            builder.Property(x => x.Expired).HasElementName("expired");
            builder.Property(x => x.UserId).HasElementName("user_id");

        }
    }
}
