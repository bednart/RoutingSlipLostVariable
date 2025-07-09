using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutingSlipLostVariable.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimedRewards",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RewardId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutionError = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimedRewards", x => x.CorrelationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimedRewards");
        }
    }
}
