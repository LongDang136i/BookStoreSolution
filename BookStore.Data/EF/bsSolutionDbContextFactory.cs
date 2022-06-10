using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookStore.Data.EF
{
    public class bsSolutionDbContextFactory : IDesignTimeDbContextFactory<bsDbContext>
    {
        public bsDbContext CreateDbContext(string[] args)
        {
            //Tạo đối tượng configuration đặt đường dẫn ở thư mục gốc là solution hiện tại (BookStore.Data)
            //Thêm file appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //Lấy chuỗi kết nối (trong file appsettings.json) bằng key BookStoreSolutionDb
            var connectionString = configuration.GetConnectionString("BookStoreSolutionDb");

            //Truyền chuỗi kết nối vào cơ chế liên kết với SQLServer
            var optionsBuilder = new DbContextOptionsBuilder<bsDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new bsDbContext(optionsBuilder.Options);
        }
    }
}