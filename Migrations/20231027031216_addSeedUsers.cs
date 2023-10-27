using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS0058_Entity_Framework_Razor.Migrations
{
    public partial class addSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            for (var i = 0; i < 150; i++)
            {
                migrationBuilder.InsertData(
                    "Users",
                    columns: new[] {
                        "Id"
      ,"UserName"
    //   ,"NormalizedUserName"
      ,"Email"
    //   ,"NormalizedEmail"
      ,"EmailConfirmed"
    //   ,"PasswordHash"
      ,"SecurityStamp"
    //   ,"ConcurrencyStamp"
    //   ,"PhoneNumber"
      ,"PhoneNumberConfirmed"
      ,"TwoFactorEnabled"
    //   ,"LockoutEnd"
      ,"LockoutEnabled"
      ,"AccessFailedCount"
    //   ,"BirthDate"
      ,"HomeAddress"
                    },
                    values: new object[] {
                        Guid.NewGuid().ToString(),                  // "Id"
                        "User-"+ i.ToString("D3"),                  //   ,"UserName"
                                                                    //   ,"NormalizedUserName"
                        $"email{i.ToString("D3")}@example.com",     //   ,"Email"
                                                                    //   ,"NormalizedEmail"
                        true,                                       //   ,"EmailConfirmed"
                                                                    //   ,"PasswordHash"
                        Guid.NewGuid().ToString(),                  //   ,"SecurityStamp"
                                                                    //   ,"ConcurrencyStamp"
                                                                    //   ,"PhoneNumber"
                        false,                                      //   ,"PhoneNumberConfirmed"
                        false,                                      //   ,"TwoFactorEnabled"
                                                                    //   ,"LockoutEnd"
                        false,                                      //   ,"LockoutEnabled"
                        0,                                          //   ,"AccessFailedCount"
                                                                    //   ,"BirthDate"
                        "...@#%..."                                 //   ,"HomeAddress"
                    }
                );
            }


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
