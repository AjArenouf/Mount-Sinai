using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OpponentScoreCount : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreText;
    public AudioSource splattSound;

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

            splattSound.Play();

            scoreText.text = "Opponent Score:" + score;

            if (score >= 10)
            {
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
}


