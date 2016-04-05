using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour
{

    public float speed = 10F;
    public float jumpSpeed = 11.0F;
    public float gravity = 20F;
    private float yVel = 0F; // Players current Y velocity

    private Vector3 vel = Vector3.zero;

    void FixedUpdate()
    {
        CharacterController cc = GetComponent<CharacterController>();

        //Horizontal Movement
        if (Input.GetButton("Horizontal") && Mathf.Abs(vel.x) < speed)
        {
            vel.x += Input.GetAxisRaw("Horizontal");
        } else {
            // friction stuff (TODO: Make neater)
            if (vel.x < -0.1)
            {
                vel.x++;
            }
            else if (vel.x > 0.1)
            {
                vel.x--;
            }
            else {
                vel.x = 0;
            }
            
        }

        //Vertical Movement
        if (Input.GetButton("Vertical") && Mathf.Abs(vel.z) < speed)
        {
            vel.z += Input.GetAxisRaw("Vertical");
        }
        else {
            // friction stuff (TODO: Make neater)
            if (vel.z < -0.1)
            {
                vel.z++;
            }
            else if (vel.z > 0.1)
            {
                vel.z--;
            }
            else {
                vel.z = 0;
            }

        }

        if (cc.isGrounded)
        {
            yVel = 0;

            if (Input.GetButton("Jump")) //Jumping
            {
                yVel = jumpSpeed;
            }

        }

        //Gravity
        yVel -= gravity * Time.deltaTime; 
        vel.y = yVel;

        //Add Movement
        cc.Move(vel * Time.deltaTime);

    }


}

