using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onco : MonoBehaviour
{
    public GameObject c;

    // Start is called before the first frame update
   public void OnTriggerEnter(Collider target){
    if(target.tag =="Player"){
        c.SetActive(false);
    }
   }
}
