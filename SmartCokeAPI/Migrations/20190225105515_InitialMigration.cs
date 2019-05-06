using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartCokeAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "SmartCoke");

            migrationBuilder.CreateTable(
                name: "Area",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictID = table.Column<string>(maxLength: 10, nullable: true),
                    RegionID = table.Column<string>(unicode: false, nullable: true),
                    AreaID = table.Column<string>(unicode: false, nullable: true),
                    AreaName = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    ServCharge = table.Column<string>(unicode: false, nullable: true),
                    AddedBy = table.Column<string>(unicode: false, nullable: true),
                    AddedTime = table.Column<string>(unicode: false, nullable: true),
                    ChargeType = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomOrders",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<string>(unicode: false, nullable: true),
                    ProductName = table.Column<string>(unicode: false, nullable: true),
                    Size = table.Column<string>(unicode: false, nullable: true),
                    Quantity = table.Column<string>(unicode: false, nullable: true),
                    Total = table.Column<string>(unicode: false, nullable: true),
                    Amount = table.Column<string>(unicode: false, nullable: true),
                    DateLogged = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomProducts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(unicode: false, nullable: true),
                    PackSize = table.Column<string>(unicode: false, nullable: true),
                    UnitAmount = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    ProductID = table.Column<string>(unicode: false, nullable: true),
                    AddedBy = table.Column<string>(unicode: false, nullable: true),
                    AddedDate = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomProducts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Distributors",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictID = table.Column<string>(unicode: false, nullable: true),
                    DistribID = table.Column<string>(unicode: false, nullable: true),
                    DistrictName = table.Column<string>(unicode: false, nullable: true),
                    Township = table.Column<string>(unicode: false, nullable: true),
                    Outlet = table.Column<string>(unicode: false, nullable: true),
                    OTContactPerson = table.Column<string>(unicode: false, nullable: true),
                    OTContactNumber = table.Column<string>(unicode: false, nullable: true),
                    OTEmail = table.Column<string>(unicode: false, nullable: true),
                    RSSName = table.Column<string>(unicode: false, nullable: true),
                    RSSNumber = table.Column<string>(unicode: false, nullable: true),
                    RSSEmail = table.Column<string>(unicode: false, nullable: true),
                    RSMName = table.Column<string>(unicode: false, nullable: true),
                    RSMNumber = table.Column<string>(unicode: false, nullable: true),
                    RSMEmail = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    AddedBy = table.Column<string>(unicode: false, nullable: true),
                    AddedDate = table.Column<string>(unicode: false, nullable: true),
                    EditedBy = table.Column<string>(unicode: false, nullable: true),
                    EditedDate = table.Column<string>(unicode: false, nullable: true),
                    RegionID = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictID = table.Column<string>(unicode: false, nullable: true),
                    RegionID = table.Column<string>(unicode: false, nullable: true),
                    DistrictName = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    AddedBy = table.Column<string>(unicode: false, nullable: true),
                    AddedDate = table.Column<string>(unicode: false, nullable: true),
                    EditBy = table.Column<string>(unicode: false, nullable: true),
                    EditTime = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventSize",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventSize = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSize", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventType = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(unicode: false, nullable: true),
                    Password = table.Column<string>(unicode: false, nullable: true),
                    Fname = table.Column<string>(unicode: false, nullable: true),
                    LastName = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(unicode: false, nullable: true),
                    PhoneNumber = table.Column<string>(unicode: false, nullable: true),
                    Email = table.Column<string>(unicode: false, nullable: true),
                    EventType = table.Column<string>(unicode: false, nullable: true),
                    Location = table.Column<string>(unicode: false, nullable: true),
                    GhanaPostGPS = table.Column<string>(unicode: false, nullable: true),
                    Venue = table.Column<string>(unicode: false, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    Duration = table.Column<string>(unicode: false, nullable: true),
                    Package = table.Column<string>(unicode: false, nullable: true),
                    PaymentType = table.Column<string>(unicode: false, nullable: true),
                    Amount = table.Column<double>(nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    LoggedDate = table.Column<DateTime>(type: "date", nullable: true),
                    EpicorStatus = table.Column<string>(unicode: false, nullable: true),
                    EventSize = table.Column<string>(unicode: false, nullable: true),
                    OrderID = table.Column<string>(unicode: false, nullable: true),
                    RSVPname = table.Column<string>(unicode: false, nullable: true),
                    RSVPNumber = table.Column<string>(unicode: false, nullable: true),
                    Region = table.Column<string>(unicode: false, nullable: true),
                    Area = table.Column<string>(unicode: false, nullable: true),
                    Lname = table.Column<string>(unicode: false, nullable: true),
                    TxnResponseCode = table.Column<string>(unicode: false, nullable: true),
                    MerchTxnRef = table.Column<string>(unicode: false, nullable: true),
                    OrderInfo = table.Column<string>(unicode: false, nullable: true),
                    Merchant = table.Column<string>(unicode: false, nullable: true),
                    PaidAmount = table.Column<string>(unicode: false, nullable: true),
                    Message = table.Column<string>(unicode: false, nullable: true),
                    ReceiptNo = table.Column<string>(unicode: false, nullable: true),
                    AcqResponseCode = table.Column<string>(unicode: false, nullable: true),
                    AuthorizeId = table.Column<string>(unicode: false, nullable: true),
                    BatchNo = table.Column<string>(unicode: false, nullable: true),
                    TransactionNo = table.Column<string>(unicode: false, nullable: true),
                    Card = table.Column<string>(unicode: false, nullable: true),
                    DSECI = table.Column<string>(unicode: false, nullable: true),
                    DSXID = table.Column<string>(unicode: false, nullable: true),
                    DSenrolled = table.Column<string>(unicode: false, nullable: true),
                    DSstatus = table.Column<string>(unicode: false, nullable: true),
                    VerToken = table.Column<string>(unicode: false, nullable: true),
                    VerType = table.Column<string>(unicode: false, nullable: true),
                    VerSecurityLevel = table.Column<string>(unicode: false, nullable: true),
                    VerStatus = table.Column<string>(unicode: false, nullable: true),
                    RiskOverallResult = table.Column<string>(unicode: false, nullable: true),
                    TxnReversalResult = table.Column<string>(unicode: false, nullable: true),
                    TxnResponseCodeDesc = table.Column<string>(unicode: false, nullable: true),
                    cscResultCode = table.Column<string>(unicode: false, nullable: true),
                    cscResultCodeDesc = table.Column<string>(unicode: false, nullable: true),
                    ReceiptErrorMessage = table.Column<string>(unicode: false, nullable: true),
                    MailStatus = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ServCharge = table.Column<string>(unicode: false, nullable: true),
                    DistributorID = table.Column<string>(unicode: false, nullable: true),
                    DistributorName = table.Column<string>(unicode: false, nullable: true),
                    District = table.Column<string>(unicode: false, nullable: true),
                    DistrictID = table.Column<string>(unicode: false, nullable: true),
                    TotalAmount = table.Column<string>(unicode: false, nullable: true),
                    DistributorAmount = table.Column<string>(unicode: false, nullable: true),
                    DeliveryMail = table.Column<string>(unicode: false, nullable: true),
                    CountCode = table.Column<string>(unicode: false, nullable: true),
                    MOMONumber = table.Column<string>(unicode: false, nullable: true),
                    MOMONetwork = table.Column<string>(unicode: false, nullable: true),
                    ReferenceType = table.Column<string>(unicode: false, nullable: true),
                    ReferenceDetails = table.Column<string>(unicode: false, nullable: true),
                    LoyalytyPoint = table.Column<string>(unicode: false, nullable: true),
                    Volume = table.Column<string>(unicode: false, nullable: true),
                    CustID = table.Column<string>(unicode: false, nullable: true),
                    PromoCode = table.Column<string>(unicode: false, nullable: true),
                    ShareAcoke = table.Column<string>(unicode: false, nullable: true),
                    BTRefrence = table.Column<string>(unicode: false, nullable: true),
                    BTDate = table.Column<string>(unicode: false, nullable: true),
                    BTBankName = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageNumber = table.Column<int>(nullable: true),
                    PackageName = table.Column<string>(unicode: false, nullable: true),
                    PackageAmount = table.Column<int>(nullable: true),
                    PackageDesc = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    PackageText = table.Column<string>(unicode: false, nullable: true),
                    Volume = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PackSizes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<string>(unicode: false, nullable: true),
                    Size = table.Column<string>(unicode: false, nullable: true),
                    Quantity = table.Column<string>(unicode: false, nullable: true),
                    Amount = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    SizeID = table.Column<string>(unicode: false, nullable: true),
                    Type = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackSizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromoID = table.Column<string>(unicode: false, nullable: true),
                    OrganisationName = table.Column<string>(unicode: false, nullable: true),
                    OrganisationContact = table.Column<string>(unicode: false, nullable: true),
                    OrganisationEmail = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    DateEntered = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProjectedOrders = table.Column<string>(unicode: false, nullable: true),
                    Duration = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionID = table.Column<string>(unicode: false, nullable: true),
                    RegionName = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SCreference",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceName = table.Column<string>(unicode: false, nullable: true),
                    Mamlade = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCreference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comolaints",
                schema: "SmartCoke",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, nullable: true),
                    Email = table.Column<string>(unicode: false, nullable: true),
                    Subject = table.Column<string>(unicode: false, nullable: true),
                    Message = table.Column<string>(unicode: false, nullable: true),
                    Date = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comolaints", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                schema: "SmartCoke",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(unicode: false, nullable: true),
                    Code = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                schema: "SmartCoke",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustCode = table.Column<string>(unicode: false, nullable: true),
                    FName = table.Column<string>(unicode: false, nullable: true),
                    Lname = table.Column<string>(unicode: false, nullable: true),
                    Uname = table.Column<string>(unicode: false, nullable: true),
                    Password = table.Column<string>(unicode: false, nullable: true),
                    PhoneNum = table.Column<string>(unicode: false, nullable: true),
                    Email = table.Column<string>(unicode: false, nullable: true),
                    Dob = table.Column<string>(unicode: false, nullable: true),
                    DobDay = table.Column<string>(unicode: false, nullable: true),
                    DobMonth = table.Column<string>(unicode: false, nullable: true),
                    Membership = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    Orders = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                schema: "SmartCoke",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<string>(unicode: false, nullable: true),
                    Comment = table.Column<string>(unicode: false, nullable: true),
                    LoggedDate = table.Column<string>(unicode: false, nullable: true),
                    OrderID = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PackageBreakdown",
                schema: "SmartCoke",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackageName = table.Column<string>(unicode: false, nullable: true),
                    ProductName = table.Column<string>(unicode: false, nullable: true),
                    PackSize = table.Column<string>(unicode: false, nullable: true),
                    Quantity = table.Column<string>(unicode: false, nullable: true),
                    Total = table.Column<string>(unicode: false, nullable: true),
                    AddedBy = table.Column<string>(unicode: false, nullable: true),
                    AddedDate = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageBreakdown", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCharge",
                schema: "SmartCoke",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Definiton = table.Column<string>(unicode: false, nullable: true),
                    ServChrgAmt = table.Column<string>(unicode: false, nullable: true),
                    AddedBy = table.Column<string>(unicode: false, nullable: true),
                    AddedDate = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<string>(unicode: false, nullable: true),
                    Type = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCharge", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Area",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomProducts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Distributors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "District",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EventSize",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EventType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Login",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Packages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PackSizes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PromoCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SCreference",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Comolaints",
                schema: "SmartCoke");

            migrationBuilder.DropTable(
                name: "CountryCodes",
                schema: "SmartCoke");

            migrationBuilder.DropTable(
                name: "CustomerDetails",
                schema: "SmartCoke");

            migrationBuilder.DropTable(
                name: "Feedback",
                schema: "SmartCoke");

            migrationBuilder.DropTable(
                name: "PackageBreakdown",
                schema: "SmartCoke");

            migrationBuilder.DropTable(
                name: "ServiceCharge",
                schema: "SmartCoke");
        }
    }
}
