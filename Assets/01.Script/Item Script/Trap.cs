using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private GameObject player;
    private bool tied = false;
    private Animator TrapAnimator;
    private Animator playerAnimator;

    private void Start()
    {
        TrapAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (tied)
        //{
        //    player.transform.localPosition = Vector3.zero;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            player.transform.position = this.gameObject.transform.position;
            player.GetComponent<PlayerInput>().blockKey = true;
            playerAnimator = player.GetComponent<Animator>();
            StartCoroutine(playerOnTrap());

        }
    }


    private IEnumerator playerOnTrap()
    {
        TrapAnimator.SetBool("trap_bite", true);
        playerAnimator.SetBool("OnTrap",true);
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        TrapAnimator.SetBool("trap_bite", false);
        playerAnimator.SetBool("OnTrap", false);
        player.GetComponent<PlayerInput>().blockKey = false;
    }

}
