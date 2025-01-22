using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecuperApp.Domain.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customertypes",
                columns: table => new
                {
                    customertypeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customertypes", x => x.customertypeid);
                });

            migrationBuilder.CreateTable(
                name: "pricetypes",
                columns: table => new
                {
                    pricetypeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pricetypes", x => x.pricetypeid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shortname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    issubtype = table.Column<bool>(type: "boolean", nullable: false),
                    parentid = table.Column<int>(type: "integer", nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.productid);
                    table.ForeignKey(
                        name: "fk_products_products_parentid",
                        column: x => x.parentid,
                        principalTable: "products",
                        principalColumn: "productid");
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "shipmenttypes",
                columns: table => new
                {
                    shipmenttypeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipmenttypes", x => x.shipmenttypeid);
                });

            migrationBuilder.CreateTable(
                name: "weightcontroltypes",
                columns: table => new
                {
                    weightcontroltypeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weightcontroltypes", x => x.weightcontroltypeid);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customertypeid = table.Column<int>(type: "integer", nullable: false),
                    nit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    cell = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    clientsince = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    needspickup = table.Column<bool>(type: "boolean", nullable: true),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.customerid);
                    table.ForeignKey(
                        name: "fk_customers_customertypes_customertypeid",
                        column: x => x.customertypeid,
                        principalTable: "customertypes",
                        principalColumn: "customertypeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employeeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    documentnumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    dateofbirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dateofjoin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.employeeid);
                    table.ForeignKey(
                        name: "fk_employees_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "roleid");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    paymentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    totalweight = table.Column<int>(type: "integer", nullable: false),
                    totalprice = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.paymentid);
                    table.ForeignKey(
                        name: "fk_payments_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payrollconfigs",
                columns: table => new
                {
                    payrollconfigid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    priceperkilo = table.Column<double>(type: "double precision", nullable: false),
                    iscurrentprice = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payrollconfigs", x => x.payrollconfigid);
                    table.ForeignKey(
                        name: "fk_payrollconfigs_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_payrollconfigs_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productprices",
                columns: table => new
                {
                    productpriceid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    customerid = table.Column<int>(type: "integer", nullable: false),
                    pricetypeid = table.Column<int>(type: "integer", nullable: false),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    iscurrentprice = table.Column<bool>(type: "boolean", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productprices", x => x.productpriceid);
                    table.ForeignKey(
                        name: "fk_productprices_customers_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productprices_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productprices_pricetypes_pricetypeid",
                        column: x => x.pricetypeid,
                        principalTable: "pricetypes",
                        principalColumn: "pricetypeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productprices_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    shipmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<int>(type: "integer", nullable: false),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    shipmenttypeid = table.Column<int>(type: "integer", nullable: false),
                    shipmentstartdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    shipmentenddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ispaid = table.Column<bool>(type: "boolean", nullable: false),
                    iscomplete = table.Column<bool>(type: "boolean", nullable: false),
                    totalprice = table.Column<double>(type: "double precision", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipments", x => x.shipmentid);
                    table.ForeignKey(
                        name: "fk_shipments_customers_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shipments_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shipments_shipmenttypes_shipmenttypeid",
                        column: x => x.shipmenttypeid,
                        principalTable: "shipmenttypes",
                        principalColumn: "shipmenttypeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weightcontrols",
                columns: table => new
                {
                    weightcontrolid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    weightcontroltypeid = table.Column<int>(type: "integer", nullable: false),
                    ispaid = table.Column<bool>(type: "boolean", nullable: false),
                    datestart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dateend = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weightcontrols", x => x.weightcontrolid);
                    table.ForeignKey(
                        name: "fk_weightcontrols_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_weightcontrols_weightcontroltypes_weightcontroltypeid",
                        column: x => x.weightcontroltypeid,
                        principalTable: "weightcontroltypes",
                        principalColumn: "weightcontroltypeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipmentdetails",
                columns: table => new
                {
                    shipmentdetailid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shipmentid = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    shipmentdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    subtotal = table.Column<double>(type: "double precision", nullable: false),
                    productprice = table.Column<double>(type: "double precision", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shipmentdetails", x => x.shipmentdetailid);
                    table.ForeignKey(
                        name: "fk_shipmentdetails_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shipmentdetails_shipments_shipmentid",
                        column: x => x.shipmentid,
                        principalTable: "shipments",
                        principalColumn: "shipmentid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "remainings",
                columns: table => new
                {
                    remainingid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weightcontrolid = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_remainings", x => x.remainingid);
                    table.ForeignKey(
                        name: "fk_remainings_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_remainings_weightcontrols_weightcontrolid",
                        column: x => x.weightcontrolid,
                        principalTable: "weightcontrols",
                        principalColumn: "weightcontrolid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weightcontroldetails",
                columns: table => new
                {
                    weightcontroldetailid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weightcontrolid = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weightcontroldetails", x => x.weightcontroldetailid);
                    table.ForeignKey(
                        name: "fk_weightcontroldetails_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_weightcontroldetails_weightcontrols_weightcontrolid",
                        column: x => x.weightcontrolid,
                        principalTable: "weightcontrols",
                        principalColumn: "weightcontrolid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paymentdetails",
                columns: table => new
                {
                    paymentsdetailid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    paymentid = table.Column<int>(type: "integer", nullable: false),
                    weightcontroldetailid = table.Column<int>(type: "integer", nullable: true),
                    productprice = table.Column<int>(type: "integer", nullable: false),
                    createddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdby = table.Column<string>(type: "text", nullable: true),
                    updateddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedby = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paymentdetails", x => x.paymentsdetailid);
                    table.ForeignKey(
                        name: "fk_paymentdetails_payments_paymentid",
                        column: x => x.paymentid,
                        principalTable: "payments",
                        principalColumn: "paymentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_paymentdetails_weightcontroldetails_weightcontroldetailid",
                        column: x => x.weightcontroldetailid,
                        principalTable: "weightcontroldetails",
                        principalColumn: "weightcontroldetailid");
                });

            migrationBuilder.InsertData(
                table: "customertypes",
                columns: new[] { "customertypeid", "createdby", "createddate", "description", "isactive", "name", "updatedby", "updateddate" },
                values: new object[,]
                {
                    { 1, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Personas a los que les compro material", true, "Proveedor", null, null },
                    { 2, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Personas a los que les vendo mi material ya procesado", true, "Cliente", null, null }
                });

            migrationBuilder.InsertData(
                table: "pricetypes",
                columns: new[] { "pricetypeid", "createdby", "createddate", "description", "isactive", "name", "updatedby", "updateddate" },
                values: new object[,]
                {
                    { 1, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Precios de compra de los productos. Material que ingresa a la bodega y el valor que se paga a los proveedores.", true, "Compra", null, null },
                    { 2, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Precios de venta de los productos. Material que sale de la bodega y el valor que se le cobra a los clientes.", true, "Venta", null, null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "roleid", "createdby", "createddate", "isactive", "name", "updatedby", "updateddate" },
                values: new object[] { 1, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), true, "Admin", null, null });

            migrationBuilder.InsertData(
                table: "shipmenttypes",
                columns: new[] { "shipmenttypeid", "createdby", "createddate", "description", "isactive", "name", "updatedby", "updateddate" },
                values: new object[,]
                {
                    { 1, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Material que ingresa a la bodega enviado por los proveedores. Compras", true, "Ingreso", null, null },
                    { 2, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "Material que ingresa a la bodega enviado por los proveedores. Ventas", true, "Salida", null, null }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "employeeid", "createdby", "createddate", "dateofbirth", "dateofjoin", "documentnumber", "isactive", "lastname", "name", "password", "roleid", "updatedby", "updateddate", "username" },
                values: new object[] { 1, "Seeder", new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 10, 45, 45, 0, DateTimeKind.Unspecified), "1234", true, "Admin", "Super", "Admin123", 1, null, null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "ix_customers_customertypeid",
                table: "customers",
                column: "customertypeid");

            migrationBuilder.CreateIndex(
                name: "ix_employees_roleid",
                table: "employees",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ix_paymentdetails_paymentid",
                table: "paymentdetails",
                column: "paymentid");

            migrationBuilder.CreateIndex(
                name: "ix_paymentdetails_weightcontroldetailid",
                table: "paymentdetails",
                column: "weightcontroldetailid");

            migrationBuilder.CreateIndex(
                name: "ix_payments_employeeid",
                table: "payments",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_payrollconfigs_employeeid",
                table: "payrollconfigs",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_payrollconfigs_productid",
                table: "payrollconfigs",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_productprices_customerid",
                table: "productprices",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "ix_productprices_employeeid",
                table: "productprices",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_productprices_pricetypeid",
                table: "productprices",
                column: "pricetypeid");

            migrationBuilder.CreateIndex(
                name: "ix_productprices_productid",
                table: "productprices",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_products_parentid",
                table: "products",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_remainings_productid",
                table: "remainings",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_remainings_weightcontrolid",
                table: "remainings",
                column: "weightcontrolid");

            migrationBuilder.CreateIndex(
                name: "ix_shipmentdetails_productid",
                table: "shipmentdetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_shipmentdetails_shipmentid",
                table: "shipmentdetails",
                column: "shipmentid");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_customerid",
                table: "shipments",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_employeeid",
                table: "shipments",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_shipments_shipmenttypeid",
                table: "shipments",
                column: "shipmenttypeid");

            migrationBuilder.CreateIndex(
                name: "ix_weightcontroldetails_productid",
                table: "weightcontroldetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_weightcontroldetails_weightcontrolid",
                table: "weightcontroldetails",
                column: "weightcontrolid");

            migrationBuilder.CreateIndex(
                name: "ix_weightcontrols_employeeid",
                table: "weightcontrols",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_weightcontrols_weightcontroltypeid",
                table: "weightcontrols",
                column: "weightcontroltypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paymentdetails");

            migrationBuilder.DropTable(
                name: "payrollconfigs");

            migrationBuilder.DropTable(
                name: "productprices");

            migrationBuilder.DropTable(
                name: "remainings");

            migrationBuilder.DropTable(
                name: "shipmentdetails");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "weightcontroldetails");

            migrationBuilder.DropTable(
                name: "pricetypes");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "weightcontrols");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "shipmenttypes");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "weightcontroltypes");

            migrationBuilder.DropTable(
                name: "customertypes");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
