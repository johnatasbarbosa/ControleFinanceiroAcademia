﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcademia
{
    class ControleAcademiaContexto : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Mes> Meses { get; set; }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Plano> Planos { get; set; }

        public DbSet<Ciclo> Ciclos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
