using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Services.Data.Migrations
{
    public partial class AddedUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a69d5eaf-71bc-43aa-9ade-13aac6f7dd0f", "Teodor", "Lesly", "AQAAAAEAACcQAAAAEAHwv2tAtuaNhH/hvWwbzLXrsYmaxo71JC6Rg31pILJ9lCT5m51HhOGhf8HiX0Am/Q==", "fc66a51e-d272-4928-9b27-60fb7b959095" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f6736f2-c60b-4db2-8c2c-24c3aebf2c6c", "Linda", "Michaels", "AQAAAAEAACcQAAAAEO7LTKeVwn32NIvGMbYvSftSIs7RYH6kGhGWUYSfP9Cloi6MNWJCaVx8nu0mBe9Uwg==", "f2efaf75-467f-4828-95ac-4f0d12bc9091" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59baee30-a355-45ab-a7db-3ef38ed62e57", "AQAAAAEAACcQAAAAEICbUAlDsPrjW0+VFCmkFwNZdAAO/HVsWJQHb/ea+lZBFr0Db+mW8vVUBbKQlC0sMQ==", "875029c9-a3a1-4b35-a252-8fecf83cc799" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e89caf78-5abf-4e0d-844a-30bbb3aef06a", "AQAAAAEAACcQAAAAENm8wQJosnhu1GnFF0+jDXJF5q+3DQqMKH/9PdurQp8aPdUn5RH/oqVkr0QH/kiTLA==", "64aadad5-59dd-411e-af91-2b0001b09f89" });
        }
    }
}
