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

    public Transform cameraTransform;
    Animator animator;
  
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Transform shootPoint;
    public GameObject arCamera;


    // Start is called before the first frame update
    void Start()
    {
        currentTarget = target;
        animator = GetComponent<Animator>();
        arCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
        float speed = 2f;
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

        Vector3 directionToTarget = currentTarget.position - transform.position;

        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrowState")
        {
            animator.SetTrigger("isColliding");
            Shoot();

            Vector3 directionToCamera = cameraTransform.position - transform.position;
            directionToCamera.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation = targetRotation;
           
            
        }
    }

    private void Shoot()
    {
        GameObject BoyBalloon = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        Vector3 direction = (arCamera.transform.position - transform.position).normalized;

        Rigidbody BoyBalloonRigidbody = BoyBalloon.GetComponent<Rigidbody>();
        BoyBalloonRigidbody.velocity = direction * projectileSpeed;
    }

}


