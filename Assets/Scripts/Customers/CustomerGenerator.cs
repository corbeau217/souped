using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    public CustomerNode spawnNode;
    public CustomerNode orderNode;
    public CustomerNode exitNode;
    public GameObject customerPrefab;
    public Transform customerContainer;

    void Start(){}
    void Update(){}
    void OnDrawGizmos(){}

    public CustomerMovement SpawnCustomer(){
        GameObject newCustomer = (GameObject)Instantiate( customerPrefab, spawnNode.transform.position, spawnNode.transform.rotation, customerContainer );
        CustomerMovement movement = newCustomer.GetComponent<CustomerMovement>();
        if(movement==null){
            Debug.Log("spooky ghost customer "+newCustomer.name);
            return null;
        }
        movement.orderNode = orderNode;
        movement.exitNode = exitNode;

        // immediately start ordering
        movement.StartOrdering();

        // TODO : handle rolling our soup option

        // give it back
        return movement;
    }
}
