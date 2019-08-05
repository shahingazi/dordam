using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceComparisonWeb.Migrations
{
    public partial class EcommercePriceFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EcommercePriceFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Product_name = table.Column<string>(nullable: true),
                    Manufacturer_Part_NumberMPN = table.Column<string>(nullable: true),
                    EAN = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Product_URL = table.Column<string>(nullable: true),
                    Image_URL = table.Column<string>(nullable: true),
                    Price_incl_VAT = table.Column<double>(nullable: false),
                    Shipping_cost = table.Column<double>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    Stock_status = table.Column<string>(nullable: true),
                    Bundle = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcommercePriceFile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcommercePriceFile");
        }
    }
}
