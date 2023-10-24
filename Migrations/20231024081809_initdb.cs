using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using RazorEF;

namespace CS0058_Entity_Framework_Razor.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    content = table.Column<string>(type: "NTEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.id);
                });
            migrationBuilder.InsertData(
                table: "articles",
                columns: new[] { "title", "createDate", "content" },
                values: new object[] {
                    "Bài viết 01",
                    new DateTime(2023, 10, 24),
                    "Nội dung 01"
                }
            );

            Randomizer.Seed = new Random(8675309);

            var fakeArticle = new Faker<Article>();
            fakeArticle.RuleFor((a) => a.title, (f) => f.Lorem.Sentence(5));
            fakeArticle.RuleFor((a) => a.createDate, (f) => f.Date.Between(new DateTime(2022, 12, 31), new DateTime(2000, 01, 01)));
            fakeArticle.RuleFor((a) => a.content, (f) => f.Lorem.Paragraphs(1, 2));


            for (int i = 0; i < 499; i++)
            {
                Article article = fakeArticle.Generate();

                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "title", "createDate", "content" },
                    values: new object[] {
                    article.title,
                    article.createDate,
                    article.content,
                    }
                );
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
