using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuDecisoresAB : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    private readonly ServicoDecisoresAB _servico = new();
    public override string Titulo => "Decisores Σ={a,b}: L_fim_b e L_mult3_b";

    public MenuDecisoresAB(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        Console.WriteLine("1 - L_fim_b = termina com 'b'");
        Console.WriteLine("2 - L_mult3_b = #b múltiplo de 3");
        Console.Write("Escolha (1/2): ");
        string? op = Console.ReadLine();
        if (op is not ("1" or "2"))
        {
            Console.WriteLine("Opção inválida.");
            Pausa();
            return;
        }

        Console.Write("Digite w (apenas 'a' e 'b'): ");
        string w = Console.ReadLine() ?? string.Empty;
        if (!_servico.AlfabetoValido(w))
        {
            Console.WriteLine("Alfabeto inválido. Use apenas 'a' ou 'b'.");
            Pausa();
            return;
        }

        bool aceita = op == "1" ? _servico.DecideFimComB(w) : _servico.DecideMult3DeB(w);
        Console.WriteLine($"\n{(aceita ? "SIM" : "NÃO")}");
        Pausa();
    }

    private void Pausa()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuAV2(_servicoMenu));
    }
}
