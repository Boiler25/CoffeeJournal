using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeJournal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "coffee_beans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoasterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Region = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Process = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RoastLevel = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coffee_beans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_coffee_beans_roasters_RoasterId",
                        column: x => x.RoasterId,
                        principalTable: "roasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grinders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    BurrType = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grinders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_grinders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    BrewingMethod = table.Column<int>(type: "integer", nullable: false),
                    CoffeeDose = table.Column<double>(type: "double precision", nullable: false),
                    WaterAmount = table.Column<double>(type: "double precision", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: true),
                    BloomWater = table.Column<double>(type: "double precision", nullable: true),
                    BloomTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.Id);
                    table.CheckConstraint("CK_recipes_coffee_dose_positive", "\"CoffeeDose\" > 0");
                    table.CheckConstraint("CK_recipes_water_amount_positive", "\"WaterAmount\" > 0");
                    table.ForeignKey(
                        name: "FK_recipes_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "coffee_bags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoffeeBeanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RoastDate = table.Column<DateOnly>(type: "date", nullable: true),
                    OpenedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FinishedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coffee_bags", x => x.Id);
                    table.CheckConstraint("CK_coffee_bags_weight_positive", "\"Weight\" > 0");
                    table.ForeignKey(
                        name: "FK_coffee_bags_coffee_beans_CoffeeBeanId",
                        column: x => x.CoffeeBeanId,
                        principalTable: "coffee_beans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_coffee_bags_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "brew_sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoffeeBagId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrinderId = table.Column<Guid>(type: "uuid", nullable: true),
                    BrewedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GrindSize = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Sweetness = table.Column<int>(type: "integer", nullable: true),
                    Acidity = table.Column<int>(type: "integer", nullable: true),
                    Bitterness = table.Column<int>(type: "integer", nullable: true),
                    FlavorNotes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    NextTimeNotes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brew_sessions", x => x.Id);
                    table.CheckConstraint("CK_brew_sessions_acidity", "\"Acidity\" IS NULL OR \"Acidity\" BETWEEN 1 AND 5");
                    table.CheckConstraint("CK_brew_sessions_bitterness", "\"Bitterness\" IS NULL OR \"Bitterness\" BETWEEN 1 AND 5");
                    table.CheckConstraint("CK_brew_sessions_sweetness", "\"Sweetness\" IS NULL OR \"Sweetness\" BETWEEN 1 AND 5");
                    table.ForeignKey(
                        name: "FK_brew_sessions_coffee_bags_CoffeeBagId",
                        column: x => x.CoffeeBagId,
                        principalTable: "coffee_bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_brew_sessions_grinders_GrinderId",
                        column: x => x.GrinderId,
                        principalTable: "grinders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_brew_sessions_recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_brew_sessions_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brew_sessions_BrewedAt",
                table: "brew_sessions",
                column: "BrewedAt");

            migrationBuilder.CreateIndex(
                name: "IX_brew_sessions_CoffeeBagId",
                table: "brew_sessions",
                column: "CoffeeBagId");

            migrationBuilder.CreateIndex(
                name: "IX_brew_sessions_GrinderId",
                table: "brew_sessions",
                column: "GrinderId");

            migrationBuilder.CreateIndex(
                name: "IX_brew_sessions_RecipeId",
                table: "brew_sessions",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_brew_sessions_UserId",
                table: "brew_sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_coffee_bags_CoffeeBeanId",
                table: "coffee_bags",
                column: "CoffeeBeanId");

            migrationBuilder.CreateIndex(
                name: "IX_coffee_bags_UserId",
                table: "coffee_bags",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_coffee_beans_RoasterId",
                table: "coffee_beans",
                column: "RoasterId");

            migrationBuilder.CreateIndex(
                name: "IX_grinders_UserId",
                table: "grinders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_UserId",
                table: "recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brew_sessions");

            migrationBuilder.DropTable(
                name: "coffee_bags");

            migrationBuilder.DropTable(
                name: "grinders");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "coffee_beans");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roasters");
        }
    }
}
