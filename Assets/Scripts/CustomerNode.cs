using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerNode : MonoBehaviour
{
    public bool drawReferenceGizmos = true;
    public float gizmoCoordScale;
    void Start(){}
    void Update(){}
    void OnDrawGizmos(){
        if(drawReferenceGizmos) DrawCoordFrame();
    }

    private void DrawCoordFrame(){
        Vector3 rightLocation = transform.position+(transform.right*(gizmoCoordScale));
        Vector3 upLocation = transform.position+(transform.up*(gizmoCoordScale));
        Vector3 forwardLocation = transform.position+(transform.forward*(gizmoCoordScale));

        float endSphereSize = 0.05f * gizmoCoordScale;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, rightLocation);
        Gizmos.DrawSphere(rightLocation, endSphereSize);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, upLocation);
        Gizmos.DrawSphere(upLocation, endSphereSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, forwardLocation);
        Gizmos.DrawSphere(forwardLocation, endSphereSize);
    }
}
