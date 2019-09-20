namespace ControleFinanceiroAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renomeando_Tabelas : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Alunoes", newName: "Alunos");
            RenameTable(name: "dbo.Cicloes", newName: "Ciclos");
            RenameTable(name: "dbo.Mes", newName: "Meses");
            RenameTable(name: "dbo.Planoes", newName: "Planos");
            RenameTable(name: "dbo.Professors", newName: "Professores");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Professores", newName: "Professors");
            RenameTable(name: "dbo.Planos", newName: "Planoes");
            RenameTable(name: "dbo.Meses", newName: "Mes");
            RenameTable(name: "dbo.Ciclos", newName: "Cicloes");
            RenameTable(name: "dbo.Alunos", newName: "Alunoes");
        }
    }
}
