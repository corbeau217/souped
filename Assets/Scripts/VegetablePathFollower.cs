using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablePathFollower : MonoBehaviour
{
    public VegetablePath pathToFollow;
    [Tooltip("the rate at which it moves along the path")]
    public float pathMovementSpeed = 0.25f;
    [Tooltip("how far along the path it is")]
    public float pathMovementPercent = 0.0f;
    [Tooltip("when to try delete this object")]
    public float movementCompletePercent = 1.1f;

    void Start(){}
    void Update(){
        // only move if we have a path
        if(pathToFollow != null){
            pathMovementPercent += pathMovementSpeed * Time.deltaTime;
            // find where to go
            Vector3 desiredPosition = pathToFollow.GetPointOnPath(pathMovementPercent);
            // set it directly lol
            transform.position = desiredPosition;
        }

        // when we finished moving
        if(pathMovementPercent >= movementCompletePercent){
            HandlePathComplete();
        }
    }
    void OnDrawGizmos(){}

    public void SetFollowingPath(VegetablePath followingPath){
        pathToFollow = followingPath;
    }
    private void HandlePathComplete(){
        // we in the soup noww
        // TODO : tell our soup we arrived
        // delete this object
        Destroy(gameObject);
    }
}
