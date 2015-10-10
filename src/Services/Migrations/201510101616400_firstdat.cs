namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstdat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DownloadUrl = c.String(),
                        Slug = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        LowerDescriptionHeadline = c.String(),
                        LowerDescription = c.String(),
                        Mailchimp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lead",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeadStatus = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Skype = c.String(),
                        Phone = c.String(),
                        Company = c.String(),
                        Name = c.String(),
                        ProjectDeadline = c.String(),
                        ProjectStart = c.String(),
                        ProjectDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lead");
            DropTable("dbo.Case");
        }
    }
}
