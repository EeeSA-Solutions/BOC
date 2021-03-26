namespace BOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Phonenumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Phonenumber", c => c.String(nullable: false));
        }
    }
}
