using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    public GameObject canvasObject;

    private bool isCheckingCollisions = false;

    public CanvasElementFader canvasElementFader;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collider")
        {
            canvasElementFader.ResetElements();
        }
    }

   
}
