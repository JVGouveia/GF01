namespace Program;

public class Categoria
{
    private string _nome;
    private string _descricao;

    public Categoria(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
        
    }

    //getters and setters

    public string Nome
    {
        get {return _nome;}
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
        get {return _descricao;}
        set{_descricao = value;}
    }

}
