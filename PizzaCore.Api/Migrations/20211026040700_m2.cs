using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PizzaCore.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerDto",
                columns: table => new
                {
                    CusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CusName = table.Column<string>(type: "text", nullable: true),
                    CusContact = table.Column<string>(type: "text", nullable: true),
                    CusAddress = table.Column<string>(type: "text", nullable: true),
                    CusCity = table.Column<string>(type: "text", nullable: true),
                    CusCountry = table.Column<string>(type: "text", nullable: true),
                    CusCreatedDate = table.Column<string>(type: "text", nullable: true),
                    CusUpdatedDate = table.Column<string>(type: "text", nullable: true),
                    CusStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDto", x => x.CusId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOption",
                columns: table => new
                {
                    MethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MethodName = table.Column<string>(type: "text", nullable: true),
                    Charge = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOption", x => x.MethodId);
                });

            migrationBuilder.CreateTable(
                name: "MemberShip",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    MinimumExpenses = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShip", x => x.MembershipId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CustomerCusId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    DeliveryOptionMethodId = table.Column<int>(type: "int", nullable: true),
                    DateWanted = table.Column<string>(type: "text", nullable: true),
                    TimeWanted = table.Column<string>(type: "text", nullable: true),
                    OrdSubTotal = table.Column<float>(type: "float", nullable: false),
                    OrdDiscount = table.Column<float>(type: "float", nullable: false),
                    OrdTax = table.Column<float>(type: "float", nullable: false),
                    OrdTotal = table.Column<float>(type: "float", nullable: false),
                    OrdCreatedDate = table.Column<string>(type: "text", nullable: true),
                    OrdUpdatedDate = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerDto_CustomerCusId",
                        column: x => x.CustomerCusId,
                        principalTable: "CustomerDto",
                        principalColumn: "CusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryOption_DeliveryOptionMethodId",
                        column: x => x.DeliveryOptionMethodId,
                        principalTable: "DeliveryOption",
                        principalColumn: "MethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMemberShip",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CustomerCusId = table.Column<int>(type: "int", nullable: true),
                    MembershipId = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<string>(type: "text", nullable: true),
                    UsedUntil = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMemberShip", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_CustomerMemberShip_CustomerDto_CustomerCusId",
                        column: x => x.CustomerCusId,
                        principalTable: "CustomerDto",
                        principalColumn: "CusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerMemberShip_MemberShip_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "MemberShip",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailsPizza",
                columns: table => new
                {
                    PizzaOrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    PizzaSizeId = table.Column<int>(type: "int", nullable: true),
                    CrustPriceId = table.Column<int>(type: "int", nullable: true),
                    PizzaSubTotal = table.Column<float>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsPizza", x => x.PizzaOrderDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderDetailsPizza_CrustPrices_CrustPriceId",
                        column: x => x.CrustPriceId,
                        principalTable: "CrustPrices",
                        principalColumn: "CrustPriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetailsPizza_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetailsPizza_PizzaPrice_PizzaSizeId",
                        column: x => x.PizzaSizeId,
                        principalTable: "PizzaPrice",
                        principalColumn: "PizzaSizeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    StatusName = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusId);
                    table.ForeignKey(
                        name: "FK_OrderStatus_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtraTopping",
                columns: table => new
                {
                    ExtraToppingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PizzaOrderDetailsId = table.Column<int>(type: "int", nullable: true),
                    ToppingPriceId = table.Column<int>(type: "int", nullable: true),
                    Side = table.Column<string>(type: "text", nullable: true),
                    Portion = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraTopping", x => x.ExtraToppingId);
                    table.ForeignKey(
                        name: "FK_ExtraTopping_OrderDetailsPizza_PizzaOrderDetailsId",
                        column: x => x.PizzaOrderDetailsId,
                        principalTable: "OrderDetailsPizza",
                        principalColumn: "PizzaOrderDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraTopping_ToppingPrices_ToppingPriceId",
                        column: x => x.ToppingPriceId,
                        principalTable: "ToppingPrices",
                        principalColumn: "ToppingPriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMemberShip_CustomerCusId",
                table: "CustomerMemberShip",
                column: "CustomerCusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMemberShip_MembershipId",
                table: "CustomerMemberShip",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraTopping_PizzaOrderDetailsId",
                table: "ExtraTopping",
                column: "PizzaOrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraTopping_ToppingPriceId",
                table: "ExtraTopping",
                column: "ToppingPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsPizza_CrustPriceId",
                table: "OrderDetailsPizza",
                column: "CrustPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsPizza_OrderId",
                table: "OrderDetailsPizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsPizza_PizzaSizeId",
                table: "OrderDetailsPizza",
                column: "PizzaSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerCusId",
                table: "Orders",
                column: "CustomerCusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryOptionMethodId",
                table: "Orders",
                column: "DeliveryOptionMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_OrderId",
                table: "OrderStatus",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMemberShip");

            migrationBuilder.DropTable(
                name: "ExtraTopping");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "MemberShip");

            migrationBuilder.DropTable(
                name: "OrderDetailsPizza");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "CustomerDto");

            migrationBuilder.DropTable(
                name: "DeliveryOption");
        }
    }
}
