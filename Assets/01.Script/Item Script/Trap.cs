using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator TrapAnimator;


    void Start()
    {
        TrapAnimator = GetComponent<Animator>();
    }
 
    public IEnumerator TrapAnimation()
    {
        TrapAnimator.SetBool("trap_bite", true);
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        TrapAnimator.SetBool("trap_bite", false);

        //물리면 파괴되게 함
        //if (TrapAnimator.GetBool("trap_bite") == false)
        //{
        //    Destroy(gameObject);
        //}
        
    }

        
        
    
}
