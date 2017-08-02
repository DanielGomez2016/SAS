namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNivelEducativo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NivelEducativo",
                c => new
                    {
                        NivelEducativoId = c.Int(nullable: false, identity: true),
                        Nivel = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.NivelEducativoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NivelEducativo");
        }
    }
}
