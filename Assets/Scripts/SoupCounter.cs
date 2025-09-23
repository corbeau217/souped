using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupCounter : MonoBehaviour
{
    public List<GameObject> countBlips;
    public int counter = 0;
    void Start(){}
    void Update(){
        for(int i = 0; i < countBlips.Count; i++){
            // when the combo counter is more than the index
            //  1 means it includes index 0
            countBlips[i].SetActive( i<counter );
        }
    }

    public void SetCounter(int count){
        this.counter = count;
    }
}
