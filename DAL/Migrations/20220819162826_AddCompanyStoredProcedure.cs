using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddCompanyStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create procedure GetCompanies as
                begin
                    select * 
                    from companies;
                end
                ");

            migrationBuilder.Sql(@"
                create procedure GetCompany @id int as
                begin
                    SELECT *
                    FROM Companies 
                    WHERE Id = @id;
                end
                ");

            migrationBuilder.Sql(@"
                create procedure AddCompany @name nvarchar(50), @address nvarchar(150) as
                begin
                    begin transaction
                    begin try
                        insert into companies (name, address) 
                        values (@name, @address);
                        commit transaction
                    end try
                    begin catch
                        rollback transaction
                    end catch
                    select *
                    from companies 
                    where id = (select cast(scope_identity() as int));
                end
                ");

            migrationBuilder.Sql(@"
                create procedure UpdateCompany @id int, @name nvarchar(50), @address nvarchar(150) as
                begin
                    begin transaction
                    begin try
                        update companies
                        set name = @name, address = @address
                        where id = @id;
                        commit transaction
                    end try
                    begin catch
                        rollback transaction
                    end catch
                    select *
                    from companies 
                    where id = @id;
                end
                ");

            migrationBuilder.Sql(@"
                create procedure RemoveCompany @id int as
                begin
                    begin transaction
                    begin try
                        delete from companies 
                        where id = @id;
                        commit transaction
                    end try
                    begin catch
                        rollback transaction
                    end catch
                end
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
