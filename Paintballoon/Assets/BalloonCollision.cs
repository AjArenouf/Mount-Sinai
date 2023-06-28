using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    public GameObject canvasObject;

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collider" )
        {
            canvasObject.SetActive(true);
        }
    }
}
