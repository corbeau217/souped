using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryHandler : MonoBehaviour
{
    public VegetablePath pathToThrowVegies;
    public Transform vegieSpawnContainer;

    public VegetableSpawner vegieSpawner;
    public VegetableShapesList currentVegetableList;

    public int vegetablesToSpawn = 0;
    public float spawnTimeout = 0.0f;
    public float timeBetweenSpawns = 1.0f;

    public bool randomiseVegetableSpawns = true;
    public bool startSpawningVegetables = true;

    void Start(){
        // ask that we spawn that many vegetables
        vegetablesToSpawn = currentVegetableList.vegetableShapes.Count;
    }
    void Update(){
        UpdateSpawnList();
        if((vegetablesToSpawn > 0)){
            AttemptVegieSpawn();
        }
    }

    private void UpdateSpawnList(){
        this.vegieSpawner.vegieSpawnablePrefabs = currentVegetableList.vegetableShapes;
    }

    private void AttemptVegieSpawn(){
        if(spawnTimeout <= 0.0f){
            // do the spawning
            SpawnAnVegie();
        }
        else {
            // snooze vegie spawn
            //  avoiding going below 0
            spawnTimeout = Mathf.Max((spawnTimeout - Time.deltaTime), 0.0f);
        }
    }
    private void SpawnAnVegie(){
        // ask to spawn a random vegie on our path
        if(randomiseVegetableSpawns) vegieSpawner.SpawnRandomVegetable(vegieSpawnContainer, pathToThrowVegies);
        // assuming the vegetables to spawn is no more than the number of vegies in the list
        else vegieSpawner.SpawnVegetable(vegetablesToSpawn-1, vegieSpawnContainer, pathToThrowVegies);
        // then timeout the spawn
        spawnTimeout = timeBetweenSpawns;
        vegetablesToSpawn--;
    }

    public bool HasSpawnedAllVegetables(){
        return (this.vegetablesToSpawn == 0);
    }
    public void SetTimeBetweenSpawns(float newTime){
        timeBetweenSpawns = newTime;
        // clamp the spawn timeout to be the new timeout incase we were already sleeping
        //  so that we dont wait as long if our new timeout is less than before
        spawnTimeout = Mathf.Min(spawnTimeout, newTime);
    }
}
