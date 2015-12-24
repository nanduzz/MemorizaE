﻿using UnityEngine;
using System.Collections;

public class GameGridController : MonoBehaviour {

    [SerializeField]
    private int tamanhoHorizontal, tamanhoVertical;

    [SerializeField]
    private GameObject cartaBase;

    private GameObject[] cartas;

    [SerializeField]
    private GameObject Camera;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        cartas = new GameObject[tamanhoHorizontal * tamanhoVertical];
        CriaGrid(spriteRenderer.bounds.size[0], spriteRenderer.bounds.size[1]);
    }

    void CriaGrid(float cartaX, float cartaY)
    {
        if ((tamanhoHorizontal * tamanhoVertical) % 2 != 0)
        {
            Debug.Log("tamanho do grid deve ser par");
        }
        int i = 0;
        int metadeCartas = (tamanhoHorizontal * tamanhoVertical) / 2;
        for (int x = 0; x < tamanhoHorizontal; x++)
        {
            for (int y = 0; y < tamanhoVertical; y++)
            {
                cartas[i] = (GameObject)Instantiate(cartaBase, new Vector3(x * cartaX, y * cartaY), Quaternion.identity);
                cartas[i].name = x + " - " + y;
                if ( i < metadeCartas)
                {
                    cartas[i].GetComponent<Carta>().IdImagem = Random.Range(0, 13);
                }
                else
                {
                    cartas[i].GetComponent<Carta>().IdImagem = cartas[i - metadeCartas].GetComponent<Carta>().IdImagem;
                }
                i++;
            }
        }
        Camera.transform.position = new Vector3(cartas[i-1].transform.position.x / 2,
                                                cartas[i-1].transform.position.y / 2,
                                                Camera.transform.position.z);

    }
}
