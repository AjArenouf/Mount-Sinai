using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreCount : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private void OnCollisionEnter(Collision collision)
    {
        // Increase score when collision occurs
        score++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Update the UI text element to display the updated score
        scoreText.text = "Score: " + score;
    }


}
