using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tbl_product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_CategoryId",
                table: "tbl_product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product",
                column: "CategoryId",
                principalTable: "tbl_category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_category_CategoryId",
                table: "tbl_product");

            migrationBuilder.DropIndex(
                name: "IX_tbl_product_CategoryId",
                table: "tbl_product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tbl_product");
        }
    }
}
