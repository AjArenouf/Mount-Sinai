using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovement : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    private Transform currentTarget;
    

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = target;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 1f;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);

        if (transform.position == currentTarget.position)
        {
            if (currentTarget == target)
                currentTarget = target2;
            else if (currentTarget == target2)
                currentTarget = target3;
            else if (currentTarget == target3)
                currentTarget = target4;
            else if (currentTarget == target4)
                currentTarget = target;

        }

    }
}
