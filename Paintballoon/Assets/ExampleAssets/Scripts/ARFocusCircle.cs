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
    public GameObject object1;

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

        //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
          //  PlaceObject();
        //}
    }

   public void PlaceObject()
    {
        GameObject[] virtualObjects = new GameObject[] { object1 };

        for (int i = 0; i < virtualObjects.Length; i++)
        {
            GameObject objectToPlace = Instantiate(virtualObjects[i]);
            objectToPlace.SetActive(true);
            objectToPlace.transform.position = placementPose.position;
            objectToPlace.transform.rotation = placementPose.rotation;
        }

        button.SetActive(false);
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        Destroy(placementIndicator);
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
