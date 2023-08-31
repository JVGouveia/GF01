using System;

namespace Program.Model
{

    public class Produto
    {
        private static int proximoId = 1;
        private int id;
        private string _nome;
        private string _descricao;
        private float _preco;
        private Categoria _categoria;

        public int Id
        {
            get { return id; }
        }

        public Produto(string nome, string descricao, float preco, Categoria categoria)
        {
            id = proximoId++;
            _nome = nome;
            _descricao = descricao;
            _preco = preco;
            _categoria = categoria;
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value.Length > 0)
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

        public float Preco
        {
            get { return _preco; }
            set
            {
                if (Preco >= 0.0f)
                {
                    _preco = value;
                }
                else
                {
                    throw new ArgumentException("Preço não pode ser negativo.");
                }
            }
        }

        public Categoria Categoria
        {
            get { return _categoria; } 
            set
            {
                if (value != null)
                {
                    _categoria = value;
                }
                else
                {
                    throw new ArgumentNullException("Categoria não pode ser nula.");
                }
            }
        }
    }
}
