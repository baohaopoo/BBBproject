using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready, // 발사 준비
        Empty // 총알 없음
    }

    public State state { get; private set; } // 현재 총의 상태
    // ㄴ 외부에서는 읽을수 있지만 변경은 불가능하다.

    public Transform fireTransform; // 총알이 발사될 위치
    public ParticleSystem shellEjectEffect; // 탄피 배출 효과
    public ParticleSystem muzzleFlashEffect; // 총구 화염 효과

    private LineRenderer bulletLineRenderer; // 총알 궤적을 그리기 위한 렌더러

    [SerializeField]
    private GameObject HitEffect; //총에 맞았을때 나오는 효과

    [HideInInspector]
    public bool isFineSightMode = false;

    public int damage = 20; // 공격력
    private float fireDistance = 50f; // 사정거리

    public int bulletRemain = 5; // 남은 총알
    public int bulletCapacity = 5; // 총알 용량

    public float timeBetFire = 0.12f; // 총알 발사 사이의 시간간격
    public float lastFireTime = 0; // 총을 마지막으로 발사한 시점 


    private void Awake()
    {
        // 사용할 컴포넌트들의 참조를 가져오기
        bulletLineRenderer = GetComponent<LineRenderer>();

        bulletLineRenderer.positionCount = 2; //라인렌더러가 사용할 점의 수 
        bulletLineRenderer.enabled = false;


    }

    private void OnEnable()
    {
        // 총 상태 초기화
        state = State.Ready; //총의 상태 : 준비되어있음
        lastFireTime = 0;

    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            bulletRemain = 5;
        }

      
    }

    public void UpdateUI()
    {
        if (UIManager.instance != null)
        {

            UIManager.instance.updateBullet(bulletRemain);
        }
    }


    // 발사 시도
    public void Fire()
    {
        //마지막 발사 했을때에서 timeBetfire이상의 시간이 났을때 
        if( state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            //마지막 총 발사 시점 갱신
            lastFireTime = Time.time;

            Shot(); //쏴라!
        }
    }

    // 실제 발사 처리
    private void Shot()
    {
        //레이캐스트에 의한 충돌 정보 저장
        RaycastHit hit;
        //탄알이 맞은곳
        Vector3 hitPosition = Vector3.zero;

        //레이캐스트(시작지점, 방향 ,충돌정보, 거리)
        if (Physics.Raycast(fireTransform.position,fireTransform.forward,out hit, fireDistance))
        {

            //피격 이벤트 생성
            //Instantiate(생성할 오브젝트, 생성될 위치, 어느 방향으로?)
            Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));


            //레이가 물체에 닿은경우에는 True, 아님 Fasle 
            //충돌체로부터 Damageable 가져오기 
            Damageable target = hit.collider.GetComponent<Damageable>();
            if (target != null) //충돌체가 Damaeable 컴포넌트 가지고 있으면
            {
                //상대방의 OnDamge 함수 실행시켜서 데미지 입히기//
                //탄알의 데미지, 탄알이 맞은 위치, 탄알이 맞은 방향
                target.OnDamage(damage, hit.point, hit.normal);

            }

            //레이가 충돌한 위치 저장
            hitPosition = hit.point;

        }
        else
        {
            //레이가 다른물체와 충돌하지 않았다면 
            //탄알이 최대 사정거리까지 날아갔을때의 위치를 충돌위치로 두기
            hitPosition = fireTransform.position + fireTransform.forward* fireDistance;
        }

        //발사 이펙트 재생
        StartCoroutine(ShotEffect(hitPosition));

        //탄알의 수 -1 
        bulletRemain -= 1;
        UpdateUI();
        if (bulletRemain <= 0)
        {
            //총알이 남은게 없다면 현재상태 Empty
            state = State.Empty;
        }
    }

    
    // 발사 이펙트와 총알 궤적을 그린다    //코루틴사용
    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        shellEjectEffect.Play(); //탄피 배출 효과 재생
        muzzleFlashEffect.Play();

        //탄알 궤적 그리기
        //라인의 시작점은 총구에 위치한다. 
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        //라인의 끝점은 입력으로 들어온 충돌에 위치한다. 
        bulletLineRenderer.SetPosition(1, hitPosition);
        bulletLineRenderer.enabled = true;


        // 0.03초 동안 잠시 처리를 대기
        yield return new WaitForSeconds(0.03f);

        // 라인 렌더러를 비활성화하여 총알 궤적을 지운다
        bulletLineRenderer.enabled = false;
    }

}
