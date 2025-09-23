using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerHandler : MonoBehaviour
{
    public GameObject burnerFlame;
    public float cookingTimeRemaining = 0.0f;

    void Start(){}
    void Update(){
        // snooze for cooking
        //  avoiding going below 0
        cookingTimeRemaining = Mathf.Max((cookingTimeRemaining - Time.deltaTime), 0.0f);

        // show our flames if we're cooking
        burnerFlame.SetActive(IsCooking());
    }

    public void SetCookingTime(float timeToCook){
        cookingTimeRemaining = timeToCook;
    }
    public bool IsCooking(){
        return cookingTimeRemaining > 0.0f;
    }
}
