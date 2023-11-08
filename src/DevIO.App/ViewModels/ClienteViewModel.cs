using Microsoft.VisualBasic;
using System.ComponentModel;
        using System.ComponentModel.DataAnnotations;

        namespace DevIO.App.ViewModels
        {
            public class ClienteViewModel
            {
                [Key]
                public Guid Id { get; set; }

                [DisplayName("Nome/Razão Social")]
                [Required(ErrorMessage = "O campo {0} é obrigatório")]
                [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
                public string Nome { get; set; }



                [DisplayName("CPF/CNPJ")]
                [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
                public string Documento { get; set; }

                [StringLength(18, ErrorMessage = "O campo {0} precisa ter entre 11 e 14 caracteres", MinimumLength = 10)]
                [DisplayName("CPF/CNPJ")]
                [Required(ErrorMessage = "O campo {0} é obrigatório")]
                public string DocumentoComFormatacao { get; set; }


                [DisplayName("E-mail")]
                [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 7)]
                [Required(ErrorMessage = "O campo {0} é obrigatório")]
                [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "As informações inseridas não correspondem a um endereço de e-mail válido.")]
                public string Mail { get; set; }


                public string Telefone { get; set; }

                [StringLength(14, ErrorMessage = "O campo {0} precisa ter 11 caracteres", MinimumLength = 11)]
                [DisplayName("Telefone")]
                [Required(ErrorMessage = "O campo {0} é obrigatório")]
                public string TelefoneComFormatacao { get; set; }



                [ScaffoldColumn(false)]
                public DateTime DataCadastro { get; set; }



                [DisplayName("Selecione o tipo de Pessoa")]
                public int TipoCliente { get; set; }


                [DisplayName("Inscrição Estadual para Pessoa Física:")]
                public int PessoaFisicaInscricao { get; set; }


                [DisplayName("Inscrição Estadual")]
                public string? InscricaoEstadual { get; set; }


                [StringLength(15, ErrorMessage = "O campo {0} precisa ter 12 caracteres", MinimumLength = 15)]
                [DisplayName("Inscrição Estadual")]
                public string? InscricaoEstadualComFormatacao { get; set; }


                public bool Isento { get; set; }

                [DisplayName("Selecione o gênero do Cliente")]
                public int? Genero { get; set; }

                [Display(Name = "Data de Nascimento")]
                public DateTime? DataNascimento { get; set; }



                [DisplayName("Bloqueio o acesso do Cliente na sua Loja")]
                public bool Bloqueado { get; set; }

                [DisplayName("Senha")]
                [Required(ErrorMessage = "O campo {0} é obrigatório")]
                [StringLength(15, MinimumLength = 8, ErrorMessage = "A {0} deve ter entre 8 e 15 caracteres")]
                public string Senha { get; set; }


                [DisplayName("Confirmação de Senha")]
                [Required(ErrorMessage = "O campo {0} é obrigatório")]
                [Compare("Senha", ErrorMessage = "As senhas não conferem")]
                [DataType(DataType.Password)]
                [Display(Name = "Confirmação de Senha")]
                public string ConfirmacaoSenha { get; set; }

            }
        }