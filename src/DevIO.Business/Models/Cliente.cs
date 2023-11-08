    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    namespace DevIO.Business.Models
    {
        public class Cliente : Entity
        {
            public string Nome { get; set; }
            public string Documento { get; set; }
            public string Mail { get; set; }
            public string Telefone { get; set; }
            public DateTime DataCadastro { get; set; }
            public TipoCliente TipoCliente { get; set; }
            public string? InscricaoEstadual { get; set; }
            public bool? Isento { get; set; }
            public Genero? Genero { get; set; }
            public DateTime? DataNascimento { get; set; }
            public bool Bloqueado { get; set; }
            public string Senha { get; set; }

               }
    }