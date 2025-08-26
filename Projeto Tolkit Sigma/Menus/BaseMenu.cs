using Projeto_Tolkit_Sigma.Servicos;

namespace Projeto_Tolkit_Sigma.Menus;

public abstract class BaseMenu
{
    private ServicoMenu _servicoMenu;
    protected List<BaseMenu> Opcoes = new List<BaseMenu>();
    
    public BaseMenu(ServicoMenu servicoMenu)
    {
        _servicoMenu = servicoMenu;
    }
    
    public virtual string Titulo { get;  }

    public virtual void MostarOpcoes()
    {
    }
}