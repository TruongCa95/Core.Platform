using Domain.Entities.TimeSheet;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void SeedKPICriteriaAndScales(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KPICriteria>().HasData(
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Thầy giáo của ITS chỉ đạo, hướng dẫn học sinh có thành tích đặc biệt xuất sắc ở các cuộc thi của Trường, của Quốc gia", Point = "+40đ", Type = "plus", DisplayOrder = 1, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Thầy giáo có đóng góp về góp ý, ý tưởng, tham gia trực tiếp hiện thực hóa ý tưởng đạt hiệu quả vượt bậc", Point = "+40đ", Type = "plus", DisplayOrder = 2, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Thầy giáo có những cống hiến quên mình vì sự phát triển của Tổ chức được quản lý trực tiếp đánh giá xuất sắc / đề xuất từ quản lý trực tiếp", Point = "+40đ", Type = "plus", DisplayOrder = 3, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp không có học sinh ở dưới điểm 9 trong các bài kiểm tra, điểm thi học kỳ trên trường", Point = "+25đ", Type = "plus", DisplayOrder = 4, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Phụ huynh ý kiến khen / giới thiệu thêm học sinh cho lớp / trung tâm", Point = "+15đ", Type = "plus", DisplayOrder = 5, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Đi dạy đầy đủ 100% các buổi dạy được phân công trong tháng", Point = "+5đ", Type = "plus", DisplayOrder = 6, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp không có học sinh ở dưới điểm 8 trong các bài kiểm tra", Point = "+10đ", Type = "plus", DisplayOrder = 7, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có trên 80% học sinh điểm thi trên 8", Point = "+10đ", Type = "plus", DisplayOrder = 8, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có 1 hoặc 2 học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm", Point = "-5đ", Type = "minus", DisplayOrder = 9, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có 3 hoặc 4 học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm", Point = "-10đ", Type = "minus", DisplayOrder = 10, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Từ chối dạy những buổi theo lịch đã đăng ký", Point = "-10đ", Type = "minus", DisplayOrder = 11, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có 5 hoặc 6 bạn học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm", Point = "-15đ", Type = "minus", DisplayOrder = 12, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có 1 hoặc 2 học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm", Point = "-10đ", Type = "minus", DisplayOrder = 13, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có 3 hoặc 4 học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm", Point = "-15đ", Type = "minus", DisplayOrder = 14, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có 5 hoặc 6 bạn học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm", Point = "-20đ", Type = "minus", DisplayOrder = 15, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPICriteria { Id = Guid.NewGuid(), Criteria = "Lớp có bạn học sinh có điểm kiểm tra / thi < 6 điểm", Point = "-40đ", Type = "minus", DisplayOrder = 16, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) }
            );

            modelBuilder.Entity<KPIScale>().HasData(
                new KPIScale { Id = Guid.NewGuid(), Grade = "Ki A*", Score = "140đ", Factor = 1.4m, Description = "Xuất sắc vượt bậc", DisplayOrder = 1, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPIScale { Id = Guid.NewGuid(), Grade = "Ki A", Score = "125đ", Factor = 1.25m, Description = "Xuất sắc", DisplayOrder = 2, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPIScale { Id = Guid.NewGuid(), Grade = "Ki B+", Score = "110đ", Factor = 1.1m, Description = "Khá giỏi", DisplayOrder = 3, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPIScale { Id = Guid.NewGuid(), Grade = "Ki B", Score = "100đ", Factor = 1.0m, Description = "Đạt chuẩn (Mặc định)", DisplayOrder = 4, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPIScale { Id = Guid.NewGuid(), Grade = "Ki C+", Score = "90đ", Factor = 0.9m, Description = "Cần cố gắng", DisplayOrder = 5, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPIScale { Id = Guid.NewGuid(), Grade = "Ki C", Score = "80đ", Factor = 0.8m, Description = "Chưa đạt", DisplayOrder = 6, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) },
                new KPIScale { Id = Guid.NewGuid(), Grade = "Ki D", Score = "60đ", Factor = 0.65m, Description = "Vi phạm / Kém", DisplayOrder = 7, IsActive = true, CreatedDate = new DateTime(2026, 1, 1), UpdatedDate = new DateTime(2026, 1, 1) }
            );
        }
    }
}
