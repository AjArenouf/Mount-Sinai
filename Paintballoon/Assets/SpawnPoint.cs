using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject SpawnableObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(SpawnableObject, spawnPoint.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
