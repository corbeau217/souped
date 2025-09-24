using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceWatcher : MonoBehaviour
{
    public ChecklistStatus checklistStatus;
    [Space(10)]
    public ComboCounter derekCombo;
    public ComboCounter playerCombo;
    [Space(10)]
    public int minimumStarsForPromotion = 7;
    public bool isPromotable = false;
    void Start(){}
    void Update(){
        int derekCount = derekCombo.GetCappedCount();
        int playerCount = playerCombo.GetCappedCount();
        // derek has less recognised combo and the player has the minimum for promotion
        isPromotable = ((derekCount<playerCount)&&(playerCount>=minimumStarsForPromotion));
    }
}
