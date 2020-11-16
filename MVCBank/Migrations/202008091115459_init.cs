namespace MVCBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        AccountType = c.Int(),
                        OpeningBalance = c.Decimal(nullable: false, storeType: "money"),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false, maxLength: 50),
                        BranchAddress = c.String(nullable: false),
                        BranchPhone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 80),
                        Designations = c.Int(),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                        JoiningDate = c.DateTime(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Deposit = c.Decimal(nullable: false, storeType: "money"),
                        Withdraw = c.Decimal(nullable: false, storeType: "money"),
                        TransactionDate = c.DateTime(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Designations = c.Int(),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                        JoiningDate = c.DateTime(nullable: false),
                        BranchId = c.Int(nullable: false),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Accounts", "BranchId", "dbo.Branches");
            DropIndex("dbo.Transactions", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Accounts", new[] { "BranchId" });
            DropIndex("dbo.Accounts", new[] { "CustomerId" });
            DropTable("dbo.UserViewModels");
            DropTable("dbo.Users");
            DropTable("dbo.EmployeeViewModels");
            DropTable("dbo.Customers");
            DropTable("dbo.Transactions");
            DropTable("dbo.Employees");
            DropTable("dbo.Branches");
            DropTable("dbo.Accounts");
        }
    }
}
