using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupSelection : MonoBehaviour
{
    public DeliveryHandler deliveryHandler;
    public BoilerHandler boiler;
    public List<VegetableShapesList> soupRecipes;
    public GameObject recipeSelectionMenu;
    public bool showSelectionMenu = false;

    void Start(){}
    void Update(){

        showSelectionMenu = (
            (deliveryHandler.HasSpawnedAllVegetables()) &&
            !(deliveryHandler.VegiesStillThrowing()) &&
            !(boiler.IsCooking())
        );
        recipeSelectionMenu.SetActive( showSelectionMenu );
    }
    void OnDrawGizmos(){}

    public void StartSoupRecipe(int soupIndex){
        deliveryHandler.ChangeRecipe( soupRecipes[soupIndex] );
    }
}
