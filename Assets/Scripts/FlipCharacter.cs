using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{

   [SerializeField] bool facingRight, facingLeft;
  public void FlipRight()
    {
        if (facingLeft)
        {
            gameObject.transform.Rotate(0f, 180f, 0f, Space.Self);

            facingLeft = false;
            facingRight = true;

        }
        
    }

    public void FlipLeft()
    {
        if (facingRight)
        {
            gameObject.transform.Rotate(0f, 180f, 0f, Space.Self);

            facingLeft = true;
            facingRight = false;

        }
        
    }
}
