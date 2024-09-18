using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class GameManager : MonoBehaviour

{

   

    
    public GameObject blocoPrefab;       
    public GameObject jogador1Prefab;  
    public GameObject jogador2Prefab;   
   
    public int numLinhas = 5;           
    public int numColunas = 5;          
    public float espacoEntreBlocos = 1.0f; 
    private Bloco[,] grade;               
    private int contadorTerritoriosConquistados; 
    public static GameManager instance;
    void Awake()
    {
        instance = this;
        grade = new Bloco[numLinhas, numColunas];
        CriarGrade();
    }
    void CriarGrade()
    {
        for (int i = 0; i < numLinhas; i++)
        {
            for (int j = 0; j < numColunas; j++)
            {
                Vector3 posicao = new Vector3(j * espacoEntreBlocos, 0, i * espacoEntreBlocos);
                GameObject novoBloco = Instantiate(blocoPrefab, posicao, Quaternion.identity);
                grade[i, j] = novoBloco.GetComponent<Bloco>();
            }

        }

        

        Vector3 posicaoJogador1 = new Vector3(0, 0, 0);

        Vector3 posicaoJogador2 = new Vector3((numColunas - 1) * espacoEntreBlocos, 0, (numLinhas - 1) * espacoEntreBlocos);

        

        Camera.main.transform.position = new Vector3((numColunas - 1) * espacoEntreBlocos / 2, 10, (numLinhas - 1) * espacoEntreBlocos / 2);

        Camera.main.transform.LookAt(new Vector3((numColunas - 1) * espacoEntreBlocos / 2, 0, (numLinhas - 1) * espacoEntreBlocos / 2));

        

        Instantiate(jogador1Prefab, posicaoJogador1, Quaternion.identity);

        Instantiate(jogador2Prefab, posicaoJogador2, Quaternion.identity);

    }
    public void ConquistarTerritorio()

    {
        contadorTerritoriosConquistados++;

        

        if (contadorTerritoriosConquistados >= numLinhas * numColunas)

        {

            int territoriosJogador1 = 0;

            int territoriosJogador2 = 0;

            

            foreach (Bloco bloco in grade)

            {

                if (bloco.PegarJogadorDono()== 1) 

                {

                    territoriosJogador1++;

                }

                else if (bloco.PegarJogadorDono() == 2)

                {

                    territoriosJogador2++;

                }

            }

            FimDeJogo(territoriosJogador1, territoriosJogador2);

        }

    }
    private void FimDeJogo(int territoriosJogador1, int territoriosJogador2)
    {
        string vencedor;
        if (territoriosJogador1 > territoriosJogador2)
        {
            vencedor = "Jogador 1 é o vencedor!";
        }
        else if (territoriosJogador2 > territoriosJogador1)
        {
            vencedor = "Jogador 2 é o vencedor!";
        }
        else
        {
            vencedor = "Empate!";
        }

        

        Debug.Log(vencedor);

    }

}

