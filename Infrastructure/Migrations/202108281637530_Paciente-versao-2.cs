namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pacienteversao2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacientes", "Sobrenome", c => c.String());
            AddColumn("dbo.Pacientes", "Email", c => c.String());
            AddColumn("dbo.Pacientes", "Cidade", c => c.String());
            AddColumn("dbo.Pacientes", "Telefone", c => c.String());
            AddColumn("dbo.Pacientes", "Sexo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pacientes", "Peso", c => c.Single(nullable: false));
            AddColumn("dbo.Pacientes", "Altura", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacientes", "Altura");
            DropColumn("dbo.Pacientes", "Peso");
            DropColumn("dbo.Pacientes", "Sexo");
            DropColumn("dbo.Pacientes", "Telefone");
            DropColumn("dbo.Pacientes", "Cidade");
            DropColumn("dbo.Pacientes", "Email");
            DropColumn("dbo.Pacientes", "Sobrenome");
        }
    }
}
