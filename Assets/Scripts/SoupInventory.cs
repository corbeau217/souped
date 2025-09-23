using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupInventory : MonoBehaviour
{
    public SoupSelection soupSelection;
    public List<SoupCounter> soupCounters = new List<SoupCounter>();
    public int[] soupAmounts;
    public int soupOptionCount = 0;
    public int soupsPerCook = 4;

    void Start(){
        soupOptionCount = soupSelection.soupRecipes.Count;
        soupAmounts = new int[soupOptionCount];
    }
    void Update(){
        for(int i = 0; i < soupCounters.Count; i++){
            soupCounters[i].SetCounter(soupAmounts[i]);
        }
    }

    public void AddSoups(int soupIndex){
        if(soupIndex < soupOptionCount){
            soupAmounts[soupIndex] += soupsPerCook;
        }
    }
    public bool ServeSoup(int soupIndex){
        if((soupIndex < soupOptionCount)&&(soupAmounts[soupIndex] > 0)){
            soupAmounts[soupIndex]--;
            return true;
        }
        else{
            return false;
        }
    }
}
