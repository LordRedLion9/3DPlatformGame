using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour
{

    public float speed = 10F;
    public float jumpSpeed = 18.0F;
    public float gravity = 40F;
    private float yVel = 0F; // Players current Y velocity

    public float rollTimer = 0;
    public float rollDistance = 15F;
    public float rollTime = 0.5F;
    public bool rolling = false;

    private Vector3 vel = Vector3.zero;

    void FixedUpdate()
    {
        CharacterController cc = GetComponent<CharacterController>();

        if (rolling) //In Rolling state
        {
            rollTimer -= Time.deltaTime;
            
            if (vel.x > 0.1) { vel.x -= 1; }
            if (vel.x < -0.1) { vel.x += 1; }
            if (vel.z > 0.1) { vel.z -= 1; }
            if (vel.z < -0.1) { vel.z += 1; }
            

            if (rollTimer <= 0)
            {
                rolling = false;
                rollTimer = 0;
            }
            
        }

        else { //In Normal state


            //Horizontal Movement
            if (Input.GetButton("Horizontal") && Mathf.Abs(vel.x) < speed)
            {
                vel.x += Input.GetAxisRaw("Horizontal");
            }
            else {
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

                if (Input.GetButton("Fire3")) //rolling
                {
                    rolling = true;
                    rollTimer = rollTime;
                    vel = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * (rollDistance / rollTime);
                }

            }

            
            

        }
        //Gravity
        yVel -= gravity * Time.deltaTime;
        vel.y = yVel;

        //Add Movement
        cc.Move(vel * Time.deltaTime);
    }

}

