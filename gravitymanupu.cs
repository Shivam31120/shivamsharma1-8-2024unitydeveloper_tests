using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitymanupu : MonoBehaviour
{
    public CharacterController holo;
    public GameObject d;
    public float rotationspeed=2f;
    public CharacterController cc;
    public Transform cd;
     private Vector3 velocity;
    public float  gravity = -14f;
    // Start is called before the first frame update
    void Start()
    {
        holo = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            
            transform.rotation = Quaternion.Euler(0f,0f,90f);
           
        }
         if(Input.GetKeyDown(KeyCode.RightArrow)){
            
            transform.rotation = Quaternion.Euler(0f,0f,-90f);
        }
         if(Input.GetKeyDown(KeyCode.UpArrow)){
            
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            
            transform.rotation = Quaternion.Euler(0f,0f,180f);
        }
         if(Input.GetKeyDown(KeyCode.Return)){
            cd.rotation *= transform.rotation;
            
            

            
           // cc.Move(movdi*Time.deltaTime);
            
         }
         
    }

        
    
    /*public void EnableGameObject(){
        if(holo.isGrounded == false ){
            d.SetActive(true);
        }
    }*/
    public void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            d.SetActive(false);
        }
    }
    
        
    
    /*public void SetActiveState(bool isActive)
    {
        if (holo.isGrounded == false)
        {
            d.SetActive(isActive);
        }
    }*/
    
}
