using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SparkEquation.Trial.WebAPI.Data.Migrations
{
    public partial class AddingMoreFieldsToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ItemsInStock",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Featured",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ItemsInStock",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Product");
        }
    }
}
