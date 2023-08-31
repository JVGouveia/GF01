using System;

namespace Program.Model
{
    public class Cliente
    {
        private static int proximoId = 1;
        private int id;
        private string? nome;
        private string? sobrenome;
        private string? endereco;
        private string? numeroTelefone;

        public int Id
        {
            get { return id; }
        }

        public string? Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string? Sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }

        public string? Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string? NumeroTelefone
        {
            get { return numeroTelefone; }
            set { numeroTelefone = value; }
        }

        public Cliente(string nome, string sobrenome, string endereco, string numeroTelefone)
        {
            id = proximoId++;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            NumeroTelefone = numeroTelefone;
        }

        public void ErroCasoNull()
        {
            if (ObjetoEhValido())
            {
                Console.WriteLine("Cadastro Efetuado!");
            }
            else
            {
                Console.WriteLine("Dados inválidos");
            }
        }

        public bool ObjetoEhValido()
        {
            return (Nome != null && Sobrenome != null && Endereco != null && NumeroTelefone != null);
        }
    }
}