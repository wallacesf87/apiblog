﻿namespace apiblog.Entities
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}