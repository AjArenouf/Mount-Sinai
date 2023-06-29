using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour

{
    public GameObject paintballoon;
    public Camera arCamera;
    int score;
    public Text scoreText;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShootBalloon();
        }
    }
    public void ShootBalloon()
    {
        GameObject BalloonInstantiated = Instantiate(paintballoon, arCamera.transform.position, arCamera.transform.rotation);

        Vector3 impulse = new Vector3(0.0f, 0.0f, 30.0f);

        BalloonInstantiated.GetComponent<Rigidbody>().AddRelativeForce(impulse, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "Spawnable")
        {
            score++;

            scoreText.text = "Score:" + score;
        }

    }
}
