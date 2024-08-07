using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public CharacterController cc;
 
    public float jump = 2f;
    public Animator aa;
    private Vector3 velocity;
    public float  gravity = -14f;
   
    

    // Start is called before the first frame update
    void Start()
    {
        cc =GetComponent<CharacterController>();
        
        aa= GetComponent<Animator>();
    }

    
    void Update()
    {
         bool isjump =Input.GetKeyDown(KeyCode.Space);
         
        
        if(cc.isGrounded){
            velocity.y -= gravity*Time.deltaTime;
            
            if(isjump){
               // uVelocity = jump;
                velocity.y = Mathf.Sqrt(jump*gravity*-2f);
                
            }
            if(velocity.y<0){
                velocity.y = -2f;
            }

        }
        else{
            velocity.y += gravity*Time.deltaTime;
        }
       // Vector3 move = new Vector3(0,uVelocity,0);
        cc.Move(velocity*Time.deltaTime);
        
        aa.SetBool("jump",isjump);
    }
}
