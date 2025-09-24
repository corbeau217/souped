using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
    public List<GameObject> comboBlips;
    public int maxRecognisedCombo = 8;
    public int comboCount = 0;
    void Start(){}
    void Update(){
        maxRecognisedCombo = comboBlips.Count;
        for(int i = 0; i < comboBlips.Count; i++){
            // when the combo counter is more than the index
            //  1 means it includes index 0
            comboBlips[i].SetActive( i<comboCount );
        }
    }

    public void IncreaseCombo(){
        this.comboCount++;
    }
    public void ResetCombo(){
        this.comboCount = 0;
    }
    public int GetCappedCount(){
        return Mathf.Min(comboCount,maxRecognisedCombo);
    }
}
