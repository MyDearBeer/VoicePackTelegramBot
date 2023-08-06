using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBot.Migrations
{
    /// <inheritdoc />
    public partial class StartDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tgUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusOnCommand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tgUsers", x => x.Id);
                    table.UniqueConstraint("AK_tgUsers_TelegramId", x => x.TelegramId);
                });

            migrationBuilder.CreateTable(
                name: "voiceMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TgId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voiceMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_voiceMessages_tgUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tgUsers",
                        principalColumn: "TelegramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tgUsers_Id",
                table: "tgUsers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tgUsers_TelegramId",
                table: "tgUsers",
                column: "TelegramId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_voiceMessages_Id",
                table: "voiceMessages",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_voiceMessages_UserId",
                table: "voiceMessages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "voiceMessages");

            migrationBuilder.DropTable(
                name: "tgUsers");
        }
    }
}
