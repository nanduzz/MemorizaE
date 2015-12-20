using UnityEngine;
using System.Collections;

public class GameGridController : MonoBehaviour {

    [SerializeField]
    private int tamanhoHorizontal, tamanhoVertical;

    [SerializeField]
    private GameObject cartaBase;

    [SerializeField]
    private GameObject Camera;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        
        CriaGrid(spriteRenderer.bounds.size[0], spriteRenderer.bounds.size[1]);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CriaGrid(float cartaX, float cartaY)
    {
        GameObject carta = null;
        if ((tamanhoHorizontal * tamanhoVertical) % 2 != 0)
        {
            Debug.Log("tamanho do grid deve ser par");
        }
        for (int x = 0; x < tamanhoHorizontal; x++)
        {
            for (int y = 0; y < tamanhoVertical; y++)
            {
                carta = (GameObject)Instantiate(cartaBase, new Vector3(x * cartaX, y * cartaY), Quaternion.identity);
                carta.name = x + " - " + y;
            }
        }
        Camera.transform.position = new Vector3(carta.transform.position.x / 2,
                                                carta.transform.position.y / 2,
                                                Camera.transform.position.z);

    }
}
