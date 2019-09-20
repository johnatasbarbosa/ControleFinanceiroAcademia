namespace ControleFinanceiroAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atributo_Telefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alunoes", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alunoes", "Telefone");
        }
    }
}
