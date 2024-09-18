using UnityEngine;
using static UnityEditor.Progress;

public class Bloco : MonoBehaviour
{
   
    private bool conquistado = false;

    
    private SpriteRenderer spriteRenderer;

    
    private int jogadorDono;

    void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

       
        AtualizarCor(Color.white);
    }

 
    public void AlterarConquista(bool jogador1, Color corDoJogador)
    {
        if (conquistado) return;

        
        conquistado = true;

       
        AtualizarCor(corDoJogador);

        
        jogadorDono = jogador1 ? 1 : 2;

        // Notifica o GameManager que um territ�rio foi conquistado.
        GameManager.instance.ConquistarTerritorio();
    }

    // M�todo p�blico que retorna o estado de conquista do bloco (true ou false).
    public bool PegarConquistado()
    {
        return conquistado; // Retorna true se o bloco foi conquistado, false caso contr�rio.
    }

    // M�todo p�blico que retorna o n�mero do jogador que conquistou o bloco.
    public int PegarJogadorDono()
    {
        return jogadorDono; // Retorna 1 se o jogador 1 conquistou o bloco, ou 2 se o jogador 2 conquistou.
    }

    // M�todo privado que atualiza a cor do bloco, normalmente chamado quando o bloco � conquistado.
    private void AtualizarCor(Color novaCor)
    {
        spriteRenderer.color = novaCor; // Muda a cor do SpriteRenderer para a cor especificada.
    }
}

