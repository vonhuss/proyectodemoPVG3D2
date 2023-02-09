using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adminmove : MonoBehaviour
{
    public int puntos;
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        puntos = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sumarpuntos(int score)
    {
        puntos = puntos + score;
    }
}
