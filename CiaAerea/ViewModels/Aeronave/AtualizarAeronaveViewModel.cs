namespace CIAArea.ViewModels;


// Classe - POKO
public class AtualizarAeronaveViewModel
{
    public AtualizarAeronaveViewModel(int id, string fabricante, string modelo, string codigo)
    {
        Id = id;
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }

    public int Id { get; set; }
    public string Fabricante { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }

    
}