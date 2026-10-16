using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fundzo.Data.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //Industry
            migrationBuilder
                .Sql("INSERT INTO Industry (Name, Description) Values ('Finance', 'fintech');");
            migrationBuilder
                .Sql("INSERT INTO Industry (Name, Description) Values ('Education', 'Schools');");

            //Country
            migrationBuilder
                .Sql("INSERT INTO Country (Name, ShortCode, CountryCode) Values ('United Kingdom', 'UK', '44');");
            migrationBuilder
                .Sql("INSERT INTO Country (Name, ShortCode, CountryCode) Values ('Iceland', 'IS', '354');");

            //Categories
            migrationBuilder
                .Sql("INSERT INTO Category (Name) Values ('Culture & heritage')");
            migrationBuilder
                .Sql("INSERT INTO Category (Name) Values ('Community infrastructure')");
            migrationBuilder
                .Sql("INSERT INTO Category (Name) Values ('Helping the homeless')");
            migrationBuilder
                .Sql("INSERT INTO Category (Name) Values ('Education & learning')");
            migrationBuilder
                .Sql("INSERT INTO Category (Name) Values ('Medical, disease & illness')");
            migrationBuilder
                .Sql("INSERT INTO Category (Name) Values ('Rent, food & monthly bills')");
            migrationBuilder
                .Sql("INSERT INTO Category (Name) Values ('Small business investment')");

            //Currencies
            migrationBuilder
                .Sql("INSERT INTO Currency (Code, Name, Symbol) Values ('IKR', 'Icelandic Kronar', 'kr')");
            migrationBuilder
                .Sql("INSERT INTO Currency (Code, Name, Symbol) Values ('GBP', 'Pound', '£')");
            migrationBuilder
                .Sql("INSERT INTO Currency (Code, Name, Symbol) Values ('EUR', 'Euro', '€')");
            migrationBuilder
                .Sql("INSERT INTO Currency (Code, Name, Symbol) Values ('USD', 'US Dollar', '$')");
            migrationBuilder
                .Sql("INSERT INTO Currency (Code, Name, Symbol) Values ('AUD', 'Australian Dollar', '$')");

            //Dontation Status
            migrationBuilder
                .Sql("INSERT INTO DonationStatus (Status) Values ('Pledged')");
            migrationBuilder
                .Sql("INSERT INTO DonationStatus (Status) Values ('Completed')");
            migrationBuilder
                .Sql("INSERT INTO DonationStatus (Status) Values ('Withdrawn')");

            //Fundraiser Status
            migrationBuilder
                .Sql("INSERT INTO FundraiserStatus (Status) Values ('Planned')");
            migrationBuilder
                .Sql("INSERT INTO FundraiserStatus (Status) Values ('Active')");
            migrationBuilder
                .Sql("INSERT INTO FundraiserStatus (Status) Values ('Closed')");

            //Fundraiser Type
            migrationBuilder
                .Sql("INSERT INTO FundraiserType (Type) Values ('Individual')");
            migrationBuilder
                .Sql("INSERT INTO FundraiserType (Type) Values ('Organistion')");

            //Organisation
            migrationBuilder
                .Sql("INSERT INTO Organisation (Name, CompanyNumber) Values ('Gleipnir', 'ABC12345678')");

            //Payment Method
            migrationBuilder
                .Sql("INSERT INTO PaymentMethod (Method) Values ('Stripe - Payment Card')");
            migrationBuilder
                .Sql("INSERT INTO PaymentMethod (Method) Values ('Stripe - ApplePay')");
            migrationBuilder
                .Sql("INSERT INTO PaymentMethod (Method) Values ('Paypal')");

            //Payment Status
            migrationBuilder
                .Sql("INSERT INTO PaymentStatus (Status) Values ('Cancelled')");
            migrationBuilder
                .Sql("INSERT INTO PaymentStatus (Status) Values ('Complete')");
            migrationBuilder
                .Sql("INSERT INTO PaymentStatus (Status) Values ('Failed - Fraud')");
            migrationBuilder
                .Sql("INSERT INTO PaymentStatus (Status) Values ('Failed - Technical')");
            migrationBuilder
                .Sql("INSERT INTO PaymentStatus (Status) Values ('Failed - Verification')");
            migrationBuilder
                .Sql("INSERT INTO PaymentStatus (Status) Values ('Pending')");
            migrationBuilder
                .Sql("INSERT INTO PaymentStatus (Status) Values ('Refunded')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Industry");

            migrationBuilder
                .Sql("DELETE FROM Country");

            migrationBuilder
                .Sql("DELETE FROM Category");

            migrationBuilder
                .Sql("DELETE FROM Currency");

            migrationBuilder
                .Sql("DELETE FROM Donation");

            migrationBuilder
                .Sql("DELETE FROM DonationStatus");

            migrationBuilder
                .Sql("DELETE FROM Fundraiser");

            migrationBuilder
                .Sql("DELETE FROM FundraiserStatus");

            migrationBuilder
                .Sql("DELETE FROM FundraiserType");

            migrationBuilder
                .Sql("DELETE FROM Organisation");

            migrationBuilder
                .Sql("DELETE FROM Payment");

            migrationBuilder
                .Sql("DELETE FROM PaymentMethod");

            migrationBuilder
                .Sql("DELETE FROM PaymentStatus");

        }
    }
}
