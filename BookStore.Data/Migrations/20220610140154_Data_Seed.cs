using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class Data_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("90057ee3-511a-4de1-94c2-93898f1018d9"),
                column: "ConcurrencyStamp",
                value: "2772251b-2319-4572-bbd2-ed5c995d8bc9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4965cc8-fdab-433f-ae1d-79540827db5a"),
                column: "ConcurrencyStamp",
                value: "18b9b529-23a6-4515-a7df-57afbe437a2c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a744cca-d50d-4369-8e41-3fe91db7cb1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98a09c2b-cb32-4eec-b90a-ada38a078789", "AQAAAAEAACcQAAAAENaOTP/R4MsWNiRsY5r8ecMC7t5bvT8iRVb8UI+q6AxM+ZX2s8l1JAF0EdgdJWHpDQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1cee3d50-87bb-48d5-a493-376829c581c9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "776dd5b8-2834-47cd-9fd7-74aa31900b84", "AQAAAAEAACcQAAAAEPN2CxuTQc6RgUnWdR5oXqDtsAdANkcoB4uWnX1ZzAVBy8v/zfp3hQoWKoIx1/j8Xg==" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "Status",
                value: 1);

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "ProductTrId", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Áo sơ mi nam trắng Việt Tiến", "Áo sơ mi nam trắng Việt Tiến", "vi", "Áo sơ mi nam trắng Việt Tiến", 1, "ao-so-mi-nam-trang-viet-tien", "Áo sơ mi nam trắng Việt Tiến", "Áo sơ mi nam trắng Việt Tiến" },
                    { 2, "Viet Tien Men T-Shirt", "Viet Tien Men T-Shirt", "en", "Viet Tien Men T-Shirt", 1, "viet-tien-men-t-shirt", "Viet Tien Men T-Shirt", "Viet Tien Men T-Shirt" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 785, DateTimeKind.Local).AddTicks(3616), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3733), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3799), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3802), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3805), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3807), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3809), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3811), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3813), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3815), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3817), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3819), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3821), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3824), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3826), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3828), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3830), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3832), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3834), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3836), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 1, 53, 786, DateTimeKind.Local).AddTicks(3838), 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "ProductTrId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "ProductTrId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("90057ee3-511a-4de1-94c2-93898f1018d9"),
                column: "ConcurrencyStamp",
                value: "9f32e097-eba1-40dc-b22f-b9a675da93a9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4965cc8-fdab-433f-ae1d-79540827db5a"),
                column: "ConcurrencyStamp",
                value: "0fa954f8-90f1-4f50-b190-b55b6a48b254");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a744cca-d50d-4369-8e41-3fe91db7cb1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db150a07-8b2e-4a22-8c53-ae6e3e6c175c", "AQAAAAEAACcQAAAAEN7dHp6+id4tgVN0pQWos0hGNtgri4T0a+XkX0JnX5AfPH6wGX+X9SHzp0JwZhnxQA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1cee3d50-87bb-48d5-a493-376829c581c9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65639908-1af3-4c54-8c00-65f1bf040504", "AQAAAAEAACcQAAAAEOFvGVyKptXHBF6hDJFgZqe1oeqamHLbpjvzhZLILDDeFZ1GKUxTqTETp6NhKxpXVQ==" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 494, DateTimeKind.Local).AddTicks(6333), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2869), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2959), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2962), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2964), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2966), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2968), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2970), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2973), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2975), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2977), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2979), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2981), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2983), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2985), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2987), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2989), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2991), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2993), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2995), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 20, 59, 37, 496, DateTimeKind.Local).AddTicks(2997), 10 });
        }
    }
}
