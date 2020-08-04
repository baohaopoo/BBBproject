using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanWalk : MonoBehaviour
{
    private Animator humanAnimator;
    private float speed = 3f;
    private Quaternion rotation;
    private Rigidbody humanRigidbody;
    private bool isWalking;
    private float behaviorTime = 8f; //일정시간이 지나면 새로운 행동하기
    private float lastBehaviorTime; //마지막 행동 시점

    void Start()
    {
        humanRigidbody = GetComponent<Rigidbody>();
        humanAnimator = GetComponent<Animator>();
        rotation = this.transform.rotation;
        isWalking = true;
    }


    private void Update()
    {
        if (Time.time > lastBehaviorTime + behaviorTime)
        {
            lastBehaviorTime = Time.time;
            randomBehavor();
        }

        if (isWalking)
        {
            Walking();
        }
    }


    private void Walking()
    {
        humanAnimator.SetBool("walk", true);
        Vector3 moveDistance = transform.forward * speed * Time.deltaTime;
        humanRigidbody.MovePosition(humanRigidbody.position + moveDistance);
    }

    private void randomBehavor()
    {
        //중간중간 멈춰서 행동
        int b = Random.Range(0, 3);
        if (b == 0)
        {
            isWalking = false;
            humanAnimator.SetBool("walk", false);
        }
        else
        {
            isWalking = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BackOrRight")
        {
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                turn360();
            }
            else if (r == 1)
            {
                turnRight();
            }
        }
        else if (other.tag == "BackOrLeft")
        {
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                turn360();
            }
            else if (r == 1)
            {
                turnLeft();
            }
        }
        else if (other.tag == "Left")
        {
            turnLeft();
        }
        else if (other.tag == "Right")
        {
            turnRight();
        }
        else if (other.tag == "Back")
        {
            turn360();
        }

    }

    private void turn360()
    {
        transform.rotation = rotation * new Quaternion(0, 1, 0, 0);
    }
    private void turnRight()
    {
        transform.Rotate(0, 45, 0);
    }
    private void turnLeft()
    {
        transform.Rotate(0, -45, 0);
    }
}