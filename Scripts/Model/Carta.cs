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
    [SerializeField]
    private int idImagem;
    private static bool podeJogar;

    [SerializeField]
    private Sprite costasCarta;

    [SerializeField]
    private Animator anim;

    public int IdImagem
    {
        get
        {
            return idImagem;
        }

        set
        {
            idImagem = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        podeJogar = true;
        isCartaAtiva = false;
        imagens = Resources.LoadAll<Sprite>("Imagens");
    }

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
                if (cartaSelecionada.IdImagem == this.IdImagem)
                {
                    PontuacaoController.MarcaAcerto();
                    podeJogar = true;
                    cartaSelecionada = null;
                }
                else
                {
                    PontuacaoController.MarcaErro();
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
            imagem.sprite = imagens[this.IdImagem];
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
