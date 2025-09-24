using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupQualityHandler : MonoBehaviour
{
    public ChecklistStatus checklistStatus;
    public int unchoppedVeggiesReceived = 0;

    void Start(){}
    void Update(){}

    public void IncreaseUncutVeggieCount(){
        unchoppedVeggiesReceived++;
    }
    public void ClearPreviousQuality(){
        unchoppedVeggiesReceived=0;
    }
    public bool HadUncutVeggies(){
        bool hadUncut = (unchoppedVeggiesReceived>0);
        // when we have access to the checklist and didnt receive uncut veggies, mark the good soup done
        if((checklistStatus!=null)&&(!hadUncut)){ checklistStatus.MarkItemDone(1); }
        return hadUncut;
    }
}
