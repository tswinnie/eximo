using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eximo.data.Migrations
{
    public partial class AddEncryptionService : Migration
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
                values: new object[] { 1, new byte[] { 51, 146, 146, 251, 171, 28, 128, 51, 125, 48, 243, 152, 146, 158, 234, 204 }, new byte[] { 233, 245, 240, 212, 3, 202, 185, 87, 149, 143, 29, 0, 150, 74, 89, 150 }, new byte[] { 243, 141, 175, 107, 106, 108, 100, 227, 175, 225, 70, 229, 1, 48, 52, 0 }, new byte[] { 15, 218, 140, 85, 190, 152, 185, 0, 19, 144, 248, 54, 44, 96, 32, 49, 230, 9, 179, 246, 81, 10, 49, 197, 229, 76, 3, 44, 44, 158, 14, 167 }, new byte[] { 35, 117, 255, 163, 161, 150, 65, 131, 108, 111, 140, 118, 234, 173, 80, 89, 197, 50, 231, 215, 220, 72, 4, 11, 14, 93, 29, 69, 224, 190, 135, 47 }, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, new byte[] { 2, 140, 95, 142, 67, 141, 138, 41, 140, 57, 74, 43, 162, 160, 171, 171 }, new byte[] { 48, 185, 94, 0, 19, 228, 144, 244, 222, 165, 92, 250, 7, 31, 237, 113 }, new byte[] { 219, 97, 108, 56, 73, 121, 148, 235, 130, 212, 73, 39, 102, 62, 22, 237 }, new byte[] { 44, 16, 112, 185, 221, 225, 129, 242, 54, 126, 158, 226, 140, 199, 136, 174 }, new byte[] { 240, 107, 184, 92, 12, 28, 63, 83, 127, 175, 169, 134, 35, 154, 42, 115 } });

            migrationBuilder.InsertData(
                table: "AuthorizationTypes",
                columns: new[] { "AuthorizationId", "AuthorizationActive", "AuthorizationName", "UserId" },
                values: new object[] { 1, new byte[] { 96, 107, 243, 117, 204, 153, 34, 250, 26, 190, 105, 11, 1, 203, 23, 164 }, new byte[] { 229, 13, 44, 171, 75, 36, 203, 122, 192, 160, 224, 91, 161, 21, 138, 198 }, 1 });

            migrationBuilder.InsertData(
                table: "AuthorizationTypes",
                columns: new[] { "AuthorizationId", "AuthorizationActive", "AuthorizationName", "UserId" },
                values: new object[] { 2, new byte[] { 96, 107, 243, 117, 204, 153, 34, 250, 26, 190, 105, 11, 1, 203, 23, 164 }, new byte[] { 117, 42, 132, 130, 198, 51, 138, 187, 253, 165, 70, 20, 120, 216, 163, 84 }, 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "ContactAddressAddressId", "PhoneNumberPhoneId", "UserId" },
                values: new object[] { 1, null, null, 1 });

            migrationBuilder.InsertData(
                table: "DataBrokers",
                columns: new[] { "DataBrokerId", "Bio", "CaptureCustomerInfo", "CustomerAccountStatus", "Name", "OptOutLink", "UserId", "VerificationType", "Website" },
                values: new object[] { 1, new byte[] { 29, 66, 62, 113, 162, 100, 129, 27, 20, 4, 121, 97, 170, 43, 24, 242, 16, 202, 9, 54, 240, 206, 62, 195, 117, 177, 57, 20, 66, 240, 16, 82 }, new byte[] { 230, 29, 218, 2, 200, 210, 123, 196, 163, 226, 223, 10, 37, 119, 69, 120 }, new byte[] { 179, 52, 236, 249, 142, 127, 145, 145, 100, 223, 230, 78, 215, 53, 126, 166 }, new byte[] { 183, 250, 87, 216, 43, 49, 142, 250, 145, 99, 86, 224, 71, 135, 145, 209 }, new byte[] { 27, 80, 49, 1, 15, 55, 167, 125, 174, 165, 253, 231, 34, 70, 179, 11, 189, 185, 143, 167, 154, 148, 177, 19, 239, 238, 181, 72, 251, 2, 250, 241 }, 1, new byte[] { 229, 13, 44, 171, 75, 36, 203, 122, 192, 160, 224, 91, 161, 21, 138, 198 }, new byte[] { 28, 134, 1, 100, 76, 229, 109, 219, 192, 250, 227, 35, 160, 163, 86, 11, 61, 188, 84, 135, 150, 59, 5, 184, 41, 61, 11, 72, 83, 177, 12, 208 } });

            migrationBuilder.InsertData(
                table: "EmailMarketings",
                columns: new[] { "EmailMarketingId", "EmailMarketingStatus", "MarketerName", "UserId", "Website" },
                values: new object[] { 1, new byte[] { 179, 52, 236, 249, 142, 127, 145, 145, 100, 223, 230, 78, 215, 53, 126, 166 }, new byte[] { 220, 27, 49, 136, 25, 247, 133, 197, 246, 31, 17, 57, 112, 140, 32, 182, 68, 154, 172, 32, 52, 86, 250, 123, 112, 109, 19, 219, 101, 23, 224, 193 }, 1, new byte[] { 202, 80, 66, 236, 94, 175, 27, 244, 58, 170, 110, 225, 70, 52, 178, 112, 34, 156, 77, 56, 198, 209, 106, 249, 204, 123, 72, 246, 1, 51, 209, 49 } });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Description", "NotificationCompleted", "NotificationDate", "Title", "UserId" },
                values: new object[] { 1, null, false, new byte[] { 145, 27, 164, 141, 210, 180, 211, 217, 132, 175, 112, 45, 250, 121, 93, 238, 193, 111, 166, 59, 40, 142, 176, 209, 161, 57, 129, 33, 30, 205, 232, 174 }, new byte[] { 251, 93, 154, 214, 0, 116, 96, 70, 187, 129, 102, 8, 181, 2, 166, 60, 110, 175, 29, 50, 47, 173, 198, 130, 44, 27, 47, 255, 239, 15, 33, 17 }, 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "CardName", "CardNumber", "CardType", "SecurityNumber", "UserId" },
                values: new object[] { 1, new byte[] { 223, 160, 159, 174, 136, 31, 13, 64, 123, 180, 239, 56, 157, 225, 0, 15 }, new byte[] { 88, 58, 192, 63, 57, 119, 236, 19, 90, 67, 246, 250, 200, 191, 100, 65 }, new byte[] { 103, 204, 166, 62, 16, 103, 108, 119, 137, 34, 254, 15, 175, 226, 70, 191 }, new byte[] { 188, 135, 37, 227, 63, 166, 53, 46, 53, 162, 114, 54, 127, 1, 51, 144 }, 1 });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "AreaCode", "PhoneNumber", "UserId" },
                values: new object[] { 1, new byte[] { 87, 143, 102, 6, 27, 208, 210, 207, 20, 201, 54, 127, 204, 111, 21, 81 }, new byte[] { 177, 100, 102, 74, 78, 56, 138, 204, 63, 31, 200, 223, 136, 172, 152, 238 }, 1 });

            migrationBuilder.InsertData(
                table: "ServicePlan",
                columns: new[] { "ServicePlanId", "ServiceName", "UserId" },
                values: new object[] { 1, new byte[] { 151, 67, 128, 13, 147, 59, 217, 30, 134, 244, 131, 88, 126, 5, 210, 172 }, 1 });

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
