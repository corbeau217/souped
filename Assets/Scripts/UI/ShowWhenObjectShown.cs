using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenObjectShown : MonoBehaviour
{
    public GameObject objectToWatch;
    public GameObject managesObject;
    void Start(){}
    void Update(){
        managesObject.SetActive(objectToWatch.activeSelf);
    }
}
