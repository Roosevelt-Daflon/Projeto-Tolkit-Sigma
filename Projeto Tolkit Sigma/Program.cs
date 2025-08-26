
using Projeto_Tolkit_Sigma.Menus;
using Projeto_Tolkit_Sigma.Servicos;

var menuService = new ServicoMenu();


menuService.AlterarMenu(new MenuPrincipal(menuService));