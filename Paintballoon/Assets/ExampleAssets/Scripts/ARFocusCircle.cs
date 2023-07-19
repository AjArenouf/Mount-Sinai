using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ARFocusCircle : MonoBehaviour
{
    // Rest of the code remains the same...
    // (I removed the comments in the following code for brevity)
    // (You can add them back if needed)

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;

    public GameObject button;

    public GameObject placementIndicator;

    private Image placementIndicatorImage; // Change 'Renderer' to 'Image'

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool placementIndicatorEnabled = true;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();

        placementIndicatorImage = placementIndicator.GetComponent<Image>(); // Assign Image instead of Renderer
        if (placementIndicatorImage == null)
        {
            Debug.LogError("Placement indicator does not have an Image component.");
        }
        //scanText.SetActive(true);
        //placeText.SetActive(false);
    }

    void Update()
    {

        if (placementIndicatorEnabled == true)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    void PlaceObject()
    {
        GameObject[] virtualObjects = new GameObject[] { object1, object2, object3, object4, object5 };

        for (int i = 0; i < virtualObjects.Length; i++)
        {
            GameObject objectToPlace = Instantiate(virtualObjects[i]);
            objectToPlace.SetActive(true);
            objectToPlace.transform.position = placementPose.position;
            objectToPlace.transform.rotation = placementPose.rotation;
        }
        StartCoroutine(FadeButtonAndIndicator());
    }

    private IEnumerator FadeButtonAndIndicator()
    {
        // Wait for a short duration before starting the fade
        yield return new WaitForSeconds(1.0f);

        // Rest of the code remains the same...
    }

    public void SpawnAllObjects()
    {
        PlaceObject();
    }

    private void UpdatePlacementIndicator()
    {
        if (placementIndicator != null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
