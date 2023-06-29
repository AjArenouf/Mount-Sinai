using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    public GameObject canvasObject;

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collider" )
        {
            canvasObject.SetActive(true);
        }
    }
}
