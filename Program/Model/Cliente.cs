using System;

namespace Program.Model
{
    public class Cliente
{
    public int? Id { get; set; }
    private string? nome;
    private string? sobrenome;
    private string? endereco;
    private string? numerotelefone;

    public string? Nome { 
        get {return nome;}
        set {nome = value;}
    }
    public string? Sobrenome {
        get {return sobrenome;}
        set {sobrenome = value;}
    }
    public string? Endereco{
        get {return endereco;}
        set {endereco = value;}
    }
    public string? NumeroTelefone{
        get {return numerotelefone;}
        set {numerotelefone = value;}
    }
    
    public Cliente(int id, string nome, string sobrenome, string endereco, string numeroTelefone)
    {
        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
        Endereco = endereco;
        NumeroTelefone = numeroTelefone;
    }

    public void ErroCasoNull() {
        if (ObjetoEhValido()) {
            Console.WriteLine("Cadastro Efetuado!");
        } else {
            Console.WriteLine("Dados inválidos");
        }
    }

    public bool ObjetoEhValido() {
        return (Nome != null && Sobrenome != null && Endereco != null && NumeroTelefone != null);
    }
}
}