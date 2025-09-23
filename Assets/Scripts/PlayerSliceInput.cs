using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSliceInput : MonoBehaviour
{
    public LayerMask sliceableLayers;
    public VegetablePath vegiePath;
    public SoupQualityHandler qualityHandler;
    public Camera playerCamera;
    // public bool isInputDetected = false;
    void Start(){}
    void Update(){
        // check for the firing
        if(Input.GetButton("Fire1")){
            // find the ray from camera
            RaycastHit hitObject;
            Ray mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            // collided with something
            if (Physics.Raycast(mouseRay, out hitObject, 50.0f,sliceableLayers)){
                // grab the object and try find slice behaviour
                GameObject hitGameObject = hitObject.transform.gameObject;
                VegetableSliceBehaviour sliceBehaviour = hitGameObject.GetComponent<VegetableSliceBehaviour>();
                // found the slice behaviour
                if(sliceBehaviour != null){
                    // slice and give it a path to follow
                    sliceBehaviour.SliceVegetable(vegiePath,qualityHandler);
                }
            }
        }
    }
    void OnDrawGizmos(){}


}
