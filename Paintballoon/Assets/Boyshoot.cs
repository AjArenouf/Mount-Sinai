using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boyshoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootInterval = 2f;
    public float projectileSpeed = 10f;

    private GameObject arCamera;
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        arCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, arCamera.transform.position);

        if (distance < 15f && elapsedTime >= shootInterval)
        {
            Shoot();
            elapsedTime = 0f;
        }

        elapsedTime += Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject BoyBalloon = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        Vector3 direction = (arCamera.transform.position - transform.position).normalized;

        Rigidbody BoyBalloonRigidbody = BoyBalloon.GetComponent<Rigidbody>();
        BoyBalloonRigidbody.velocity = direction * projectileSpeed;
    }
}