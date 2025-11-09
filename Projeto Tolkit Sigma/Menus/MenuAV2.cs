using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuAV2 : BaseMenu
{
    private readonly ServicoMenu _servicoMenu;
    public override string Titulo => "AV2 — Decidibilidade, Reconhecimento e Modelos";

    public MenuAV2(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
        Opcoes.Clear();
        Opcoes.Add(new MenuClassificadorPI(_servicoMenu));
        Opcoes.Add(new MenuDecisoresAB(_servicoMenu));
        Opcoes.Add(new MenuReconhecedorNaoTerminante(_servicoMenu));
        Opcoes.Add(new MenuDetectorIngenuoLoop(_servicoMenu));
        Opcoes.Add(new MenuSimuladorAFD(_servicoMenu));
    }

    public override void MostarOpcoes()
    {
        Console.WriteLine("1 - Classificador P/I por JSON embutido");
        Console.WriteLine("2 - Decisores Σ={a,b}: L_fim_b e L_mult3_b");
        Console.WriteLine("3 - Reconhecedor que pode não terminar");
        Console.WriteLine("4 - Detector ingênuo de loop + reflexão");
        Console.WriteLine("5 - Simulador de AFD (caso fixo)");
        Console.Write("Escolha uma opção: ");
        string? opcaoInput = Console.ReadLine();
        if (!int.TryParse(opcaoInput, out int opcao) || opcao < 1 || opcao > Opcoes.Count)
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ReadKey();
            _servicoMenu.AlterarMenu(this);
            return;
        }
        _servicoMenu.AlterarMenu(Opcoes[opcao - 1]);
    }
}
