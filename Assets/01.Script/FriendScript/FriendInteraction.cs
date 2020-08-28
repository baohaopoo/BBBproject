using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendInteraction : MonoBehaviour
{
    public GameObject myCam;
    private Animator bearAnimator;

    private void Start()
    {
        bearAnimator = GetComponent<Animator>();
    }
    public void FriendOff()
    {
        gameObject.SetActive(false);
    }
    public void CamOn(bool onoff)
    {
        myCam.SetActive(onoff);
    }
    public void MeetAnim()
    {
        bearAnimator.SetTrigger("find");
    }
}
