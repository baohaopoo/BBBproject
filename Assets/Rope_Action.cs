using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 줄을 잡으면 줄이 흔들흔들, 플레이어의 애니메이션이 바뀜
public class Rope_Action : MonoBehaviour
{

    GameObject Player;
    Animator playeranimator;
    bool isRope;
    Rigidbody roperigidbody;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //플레이어 객체 소환
        playeranimator = GetComponent<Animator>();
        roperigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {


        //rigidbody.velocity = new Vector3(0, 0, 1);
        //rigidbody.AddForce(new Vector3(0, 0, 1));


        //this.gameObject.transform.Translate(Vector3.up * 0.03f * Time.deltaTime);

        // this.gameObject.transform.Rotate(Vector3.left * 3f * Time.deltaTime );

     
       

        if (isRope)
        {
          //  playeranimator.SetBool("isRope", isRope);


            if (transform.localRotation.x < -92f)
            {
                direction = -1;
            }
            else if (transform.localRotation.x > 99)
            {
                direction = 1;
            }

            this.gameObject.transform.Rotate(Vector3.left * direction * 1f * Time.deltaTime);

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            Debug.Log("Enter player");
            //playeranimator.SetFloat("", playerInput.move);

            isRope = true;
            //Player.transform.position += new Vector3(0,1,0);
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("out player");
        isRope = false;
    }
    //private void OnCollisionExit(Collider other)
    //{
      
    //}

   
}
