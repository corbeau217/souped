using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSpawner : MonoBehaviour
{
    [Tooltip("what this spawner can create")]
    public List<GameObject> vegieSpawnablePrefabs = new List<GameObject>();
    // public Vector3 rotationalVelocity = Vector3.zero;

    void Start(){}
    void Update(){}
    void OnDrawGizmos(){}

    public void SpawnRandomVegetable(Transform parentTransform, VegetablePath vegiePath){
        if(vegieSpawnablePrefabs==null) {
            Debug.Log("sorry boss, no vegie prefabs on " + gameObject.name);
            return;
        }

        // choose one
        int selectionIndex = Random.Range(0,(vegieSpawnablePrefabs.Count-1));

        SpawnVegetable(selectionIndex, parentTransform,vegiePath);
    }
    public void SpawnAllVegetables(Transform parentTransform, VegetablePath vegiePath){
        for(int i = 0; i < this.vegieSpawnablePrefabs.Count; i++){
            SpawnVegetable(i, parentTransform,vegiePath);
        }
    }
    public void SpawnVegetable(int indexToSpawn, Transform parentTransform, VegetablePath vegiePath){
        if(vegieSpawnablePrefabs.Count==0){
            Debug.Log("sorry boss, no options on " + gameObject.name);
            return;
        }
        // spawn it
        GameObject spawnedVegie = (GameObject)Instantiate( vegieSpawnablePrefabs[indexToSpawn], parentTransform );

        // fetch rigid body
        VegetablePathFollower spawnedPathFollower = spawnedVegie.GetComponent<VegetablePathFollower>();

        // dud vegie?
        if(spawnedPathFollower==null) {
            Debug.Log("sorry boss, that's a dud vegie, "+gameObject.name+" didnt have VegetablePathFollower");
            return;
        }

        // otherwise give it the stuff
        spawnedPathFollower.SetFollowingPath(vegiePath);
    }
}
