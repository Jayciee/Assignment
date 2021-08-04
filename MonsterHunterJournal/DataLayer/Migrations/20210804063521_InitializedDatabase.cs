using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitializedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ailments",
                columns: table => new
                {
                    AilmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ailments", x => x.AilmentID);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    ElementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.ElementID);
                });

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    HabitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.HabitID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SizeFloor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SizeCeiling = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    WeaponTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.WeaponTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    MonsterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ThreatLevel = table.Column<int>(type: "int", nullable: true),
                    PrimaryElementID = table.Column<int>(type: "int", nullable: true),
                    PrimaryAilmentID = table.Column<int>(type: "int", nullable: true),
                    MonsterImage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SizeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.MonsterID);
                    table.ForeignKey(
                        name: "FK__Monsters__Primar__72C60C4A",
                        column: x => x.PrimaryElementID,
                        principalTable: "Elements",
                        principalColumn: "ElementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Monsters__Primar__73BA3083",
                        column: x => x.PrimaryAilmentID,
                        principalTable: "Ailments",
                        principalColumn: "AilmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Monsters__SizeID__71D1E811",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CounterTactics",
                columns: table => new
                {
                    WeaponTypeID = table.Column<int>(type: "int", nullable: false),
                    HabitID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CounterT__19D4B1583508EDBF", x => new { x.WeaponTypeID, x.HabitID });
                    table.ForeignKey(
                        name: "FK__CounterTa__Habit__5DCAEF64",
                        column: x => x.HabitID,
                        principalTable: "Habits",
                        principalColumn: "HabitID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CounterTa__Weapo__5CD6CB2B",
                        column: x => x.WeaponTypeID,
                        principalTable: "WeaponTypes",
                        principalColumn: "WeaponTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    WeaponTypeID = table.Column<int>(type: "int", nullable: true),
                    Rarity = table.Column<int>(type: "int", nullable: true),
                    ElementID = table.Column<int>(type: "int", nullable: true),
                    AilmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponID);
                    table.ForeignKey(
                        name: "FK__Weapons__Ailment__52593CB8",
                        column: x => x.AilmentID,
                        principalTable: "Ailments",
                        principalColumn: "AilmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Weapons__Element__5165187F",
                        column: x => x.ElementID,
                        principalTable: "Elements",
                        principalColumn: "ElementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Weapons__WeaponT__5070F446",
                        column: x => x.WeaponTypeID,
                        principalTable: "WeaponTypes",
                        principalColumn: "WeaponTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monsters_Habits",
                columns: table => new
                {
                    MonsterID = table.Column<int>(type: "int", nullable: false),
                    HabitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Monsters__F04D3A367108AAFA", x => new { x.MonsterID, x.HabitID });
                    table.ForeignKey(
                        name: "FK__Monsters___Habit__6C190EBB",
                        column: x => x.HabitID,
                        principalTable: "Habits",
                        principalColumn: "HabitID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Monsters___Monst__70DDC3D8",
                        column: x => x.MonsterID,
                        principalTable: "Monsters",
                        principalColumn: "MonsterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HunterName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TimeTaken = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RecordedMonsterSize = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MonsterID = table.Column<int>(type: "int", nullable: true),
                    WeaponID = table.Column<int>(type: "int", nullable: true),
                    HuntSucceeded = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK__Records__Monster__6FE99F9F",
                        column: x => x.MonsterID,
                        principalTable: "Monsters",
                        principalColumn: "MonsterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Records__WeaponI__68487DD7",
                        column: x => x.WeaponID,
                        principalTable: "Weapons",
                        principalColumn: "WeaponID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CounterTactics_HabitID",
                table: "CounterTactics",
                column: "HabitID");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_PrimaryAilmentID",
                table: "Monsters",
                column: "PrimaryAilmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_PrimaryElementID",
                table: "Monsters",
                column: "PrimaryElementID");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_SizeID",
                table: "Monsters",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_Habits_HabitID",
                table: "Monsters_Habits",
                column: "HabitID");

            migrationBuilder.CreateIndex(
                name: "IX_Records_MonsterID",
                table: "Records",
                column: "MonsterID");

            migrationBuilder.CreateIndex(
                name: "IX_Records_WeaponID",
                table: "Records",
                column: "WeaponID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_AilmentID",
                table: "Weapons",
                column: "AilmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_ElementID",
                table: "Weapons",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponTypeID",
                table: "Weapons",
                column: "WeaponTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CounterTactics");

            migrationBuilder.DropTable(
                name: "Monsters_Habits");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Habits");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Ailments");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "WeaponTypes");
        }
    }
}
