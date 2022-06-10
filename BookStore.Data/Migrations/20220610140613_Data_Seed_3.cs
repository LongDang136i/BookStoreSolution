using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class Data_Seed_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("90057ee3-511a-4de1-94c2-93898f1018d9"),
                column: "ConcurrencyStamp",
                value: "ff8b53de-9a94-46a6-a914-56301f46a356");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4965cc8-fdab-433f-ae1d-79540827db5a"),
                column: "ConcurrencyStamp",
                value: "aa9b33dc-eaed-4aef-9120-68d694b2b445");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a744cca-d50d-4369-8e41-3fe91db7cb1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab4d3321-c80c-44c8-917d-2dcf052483f4", "AQAAAAEAACcQAAAAEC7ORZ+ofNyicVrxPvyMcDKVS9+fSsHPP9ubrlOtFyi0I7xipuSky2rESJB43QJUig==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1cee3d50-87bb-48d5-a493-376829c581c9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7278ad41-e9fe-448b-835a-d8bb9eec0f42", "AQAAAAEAACcQAAAAEO5XKr7WREkDdqiY3hbl6noVt9u9+z97ayFIiuzIg5XUL/kJZzNcqfAVIRDeYHiXtw==" });

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
                table: "ProductInBrands",
                columns: new[] { "BrandId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 639, DateTimeKind.Local).AddTicks(6446), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7124), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7205), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7208), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7210), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7213), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7215), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7218), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7220), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7224), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7226), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7228), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7230), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7232), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7234), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7236), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7238), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7240), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7242), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7244), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 6, 12, 640, DateTimeKind.Local).AddTicks(7246), 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInBrands",
                keyColumns: new[] { "BrandId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInBrands",
                keyColumns: new[] { "BrandId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductInBrands",
                keyColumns: new[] { "BrandId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("90057ee3-511a-4de1-94c2-93898f1018d9"),
                column: "ConcurrencyStamp",
                value: "161b25c7-b565-42ae-8a19-5f4ca002b6a3");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4965cc8-fdab-433f-ae1d-79540827db5a"),
                column: "ConcurrencyStamp",
                value: "7abe1fe6-388d-4898-acec-715dbef56b2b");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a744cca-d50d-4369-8e41-3fe91db7cb1d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0069ccaa-0144-4b76-a42f-9e965bfe98a2", "AQAAAAEAACcQAAAAEEfbQQf79jnz+DNXK670h9E9UIu6b8qSlTamLKA6q/gCbZnF9Zcjv9j5ZUa6hNV6lQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1cee3d50-87bb-48d5-a493-376829c581c9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "835dedff-319f-4a82-bf4e-3fc64d4d9b85", "AQAAAAEAACcQAAAAEDHVRMbYTpb9OhXr929XCTPNqAELxBveBRJDzTPdokQw2FcBTGyjaDoYFzibiaZ+dw==" });

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
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 74, DateTimeKind.Local).AddTicks(3995), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6544), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6682), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6686), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6688), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6691), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6693), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6695), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6697), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6699), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6701), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6703), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6705), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6707), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6709), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6712), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6714), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6716), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6718), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6720), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22,
                columns: new[] { "DateCreated", "Stock" },
                values: new object[] { new DateTime(2022, 6, 10, 21, 4, 7, 75, DateTimeKind.Local).AddTicks(6722), 10 });
        }
    }
}
