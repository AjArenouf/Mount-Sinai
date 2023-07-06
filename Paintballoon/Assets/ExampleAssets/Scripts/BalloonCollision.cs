using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    public GameObject canvasObject;

    private bool isCheckingCollisions = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collider")
        {
            if (!isCheckingCollisions)
            {
                StartCoroutine(CheckingCollisions());
            }
        }
    }

    IEnumerator CheckingCollisions()
    {
        isCheckingCollisions = true;

        while (true)
        {
            canvasObject.SetActive(true);
            yield return null;
        }
    }
}
