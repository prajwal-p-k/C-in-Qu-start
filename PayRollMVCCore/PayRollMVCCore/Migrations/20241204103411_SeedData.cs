using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayRollMVCCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("insert into Departments values('Administraion')");
            //migrationBuilder.Sql("insert into Departments values('Accounts')");
            //migrationBuilder.Sql("insert into Departments values('Finance')");
           migrationBuilder.Sql("insert into Employees values('Prajwal','prajwal@gmail.com',9108022525,'Kodiyala@123','4/5/2002','6/7/2024',50000,'fullstack developer',13,'mandya')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
