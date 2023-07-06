using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpponentScoreCount : MonoBehaviour
{
    int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collider")
        {
            score++;

            scoreText.text = "Opponent Score:" + score;

            if (score >= 10)
            {
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
}


