using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableObjectMovement : MonoBehaviour {

    public float MovementSpeed = 1.0f;
    public float MovementRadius = 1.0f;
    private Vector3 initialPosition;
    private float elapsedTime = 0.0f;



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
            elapsedTime += Time.deltaTime;

            Vector2 randomPosition = Random.insideUnitCircle * MovementRadius;

            Vector3 newPosition = initialPosition + new Vector3(randomPosition.x, 0, randomPosition.y);

            transform.position = Vector3.MoveTowards(transform.position, newPosition, MovementSpeed * Time.deltaTime);
        }
    }
}



    