using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetablePath : MonoBehaviour
{
    public List<Vector3> pathPoints = new List<Vector3>();
    public Color pathGizmoColour = Color.grey;

    void Start(){}
    void Update(){}
    void OnDrawGizmos(){
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.15f);
        Gizmos.color = pathGizmoColour;
        for(int i = 0; i < pathPoints.Count; i++){
            Vector3 prevLocation = transform.position;
            if(i > 0){
                prevLocation += pathPoints[i-1];
            }
            Vector3 currLocation = transform.position + pathPoints[i];
            Gizmos.DrawLine(prevLocation, currLocation);
            Gizmos.DrawSphere(currLocation, 0.1f);
        }
    }

    // finds a point on the path
    public Vector3 GetPointOnPath(float t){
        // no points or no t
        if((pathPoints.Count == 0)||(t == 0.0f)) return transform.position;
        // full t?
        if(t>=1.0f) return (transform.position + pathPoints[pathPoints.Count-1]);
        // otherwise find the point we are
        float segmentFraction = t * (this.pathPoints.Count);

        // indices of points
        //  giving our from point a chance to be -1
        int fromPointIndex = (int)(segmentFraction) -1;
        int toPointIndex = fromPointIndex+1;
        // check we went over
        if(toPointIndex > (pathPoints.Count-1)){
            return (transform.position + pathPoints[pathPoints.Count-1]);
        }
        // interpolation value
        float tBetween = segmentFraction % 1.0f;
        // locations
        Vector3 fromLocation = transform.position;
        // not desiring the path transform as the from location?
        if(fromPointIndex >= 0){
            fromLocation += pathPoints[fromPointIndex];
        }
        Vector3 toLocation = transform.position + pathPoints[toPointIndex];
        // do the lerp
        return Vector3.Lerp(fromLocation, toLocation, tBetween);
    }
}
