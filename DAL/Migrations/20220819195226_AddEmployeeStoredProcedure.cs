using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddEmployeeStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create procedure GetEmployees as
                begin
                    select * 
                    from employees;
                end
                ");

            migrationBuilder.Sql(@"
                create procedure GetEmployee @id int as
                begin
                    select * 
                    from employees
                    where id = @id;
                end
                ");

            migrationBuilder.Sql(@"
                create procedure AddEmployee @name nvarchar(50), @title nvarchar(50), @companyid int as
                begin
                    begin transaction
                    begin try
                        insert into employees (name, title, companyid) 
                        values (@name, @title, @companyid);
                        commit transaction
                    end try
                    begin catch
                        rollback transaction
                    end catch
                    select *
                    from employees
                    where id = (select cast(scope_identity() as int));
                end
                ");

            migrationBuilder.Sql(@"
                create procedure UpdateEmployee @id int, @name nvarchar(50), @title nvarchar(50), @companyid int as
                begin
                    begin transaction
                    begin try
                        update employees
                        set name = @name, title = @title, companyid = @companyid
                        where id = @id;
                        commit transaction
                    end try
                    begin catch
                        rollback transaction
                    end catch
                    select *
                    from employees
                    where id = @id;
                end
                ");

            migrationBuilder.Sql(@"
                create procedure RemoveEmployee @id int as
                begin
                    begin transaction
                    begin try
                        delete from employees
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
