using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Bio", "CreatedAt", "Email", "Name", "Password", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "UrlDoUsuario1", "Sou o Usuário 1", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@email.com", "Usuário 1", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1" },
                    { 2L, "UrlDoUsuario2", "Sou o Usuário 2", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@email.com", "Usuário 2", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2" },
                    { 3L, "UrlDoUsuario3", "Sou o Usuário 3", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@email.com", "Usuário 3", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3" },
                    { 4L, "UrlDoUsuario4", "Sou o Usuário 4", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@email.com", "Usuário 4", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4" },
                    { 5L, "UrlDoUsuario5", "Sou o Usuário 5", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@email.com", "Usuário 5", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5" },
                    { 6L, "UrlDoUsuario6", "Sou o Usuário 6", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@email.com", "Usuário 6", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6" },
                    { 7L, "UrlDoUsuario7", "Sou o Usuário 7", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@email.com", "Usuário 7", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7" },
                    { 8L, "UrlDoUsuario8", "Sou o Usuário 8", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@email.com", "Usuário 8", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8" },
                    { 9L, "UrlDoUsuario9", "Sou o Usuário 9", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@email.com", "Usuário 9", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9" },
                    { 10L, "UrlDoUsuario10", "Sou o Usuário 10", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@email.com", "Usuário 10", "123", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, "Post 1", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, "Post 2", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 3L, "Post 3", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 4L, "Post 4", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 5L, "Post 5", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 6L, "Post 6", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 7L, "Post 7", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 8L, "Post 8", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 9L, "Post 9", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 10L, "Post 10", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "PostId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, "Comentário 1", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 2L, "Comentário 2", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 3L, "Comentário 3", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 4L, "Comentário 4", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 5L, "Comentário 5", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 6L, "Comentário 6", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 7L, "Comentário 7", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 8L, "Comentário 8", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 9L, "Comentário 9", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 10L, "Comentário 10", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedAt", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L },
                    { 2L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 3L },
                    { 3L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L },
                    { 4L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 3L },
                    { 5L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L },
                    { 6L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 3L },
                    { 7L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L },
                    { 8L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 3L },
                    { 9L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L },
                    { 10L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendId",
                table: "Friendships",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserId",
                table: "Friendships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
