using UnityEngine;
using System.Collections;

public class PontuacaoController : MonoBehaviour {

    public static PontuacaoController instance;

    private static int multiplicadorAcertos;
    private static int pontuacaoBase;

    [SerializeField]
    private static int pontuacaoTotal;
    
    void Awake()
    {
        MakeSingleton();
        reiniciaMultiplicadorAcerto();
        pontuacaoBase = 100;
        pontuacaoTotal = 0;
    }

    public static void MarcaAcerto()
    {
        pontuacaoTotal += pontuacaoBase * multiplicadorAcertos;
        multiplicadorAcertos++;
        Debug.Log(pontuacaoTotal);
        Debug.Log(multiplicadorAcertos);
    }

    public static void MarcaErro()
    {
        multiplicadorAcertos = 1;
        Debug.Log(multiplicadorAcertos);
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

    void reiniciaMultiplicadorAcerto()
    {
        multiplicadorAcertos = 1;
    }


}
