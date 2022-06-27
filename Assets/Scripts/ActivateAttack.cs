using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAttack : MonoBehaviour
{

    public BoxCollider2D THand,BHand,TLeg,BLeg;

    private void Start()
    {
        THand.enabled = false;
        BHand.enabled = false;
        TLeg.enabled = false;
        BLeg.enabled = false;
    }
    public void HandCollidersActivate()
    {

        THand.enabled = true;
        BHand.enabled = true;
    }

    public void HandCollidersStop()
    {
        
            THand.enabled = false;
            BHand.enabled = false;
        
            
    }

    public void LegCollidersActivate()
    {
        TLeg.enabled = true;
        BLeg.enabled = true;
    }

    public void LegCollidersStop()
    {
        
            TLeg.enabled = false;
            BLeg.enabled = false;
        
        
    }
}

