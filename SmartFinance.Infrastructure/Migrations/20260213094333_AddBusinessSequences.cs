using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessSequences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneratedNumberResults",
                columns: table => new
                {
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.Sql(@"
                CREATE SEQUENCE CustomerSequence START WITH 1 INCREMENT BY 1;
                CREATE SEQUENCE OrderSequence START WITH 1 INCREMENT BY 1;
                CREATE SEQUENCE InvoiceSequence START WITH 1 INCREMENT BY 1;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_GenerateBusinessCode
                    @SequenceName NVARCHAR(50),
                    @Prefix NVARCHAR(20)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    DECLARE @NextValue INT;
                    DECLARE @Sql NVARCHAR(MAX);

                    SET @Sql = 'SELECT @NextValue = NEXT VALUE FOR ' + QUOTENAME(@SequenceName);

                    EXEC sp_executesql 
                        @Sql,
                        N'@NextValue INT OUTPUT',
                        @NextValue OUTPUT;

                    SELECT 
                        @Prefix AS Prefix,
                        @NextValue AS CurrentValue;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneratedNumberResults");

            migrationBuilder.Sql("DROP PROCEDURE sp_GenerateBusinessCode;");
            migrationBuilder.Sql("DROP SEQUENCE CustomerSequence;");
            migrationBuilder.Sql("DROP SEQUENCE OrderSequence;");
            migrationBuilder.Sql("DROP SEQUENCE InvoiceSequence;");
        }
    }
}
