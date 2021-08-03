namespace SamuelNFCApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertcitytostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientsPersonal", "City", c => c.String());
            AlterColumn("dbo.ClientsPersonal", "District", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientsPersonal", "District", c => c.Int());
            AlterColumn("dbo.ClientsPersonal", "City", c => c.Int());
        }
    }
}
