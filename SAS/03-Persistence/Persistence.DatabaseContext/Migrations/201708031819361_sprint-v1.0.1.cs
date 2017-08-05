namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprintv101 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DepartamentoId", "dbo.Departamento");
            DropIndex("dbo.AspNetUsers", new[] { "DepartamentoId" });
            DropColumn("dbo.AspNetUsers", "DepartamentoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Departamento_DepartamentoId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Departamento_DepartamentoId");
            AddForeignKey("dbo.AspNetUsers", "Departamento_DepartamentoId", "dbo.Departamento", "DepartamentoId");
        }
    }
}
