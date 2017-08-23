namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv136 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.College", "EducationLevel_Id", "dbo.EducationLevel");
            DropIndex("dbo.College", new[] { "EducationLevel_Id" });
            DropColumn("dbo.College", "LevelId");
            RenameColumn(table: "dbo.College", name: "EducationLevel_Id", newName: "LevelId");
            AlterColumn("dbo.College", "LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.College", "LevelId");
            AddForeignKey("dbo.College", "LevelId", "dbo.EducationLevel", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.College", "LevelId", "dbo.EducationLevel");
            DropIndex("dbo.College", new[] { "LevelId" });
            AlterColumn("dbo.College", "LevelId", c => c.Int());
            RenameColumn(table: "dbo.College", name: "LevelId", newName: "EducationLevel_Id");
            AddColumn("dbo.College", "LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.College", "EducationLevel_Id");
            AddForeignKey("dbo.College", "EducationLevel_Id", "dbo.EducationLevel", "Id");
        }
    }
}
