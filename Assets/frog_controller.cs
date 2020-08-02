using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_controller : MonoBehaviour
{

    //distance함수 + 코루틴 함수 + 레이캐스트



    private GameObject Target; //플레이어
    public float attackdist = 10; //공격사정거리
    public float tracingdist = 10; //추적 거리
    Vector3 frogPosition;
    Vector3 TargetPosition;
    Vector3 dist;

    // Start is called before the first frame update
    void Start()
    {
        frogPosition = gameObject.transform.position;
    }


    // Update is called once per frame
    void Update()
    {

        Vector3 newPos = frogPosition + dist;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {


            Debug.Log("공격및 따라오기");

           dist =  other.transform.position - frogPosition;

            //Vector3 goal = frogPosition + dist;
            //frogPosition = Vector3.Lerp(frogPosition, goal, 5 * Time.deltaTime);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    transform.position = transform.position+ frogPosition + dist;
    //}
    public void distance(Vector3 position1, Vector3 position2)
    {

        float dist = Vector3.Distance(position1, position2);

        if (dist <= attackdist)
        {
            Debug.Log("공격할까요");
            //공격시작
        }
        else if (dist <= tracingdist)
        {
            //추적시작
            Debug.Log("추적할까요");
        }
        else
        {
            //추적 범위를 벗어남. 적 대기 상태 돌입.
            Debug.Log("대기합시다");
        }
    
        
    
    }
}
