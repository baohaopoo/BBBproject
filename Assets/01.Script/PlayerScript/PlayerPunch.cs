using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerPunch : MonoBehaviourPun
{
    private Animator playerAnimator;
    public GameObject punchCollider;
   // bool punchseton = false;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        //punchCollider.SetActive(punchseton);
    }

    void Update()
    {
        // 로컬일때
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0)) //키를 누르면
            {
                onpunch();
             

            }

            if (Input.GetMouseButtonUp(0))
            {
                offpunching();


            }
        }
            
     }




    private void onpunch()
    {

        photonView.RPC("Punchging", RpcTarget.All);

    }

    private void offpunching()
    {

        photonView.RPC("Punchgingoff", RpcTarget.All);

    }


    [PunRPC]
    public void Punchging()
    {

      
        punchCollider.SetActive(true);
        playerAnimator.SetTrigger("isPunch");



    }


    [PunRPC]
    public void Punchgingoff()
    {


        punchCollider.SetActive(false);



    }


}
