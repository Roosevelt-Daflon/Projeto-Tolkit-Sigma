using System.Text.Json;
using Projeto_Tolkit_Sigma.Dominio.Modelos;

namespace Projeto_Tolkit_Sigma.Servicos;

public class ServicoJson
{
    public List<ItemProblema>? CarregarProblemas(string caminho)
    {
        if (!File.Exists(caminho))
            return null;
        try
        {
            var json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<ItemProblema>>(json);
        }
        catch
        {
            return null;
        }
    }
}