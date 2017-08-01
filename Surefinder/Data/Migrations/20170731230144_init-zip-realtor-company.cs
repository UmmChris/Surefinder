using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Surefinder.Data.Migrations
{
    public partial class initziprealtorcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    State = table.Column<string>(maxLength: 25, nullable: true),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 100, nullable: true),
                    Zip = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Zip",
                columns: table => new
                {
                    ZipID = table.Column<int>(nullable: false),
                    State = table.Column<int>(maxLength: 25, nullable: false),
                    Status = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zip", x => x.ZipID);
                });

            migrationBuilder.CreateTable(
                name: "Realtor",
                columns: table => new
                {
                    RealtorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    State = table.Column<string>(maxLength: 25, nullable: true),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    Website = table.Column<string>(maxLength: 100, nullable: true),
                    Zip = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realtor", x => x.RealtorID);
                    table.ForeignKey(
                        name: "FK_Realtor_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Realtor_CompanyID",
                table: "Realtor",
                column: "CompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Realtor");

            migrationBuilder.DropTable(
                name: "Zip");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
