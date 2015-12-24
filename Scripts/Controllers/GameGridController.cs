using UnityEngine;
using System.Collections;

public class GameGridController : MonoBehaviour {

    [SerializeField]
    private int tamanhoHorizontal, tamanhoVertical;

    [SerializeField]
    private GameObject cartaBase;

    private GameObject[] cartas;

    [SerializeField]
    private GameObject cameraCena;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public static int numeroDePares;

    void Awake()
    {
        cartas = new GameObject[tamanhoHorizontal * tamanhoVertical];
        numeroDePares = (tamanhoHorizontal * tamanhoVertical) / 2;
        CriaGrid(spriteRenderer.bounds.size[0], spriteRenderer.bounds.size[1]);
    }

    void CriaGrid(float cartaX, float cartaY)
    {
        if ((tamanhoHorizontal * tamanhoVertical) % 2 != 0)
        {
            Debug.Log("tamanho do grid deve ser par");
        }
        int i = 0;
        for (int x = 0; x < tamanhoHorizontal; x++)
        {
            for (int y = 0; y < tamanhoVertical; y++)
            {
                cartas[i] = (GameObject)Instantiate(cartaBase, new Vector3(x * cartaX, y * cartaY), Quaternion.identity);
                cartas[i].name = x + " - " + y;
                if ( i < numeroDePares)
                {
                    cartas[i].GetComponent<Carta>().IdImagem = Random.Range(0, 13);
                }
                else
                {
                    cartas[i].GetComponent<Carta>().IdImagem = cartas[i - numeroDePares].GetComponent<Carta>().IdImagem;
                }
                i++;
            }
        }
        PosicionaCamera();
        EmbaralhaCartas(cartas);
        PosicionaCartas(cartaX, cartaY);
    }

    void PosicionaCamera()
    {
        cameraCena.transform.position = new Vector3(cartas[cartas.Length - 1].transform.position.x / 2,
                                                cartas[cartas.Length - 1].transform.position.y / 2,
                                                cameraCena.transform.position.z);
    }
    void EmbaralhaCartas(GameObject[] list)
    {
        int n = list.Length;
        while ( n> 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject aux = list[k];
            list[k] = list[n];
            list[n] = aux;
        }
        
    }

    void PosicionaCartas( float tamanhoCartaX, float tamanhoCartaY)
    {
        int i = 0;
        for (int x = 0; x < tamanhoHorizontal; x++)
        {
            for (int y = 0; y < tamanhoVertical; y++)
            {
                cartas[i].transform.position = new Vector3(x * tamanhoCartaX, y * tamanhoCartaY);
                i++;
            }
        }
    }
}
