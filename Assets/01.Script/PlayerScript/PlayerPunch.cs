using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerPunch : MonoBehaviourPun
{
    private Animator playerAnimator;
    public GameObject punchCollider;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Punching();
                gopunch();
            }
            if (Input.GetMouseButtonUp(0))
            {
                punchCollider.SetActive(false);
            }
        }
    }


    public void gopunch()
    {

        photonView.RPC("Punching", RpcTarget.All);
    
    }
    [PunRPC]
    private void Punching()
    {
        punchCollider.SetActive(true);
        playerAnimator.SetTrigger("isPunch");
        Debug.Log("펀찌");
        
    }
}
