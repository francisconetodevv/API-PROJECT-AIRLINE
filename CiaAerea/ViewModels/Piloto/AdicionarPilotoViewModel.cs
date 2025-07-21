namespace CIAAerea.ViewModels.Piloto;

public class AdicionarPiloViewModel
{
    public AdicionarPiloViewModel(string nome, string matricula)
    {
        Nome = nome;
        Matricula = matricula;
    }

    public string Nome { get; set; }
    public string Matricula { get; set; }


}