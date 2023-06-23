using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    private ARTargetSpawnPoint placeIndicator;

    public GameObject objectToPlace;

    private GameObject newPlacedObject;

    // Start is called before the first frame update
    void Start()
    {
        placeIndicator = FindObjectOfType<ARTargetSpawnPoint>();

    }

    public void ClicktoPlace()
    {
        newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);

    }
}