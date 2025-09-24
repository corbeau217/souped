using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerService : MonoBehaviour
{
    public ChecklistStatus checklistStatus;
    public ComboCounter derekCounter;
    public ComboCounter playerCounter;
    [Space(10)]
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
        bool haveSoup = soupInventory.HaveSoupToServe( soupIndex );
        bool wantsSoup = currentCustomer.WantsSoup(soupIndex);
        if( haveSoup ){
            soupInventory.ServeSoup(soupIndex);
            currentCustomer.FinishOrdering(soupIndex);

            // regardless of soup served, derek gets a star
            if(derekCounter!=null){ derekCounter.IncreaseCombo(); }
            if(playerCounter!=null){
                // if it wasnt the right soup, break our combo
                if((!wantsSoup)){
                    playerCounter.ResetCombo();
                    // TODO : say it was bad somehow
                }
                else {
                    // otherwise mark the checklist item as done
                    if(checklistStatus!=null){ checklistStatus.MarkItemDone(2); }
                }
            }

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
