using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerScoreCount : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreText;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBall")
        {
            score++;

            scoreText.text = "Your Score:" + score;

            if (score >= 10)
            {
                SceneManager.LoadScene("WinningScene");
            }
        }
    }

    
}
