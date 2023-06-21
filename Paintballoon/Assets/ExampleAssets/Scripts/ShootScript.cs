using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour

{
    public GameObject paintballoon;
    public Camera arCamera;

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

        Vector3 impulse = new Vector3(0.0f, 0.0f, 100.0f);

        BalloonInstantiated.GetComponent<Rigidbody>().AddRelativeForce(impulse, ForceMode.Impulse);
    }
}
