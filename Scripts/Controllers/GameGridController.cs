using UnityEngine;
using System.Collections;

public class GameGridController : MonoBehaviour {

    [SerializeField]
    private int tamanhoHorizontal, tamanhoVertical;

    [SerializeField]
    private GameObject cartaBase;

    void Awake()
    {
        CriaGrid();

        

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CriaGrid()
    {

        if ((tamanhoHorizontal * tamanhoVertical) % 2 != 0)
        {
            Debug.Log("tamanho do grid deve ser par");
        }
        for (int x = 0; x < tamanhoHorizontal; x++)
        {
            for (int y = 0; y < tamanhoVertical; y++)
            {
                GameObject carta = (GameObject)Instantiate(cartaBase, new Vector3(x, y), Quaternion.identity);
                carta.name = x + " - " + y;
            }
        }
    }
}
