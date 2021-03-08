using Microsoft.EntityFrameworkCore.Migrations;

namespace GameFacto.Data.Migrations
{
    public partial class productSpAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var spAppLog = @"CREATE PROCEDURE SPProduct
                            @RecordUserId int,
                            @UpdateUserId int,
                            @RecordDate datetime,
                            @UpdateDate datetime,
                            @Name nvarchar(MAX),
                            @Description nvarchar(MAX),
                            @Imageurl nvarchar(MAX),
                            @Price real,
                            @CategoryId int,
                            @IsDeleted bit
                        AS
                        BEGIN
                             declare @ProductId bigint
                            Insert into Product(
                                   [RecordUserId]
                                   ,[UpdateUserId]
                                   ,[RecordDate]
                                   ,[UpdateDate]
                                   ,[Name]
                                   ,[Description]
                                   ,[Imageurl]
                                   ,[Price]
                                   ,[CategoryId]
                                   ,[IsDeleted]
                                   )
                         Values (@RecordUserId,  @UpdateUserId,@RecordDate,@UpdateDate,@Name, @Description,@ImageUrl,@Price,@CategoryId,@IsDeleted)
                        set @ProductId = SCOPE_IDENTITY();
                        select @ProductId
                        END
                        GO";
            migrationBuilder.Sql(spAppLog);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
