﻿using apiblog.Entities;

namespace apiblog.Config
{
    public class EmailMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Email>
    {

        public EmailMapping()
        {
            ToTable("email", "dbo");
            HasKey(p => p.IdEmail);
            Property(p => p.IdEmail).HasColumnName("idemail");
            Property(p => p.Endereco).HasColumnName("endereco");
            HasRequired(p => p.Pessoa).WithMany(c => c.Emails).Map(p => p.MapKey("idpessoa"));
        }

    }
}