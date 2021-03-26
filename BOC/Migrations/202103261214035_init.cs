namespace BOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 20),
                        Lastname = c.String(nullable: false, maxLength: 20),
                        BirthDate = c.DateTime(nullable: false),
                        Phonenumber = c.String(),
                        Email = c.String(nullable: false),
                        ValidateEmail = c.String(),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
