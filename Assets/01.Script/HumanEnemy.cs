using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HumanEnemy : MonoBehaviour
{
    public LayerMask PlayerTarget;//추적대상 레이어
    private NavMeshAgent pathFinder;
    private Animator humanEnemyAnimator;
    private Transform targetTransform; 
    
    private void Awake()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        humanEnemyAnimator = GetComponent<Animator>();


    }
    public void Setup(float newSpeed)
    {
        //인간 생성할때 스피드 외부에서 정해주고 시작
        pathFinder.speed = newSpeed; 
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {
        pathFinder.isStopped = false;
        targetTransform = FindObjectOfType<PlayerController>().transform;
        pathFinder.SetDestination(targetTransform.position);
        
       //humanEnemyAnimator.SetBool("HasTarget", TargetinRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("잡았다 요놈");
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                //playerController.Die();
                gameObject.SetActive(false);

            }
        }
    }
}
