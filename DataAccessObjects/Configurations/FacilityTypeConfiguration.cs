using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace DataAccessObjects.Configurations
{
    public class FacilityTypeConfiguration : IEntityTypeConfiguration<FacilityType>
    {
        public void Configure(EntityTypeBuilder<FacilityType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData(
                new FacilityType { Id = 1, Name = "Bệnh viện", Description = "Cơ sở y tế chuyên điều trị các bệnh lý đa dạng." },
                new FacilityType { Id = 2, Name = "Phòng khám", Description = "Cơ sở y tế nhỏ, chủ yếu khám chữa bệnh ngoại trú." },
                new FacilityType { Id = 3, Name = "Nhà thuốc", Description = "Cửa hàng cung cấp thuốc và các sản phẩm y tế." }
            );
        }
    }
}
