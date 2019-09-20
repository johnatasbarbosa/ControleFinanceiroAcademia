namespace ControleFinanceiroAcademia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        DiaPagamento = c.Int(nullable: false),
                        Peso = c.Single(nullable: false),
                        Braco = c.Single(nullable: false),
                        Abs = c.Single(nullable: false),
                        Gluteo = c.Single(nullable: false),
                        Perna = c.Single(nullable: false),
                        IMC = c.Single(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cicloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataFinal = c.DateTime(),
                        Aluno_Id = c.Int(),
                        Plano_Id = c.Int(),
                        Professor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alunoes", t => t.Aluno_Id)
                .ForeignKey("dbo.Planoes", t => t.Plano_Id)
                .ForeignKey("dbo.Professors", t => t.Professor_Id)
                .Index(t => t.Aluno_Id)
                .Index(t => t.Plano_Id)
                .Index(t => t.Professor_Id);
            
            CreateTable(
                "dbo.Mes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Pago = c.Boolean(nullable: false),
                        DiaPagamento = c.DateTime(),
                        Ciclo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cicloes", t => t.Ciclo_Id)
                .Index(t => t.Ciclo_Id);
            
            CreateTable(
                "dbo.Planoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeDias = c.Int(nullable: false),
                        Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cicloes", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.Cicloes", "Plano_Id", "dbo.Planoes");
            DropForeignKey("dbo.Mes", "Ciclo_Id", "dbo.Cicloes");
            DropForeignKey("dbo.Cicloes", "Aluno_Id", "dbo.Alunoes");
            DropIndex("dbo.Mes", new[] { "Ciclo_Id" });
            DropIndex("dbo.Cicloes", new[] { "Professor_Id" });
            DropIndex("dbo.Cicloes", new[] { "Plano_Id" });
            DropIndex("dbo.Cicloes", new[] { "Aluno_Id" });
            DropTable("dbo.Professors");
            DropTable("dbo.Planoes");
            DropTable("dbo.Mes");
            DropTable("dbo.Cicloes");
            DropTable("dbo.Alunoes");
        }
    }
}
