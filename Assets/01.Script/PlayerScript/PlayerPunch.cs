using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    private Animator playerAnimator;
    public GameObject punchCollider;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Punching();
        }
        if (Input.GetMouseButtonUp(0))
        {
            punchCollider.SetActive(false);
        }     
    }

    private void Punching()
    {
        punchCollider.SetActive(true);
        playerAnimator.SetTrigger("isPunch");
        Debug.Log("펀찌");
        
    }
}
