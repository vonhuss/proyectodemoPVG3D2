using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int points;
    float time;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        timeTxt.text = Timer().ToString("F2");
        scoreTxt.text = points.ToString();
    }

    public void PointsUpdate(int score)
    {
        points += score;
    }

    public float Timer()
    {
        time += Time.deltaTime;

        return time;
    }
}
