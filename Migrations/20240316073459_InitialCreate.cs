using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pseudo = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    pwd = table.Column<string>(type: "text", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: false),
                    pdpPath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    idPicture = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    picturePath = table.Column<string>(type: "text", nullable: false),
                    idUser = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    views = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.idPicture);
                    table.ForeignKey(
                        name: "FK_Picture_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPicture",
                columns: table => new
                {
                    idCategoryPicture = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idCategory = table.Column<int>(type: "integer", nullable: false),
                    idPicture = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPicture", x => x.idCategoryPicture);
                    table.ForeignKey(
                        name: "FK_CategoryPicture_Category_idCategory",
                        column: x => x.idCategory,
                        principalTable: "Category",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPicture_Picture_idPicture",
                        column: x => x.idPicture,
                        principalTable: "Picture",
                        principalColumn: "idPicture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    idComment = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idUser = table.Column<int>(type: "integer", nullable: false),
                    idPicture = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.idComment);
                    table.ForeignKey(
                        name: "FK_Comment_Picture_idPicture",
                        column: x => x.idPicture,
                        principalTable: "Picture",
                        principalColumn: "idPicture",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    idLike = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idUser = table.Column<int>(type: "integer", nullable: false),
                    idPicture = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.idLike);
                    table.ForeignKey(
                        name: "FK_Like_Picture_idPicture",
                        column: x => x.idPicture,
                        principalTable: "Picture",
                        principalColumn: "idPicture",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPicture_idCategory",
                table: "CategoryPicture",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPicture_idPicture",
                table: "CategoryPicture",
                column: "idPicture");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_idPicture",
                table: "Comment",
                column: "idPicture");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_idUser",
                table: "Comment",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Like_idPicture",
                table: "Like",
                column: "idPicture");

            migrationBuilder.CreateIndex(
                name: "IX_Like_idUser",
                table: "Like",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_idUser",
                table: "Picture",
                column: "idUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPicture");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
