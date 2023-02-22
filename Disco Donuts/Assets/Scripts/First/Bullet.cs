using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float power;
    public float potency;
    public float timeForRestart = 8f;
    public int points;

   

    private Vector3 pos;

    private Rigidbody rb;
    private SphereCollider sphereCollider;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        power = 1;
       
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             power = 1;
             power += Time.deltaTime;

        }

        if(Input.GetKeyUp(KeyCode.Space)){

            rb.AddForce(Vector3.up * power * potency * Time.deltaTime, ForceMode.Impulse);
      
         }

     /*   if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManagerScript.PointsUpdate(points);
        Restart();
        
    }

    public void Restart()
    {
        rb.velocity = Vector3.zero; 
        transform.position = pos;
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            Restart();
        }
    }
}
