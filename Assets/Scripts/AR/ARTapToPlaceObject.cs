using DevGameRoshan;
using Events;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
  public GameObject placementIndicator;

  private GameObject objectToPlace;
  private ARRaycastManager rayManager;
  private Pose placementPose;
  private bool placementPoseIsValid = false;

  void Start()
  {
    rayManager = FindObjectOfType<ARRaycastManager>();
    EventManager.Instance.AddListener<ObjectToPlaceSelectedEvent>(OnObjectToPlaceSelectedEvent);
  }

  private void OnObjectToPlaceSelectedEvent(ObjectToPlaceSelectedEvent e)
  {
    objectToPlace = e.getCurrentObjectToPlace();
  }

  void Update()
  {
    UpdatePlacementPose();
    UpdatePlacementIndicator();

    if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
      PlaceObject();
    }
  }

  private void PlaceObject()
  {
    // Check Object to Place
    if (objectToPlace != null)
    {
      Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    }
  }

  private void UpdatePlacementIndicator()
  {
    if (placementPoseIsValid)
    {
      placementIndicator.SetActive(true);
      placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
    }
    else
    {
      placementIndicator.SetActive(false);
    }
  }

  private void UpdatePlacementPose()
  {
    //var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
    var hits = new List<ARRaycastHit>();
    rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

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
