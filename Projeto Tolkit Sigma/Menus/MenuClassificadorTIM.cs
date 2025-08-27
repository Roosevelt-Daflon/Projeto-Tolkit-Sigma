using Projeto_Tolkit_Sigma.Servicos;
using Projeto_Tolkit_Sigma.Dominio.Modelos;  

namespace Projeto_Tolkit_Sigma.Menus;

public class MenuClassificadorTIM : BaseMenu
{
    private readonly ServicoJson _servicoJson = new();
    private readonly ServicoMenu _servicoMenu;
    private int acertos = 0, erros = 0;

    public override string Titulo => "Classificador T/I/N por JSON";

    public MenuClassificadorTIM(ServicoMenu servicoMenu) : base(servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }

    public override void MostarOpcoes()
    {
        string caminho;
        List<ItemProblema>? problemas = null;
        do
        {
            Console.Write("\nDigite o caminho do arquivo JSON: ");
            caminho = Console.ReadLine()?.Trim() ?? "";
            problemas = _servicoJson.CarregarProblemas(caminho);
            if (problemas == null)
                Console.WriteLine("Arquivo não encontrado ou inválido. Tente novamente.");
        } while (problemas == null);

        acertos = 0; erros = 0;
        foreach (var problema in problemas)
        {
            Console.WriteLine($"\n{problema.Descricao}");
            Console.Write("Classifique (T/I/N): ");
            var resposta = Console.ReadLine()?.Trim().ToUpper();

            if (resposta == problema.ClassificacaoCorreta)
                acertos++;
            else
                erros++;
        }

        Console.WriteLine($"\nResumo: Acertos: {acertos}, Erros: {erros}");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        _servicoMenu.AlterarMenu(new MenuPrincipal(_servicoMenu));
    }
}