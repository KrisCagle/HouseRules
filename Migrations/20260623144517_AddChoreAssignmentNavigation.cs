using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRules.Migrations
{
    /// <inheritdoc />
    public partial class AddChoreAssignmentNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chore_ChoreAssignmment_ChoreAssignmmentId",
                table: "Chore");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreCompletion_Chore_ChoreId",
                table: "ChoreCompletion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreCompletion",
                table: "ChoreCompletion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreAssignmment",
                table: "ChoreAssignmment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chore",
                table: "Chore");

            migrationBuilder.DropIndex(
                name: "IX_Chore_ChoreAssignmmentId",
                table: "Chore");

            migrationBuilder.DropColumn(
                name: "ChoreAssignmmentId",
                table: "Chore");

            migrationBuilder.RenameTable(
                name: "ChoreCompletion",
                newName: "ChoreCompletions");

            migrationBuilder.RenameTable(
                name: "ChoreAssignmment",
                newName: "ChoreAssignmments");

            migrationBuilder.RenameTable(
                name: "Chore",
                newName: "Chores");

            migrationBuilder.RenameIndex(
                name: "IX_ChoreCompletion_ChoreId",
                table: "ChoreCompletions",
                newName: "IX_ChoreCompletions_ChoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreCompletions",
                table: "ChoreCompletions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreAssignmments",
                table: "ChoreAssignmments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chores",
                table: "Chores",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                column: "ConcurrencyStamp",
                value: "86f805ff-2240-4ec4-8431-def0e2b390ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8f0e1c2-1234-4b56-89ab-cdef01234567",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb17ce87-7460-49c7-a61a-b072967fe433", "AQAAAAIAAYagAAAAEHsLpO5hjYhdy7OeQ+zOAziLXratzpGvHrThb+OTkDNurdihAxWyYZBfqvJenVxtYA==", "0b332270-793e-441f-adea-e63d604252c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9e1f2d3-5678-4c67-90bc-ef0123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df9f9e27-52b3-4292-9278-b0dc4de426fe", "AQAAAAIAAYagAAAAEIO1R+TW1vmUuJrek2L39pyCVxN6ZlnNJ8Hq1WrC05dew+0/39CN1OTFFxKrdEGRHg==", "bda0c24f-5f89-4a27-aa11-29510b098995" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c9f6f31-6fa9-4cc2-9146-1aa64b024a25", "AQAAAAIAAYagAAAAEMXxyX/qeQ1EXBTXK/zNwJ22nXcx/MS9w8o5EHL/50tdyQY6bDxefI8RTZ0V5YcmRA==", "429743ef-1603-43be-ae9e-2d0195ee8ca5" });

            migrationBuilder.CreateIndex(
                name: "IX_ChoreCompletions_UserProfileId",
                table: "ChoreCompletions",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoreAssignmments_ChoreId",
                table: "ChoreAssignmments",
                column: "ChoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoreAssignmments_UserProfileId",
                table: "ChoreAssignmments",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreAssignmments_Chores_ChoreId",
                table: "ChoreAssignmments",
                column: "ChoreId",
                principalTable: "Chores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreAssignmments_UserProfiles_UserProfileId",
                table: "ChoreAssignmments",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreCompletions_Chores_ChoreId",
                table: "ChoreCompletions",
                column: "ChoreId",
                principalTable: "Chores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreCompletions_UserProfiles_UserProfileId",
                table: "ChoreCompletions",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoreAssignmments_Chores_ChoreId",
                table: "ChoreAssignmments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreAssignmments_UserProfiles_UserProfileId",
                table: "ChoreAssignmments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreCompletions_Chores_ChoreId",
                table: "ChoreCompletions");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreCompletions_UserProfiles_UserProfileId",
                table: "ChoreCompletions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chores",
                table: "Chores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreCompletions",
                table: "ChoreCompletions");

            migrationBuilder.DropIndex(
                name: "IX_ChoreCompletions_UserProfileId",
                table: "ChoreCompletions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreAssignmments",
                table: "ChoreAssignmments");

            migrationBuilder.DropIndex(
                name: "IX_ChoreAssignmments_ChoreId",
                table: "ChoreAssignmments");

            migrationBuilder.DropIndex(
                name: "IX_ChoreAssignmments_UserProfileId",
                table: "ChoreAssignmments");

            migrationBuilder.RenameTable(
                name: "Chores",
                newName: "Chore");

            migrationBuilder.RenameTable(
                name: "ChoreCompletions",
                newName: "ChoreCompletion");

            migrationBuilder.RenameTable(
                name: "ChoreAssignmments",
                newName: "ChoreAssignmment");

            migrationBuilder.RenameIndex(
                name: "IX_ChoreCompletions_ChoreId",
                table: "ChoreCompletion",
                newName: "IX_ChoreCompletion_ChoreId");

            migrationBuilder.AddColumn<int>(
                name: "ChoreAssignmmentId",
                table: "Chore",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chore",
                table: "Chore",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreCompletion",
                table: "ChoreCompletion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreAssignmment",
                table: "ChoreAssignmment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                column: "ConcurrencyStamp",
                value: "528c0f0e-00b5-41b9-b663-0a19208ace3a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8f0e1c2-1234-4b56-89ab-cdef01234567",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90d38610-1a32-4a07-bb3b-33e3993cc11d", "AQAAAAIAAYagAAAAEG/9EbOsj9qH0SIDq1cIOuksJGGkDbS0dNtRbxSITb3ubteqrIm1Do9RRwKDYDz8wQ==", "46974c86-e4e8-4a0b-b971-d813e3d925d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9e1f2d3-5678-4c67-90bc-ef0123456789",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "156c454d-f03a-4c66-b658-7fcb2fe15a6f", "AQAAAAIAAYagAAAAEEtP+L4uc0N0Mq1SbG7yIAr1EAlBQZa5BM09tT6qo7SgyWq0HBncsrsptcXwB08ykA==", "42ed0f83-bc15-44be-967f-6cf5e68af3bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7a61f1d-2c38-43a7-8ea3-a0ae3f0f7742", "AQAAAAIAAYagAAAAEKPuCr0UF9KZt2l5FI17GufpRFSHc3saMgtspw/0Txu1q/TyVshHoc5LejPToLtKuw==", "17eb3c04-d0fa-4eff-ab75-744f6c8c7abf" });

            migrationBuilder.UpdateData(
                table: "Chore",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChoreAssignmmentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chore",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChoreAssignmmentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chore",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChoreAssignmmentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chore",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChoreAssignmmentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chore",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChoreAssignmmentId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Chore_ChoreAssignmmentId",
                table: "Chore",
                column: "ChoreAssignmmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_ChoreAssignmment_ChoreAssignmmentId",
                table: "Chore",
                column: "ChoreAssignmmentId",
                principalTable: "ChoreAssignmment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreCompletion_Chore_ChoreId",
                table: "ChoreCompletion",
                column: "ChoreId",
                principalTable: "Chore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
