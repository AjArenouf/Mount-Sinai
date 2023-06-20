using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovement : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public float t;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, b, speed);

        Vector3 c = transform.position;
        Vector3 d = target2.position;
        transform.position = Vector3.MoveTowards(c, d, speed);

        Vector3 e = transform.position;
        Vector3 f = target3.position;
        transform.position = Vector3.MoveTowards(e, f, speed);

        Vector3 g = transform.position;
        Vector3 h = target4.position;
        transform.position = Vector3.MoveTowards(g, h, speed);

    }
}
