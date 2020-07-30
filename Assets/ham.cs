using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ham : MonoBehaviourPun
{
    public static ham instance = null;
    // Start is called before the first frame update
    public GameObject player;
    private Animator animator;

    void Start()
    {

        animator = player.GetComponent<Animator>();

    }

    public void hamani()
    {  
        
        photonView.RPC("hamgo", RpcTarget.All);
        Debug.Log("햄 애니가 켜집니까");
        


    }
    [PunRPC]
    public void hamgo()
    {
        this.gameObject.SetActive(true);
        animator.SetTrigger("isEat");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
