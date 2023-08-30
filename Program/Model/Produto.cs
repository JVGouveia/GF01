using System.Globalization;

namespace Program;

public class Produto
{
    private string _nome;
    private string _descricao;
    private float _preco;
    private Categoria _categoria;

    public Produto(string nome, string descricao, float preco, Categoria categoria)
    {
        _nome = nome;
        _descricao = descricao;
        _preco = preco;
        _categoria = categoria;

    }
    //getters and setters 

    public string Nome 
    { 
        get{return _nome; } 
        set 
        {
            if(value.Length > 0)
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
        get{return _nome;}
        set{_descricao = value;}
    }

    public float Preco
    {
        get{return _preco;}
        set
        {
            if(Preco >= 0.0f)
            {
                _preco = value;
            }
            else
            {
                throw new ArgumentException("Preço não pode ser negativo.");
            }
        }
    }
    //Aqui não precisa de validação pois Categoria já é validada.
    public Categoria Categoria
    {
        get{return _categoria;}
        set{_categoria = value;}
    }
    


}
