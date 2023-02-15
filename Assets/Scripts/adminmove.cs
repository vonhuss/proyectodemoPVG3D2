using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adminmove : MonoBehaviour
{
    public int puntos;
    public Text textoPuntos;
    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sumarpuntos(int score)
    {
        puntos = puntos + score;
        textoPuntos.text = puntos.ToString();
    }
}
