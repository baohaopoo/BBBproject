using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTied : MonoBehaviour
{

    private GameObject player;
    public GameObject trap;
    private Trap trapAnimation;
    private bool tied = false;

    private void Start()
    {
        trapAnimation = GetComponent<Trap>();
    }
    private void Update()
    {
        if (tied == true)
        {
            player.transform.SetParent(trap.transform);
            player.transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            player =other.gameObject;
            StartCoroutine(playerOnTrap());
            StartCoroutine(trapAnimation.TrapAnimation());

        }
    }

    private IEnumerator playerOnTrap()
    {
        tied = true;
        yield return new WaitForSeconds(3f);//3초동안 기다린다 
        tied = false;
        player.transform.parent=null;
    }
}