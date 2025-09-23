using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerService : MonoBehaviour
{
    public CustomerGenerator customerGenerator;
    public SoupInventory soupInventory;
    [Space(10)]
    public CustomerMovement currentCustomer;
    [Space(10)]
    public GameObject serveMenu;
    public GameObject requestMenu;

    [Space(20)]
    public GameObject errorToast;
    public float errorToastLength = 2f;
    public float errorToastRemaining = 0f;

    void Start(){}
    void Update(){
        if(currentCustomer==null){
            serveMenu.SetActive(false);
            requestMenu.SetActive(true);
        }
        // clamp 0 or more
        errorToastRemaining = Mathf.Max( (errorToastRemaining-Time.deltaTime), 0f );
        // change active by if it is more than 0 seconds
        errorToast.SetActive( (errorToastRemaining>0f) );
    }

    public void ServeCurrentCustomer(int soupIndex){
        if( soupInventory.HaveSoupToServe( soupIndex ) && currentCustomer.WantsSoup(soupIndex) ){
            soupInventory.ServeSoup(soupIndex);
            currentCustomer.FinishOrdering(soupIndex);

            serveMenu.SetActive(false);
            requestMenu.SetActive(true);
        }
        else {
            NeedSoupError(soupIndex);
        }
    }
    public void RequestCustomer(){
        this.currentCustomer = this.customerGenerator.SpawnCustomer();

        serveMenu.SetActive(true);
        requestMenu.SetActive(false);
    }
    public void NeedSoupError(int soupIndex){
        // toast a text message saying that we need more soup
        errorToastRemaining = errorToastLength;
    }
}
