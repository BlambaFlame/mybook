using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Registration.Migrations
{
    public partial class AddTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "author",
                newName: "author_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_author",
                table: "author",
                column: "author_id");

            migrationBuilder.CreateTable(
                name: "book_desc",
                columns: table => new
                {
                    book_desc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PagesCount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: true),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_desc", x => x.book_desc_id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    PublishedDate = table.Column<string>(type: "text", nullable: true),
                    IsForAdult = table.Column<bool>(type: "boolean", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    DownloadsCount = table.Column<int>(type: "integer", nullable: false),
                    BookDescId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_book_book_desc_BookDescId",
                        column: x => x.BookDescId,
                        principalTable: "book_desc",
                        principalColumn: "book_desc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "download_link",
                columns: table => new
                {
                    download_link_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Format = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    BookDescId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_download_link", x => x.download_link_id);
                    table.ForeignKey(
                        name: "FK_download_link_book_desc_BookDescId",
                        column: x => x.BookDescId,
                        principalTable: "book_desc",
                        principalColumn: "book_desc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "author_book",
                columns: table => new
                {
                    author_book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author_book", x => x.author_book_id);
                    table.ForeignKey(
                        name: "FK_author_book_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_author_book_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_genre",
                columns: table => new
                {
                    book_genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genre", x => x.book_genre_id);
                    table.ForeignKey(
                        name: "FK_book_genre_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_book_genre_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "img_link",
                columns: table => new
                {
                    img_link_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Resolution = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    BookId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_img_link", x => x.img_link_id);
                    table.ForeignKey(
                        name: "FK_img_link_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_img_link_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_author_book_AuthorId",
                table: "author_book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_author_book_BookId",
                table: "author_book",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_book_BookDescId",
                table: "book",
                column: "BookDescId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_BookId",
                table: "book_genre",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_book_genre_GenreId",
                table: "book_genre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_download_link_BookDescId",
                table: "download_link",
                column: "BookDescId");

            migrationBuilder.CreateIndex(
                name: "IX_img_link_AuthorId",
                table: "img_link",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_img_link_BookId",
                table: "img_link",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author_book");

            migrationBuilder.DropTable(
                name: "book_genre");

            migrationBuilder.DropTable(
                name: "download_link");

            migrationBuilder.DropTable(
                name: "img_link");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "book_desc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_author",
                table: "author");

            migrationBuilder.RenameTable(
                name: "author",
                newName: "Authors");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "Authors",
                newName: "AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "AuthorId");
        }
    }
}
