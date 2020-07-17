using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARPlaneTouch : MonoBehaviour
{
    [SerializeField] GameObject spawnablePrefab;
    [SerializeField] Text debugText;

    private GameObject spawnedGObj;
    private ARRaycastManager raycastMg;
    private ARPlaneManager planeMg;
    private Vector2 tapPosition;


    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastMg = GetComponent<ARRaycastManager>();
        planeMg = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        if (!getTapPos(out Vector2 tapPosition))
        {
            return;
        }

        if (raycastMg.Raycast(tapPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedGObj == null)
            {
                spawnedGObj = Instantiate(spawnablePrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedGObj.transform.position = hitPose.position;
            }

            debugText.text = planeMg.GetPlane(hits[0].trackableId).transform.localScale.x.ToString();

            spawnedGObj.transform.localScale *= (hits[0].distance * 0.7f);


            foreach (var plane in planeMg.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            planeMg.enabled = false;
            raycastMg.enabled = false;
        }
    }

    bool getTapPos(out Vector2 tapPosition)
    {
        if (Input.touchCount > 0)
        {
            tapPosition = Input.GetTouch(0).position;
            return true;
        }

        tapPosition = default;
        return false;
    }
}
