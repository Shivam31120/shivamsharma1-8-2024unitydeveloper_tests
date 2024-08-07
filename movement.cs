using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController cc;
   public Transform cam;
   public float runSpeed = 4f;
   public float st = 0.2f;
    float tsVelocity;
    public Animator aa;
    
    

    void Start(){
        aa =GetComponent<Animator>();
        cc=GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 m =new Vector3(h,0f,v).normalized;
        
        if(m.magnitude>=0.1f){
            float t = Mathf.Atan2(m.x,m.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f,t,0f);
            float ang = Mathf.SmoothDampAngle(transform.eulerAngles.y,t,ref tsVelocity,st);
            transform.rotation = Quaternion.Euler(0f,t,0f);

            Vector3 movdi = Quaternion.Euler(0f,t,0f)* Vector3.forward.normalized;

            cc.Move(movdi*runSpeed*Time.deltaTime);

        }
        aa.SetFloat("sp",m.magnitude);
        
    }
}
