
using UnityEngine;
using UnityEngine.Audio;

public class PlayerInputHandler : MonoBehaviour
{
    public GameObject playerObject;
    public Player player;
    public Transform cameraTransform;
    public float gravity = -9.8f;
    public Rigidbody rb;
    
   

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;
        Vector3 movement = Vector3.zero;
        

        if(Input.GetKey(KeyCode.W)){
           movement += cameraForward; 
        }

        if(Input.GetKey(KeyCode.S)){
            movement -= cameraForward;
        }

        if(Input.GetKey(KeyCode.A)){
            movement -= cameraRight;
        }

        if(Input.GetKey(KeyCode.D)){
           movement += cameraRight;
        }

        if(Input.GetKey(KeyCode.Space)){
            movement += cameraTransform.up;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){   //GetKeyDown only allows it to shoot one bullet per click
            player.Bullets();
        }
         
        player.Move(movement);

         
    }

   





}
