using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryHandler : MonoBehaviour
{
    public BoilerHandler boiler;
    public VegetablePath pathToThrowVegies;
    public VegetableSpawner vegieSpawner;
    public Transform vegieSpawnContainer;

    [Space(10)]
    public SoupQualityHandler qualityHandler;
    public ComboCounter playerComboCounter;

    [Space(10)]
    public SoupInventory soupInventory;
    [Space(20)]
    public VegetableShapesList currentVegetableList;
    public int soupIndex = 0;

    public int vegetablesToSpawn = 0;
    public float spawnTimeout = 0.0f;
    public float timeBetweenSpawns = 1.0f;

    public bool randomiseVegetableSpawns = true;
    public bool cookingStillRequired = false;
    public bool comboUpdateRequired = false;
    public float cookingTime = 0.0f;
    public int childCounter = 0;
    void Start(){}
    void Update(){
        this.childCounter = vegieSpawnContainer.childCount;
        UpdateSpawnList();
        if((vegetablesToSpawn > 0)){
            cookingStillRequired = true;
            AttemptVegieSpawn();
            comboUpdateRequired = false;
        }
        // none left to spawn, and spawning veggies, and not still throwing
        if((HasSpawnedAllVegetables())&&(cookingStillRequired)&&(!VegiesStillThrowing()) ){
            boiler.SetCookingTime(cookingTime);
            cookingStillRequired = false;
            comboUpdateRequired = true;
        }
        // when the cooking is done
        if((comboUpdateRequired)&&(!boiler.IsCooking())){
            // notify inventory of soups
            soupInventory.AddSoups(soupIndex);

            // no uncut veggies?
            if(!(qualityHandler.HadUncutVeggies())){
                playerComboCounter.IncreaseCombo();
            }
            else {
                playerComboCounter.ResetCombo();
            }
            comboUpdateRequired = false;
        }
    }

    private void UpdateSpawnList(){
        if(currentVegetableList!=null){
            this.vegieSpawner.vegieSpawnablePrefabs = currentVegetableList.vegetableShapes;
        }
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
        if(randomiseVegetableSpawns) {vegieSpawner.SpawnRandomVegetable(vegieSpawnContainer, pathToThrowVegies,qualityHandler);}
        // assuming the vegetables to spawn is no more than the number of vegies in the list
        else{ vegieSpawner.SpawnVegetable(vegetablesToSpawn-1, vegieSpawnContainer, pathToThrowVegies,qualityHandler);}
        // then timeout the spawn
        spawnTimeout = timeBetweenSpawns;
        vegetablesToSpawn--;
    }

    public bool HasSpawnedAllVegetables(){
        return (this.vegetablesToSpawn == 0);
    }
    public bool VegiesStillThrowing(){
        return (vegieSpawnContainer.childCount > 0);
    }
    public void SetTimeBetweenSpawns(float newTime){
        timeBetweenSpawns = newTime;
        // clamp the spawn timeout to be the new timeout incase we were already sleeping
        //  so that we dont wait as long if our new timeout is less than before
        spawnTimeout = Mathf.Min(spawnTimeout, newTime);
    }

    public void ChangeRecipe(VegetableShapesList newIngredients){
        currentVegetableList = newIngredients;
        // ask that we spawn that many vegetables
        vegetablesToSpawn = currentVegetableList.vegetableShapes.Count;
        this.cookingTime = newIngredients.cookingTime;
        qualityHandler.ClearPreviousQuality();
    }
}
