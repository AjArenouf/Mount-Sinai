using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    public GameObject canvasObject;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            canvasObject.SetActive(true);
        }
    }
}
