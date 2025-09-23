using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSliceBehaviour : MonoBehaviour
{
    void Start(){}
    void Update(){}

    // finds the slice spawner and spawns slices
    public void SliceVegetable(VegetablePath vegiePath){
        VegetableSpawner sliceSpawner = this.GetComponent<VegetableSpawner>();
        if(sliceSpawner!=null){
            // provide our parent to slices
            sliceSpawner.SpawnAllVegetables(this.transform.parent, vegiePath);

            // delete this
            Destroy(gameObject);
        }
    }

}
