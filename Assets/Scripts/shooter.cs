using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class shooter : MonoBehaviour
{
    public float potencia;
    public float poder;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            poder = 1;
        }
        if (Input.GetKey(KeyCode.Space)) {
            poder = poder + Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.forward * poder * potencia);
            Invoke("reinicia", 8);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            reinicia();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("manager").GetComponent<adminmove>().sumarpuntos(1);
        Invoke("reinicia", 5);
        this.GetComponent<SphereCollider>().enabled = false;
        //reinicia();
    }

    void reinicia()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        this.transform.position = pos;
        this.GetComponent<SphereCollider>().enabled = true;
    }
}
