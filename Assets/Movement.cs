using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    CharacterController controller;
    public GameObject maincamera;
    bool groundedPlayer;
    public float speed,x,y,JumpHeight,gravityValue,TurnSpeed;
    Vector3 dir,move,playerVelocity,scale,rotateValue;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        scale = transform.localScale;
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
        dir = maincamera.gameObject.transform.forward;
        //Convert to local Space
        //dir = transform.InverseTransformDirection(dir);
        //Reset/Ignore y axis
        dir.y = 0;
        dir.Normalize();
        move = dir * Input.GetAxis("Vertical") + maincamera.gameObject.transform.right * Input.GetAxis("Horizontal");
            controller.Move(move * Time.deltaTime * 12.5f*speed);
            if (Input.GetButton("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * gravityValue);
            }
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        

        if (Input.GetKey("c"))
        {

            transform.localScale = new Vector3(scale.x,scale.y * 0.7f,scale.z);

        }else
        {
            transform.localScale =scale;
        }    

        

        x = x+Input.GetAxis("Mouse X");
        y = Mathf.Clamp(y+Input.GetAxis("Mouse Y"),-45f,45f);



        rotation = Quaternion.Euler(-y*TurnSpeed,x*TurnSpeed,0);
        transform.rotation=Quaternion.Euler(new Vector3(0,x*TurnSpeed,0));
        maincamera.transform.rotation = rotation;
    }
}
