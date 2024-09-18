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

        // Notifica o GameManager que um território foi conquistado.
        GameManager.instance.ConquistarTerritorio();
    }

    // Método público que retorna o estado de conquista do bloco (true ou false).
    public bool PegarConquistado()
    {
        return conquistado; // Retorna true se o bloco foi conquistado, false caso contrário.
    }

    // Método público que retorna o número do jogador que conquistou o bloco.
    public int PegarJogadorDono()
    {
        return jogadorDono; // Retorna 1 se o jogador 1 conquistou o bloco, ou 2 se o jogador 2 conquistou.
    }

    // Método privado que atualiza a cor do bloco, normalmente chamado quando o bloco é conquistado.
    private void AtualizarCor(Color novaCor)
    {
        spriteRenderer.color = novaCor; // Muda a cor do SpriteRenderer para a cor especificada.
    }
}

