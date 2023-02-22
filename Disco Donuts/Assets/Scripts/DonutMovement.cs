using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutMovement : MonoBehaviour
{
    public float donutSpeed;

    Vector3 zPos = new Vector3(0, -1, 0);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(donutSpeed * Time.deltaTime * zPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit"))
        {
            Destroy(gameObject);
            if (PlayerController.playerController.score > 0)
            {
                PlayerController.playerController.score --;
            }
        }
    }

}
