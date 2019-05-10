using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Afk4Events.Data.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				"DataProtectionKeys",
				table => new
				{
					Id = table.Column<int>()
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
					FriendlyName = table.Column<string>(nullable: true),
					Xml = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
				});

			migrationBuilder.CreateTable(
				"Groups",
				table => new
				{
					Id = table.Column<Guid>(),
					Name = table.Column<string>(maxLength: 250, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Groups", x => x.Id);
				});

			migrationBuilder.CreateTable(
				"Themes",
				table => new
				{
					Id = table.Column<string>(maxLength: 250),
					Css = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Themes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				"Users",
				table => new
				{
					Id = table.Column<Guid>(),
					Name = table.Column<string>(maxLength: 250),
					Email = table.Column<string>(maxLength: 250),
					ProfilePictureUrl = table.Column<string>(nullable: true),
					GoogleId = table.Column<string>(maxLength: 250)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				"UserGroups",
				table => new
				{
					UserId = table.Column<Guid>(),
					GroupId = table.Column<Guid>(),
					IsAdmin = table.Column<bool>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserGroups", x => new {x.UserId, x.GroupId});
					table.ForeignKey(
						"FK_UserGroups_Groups_GroupId",
						x => x.GroupId,
						"Groups",
						"Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						"FK_UserGroups_Users_UserId",
						x => x.UserId,
						"Users",
						"Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				"Events",
				table => new
				{
					Id = table.Column<Guid>(),
					Comment = table.Column<string>(nullable: true),
					GroupId = table.Column<Guid>(),
					ThemeId = table.Column<string>(nullable: true),
					Name = table.Column<string>(maxLength: 500),
					Location = table.Column<string>(maxLength: 1000),
					PickedDateId1 = table.Column<Guid>(nullable: true),
					PickedDateId = table.Column<Guid>(nullable: true),
					CreatedById = table.Column<Guid>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Events", x => x.Id);
					table.ForeignKey(
						"FK_Events_Users_CreatedById",
						x => x.CreatedById,
						"Users",
						"Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						"FK_Events_Groups_GroupId",
						x => x.GroupId,
						"Groups",
						"Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						"FK_Events_Themes_ThemeId",
						x => x.ThemeId,
						"Themes",
						"Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				"EventDates",
				table => new
				{
					Id = table.Column<Guid>(),
					Start = table.Column<DateTime>(),
					End = table.Column<DateTime>(),
					EventId = table.Column<Guid>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EventDates", x => x.Id);
					table.ForeignKey(
						"FK_EventDates_Events_EventId",
						x => x.EventId,
						"Events",
						"Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				"UserAvailabilities",
				table => new
				{
					UserId = table.Column<Guid>(),
					EventDateId = table.Column<Guid>(),
					Comment = table.Column<string>(nullable: true),
					AvailabilityKind = table.Column<int>()
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserAvailabilities", x => new {x.UserId, x.EventDateId});
					table.ForeignKey(
						"FK_UserAvailabilities_EventDates_EventDateId",
						x => x.EventDateId,
						"EventDates",
						"Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						"FK_UserAvailabilities_Users_UserId",
						x => x.UserId,
						"Users",
						"Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				"IX_EventDates_EventId",
				"EventDates",
				"EventId");

			migrationBuilder.CreateIndex(
				"IX_Events_CreatedById",
				"Events",
				"CreatedById");

			migrationBuilder.CreateIndex(
				"IX_Events_GroupId",
				"Events",
				"GroupId");

			migrationBuilder.CreateIndex(
				"IX_Events_PickedDateId1",
				"Events",
				"PickedDateId1");

			migrationBuilder.CreateIndex(
				"IX_Events_ThemeId",
				"Events",
				"ThemeId");

			migrationBuilder.CreateIndex(
				"IX_UserAvailabilities_EventDateId",
				"UserAvailabilities",
				"EventDateId");

			migrationBuilder.CreateIndex(
				"IX_UserGroups_GroupId",
				"UserGroups",
				"GroupId");

			migrationBuilder.CreateIndex(
				"IX_Users_Email",
				"Users",
				"Email",
				unique: true);

			migrationBuilder.CreateIndex(
				"IX_Users_GoogleId",
				"Users",
				"GoogleId",
				unique: true);

			migrationBuilder.AddForeignKey(
				"FK_Events_EventDates_PickedDateId1",
				"Events",
				"PickedDateId1",
				"EventDates",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				"FK_EventDates_Events_EventId",
				"EventDates");

			migrationBuilder.DropTable(
				"DataProtectionKeys");

			migrationBuilder.DropTable(
				"UserAvailabilities");

			migrationBuilder.DropTable(
				"UserGroups");

			migrationBuilder.DropTable(
				"Events");

			migrationBuilder.DropTable(
				"Users");

			migrationBuilder.DropTable(
				"Groups");

			migrationBuilder.DropTable(
				"EventDates");

			migrationBuilder.DropTable(
				"Themes");
		}
	}
}
