using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Configurations
{
    public class UnderlyingDiseaseConfiguration : IEntityTypeConfiguration<UnderlyingDisease>
    {
        public void Configure(EntityTypeBuilder<UnderlyingDisease> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(ud => ud.PatientUnderlyingDiseases)
            .WithOne(pud => pud.UnderlyingDisease) 
            .HasForeignKey(pud => pud.UnderlyingDiseaseId)  
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                 new UnderlyingDisease { Id = 1, Name = "Tiểu đường", Description = "Bệnh lý do rối loạn chuyển hóa đường trong máu" },
                 new UnderlyingDisease { Id = 2, Name = "Huyết áp cao", Description = "Tăng huyết áp có thể gây nguy cơ bệnh tim mạch" },
            new UnderlyingDisease { Id = 3, Name = "Hen suyễn", Description = "Bệnh đường hô hấp mãn tính gây khó thở" },
            new UnderlyingDisease { Id = 4, Name = "Béo phì", Description = "Tình trạng mỡ thừa tích tụ quá mức gây ảnh hưởng sức khỏe" },
            new UnderlyingDisease { Id = 5, Name = "Suy tim", Description = "Tình trạng tim không bơm đủ máu đến cơ thể" },
            new UnderlyingDisease { Id = 6, Name = "Suy thận", Description = "Suy giảm chức năng thận ảnh hưởng đến bài tiết và lọc độc tố" },
            new UnderlyingDisease { Id = 7, Name = "Bệnh phổi tắc nghẽn mãn tính (COPD)", Description = "Bệnh mãn tính gây khó thở, thường gặp ở người hút thuốc lá" },
            new UnderlyingDisease { Id = 8, Name = "Loãng xương", Description = "Suy giảm mật độ xương làm tăng nguy cơ gãy xương" },
            new UnderlyingDisease { Id = 9, Name = "Bệnh Parkinson", Description = "Rối loạn thần kinh ảnh hưởng đến vận động" },
            new UnderlyingDisease { Id = 10, Name = "Bệnh Alzheimer", Description = "Bệnh thoái hóa thần kinh ảnh hưởng đến trí nhớ và nhận thức" },
            new UnderlyingDisease { Id = 11, Name = "Viêm gan B", Description = "Bệnh nhiễm virus viêm gan B gây tổn thương gan" },
            new UnderlyingDisease { Id = 12, Name = "Viêm gan C", Description = "Bệnh nhiễm virus viêm gan C có thể gây xơ gan" },
            new UnderlyingDisease { Id = 13, Name = "Rối loạn lipid máu", Description = "Mỡ máu cao có thể dẫn đến xơ vữa động mạch" },
            new UnderlyingDisease { Id = 14, Name = "Đột quỵ", Description = "Tắc nghẽn hoặc vỡ mạch máu não gây tổn thương não" },
            new UnderlyingDisease { Id = 15, Name = "Bệnh dạ dày - tá tràng", Description = "Viêm loét dạ dày hoặc trào ngược dạ dày thực quản" },
            new UnderlyingDisease { Id = 16, Name = "Suy giảm miễn dịch", Description = "Giảm khả năng đề kháng với bệnh tật" },
            new UnderlyingDisease { Id = 17, Name = "Bệnh Lupus ban đỏ hệ thống", Description = "Bệnh tự miễn ảnh hưởng nhiều cơ quan trong cơ thể" },
            new UnderlyingDisease { Id = 18, Name = "Bệnh Celiac", Description = "Bệnh không dung nạp gluten gây tổn thương ruột non" },
            new UnderlyingDisease { Id = 19, Name = "HIV/AIDS", Description = "Suy giảm miễn dịch gây nguy cơ nhiễm trùng cao" },
            new UnderlyingDisease { Id = 20, Name = "Bệnh gút", Description = "Bệnh do rối loạn chuyển hóa purin, gây viêm khớp" }
                );
        }
    }
}
