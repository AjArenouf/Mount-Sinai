using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableObjectMovement : MonoBehaviour

public float MovementSpeed = 1.0f;
public float MovementRadius = 1.0f;
private vector3 initialPosition;
    
{
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject objectToFind = GameObject.Find("SpawnableObject");
        if (objectToFind != null)
        {

        }
    }
}
