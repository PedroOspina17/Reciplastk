using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecuperApp.Domain.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ReplacePkName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "weightcontroltypeid",
                table: "weightcontroltypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "weightcontrolid",
                table: "weightcontrols",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "weightcontroldetailid",
                table: "weightcontroldetails",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "shipmenttypeid",
                table: "shipmenttypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "shipmentid",
                table: "shipments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "shipmentdetailid",
                table: "shipmentdetails",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "remainingid",
                table: "remainings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productpriceid",
                table: "productprices",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "pricetypeid",
                table: "pricetypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "payrollconfigid",
                table: "payrollconfigs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "paymentid",
                table: "payments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "paymentsdetailid",
                table: "paymentdetails",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "employees",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "customertypeid",
                table: "customertypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "customers",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "weightcontroltypes",
                newName: "weightcontroltypeid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "weightcontrols",
                newName: "weightcontrolid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "weightcontroldetails",
                newName: "weightcontroldetailid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shipmenttypes",
                newName: "shipmenttypeid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shipments",
                newName: "shipmentid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "shipmentdetails",
                newName: "shipmentdetailid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "roles",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "remainings",
                newName: "remainingid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "productprices",
                newName: "productpriceid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "pricetypes",
                newName: "pricetypeid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "payrollconfigs",
                newName: "payrollconfigid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "payments",
                newName: "paymentid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "paymentdetails",
                newName: "paymentsdetailid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "employees",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "customertypes",
                newName: "customertypeid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "customers",
                newName: "customerid");
        }
    }
}
