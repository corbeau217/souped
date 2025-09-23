using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupQualityHandler : MonoBehaviour
{
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
        return (unchoppedVeggiesReceived>0);
    }
}
