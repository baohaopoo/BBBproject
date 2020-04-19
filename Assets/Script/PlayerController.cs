using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    public float jumpPower = 5f;

    Rigidbody rigdbody;
    Collider col;

    Vector3 movement;
    float horizontalMove;
    float verticalMove;
    bool isJumping;

    void Awake()
    {
        rigdbody = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");


        if (Input.GetButtonDown("Jump"))
            isJumping = true;
        
    }

    void FixedUpdate()
    {
      //물리만 다루는 곳.
        Run();
        Jump();
        Turn();
    }

    void Run()
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;

        rigdbody.MovePosition(transform.position + movement);

    
    }

    void Jump()
    {
        if (!isJumping)
            return;

        rigdbody.MovePosition(transform.position + Vector3.up); //단순높이
        rigdbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;
    
    
    }

    void Turn()
    {

        if (horizontalMove == 0 && verticalMove == 0)
            return;
         
        Quaternion playerRotation = Quaternion.LookRotation(movement);
        rigdbody.rotation = Quaternion.Slerp(rigdbody.rotation, playerRotation, Time.deltaTime);
  
    }
}
