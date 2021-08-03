namespace SamuelNFCApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientsPersonal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        NameIsHidden = c.Boolean(nullable: false),
                        Email = c.String(),
                        EmailIsHidden = c.Boolean(nullable: false),
                        City = c.Int(),
                        CityIsHidden = c.Boolean(nullable: false),
                        District = c.Int(),
                        DistrictIsHidden = c.Boolean(nullable: false),
                        Title = c.String(),
                        TitleIsHidden = c.Boolean(nullable: false),
                        Company = c.String(),
                        CompanyIsHidden = c.Boolean(nullable: false),
                        Address = c.String(),
                        AddressIsHidden = c.Boolean(nullable: false),
                        Phone = c.String(),
                        PhoneIsHidden = c.Boolean(nullable: false),
                        DescribeYourself = c.String(),
                        DescribeYourselfIsHidden = c.Boolean(nullable: false),
                        YoutubeEmbededURL = c.String(),
                        YoutubeEmbededURLIsHidden = c.Boolean(nullable: false),
                        Link = c.String(),
                        SerialNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientsSocial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientPersonalId = c.Int(nullable: false),
                        FacebookUrl = c.String(),
                        FacebookUrlFlyOn = c.Boolean(nullable: false),
                        TwitterUrl = c.String(),
                        TwitterUrlFlyOn = c.Boolean(nullable: false),
                        TikTokUrl = c.String(),
                        TikTokUrlFlyOn = c.Boolean(nullable: false),
                        SlapUrl = c.String(),
                        SlapUrlFlyOn = c.Boolean(nullable: false),
                        WhatsAppUrl = c.String(),
                        WhatsAppUrlFlyOn = c.Boolean(nullable: false),
                        YouTubeUrl = c.String(),
                        YouTubeUrlFlyOn = c.Boolean(nullable: false),
                        InstagramUrl = c.String(),
                        InstagramUrlFlyOn = c.Boolean(nullable: false),
                        LinkedInUrl = c.String(),
                        LinkedInUrlFlyOn = c.Boolean(nullable: false),
                        GoogleMapsUrl = c.String(),
                        GoogleMapsUrlFlyOn = c.Boolean(nullable: false),
                        TelegramUrl = c.String(),
                        TelegramUrlFLyOn = c.Boolean(nullable: false),
                        ClubhoseUrl = c.String(),
                        ClubhouseUrlFlyOn = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientsPersonal", t => t.ClientPersonalId, cascadeDelete: true)
                .Index(t => t.ClientPersonalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientsSocial", "ClientPersonalId", "dbo.ClientsPersonal");
            DropIndex("dbo.ClientsSocial", new[] { "ClientPersonalId" });
            DropTable("dbo.ClientsSocial");
            DropTable("dbo.ClientsPersonal");
        }
    }
}
