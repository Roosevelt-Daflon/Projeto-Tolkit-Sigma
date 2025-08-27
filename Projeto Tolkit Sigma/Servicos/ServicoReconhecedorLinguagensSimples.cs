namespace Projeto_Tolkit_Sigma.Servicos;

public class ServicoReconhecedorLinguagensSimples
{
    private static readonly char[] Alfabeto = { 'a', 'b' };

    public bool AlfabetoValido(string? w)
    {
        if (w is null) return false;
        return w.All(c => Alfabeto.Contains(c));
    }


    public bool PertenceLParA(string w)
    {
        var qtdA = w.Count(c => c == 'a');
        return qtdA % 2 == 0;
    }


    public bool PertenceAbEstrela(string w)
    {
        if (string.IsNullOrEmpty(w)) return false;
        if (w[0] != 'a') return false;
        for (int i = 1; i < w.Length; i++)
            if (w[i] != 'b') return false;
        return true;
    }
}