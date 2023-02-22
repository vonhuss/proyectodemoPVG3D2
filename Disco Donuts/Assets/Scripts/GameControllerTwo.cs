using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerTwo : MonoBehaviour
{

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI intro;
    
    IEnumerator Intro()
    {
        scoreTxt.gameObject.SetActive(false);
        yield return new WaitForSeconds(3.7f);
        intro.gameObject.SetActive(false);
        scoreTxt.gameObject.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro());
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreTxt.text = "Score: " + PlayerController.playerController.score.ToString();
    }
}
