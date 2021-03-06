using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodBooks.Data.Migrations
{
    public partial class ReviewsSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewRating",
                table: "BookReviews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewRating",
                table: "BookReviews");
        }
    }
}
