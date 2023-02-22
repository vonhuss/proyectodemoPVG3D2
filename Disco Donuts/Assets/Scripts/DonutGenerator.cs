using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutGenerator : MonoBehaviour
{

    public GameObject[] donut;

    public float donutSpeed;
    private float xBoundary = 12;
    private float donutSpawnPosY = 200.2f;
    private float donutSpawnPosZ = 200;

    private float countdown;
    public float timeBetween = 5;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 3.7f;
    }

    // Update is called once per frame
    void Update()
    {
       
      if(countdown <= 0)
        {
            DonutGen();
            countdown = timeBetween;
        }

        countdown -= Time.deltaTime;
    }

    public void DonutGen()
    {
        float donutSpawnPosX = Random.Range(-xBoundary, xBoundary);
        int donutCount = Random.Range(0, donut.Length);

        Vector3 startingPos = new Vector3(donutSpawnPosX,donutSpawnPosY, donutSpawnPosZ);

        Instantiate(donut[donutCount], startingPos, Quaternion.Euler(90,0,0));
    }
}
