using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore5WebApp.DAL.Migrations
{
    public partial class AddStoredProcedures2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var proc1 = @"
IF OBJECT_ID('GetPersonsByState', 'P') IS NOT NULL
DROP PROC UpdateProfilesCountry
GO

CREATE PROCEDURE [dbo].GetPersonsByState
    @state varchar(255)
AS
BEGIN
    SELECT P.*
    FROM Persons p
        INNER JOIN Addresses a ON p.Id = a.PersonId
    WHERE a.state = @state
END";
            var proc2 = @"
IF OBJECT_ID('AddLookUpItem', 'P') IS NOT NULL
DROP PROC AddLookUpItem
GO

CREATE PROCEDURE [dbo].AddLookUpItem
    @Code varchar(255),
    @Description varchar(255),
    @LookUpTypeId int
AS
BEGIN
    INSERT INTO LookUps (Code, Description, LookUpType)
    VALUES (@code, @description, @lookuptypeid)
END";
            migrationBuilder.Sql(proc1);
            migrationBuilder.Sql(proc2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC GetPersonsByState");
            migrationBuilder.Sql(@"DROP PROC AddLookUpItem");
        }
    }
}
