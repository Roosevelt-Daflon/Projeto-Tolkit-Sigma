using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuReconhecedorNaoTerminante : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo => "Reconhecedor: pode não terminar (limite de passos)";

    public MenuReconhecedorNaoTerminante(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        Console.WriteLine("Linguagem alvo: L_termina_a = { w | último símbolo é 'a' }.");
        Console.WriteLine("Reconhece aceitando quando termina com 'a'; caso contrário pode não terminar.");

        Console.Write("Digite w (Σ={a,b}): ");
        string w = Console.ReadLine() ?? string.Empty;
        if (!AlfabetoValido(w))
        {
            Console.WriteLine("Alfabeto inválido. Use apenas 'a' ou 'b'.");
            Pausa();
            return;
        }

        Console.Write("Limite de passos (padrão 1000): ");
        string? limiteStr = Console.ReadLine();
        int limite = 1000;
        if (!string.IsNullOrWhiteSpace(limiteStr) && !int.TryParse(limiteStr, out limite))
        {
            Console.WriteLine("Valor inválido. Usando 1000.");
            limite = 1000;
        }
        if (limite <= 0) limite = 1000;

        int passos = 0;
        // Tenta reconhecer: se termina com 'a', aceita rapidamente
        if (!string.IsNullOrEmpty(w) && w[^1] == 'a')
        {
            Console.WriteLine("ACEITA (reconhecida)");
            Pausa();
            return;
        }

        // Caso contrário, simula uma execução que pode não terminar
        Console.WriteLine("Executando reconhecimento (pode não terminar)...");
        while (true)
        {
            passos++;
            if (passos >= limite)
            {
                Console.WriteLine($"Interrompido por limite de passos: {limite}.");
                Console.WriteLine("Execução cancelada pelo usuário/sistema.");
                break;
            }
        }
        Pausa();
    }

    private static bool AlfabetoValido(string? w)
    {
        if (w is null) return false;
        foreach (char c in w)
            if (c != 'a' && c != 'b') return false;
        return true;
    }

    private void Pausa()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuAV2(_servicoMenu));
    }
}
