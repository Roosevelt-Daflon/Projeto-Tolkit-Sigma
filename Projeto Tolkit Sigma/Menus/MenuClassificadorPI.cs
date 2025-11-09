using System.Text.Json;
using Projeto_Tolkit_Sigma.Dominio.Modelos;
using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuClassificadorPI : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo => "Classificador P/I por JSON embutido";

    private const string JsonEmbutido = """
[
  { "Descricao": "Entrada: descrição de um problema de decisão.", "ClassificacaoCorreta": "P" },
  { "Descricao": "Entrada: 1011; Pergunta: é primo?", "ClassificacaoCorreta": "I" },
  { "Descricao": "Halt: decidir se um programa para.", "ClassificacaoCorreta": "P" },
  { "Descricao": "Programa X e entrada Y específicos.", "ClassificacaoCorreta": "I" }
]
""";

    public MenuClassificadorPI(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        List<ItemProblema>? itens;
        try
        {
            itens = JsonSerializer.Deserialize<List<ItemProblema>>(JsonEmbutido);
        }
        catch
        {
            Console.WriteLine("Erro ao carregar JSON embutido.");
            Console.ReadKey();
            _servicoMenu.AlterarMenu(new MenuAV2(_servicoMenu));
            return;
        }

        if (itens is null || itens.Count == 0)
        {
            Console.WriteLine("Lista vazia.");
            Console.ReadKey();
            _servicoMenu.AlterarMenu(new MenuAV2(_servicoMenu));
            return;
        }

        int acertos = 0;
        int erros = 0;
        foreach (ItemProblema item in itens)
        {
            Console.WriteLine($"\n{item.Descricao}");
            Console.Write("Classifique (P/I): ");
            string? resposta = Console.ReadLine()?.Trim().ToUpperInvariant();
            if (resposta is not ("P" or "I"))
            {
                Console.WriteLine("Entrada inválida. Use P ou I.");
                erros++;
                continue;
            }
            if (resposta == item.ClassificacaoCorreta)
                acertos++;
            else
                erros++;
        }

        Console.WriteLine($"\nResumo: Acertos: {acertos}, Erros: {erros}, Total: {acertos + erros}");
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuAV2(_servicoMenu));
    }
}
