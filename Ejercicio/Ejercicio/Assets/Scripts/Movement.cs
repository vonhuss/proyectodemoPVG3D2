using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public float extension;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float pos_x = extension* Mathf.Sin(2 * Mathf.PI * speed * Time.time);
        pos.x = pos_x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.collider.name);
    }
}
