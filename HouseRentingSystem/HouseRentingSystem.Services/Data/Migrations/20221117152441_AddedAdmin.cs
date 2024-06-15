using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Services.Data.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bee63644-c0fb-458b-a9c0-df6c040e04b3", "AQAAAAEAACcQAAAAEDGIVfxrVT3hMygP9XR1vxeg/h3mqrA1rEw2DSRtvUzrPT/Nev4n5kEdpBNnq2ix8A==", "527085f0-c075-47e0-ab30-631ce190f26d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8551d5e6-dedf-4c04-8e4d-f18a48892a20", "AQAAAAEAACcQAAAAEF/4y1XOTkYvBVFe1SSbF094+5vXEbEowo2xQn+ov0RVlWdtRXxbSUOYaNdAOLVLrg==", "7b5a38a4-6bbe-4f62-b78d-337c4677f083" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "b2538ea2-cbfa-4743-bdb6-86bc8ddf8743", "admin@mail.com", false, "Great", "Admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEJ1hM1ZrJfpmvCU/NFM0H0YUFDP37BCV4NUGjc0K2S38KyI7742GZrzF8ZgkmwxYjw==", null, false, "5795c3f7-99f2-49f2-8397-8e56d34e6b24", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 6, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a69d5eaf-71bc-43aa-9ade-13aac6f7dd0f", "AQAAAAEAACcQAAAAEAHwv2tAtuaNhH/hvWwbzLXrsYmaxo71JC6Rg31pILJ9lCT5m51HhOGhf8HiX0Am/Q==", "fc66a51e-d272-4928-9b27-60fb7b959095" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f6736f2-c60b-4db2-8c2c-24c3aebf2c6c", "AQAAAAEAACcQAAAAEO7LTKeVwn32NIvGMbYvSftSIs7RYH6kGhGWUYSfP9Cloi6MNWJCaVx8nu0mBe9Uwg==", "f2efaf75-467f-4828-95ac-4f0d12bc9091" });
        }
    }
}
