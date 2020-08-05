using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSit : MonoBehaviour
{
    private Animator humanAnimator;
    private float behaviorTime = 10f; //일정시간이 지나면 새로운 행동하기
    private float lastBehaviorTime; //마지막 행동 시점
    private VikingCrewDevelopment.Demos.SayRandomThingsBehaviour SaySomething;

    void Start()
    {
        humanAnimator = GetComponent<Animator>();
        SaySomething = GetComponent<VikingCrewDevelopment.Demos.SayRandomThingsBehaviour>();
    }

    void Update()
    {
        if (Time.time > lastBehaviorTime + behaviorTime)
        {
            lastBehaviorTime = Time.time;
            randomBehavor();
        }
    }

    private void randomBehavor()
    {
        int b = Random.Range(0, 2);
        if (b == 0)
        {
            humanAnimator.SetBool("FoldArm", false);
            humanAnimator.SetBool("OnPhone", true);

        }
        else
        {
            humanAnimator.SetBool("OnPhone", false);
            humanAnimator.SetBool("FoldArm", true);
        }

    }
}
