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

    [SerializeField]
    private Sprite costasCarta;

    [SerializeField]
    private Animator anim;

    // Use this for initialization
    void Awake()
    {
        isCartaAtiva = false;
        imagens = Resources.LoadAll<Sprite>("Imagens");
    }
    
	void Start () {
        idImagem = Random.Range(0, imagens.Length - 1 );
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        StartCoroutine(GiraCarta());
        if (cartaSelecionada == null)
        {
            cartaSelecionada = this;
            return;
        }
        if (cartaSelecionada != null && cartaSelecionada != this)
        {
            if (cartaSelecionada.idImagem == this.idImagem)
            {
                Debug.Log("Certo Mizeravi");
            }
            else
            {
                Debug.Log("Erro Mardito");
            }
            StartCoroutine(cartaSelecionada.GiraCarta());
            StartCoroutine(this.GiraCarta());
            cartaSelecionada = null;
        }
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
