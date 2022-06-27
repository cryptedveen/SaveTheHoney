using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFlask : MonoBehaviour
{

    [SerializeField] GameObject Flask1, Flask2;
    // Start is called before the first frame update
    void Start()
    {
        Flask1.SetActive(false);
        Flask2.SetActive(false);
        
        Flask();

    }
    void Flask()
    {
        int selectflaskitem = Random.Range(0,2);

        //This will call the Spawn Enemy function of selected spawner.
        switch (selectflaskitem)
        {
            case 0: Flask1.SetActive(true); break;  
            case 1: Flask2.SetActive(true); break;
        }
    }
   

}
