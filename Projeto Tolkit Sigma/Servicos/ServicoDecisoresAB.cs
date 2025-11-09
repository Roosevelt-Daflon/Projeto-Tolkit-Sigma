namespace Projeto_Tolkit_Sigma.Servicos;

public class ServicoDecisoresAB
{
    private static readonly char[] Alfabeto = { 'a', 'b' };

    public bool AlfabetoValido(string? w)
    {
        if (w is null) return false;
        foreach (char c in w)
            if (!Alfabeto.Contains(c))
                return false;
        return true;
    }

    // L_fim_b = { w | w termina com 'b' }
    public bool DecideFimComB(string w)
    {
        if (string.IsNullOrEmpty(w)) return false; // cadeia vazia não termina com 'b'
        return w[^1] == 'b';
    }

    // L_mult3_b = { w | quantidade de 'b' é múltiplo de 3 }
    public bool DecideMult3DeB(string w)
    {
        int qtdB = 0;
        foreach (char c in w)
            if (c == 'b') qtdB++;
        return qtdB % 3 == 0;
    }
}
