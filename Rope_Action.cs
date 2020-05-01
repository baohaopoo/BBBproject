using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 줄을 잡으면 줄이 흔들흔들, 플레이어의 애니메이션이 바뀜
public class Rope_Action : MonoBehaviour
{

    GameObject Player;
    Animator playeranimator;
    bool isRope;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //플레이어 객체 소환
        playeranimator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if (isRope)
        {
            playeranimator.SetBool("isRope", isRope);
        }

  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("Enter player");
            //playeranimator.SetFloat("", playerInput.move);

            isRope = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out player");
        isRope = false;
    }
}
