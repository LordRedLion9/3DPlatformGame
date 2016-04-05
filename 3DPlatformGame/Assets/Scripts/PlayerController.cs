using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 7;
    public float jumpSpeed = 8.0F;
    public float gravity = 20F;
    private float yVel = 0;

    private Vector3 moveDirection = Vector3.zero;

    void FixedUpdate()
    {
        CharacterController cc = GetComponent<CharacterController>();
        Vector3 vel = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed;

        if (cc.isGrounded)
        {
            yVel = 0;

            if (Input.GetButton("Jump"))
            {
                yVel = jumpSpeed;
            }

        }

        yVel -= gravity * Time.deltaTime;
        vel.y = yVel;

        cc.Move(vel * Time.deltaTime);

    }


}

