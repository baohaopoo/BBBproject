using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private GameObject player;
    private bool tied = false;
    private Animator TrapAnimator;
    private Animator playerAnimator;
    private frog_controller frog;

    private void Start()
    {
        TrapAnimator = GetComponent<Animator>();
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

        else if (other.tag == "frog")
        {
            other.gameObject.transform.position = this.gameObject.transform.position;
            frog = other.gameObject.GetComponent<frog_controller>();
            StartCoroutine(frogOnTrap());
        }
    }

    private IEnumerator frogOnTrap()
    {
        
        TrapAnimator.SetBool("trap_bite", true);
        frog.target = null;
        frog.Ontrap = true;
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        TrapAnimator.SetBool("trap_bite", false);
        frog.Ontrap = false;
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
