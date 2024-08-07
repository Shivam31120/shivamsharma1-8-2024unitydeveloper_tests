using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
     public float speed;
    private CharacterController cc;
    public float s;
    public Transform cd;
    public float gravity;
    public float jump;
    float xrot = 0f;
    float yrot = 0f;
    float maxjump = 1;
    float jumpremain;
    public float jumpForce = 5f;
    public LayerMask groundLayers;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        cc=GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
       Vector3 movement = transform.right*x + transform.forward*-1*z;
        

        float mousex = Input.GetAxisRaw("Mouse X")*s*Time.deltaTime;
        float mousey = Input.GetAxisRaw("Mouse Y")*s*Time.deltaTime;

        xrot -=mousey;
        xrot = Mathf.Clamp(xrot,-90f,90f);
        yrot +=mousex;
        



        
       
        transform.localRotation = Quaternion.Euler(xrot,0f,0f);
        cd.Rotate(0f,yrot,0);

        cc.Move(movement*speed*Time.deltaTime);
        Physics.gravity = new Vector3(0f,gravity,0f);

        if(cc.isGrounded == false){
           cc.Move(Physics.gravity* Time.deltaTime) ;
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            cd.rotation = transform.rotation;}

       
        CheckGroundStatus();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ensure the character stays grounded
        }
        
        if (cc.isGrounded  && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        
       
        

        
    }
    void Jump()
    {
       velocity.y = Mathf.Sqrt(gravity*jumpForce*-2f*Time.deltaTime);
       cc.Move(velocity*Time.deltaTime);
    }
    void CheckGroundStatus()
    {
        
    }
}
