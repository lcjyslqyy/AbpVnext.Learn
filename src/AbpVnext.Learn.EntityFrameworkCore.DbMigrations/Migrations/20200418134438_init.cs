using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpVnext.Learn.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    user_phone = table.Column<string>(type: "varchar(20)", nullable: false),
                    pass_word = table.Column<string>(type: "varchar(50)", nullable: false),
                    user_status = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthorizeLists",
                columns: table => new
                {
                    userid = table.Column<string>(type: "varchar(100)", nullable: false),
                    sourceid = table.Column<string>(type: "varchar(100)", nullable: false),
                    sourcetype = table.Column<string>(type: "varchar(100)", nullable: false),
                    value = table.Column<string>(type: "varchar(500)", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthorizeLists", x => new { x.userid, x.sourceid, x.sourcetype });
                    table.ForeignKey(
                        name: "FK_UserAuthorizeLists_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "UserAuthorizeLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
