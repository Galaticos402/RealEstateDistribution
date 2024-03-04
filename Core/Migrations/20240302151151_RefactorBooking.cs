using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class RefactorBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_SaleBatches_SaleBatchId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_SaleBatches_SaleBatchId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_CustomerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_CustomerUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SaleBatchId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SaleBatchId1",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_SaleBatches_SaleBatchId",
                table: "Bookings",
                column: "SaleBatchId",
                principalTable: "SaleBatches",
                principalColumn: "SaleBatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_SaleBatches_SaleBatchId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_CustomerId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "CustomerUserId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleBatchId1",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerUserId",
                table: "Bookings",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SaleBatchId1",
                table: "Bookings",
                column: "SaleBatchId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_SaleBatches_SaleBatchId",
                table: "Bookings",
                column: "SaleBatchId",
                principalTable: "SaleBatches",
                principalColumn: "SaleBatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_SaleBatches_SaleBatchId1",
                table: "Bookings",
                column: "SaleBatchId1",
                principalTable: "SaleBatches",
                principalColumn: "SaleBatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_CustomerUserId",
                table: "Bookings",
                column: "CustomerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
