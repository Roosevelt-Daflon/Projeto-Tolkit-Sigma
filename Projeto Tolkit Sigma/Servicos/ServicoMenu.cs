using Projeto_Tolkit_Sigma.Menus;

namespace Projeto_Tolkit_Sigma.Servicos;

public class ServicoMenu
{
    private BaseMenu _baseMenu = null!;
    
    public void AlterarMenu(BaseMenu baseMenu)
    {
        _baseMenu = baseMenu;
        MostarTela();
    }
    
    
    private void MostarTela()
    {
        Console.Clear();
        Console.WriteLine(_baseMenu.Titulo);
        Console.WriteLine("=".PadRight(_baseMenu.Titulo.Length, '='));
        _baseMenu.MostarOpcoes();
    }
}