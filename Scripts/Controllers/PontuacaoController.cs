using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PontuacaoController : MonoBehaviour {

    public static PontuacaoController instance;

    private static int multiplicadorAcertos;
    private static int pontuacaoBase;

    private static int pontuacaoTotal;
    private static int numeroParesFeitos;

    [SerializeField]
    private Text textoPontuacao;

    void Awake()
    {
        MakeSingleton();
        ReiniciaMultiplicadorAcerto();
        pontuacaoBase = 100;
        pontuacaoTotal = 0;
        alteraTextoPontuacao(pontuacaoTotal);
    }

    public static void MarcaAcerto()
    {
        pontuacaoTotal += pontuacaoBase * multiplicadorAcertos;
        instance.alteraTextoPontuacao(pontuacaoTotal);
        multiplicadorAcertos++;
        numeroParesFeitos++;
        if (Ganhou()){
            Debug.Log("ganhou abertado");
        }
    }

    public static void MarcaErro()
    {
        multiplicadorAcertos = 1;
    }

	void MakeSingleton()
    {
        if ( instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void ReiniciaMultiplicadorAcerto()
    {
        multiplicadorAcertos = 1;
    }

    void alteraTextoPontuacao(int pontos)
    {
        textoPontuacao.text = "Pontos:" + pontos;
    }

    static bool Ganhou()
    {
        return numeroParesFeitos >= GameGridController.numeroDePares;
    }
    
}
