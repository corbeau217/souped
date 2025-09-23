using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public ServiceCounter serviceCounter;
    public ObjectFollower objectFollower;
    public CustomerNode orderNode;
    public CustomerNode exitNode;

    public bool receivedOrder = false;
    public int orderIndex = 0;

    void Start(){}
    void Update(){}
    void OnDrawGizmos(){}

    public void StartOrdering(){
        objectFollower.SetNewTarget(orderNode.transform);
    }
    public void FinishOrdering(){
        objectFollower.SetNewTarget(exitNode.transform);
    }
}
