using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eximo.data.Migrations
{
    public partial class UpdatedEncryptionService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetOne = table.Column<byte[]>(nullable: true),
                    StreetTwo = table.Column<byte[]>(nullable: true),
                    City = table.Column<byte[]>(nullable: true),
                    State = table.Column<byte[]>(nullable: true),
                    PostalZip = table.Column<byte[]>(nullable: true),
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
                    FirstName = table.Column<byte[]>(nullable: true),
                    LastName = table.Column<byte[]>(nullable: true),
                    UserName = table.Column<byte[]>(nullable: true),
                    Email = table.Column<byte[]>(nullable: true),
                    Password = table.Column<byte[]>(nullable: true)
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
                    AuthorizationName = table.Column<byte[]>(nullable: true),
                    AuthorizationActive = table.Column<byte[]>(nullable: false),
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
                    Name = table.Column<byte[]>(nullable: true),
                    Website = table.Column<byte[]>(nullable: true),
                    VerificationType = table.Column<byte[]>(nullable: true),
                    OptOutLink = table.Column<byte[]>(nullable: true),
                    Bio = table.Column<byte[]>(nullable: true),
                    CaptureCustomerInfo = table.Column<byte[]>(nullable: false),
                    CustomerAccountStatus = table.Column<byte[]>(nullable: false),
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
                    MarketerName = table.Column<byte[]>(nullable: true),
                    Website = table.Column<byte[]>(nullable: true),
                    EmailMarketingStatus = table.Column<byte[]>(nullable: false),
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
                    Title = table.Column<byte[]>(nullable: true),
                    Description = table.Column<byte[]>(nullable: true),
                    NotificationDate = table.Column<byte[]>(nullable: false),
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
                    CardName = table.Column<byte[]>(nullable: true),
                    CardNumber = table.Column<byte[]>(nullable: true),
                    CardType = table.Column<byte[]>(nullable: true),
                    SecurityNumber = table.Column<byte[]>(nullable: false),
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
                    AreaCode = table.Column<byte[]>(nullable: false),
                    PhoneNumber = table.Column<byte[]>(nullable: false),
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
                    ServiceName = table.Column<byte[]>(nullable: true),
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
                values: new object[] { 1, new byte[] { 48, 179, 38, 11, 193, 97, 127, 35, 83, 226, 192, 222, 244, 75, 235, 229 }, new byte[] { 76, 79, 32, 83, 107, 203, 61, 4, 55, 68, 108, 118, 217, 126, 165, 232 }, new byte[] { 10, 214, 145, 45, 6, 9, 217, 120, 246, 118, 239, 147, 166, 185, 126, 172 }, new byte[] { 127, 236, 241, 141, 208, 178, 24, 135, 89, 89, 243, 1, 205, 92, 75, 113, 183, 6, 105, 252, 110, 142, 198, 19, 96, 228, 253, 42, 110, 92, 21, 186 }, new byte[] { 141, 95, 93, 58, 116, 210, 38, 58, 135, 148, 148, 8, 187, 41, 138, 129, 235, 99, 202, 132, 42, 172, 101, 194, 92, 139, 154, 208, 8, 194, 198, 204 }, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, new byte[] { 27, 145, 118, 123, 109, 41, 6, 217, 219, 131, 28, 225, 175, 148, 201, 149 }, new byte[] { 68, 230, 21, 168, 187, 38, 115, 149, 80, 183, 110, 184, 252, 235, 49, 26 }, new byte[] { 251, 89, 219, 235, 84, 174, 143, 6, 183, 94, 105, 2, 82, 29, 27, 219 }, new byte[] { 234, 82, 37, 125, 144, 134, 246, 100, 150, 252, 85, 37, 181, 40, 68, 50 }, new byte[] { 14, 39, 205, 214, 192, 17, 188, 128, 61, 102, 101, 128, 255, 43, 183, 80 } });

            migrationBuilder.InsertData(
                table: "AuthorizationTypes",
                columns: new[] { "AuthorizationId", "AuthorizationActive", "AuthorizationName", "UserId" },
                values: new object[] { 1, new byte[] { 9, 78, 147, 202, 111, 68, 133, 56, 149, 56, 17, 160, 214, 30, 64, 52 }, new byte[] { 95, 144, 101, 100, 53, 172, 236, 109, 199, 65, 233, 75, 254, 27, 60, 120 }, 1 });

            migrationBuilder.InsertData(
                table: "AuthorizationTypes",
                columns: new[] { "AuthorizationId", "AuthorizationActive", "AuthorizationName", "UserId" },
                values: new object[] { 2, new byte[] { 9, 78, 147, 202, 111, 68, 133, 56, 149, 56, 17, 160, 214, 30, 64, 52 }, new byte[] { 183, 43, 50, 178, 240, 5, 106, 102, 133, 73, 49, 13, 93, 197, 85, 107 }, 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "ContactAddressAddressId", "PhoneNumberPhoneId", "UserId" },
                values: new object[] { 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "DataBrokers",
                columns: new[] { "DataBrokerId", "Bio", "CaptureCustomerInfo", "CustomerAccountStatus", "Name", "OptOutLink", "UserId", "VerificationType", "Website" },
                values: new object[] { 1, new byte[] { 133, 227, 21, 29, 201, 63, 150, 6, 199, 136, 149, 227, 54, 250, 94, 233, 182, 204, 104, 193, 68, 132, 81, 161, 66, 193, 136, 130, 14, 130, 166, 44 }, new byte[] { 5, 40, 39, 150, 84, 129, 167, 245, 44, 154, 48, 88, 117, 31, 233, 207 }, new byte[] { 209, 55, 131, 141, 180, 194, 26, 224, 171, 210, 204, 86, 186, 21, 3, 73 }, new byte[] { 52, 57, 209, 200, 127, 196, 28, 171, 194, 149, 60, 211, 80, 194, 180, 159 }, new byte[] { 50, 165, 167, 205, 247, 142, 35, 180, 22, 118, 61, 16, 13, 41, 10, 56, 230, 205, 113, 35, 108, 52, 159, 80, 58, 100, 81, 165, 11, 141, 225, 78 }, 1, new byte[] { 95, 144, 101, 100, 53, 172, 236, 109, 199, 65, 233, 75, 254, 27, 60, 120 }, new byte[] { 26, 194, 56, 128, 154, 96, 200, 209, 170, 232, 11, 14, 166, 28, 249, 94, 156, 163, 60, 130, 161, 123, 167, 108, 99, 54, 223, 217, 18, 2, 177, 4 } });

            migrationBuilder.InsertData(
                table: "EmailMarketings",
                columns: new[] { "EmailMarketingId", "EmailMarketingStatus", "MarketerName", "UserId", "Website" },
                values: new object[] { 1, new byte[] { 209, 55, 131, 141, 180, 194, 26, 224, 171, 210, 204, 86, 186, 21, 3, 73 }, new byte[] { 100, 224, 198, 50, 245, 120, 163, 131, 52, 26, 67, 106, 29, 81, 45, 9, 104, 169, 40, 237, 58, 120, 60, 199, 123, 222, 207, 197, 38, 239, 133, 137 }, 1, new byte[] { 164, 87, 234, 89, 88, 88, 37, 109, 182, 188, 209, 51, 175, 150, 192, 166, 109, 41, 34, 175, 66, 227, 45, 247, 221, 128, 209, 211, 219, 243, 219, 93 } });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Description", "NotificationCompleted", "NotificationDate", "Title", "UserId" },
                values: new object[] { 1, null, false, new byte[] { 241, 119, 30, 242, 95, 22, 79, 48, 59, 139, 212, 77, 96, 255, 57, 14, 130, 212, 26, 43, 229, 204, 192, 155, 126, 103, 126, 43, 182, 105, 191, 21 }, new byte[] { 36, 123, 101, 127, 33, 187, 246, 24, 227, 108, 18, 181, 223, 240, 104, 201, 94, 94, 221, 152, 168, 120, 110, 204, 238, 48, 224, 249, 32, 135, 9, 224 }, 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "CardName", "CardNumber", "CardType", "SecurityNumber", "UserId" },
                values: new object[] { 1, new byte[] { 188, 187, 254, 6, 109, 38, 171, 130, 167, 129, 198, 130, 254, 155, 16, 234 }, new byte[] { 61, 70, 166, 179, 154, 14, 154, 189, 226, 154, 227, 253, 165, 25, 31, 44 }, new byte[] { 165, 190, 234, 249, 51, 194, 119, 215, 180, 65, 19, 86, 15, 155, 197, 59 }, new byte[] { 202, 74, 83, 37, 89, 251, 13, 88, 125, 14, 86, 76, 207, 249, 1, 147 }, 1 });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "AreaCode", "PhoneNumber", "UserId" },
                values: new object[] { 1, new byte[] { 139, 149, 170, 236, 162, 248, 109, 82, 21, 8, 195, 23, 199, 196, 206, 6 }, new byte[] { 126, 240, 70, 9, 37, 53, 146, 198, 65, 10, 106, 240, 60, 134, 235, 91 }, 1 });

            migrationBuilder.InsertData(
                table: "ServicePlan",
                columns: new[] { "ServicePlanId", "ServiceName", "UserId" },
                values: new object[] { 1, new byte[] { 107, 216, 20, 204, 56, 124, 227, 73, 197, 159, 108, 141, 60, 149, 190, 42 }, 1 });

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
