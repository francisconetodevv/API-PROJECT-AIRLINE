namespace CIAAerea.ViewModels.Piloto;

public class AtualizarPilotoViewModel
{
    public AtualizarPilotoViewModel(int id, string nome, string matricula)
    {
        Nome = nome;
        Matricula = matricula;
        Id = id;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
}