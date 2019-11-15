using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eximo.data.Migrations
{
    public partial class InitalEximoCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetOne = table.Column<string>(nullable: true),
                    StreetTwo = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalZip = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationTypes",
                columns: table => new
                {
                    AuthorizationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorizationName = table.Column<string>(nullable: true),
                    AuthorizationActive = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationTypes", x => x.AuthorizationId);
                    table.ForeignKey(
                        name: "FK_AuthorizationTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataBrokers",
                columns: table => new
                {
                    DataBrokerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    VerificationType = table.Column<string>(nullable: true),
                    OptOutLink = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    CaptureCustomerInfo = table.Column<string>(nullable: true),
                    CustomerAccountStatus = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBrokers", x => x.DataBrokerId);
                    table.ForeignKey(
                        name: "FK_DataBrokers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailMarketings",
                columns: table => new
                {
                    EmailMarketingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarketerName = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    EmailMarketingStatus = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMarketings", x => x.EmailMarketingId);
                    table.ForeignKey(
                        name: "FK_EmailMarketings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NotificationDate = table.Column<DateTime>(nullable: false),
                    NotificationCompleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    CardType = table.Column<string>(nullable: true),
                    SecurityNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaCode = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phone_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePlan",
                columns: table => new
                {
                    ServicePlanId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePlan", x => x.ServicePlanId);
                    table.ForeignKey(
                        name: "FK_ServicePlan_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumberPhoneId = table.Column<int>(nullable: true),
                    ContactAddressAddressId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Address_ContactAddressAddressId",
                        column: x => x.ContactAddressAddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Phone_PhoneNumberPhoneId",
                        column: x => x.PhoneNumberPhoneId,
                        principalTable: "Phone",
                        principalColumn: "PhoneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "PostalZip", "State", "StreetOne", "StreetTwo", "UserId" },
                values: new object[] { 1, "Americus", "31709", "GA", "123 South lee st", "example street two", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, "jbrown@mail.com", "James", "Brown", "abc123", "jbrown" });

            migrationBuilder.InsertData(
                table: "AuthorizationTypes",
                columns: new[] { "AuthorizationId", "AuthorizationActive", "AuthorizationName", "UserId" },
                values: new object[] { 1, true, "Email", 1 });

            migrationBuilder.InsertData(
                table: "AuthorizationTypes",
                columns: new[] { "AuthorizationId", "AuthorizationActive", "AuthorizationName", "UserId" },
                values: new object[] { 2, true, "Phone", 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "ContactAddressAddressId", "PhoneNumberPhoneId", "UserId" },
                values: new object[] { 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "DataBrokers",
                columns: new[] { "DataBrokerId", "Bio", "CaptureCustomerInfo", "CustomerAccountStatus", "Name", "OptOutLink", "UserId", "VerificationType", "Website" },
                values: new object[] { 1, "Some bio information", "[\"Email\",\"Phone\"]", 0, "Databroker One", "http://optoutlink.com", 1, "Email", "http://databrokerone.com" });

            migrationBuilder.InsertData(
                table: "EmailMarketings",
                columns: new[] { "EmailMarketingId", "EmailMarketingStatus", "MarketerName", "UserId", "Website" },
                values: new object[] { 1, 0, "Email Marketing Name Example", 1, "http://emailmarketersite.com" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Description", "NotificationCompleted", "NotificationDate", "Title", "UserId" },
                values: new object[] { 1, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notification Title", 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "CardName", "CardNumber", "CardType", "SecurityNumber", "UserId" },
                values: new object[] { 1, "James Brown", "123445677890", "Visa", 299, 1 });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "AreaCode", "PhoneNumber", "UserId" },
                values: new object[] { 1, 229, 5555555, 1 });

            migrationBuilder.InsertData(
                table: "ServicePlan",
                columns: new[] { "ServicePlanId", "ServiceName", "UserId" },
                values: new object[] { 1, "Basic", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationTypes_UserId",
                table: "AuthorizationTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactAddressAddressId",
                table: "Contacts",
                column: "ContactAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PhoneNumberPhoneId",
                table: "Contacts",
                column: "PhoneNumberPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataBrokers_UserId",
                table: "DataBrokers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMarketings_UserId",
                table: "EmailMarketings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_UserId",
                table: "Phone",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePlan_UserId",
                table: "ServicePlan",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizationTypes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DataBrokers");

            migrationBuilder.DropTable(
                name: "EmailMarketings");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ServicePlan");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
