using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceCounter : MonoBehaviour
{
    public SoupInventory soupInventory;

    void Start(){}
    void Update(){}
    
    public bool OfferingSoup(int soupIndex){
        return ((soupIndex >= 0 )&&(soupInventory.soupOptionCount > soupIndex));
    }
    public bool ServeSoup(int soupIndex){
        return soupInventory.ServeSoup(soupIndex);
    }
}
