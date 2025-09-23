using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuProximity : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform proximityTo;
    public GameObject togglingObject;

    [Space(10)]

    public float positionRange;
    public Vector3 rotationRange;

    [Space(10)]

    public float positionProximity;
    public Vector3 rotationalProximity;

    void Start(){}
    void Update(){
        positionProximity = Vector3.Distance(cameraTransform.position, proximityTo.position);
        rotationalProximity = proximityTo.rotation.eulerAngles - cameraTransform.rotation.eulerAngles;

        if((positionProximity <= positionRange)&&(
            (rotationalProximity.x <= rotationRange.x) &&
            (rotationalProximity.y <= rotationRange.y) &&
            (rotationalProximity.z <= rotationRange.z)
        )){
            togglingObject.SetActive(true);
        }
        else {
            togglingObject.SetActive(false);
        }
    }
    void OnDrawGizmos(){}

}
