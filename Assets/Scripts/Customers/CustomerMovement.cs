using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public ObjectFollower objectFollower;
    public CustomerNode orderNode;
    public CustomerNode exitNode;

    public bool receivedCorrectOrder = false;
    public int orderIndex = 0;

    void Start(){}
    void Update(){}
    void OnDrawGizmos(){}

    public void StartOrdering(){
        objectFollower.SetNewTarget(orderNode.transform);
    }
    public bool FinishOrdering( int soupIndex ){
        receivedCorrectOrder = (orderIndex==soupIndex);
        objectFollower.SetNewTarget(exitNode.transform);
        return receivedCorrectOrder;
    }
    public bool WantsSoup( int soupIndex ){
        return (orderIndex==soupIndex);
    }
}
