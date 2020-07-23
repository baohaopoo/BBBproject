using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Trap : MonoBehaviourPun
{
    private Animator TrapAnimator;


    void Start()
    {
        TrapAnimator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public IEnumerator TrapAnimation()
    {
        TrapAnimator.SetBool("trap_bite", true);
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        TrapAnimator.SetBool("trap_bite", false);
    }

        
        
    
}
