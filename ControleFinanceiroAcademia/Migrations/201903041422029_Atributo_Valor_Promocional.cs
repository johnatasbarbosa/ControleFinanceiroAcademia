namespace ControleFinanceiroAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atributo_Valor_Promocional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cicloes", "ValorPromocional", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cicloes", "ValorPromocional");
        }
    }
}
