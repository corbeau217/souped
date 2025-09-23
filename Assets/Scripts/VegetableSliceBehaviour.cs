using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSliceBehaviour : MonoBehaviour
{
    public VegetablePathFollower vegetablePathFollower;
    void Start(){
        vegetablePathFollower = GetComponent<VegetablePathFollower>();
    }
    void Update(){
        if(vegetablePathFollower==null){
            vegetablePathFollower = GetComponent<VegetablePathFollower>();
        }
    }

    // finds the slice spawner and spawns slices
    public void SliceVegetable(VegetablePath vegiePath,SoupQualityHandler qualityHandler){
        VegetableSpawner sliceSpawner = this.GetComponent<VegetableSpawner>();
        if(sliceSpawner!=null){
            // provide our parent to slices
            sliceSpawner.SpawnSlices(this.transform.parent, vegiePath, vegetablePathFollower.pathMovementPercent,qualityHandler);

            // delete this
            Destroy(gameObject);
        }
    }

}
