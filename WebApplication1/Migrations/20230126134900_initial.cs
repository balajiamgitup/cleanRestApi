using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "orderStatus",
                columns: table => new
                {
                    statusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    statusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderStatus", x => x.statusId);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tablenumber = table.Column<int>(type: "int", nullable: false),
                    statusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_order_orderStatus_statusId",
                        column: x => x.statusId,
                        principalTable: "orderStatus",
                        principalColumn: "statusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItem",
                columns: table => new
                {
                    orderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItem", x => x.orderItemId);
                    table.ForeignKey(
                        name: "FK_orderItem_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItem_order_orderId",
                        column: x => x.orderId,
                        principalTable: "order",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bill",
                columns: table => new
                {
                    billId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalBill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill", x => x.billId);
                    table.ForeignKey(
                        name: "FK_bill_orderItem_orderItemId",
                        column: x => x.orderItemId,
                        principalTable: "orderItem",
                        principalColumn: "orderItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bill_orderItemId",
                table: "bill",
                column: "orderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_order_statusId",
                table: "order",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_itemId",
                table: "orderItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_orderId",
                table: "orderItem",
                column: "orderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill");

            migrationBuilder.DropTable(
                name: "orderItem");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "orderStatus");
        }
    }
}
