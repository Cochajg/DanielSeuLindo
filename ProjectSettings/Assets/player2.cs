using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerController : MonoBehaviour
{
   
    private const float VELOCIDADE_MOVIMENTO = 5f;

    
    [SerializeField]
    private bool jogador1;

    [SerializeField]
    private Color corDoJogador;

   
    private Vector2 direcao;

   
    void Update()
    {
        CapturarEntrada();
        MoverJogador();
    }

   
    private void CapturarEntrada()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

       
        direcao = new Vector2(movimentoHorizontal, movimentoVertical).normalized;
    }

    
    private void MoverJogador()
    {
        
        Vector3 movimento = new Vector3(direcao.x, direcao.y, 0) * VELOCIDADE_MOVIMENTO * Time.deltaTime;
        transform.Translate(movimento);
    }

    public void AplicarCorAoBloco(GameObject bloco)
    {
        Renderer blocoRenderer = bloco.GetComponent<Renderer>();
        if (blocoRenderer != null)
        {
            blocoRenderer.material.color = corDoJogador;
        }
    }
}