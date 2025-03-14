using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LDRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class restaurantCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RestaurantCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CategoryID",
                table: "Restaurants",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_RestaurantCategory_CategoryID",
                table: "Restaurants",
                column: "CategoryID",
                principalTable: "RestaurantCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_RestaurantCategory_CategoryID",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "RestaurantCategory");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CategoryID",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Restaurants");
        }
    }
}
