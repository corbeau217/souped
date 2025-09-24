using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecklistStatus : MonoBehaviour
{
    public List<ChecklistItem> checklist = new List<ChecklistItem>();
    void Start(){}
    void Update(){}

    public void MarkItemDone(int itemIndex){
        if((itemIndex>=0)&&(itemIndex<checklist.Count)){
            checklist[itemIndex].SetDone(true);
        }
        else {
            Debug.Log("don't have "+itemIndex+" as a checklist index!");
        }
    }
}
