using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class moving : MonoBehaviour
{
    private Vector3 pos;
    public float velocidad;
    public float extension;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float pos_x = extension * Mathf.Sin(2 * Mathf.PI * velocidad * Time.time);
        pos.x = pos_x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision con " + collision.collider.name);
        this.GetComponent<Animator>().SetFloat("velocidad", 4);
        this.GetComponent<Animator>().SetInteger("estado", 1);
    }

    public void setEstado(int est)
    {
        this.GetComponent<Animator>().SetInteger("estado", est);

    }
}