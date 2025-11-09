using System.Collections.Generic;
using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuDetectorIngenuoLoop : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo => "Detector ingênuo de loop + reflexão";

    public MenuDetectorIngenuoLoop(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        Console.WriteLine("Processo: x_{t+1} = (x_t^2 + 1) mod m (determinístico).");
        Console.Write("Informe m (>1): ");
        string? mStr = Console.ReadLine();
        if (!int.TryParse(mStr, out int m) || m <= 1)
        {
            Console.WriteLine("m inválido.");
            Pausa();
            return;
        }

        Console.Write("Informe x0 (0..m-1): ");
        string? x0Str = Console.ReadLine();
        if (!int.TryParse(x0Str, out int x) || x < 0 || x >= m)
        {
            Console.WriteLine("x0 inválido.");
            Pausa();
            return;
        }

        Console.Write("Limite de passos (padrão 1000): ");
        string? limStr = Console.ReadLine();
        int limite = 1000;
        if (!string.IsNullOrWhiteSpace(limStr) && !int.TryParse(limStr, out limite))
        {
            Console.WriteLine("Valor inválido. Usando 1000.");
            limite = 1000;
        }
        if (limite <= 0) limite = 1000;

        HashSet<int> visitados = new HashSet<int>();
        int passo = 0;
        bool repetiu = false;
        Console.WriteLine("\nEstados:");
        while (passo < limite)
        {
            if (visitados.Contains(x))
            {
                Console.WriteLine($"Passo {passo}: estado {x} repetido. POSSÍVEL LAÇO.");
                repetiu = true;
                break;
            }
            visitados.Add(x);
            Console.WriteLine($"Passo {passo}: {x}");
            int proximo = (x * x + 1) % m;
            x = proximo;
            passo++;
        }

        if (!repetiu && passo >= limite)
        {
            Console.WriteLine("\nInterrompido por limite de passos.");
        }

        Console.WriteLine("\nReflexão:");
        Console.WriteLine("- Heurística: repetir estado em processo determinístico finito indica ciclo.");
        Console.WriteLine("- Falsos positivos: raros aqui (sem colisão de hash).\n- Falsos negativos: podem ocorrer se o limite parar antes da repetição.");
        Pausa();
    }

    private void Pausa()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuAV2(_servicoMenu));
    }
}
