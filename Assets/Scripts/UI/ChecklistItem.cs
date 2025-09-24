using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChecklistItem : MonoBehaviour
{
    public TMP_Text textOfChecklistItem;
    public string todoPrefix = "[ ]";
    public string donePrefix = "[x]";
    public string labelText = "lorem ipsum";
    public bool isDone = false;
    void Start(){}
    void Update(){
        if(textOfChecklistItem!=null){
            textOfChecklistItem.text = ((isDone)?donePrefix:todoPrefix) +" "+ labelText;
        }
    }

    public void SetDone(bool isDone){
        this.isDone = isDone;
    }
}
