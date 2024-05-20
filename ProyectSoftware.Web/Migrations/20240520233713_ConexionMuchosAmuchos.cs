using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectSoftware.Web.Migrations
{
    /// <inheritdoc />
    public partial class ConexionMuchosAmuchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HasSongPlaylists_Playlists_PlaylistId",
                table: "HasSongPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongPlaylists_Songs_SongId",
                table: "HasSongPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongsGenders_GenderTypes_GenderTypeId",
                table: "HasSongsGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongsGenders_Songs_SongId",
                table: "HasSongsGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongUsers_Songs_SongId",
                table: "HasSongUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongUsers_Users_UserId",
                table: "HasSongUsers");

            migrationBuilder.DropIndex(
                name: "IX_HasSongUsers_SongId",
                table: "HasSongUsers");

            migrationBuilder.DropIndex(
                name: "IX_HasSongUsers_UserId",
                table: "HasSongUsers");

            migrationBuilder.DropIndex(
                name: "IX_HasSongsGenders_GenderTypeId",
                table: "HasSongsGenders");

            migrationBuilder.DropIndex(
                name: "IX_HasSongsGenders_SongId",
                table: "HasSongsGenders");

            migrationBuilder.DropIndex(
                name: "IX_HasSongPlaylists_PlaylistId",
                table: "HasSongPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_HasSongPlaylists_SongId",
                table: "HasSongPlaylists");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "HasSongUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HasSongUsers");

            migrationBuilder.DropColumn(
                name: "GenderTypeId",
                table: "HasSongsGenders");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "HasSongsGenders");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "HasSongPlaylists");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "HasSongPlaylists");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongUsers_IdUser",
                table: "HasSongUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongsGenders_IdSong",
                table: "HasSongsGenders",
                column: "IdSong");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongPlaylists_IdSong",
                table: "HasSongPlaylists",
                column: "IdSong");

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongPlaylists_Playlists_IdPlaylist",
                table: "HasSongPlaylists",
                column: "IdPlaylist",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongPlaylists_Songs_IdSong",
                table: "HasSongPlaylists",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongsGenders_GenderTypes_IdGender",
                table: "HasSongsGenders",
                column: "IdGender",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongsGenders_Songs_IdSong",
                table: "HasSongsGenders",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongUsers_Songs_IdSong",
                table: "HasSongUsers",
                column: "IdSong",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongUsers_Users_IdUser",
                table: "HasSongUsers",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HasSongPlaylists_Playlists_IdPlaylist",
                table: "HasSongPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongPlaylists_Songs_IdSong",
                table: "HasSongPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongsGenders_GenderTypes_IdGender",
                table: "HasSongsGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongsGenders_Songs_IdSong",
                table: "HasSongsGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongUsers_Songs_IdSong",
                table: "HasSongUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HasSongUsers_Users_IdUser",
                table: "HasSongUsers");

            migrationBuilder.DropIndex(
                name: "IX_HasSongUsers_IdUser",
                table: "HasSongUsers");

            migrationBuilder.DropIndex(
                name: "IX_HasSongsGenders_IdSong",
                table: "HasSongsGenders");

            migrationBuilder.DropIndex(
                name: "IX_HasSongPlaylists_IdSong",
                table: "HasSongPlaylists");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "HasSongUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HasSongUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderTypeId",
                table: "HasSongsGenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "HasSongsGenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "HasSongPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "HasSongPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HasSongUsers_SongId",
                table: "HasSongUsers",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongUsers_UserId",
                table: "HasSongUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongsGenders_GenderTypeId",
                table: "HasSongsGenders",
                column: "GenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongsGenders_SongId",
                table: "HasSongsGenders",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongPlaylists_PlaylistId",
                table: "HasSongPlaylists",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_HasSongPlaylists_SongId",
                table: "HasSongPlaylists",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongPlaylists_Playlists_PlaylistId",
                table: "HasSongPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongPlaylists_Songs_SongId",
                table: "HasSongPlaylists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongsGenders_GenderTypes_GenderTypeId",
                table: "HasSongsGenders",
                column: "GenderTypeId",
                principalTable: "GenderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongsGenders_Songs_SongId",
                table: "HasSongsGenders",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongUsers_Songs_SongId",
                table: "HasSongUsers",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HasSongUsers_Users_UserId",
                table: "HasSongUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
