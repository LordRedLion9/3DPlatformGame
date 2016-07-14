using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerControllerRotating : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    float runningSpeed = 10F;
    float jumpSpeed = 5F;
    float gravity = 12F;
    float yVel = 0F;


   private CharacterController cc;



    private void start()
    {
       
    }

    void Update()
    {
        move();            

    }

    void move()
    {

        cc = this.GetComponent<CharacterController>();

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        rotate(moveDirection);

        if (cc.isGrounded)
        {
            yVel = 0;

            if (Input.GetButton("Jump"))
            {
                yVel = jumpSpeed;
            }

        }


        yVel -= gravity * Time.deltaTime;
        moveDirection.y = yVel;
        cc.Move((moveDirection * runningSpeed) * Time.deltaTime);
    }



    void rotate(Vector3 moveDirection)
    {
        
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

}


