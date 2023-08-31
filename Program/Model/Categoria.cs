using System;

namespace Program.Model
{
    public class Categoria
    {
        private static int proximoId = 1;
        private int id;
        private string _nome;
        private string _descricao;

        public Categoria(string nome, string descricao)
        {
            id = proximoId++;
            if (!string.IsNullOrEmpty(nome))
                    _nome = nome;
                else
                    throw new ArgumentException("Nome não pode ser nulo.");
            _descricao = descricao;

        }

        //getters and setters

        public int Id
        {
            get { return id; }
        }
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nome = value;
                }
                else
                {
                    throw new ArgumentException("Nome não pode ser nulo.");
                }
            }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}