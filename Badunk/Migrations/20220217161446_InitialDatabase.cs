using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Badunk.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfo", "UserName", "password" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "mycodecantalk", "secret!password" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Tasks", "Description", "Name", "UserId" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Complete this current project. One day this task will be checked off!", "Complete this project!", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Tasks",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserInfo",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
