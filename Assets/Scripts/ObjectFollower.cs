using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform objectToFollow;

    public float movementSpeed = 10;
    public float rotationSpeed = 5;
    public float maximumDistance = 2;
    
    void Start(){}
    void Update(){
        float timeDelta = Time.deltaTime;
        if(objectToFollow!=null){
            // ...
            // handle movement
            float distanceFromTarget = Vector3.Distance(transform.position, objectToFollow.position);
            // how far are we from our point? should we go rly fast?
            float movementScale = Mathf.InverseLerp(0, maximumDistance, distanceFromTarget);
            // calms down the closer we are to the point
            float movementStep = movementScale * movementSpeed * timeDelta;
            transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, movementStep);
            
            // handle rotation
            float rotationStep = rotationSpeed * timeDelta;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, objectToFollow.rotation, rotationStep);
        }
    }
    void OnDrawGizmos(){}

    public void SetNewTarget(Transform newObjectToFollow){
        objectToFollow = newObjectToFollow;
    }
}
