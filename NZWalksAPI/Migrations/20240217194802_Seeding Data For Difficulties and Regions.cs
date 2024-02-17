using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c6e3638-ec00-4046-be62-9c55c3c98288"), "Hard" },
                    { new Guid("75013f4d-ed65-4895-86cf-5b38ab275226"), "Easy" },
                    { new Guid("be65a116-7e9a-4ff9-a68c-9fa2d8dd3d95"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("03cbe871-635e-4b27-a437-7d210ddaff9b"), "YVR", "Vancouver", "https://vancouver.ca/images/cov/feature/geography-landing.jpg" },
                    { new Guid("09946c96-29cc-4645-b231-4b4c2a6c0582"), "YYC", "Calgary", "https://peakvisor.com/img/news/Calgary-Alberta.jpg" },
                    { new Guid("1e09e80f-7e25-492b-a136-53fa8a92c277"), "JFK", "New York", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/View_of_Empire_State_Building_from_Rockefeller_Center_New_York_City_dllu_%28cropped%29.jpg/1200px-View_of_Empire_State_Building_from_Rockefeller_Center_New_York_City_dllu_%28cropped%29.jpg" },
                    { new Guid("aa94477c-78e7-4115-9617-550966e52c52"), "YYZ", "Toronto", "https://a.travel-assets.com/findyours-php/viewfinder/images/res70/516000/516652-nathan-phillips-square.jpg" },
                    { new Guid("c1e5a259-6b1c-4c54-99a5-820dfd054eef"), "YUL", "Montreal", "https://www.airtransat.com/getmedia/cafc7e6e-d0ff-497e-9998-e708f41aa191/Montreal-estival.aspx" },
                    { new Guid("da9c333c-ae19-4526-9016-8cb90dea02f1"), "LAX", "Los Angles", "https://www.visittheusa.com/sites/default/files/styles/hero_l/public/images/hero_media_image/2017-01/Getty_515070156_EDITORIALONLY_LosAngeles_HollywoodBlvd_Web72DPI_0.jpg?h=0a8b6f8b&itok=lst_2_5d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2c6e3638-ec00-4046-be62-9c55c3c98288"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("75013f4d-ed65-4895-86cf-5b38ab275226"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("be65a116-7e9a-4ff9-a68c-9fa2d8dd3d95"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("03cbe871-635e-4b27-a437-7d210ddaff9b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("09946c96-29cc-4645-b231-4b4c2a6c0582"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1e09e80f-7e25-492b-a136-53fa8a92c277"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("aa94477c-78e7-4115-9617-550966e52c52"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c1e5a259-6b1c-4c54-99a5-820dfd054eef"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("da9c333c-ae19-4526-9016-8cb90dea02f1"));
        }
    }
}
