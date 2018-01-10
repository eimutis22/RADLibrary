namespace RADLibrary.Migrations.LibraryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ISBN = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Loan",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        LoanDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        DateJoined = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loan", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Loan", "BookID", "dbo.Book");
            DropIndex("dbo.Loan", new[] { "BookID" });
            DropIndex("dbo.Loan", new[] { "MemberID" });
            DropTable("dbo.Member");
            DropTable("dbo.Loan");
            DropTable("dbo.Book");
        }
    }
}
