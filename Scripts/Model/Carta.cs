using UnityEngine;
using System.Collections;

public class Carta : MonoBehaviour {

    //    public static Carta isntance;
    public static Carta cartaSelecionada;
    public bool isCartaAtiva;

    [SerializeField]
    private SpriteRenderer imagem;

    //[SerializeField]
    public static Sprite[] imagens;
    private int idImagem;
    private static bool podeJogar;

    [SerializeField]
    private Sprite costasCarta;

    [SerializeField]
    private Animator anim;

    // Use this for initialization
    void Awake()
    {
        podeJogar = true;
        isCartaAtiva = false;
        imagens = Resources.LoadAll<Sprite>("Imagens");
    }
    
	void Start () {
        idImagem = Random.Range(0, imagens.Length - 1 );
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        if (podeJogar && this != cartaSelecionada)
        {
            podeJogar = false;
            StartCoroutine(GiraCarta());
            if (cartaSelecionada == null)
            {
                cartaSelecionada = this;
                podeJogar = true;
                return;
            }
            if (cartaSelecionada != null && cartaSelecionada != this)
            {
                if (cartaSelecionada.idImagem == this.idImagem)
                {
                    Debug.Log("Certo Mizeravi");
                    podeJogar = true;
                    cartaSelecionada = null;
                }
                else
                {
                    StartCoroutine(VoltaCartas(2f));
                }

            }
        }
    }

    IEnumerator VoltaCartas(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        StartCoroutine(cartaSelecionada.GiraCarta());
        StartCoroutine(this.GiraCarta());
        cartaSelecionada = null;
        podeJogar = true;
    }

    IEnumerator GiraCarta()
    {
        yield return StartCoroutine(transform.RotateObject(90, 0.5f));
        if (!isCartaAtiva)
        {
            imagem.sprite = imagens[idImagem];
            isCartaAtiva = true;
        }
        else {
            imagem.sprite = costasCarta;
            isCartaAtiva = false;
        }
        yield return StartCoroutine(transform.RotateObject(90, 0.5f));
        if (isCartaAtiva)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
