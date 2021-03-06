﻿using apiblog.Entities;

namespace apiblog.Config
{
    public class EnderecoMapping : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Endereco>
    {

        public EnderecoMapping()
        {
            ToTable("endereco", "dbo");
            HasKey(p => p.IdEndereco);
            Property(p => p.IdEndereco).HasColumnName("idendereco");
            Property(p => p.Rua).HasColumnName("rua");
            HasRequired(p => p.Pessoa).WithMany(c => c.Enderecos).Map(p => p.MapKey("idpessoa"));
        }

    }
}