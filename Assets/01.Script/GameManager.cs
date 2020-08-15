using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;


public class GameManager : MonoBehaviourPunCallbacks//, IPunObservable
{
    public Gun guninstance;


    //싱글톤 접근용 프로퍼티
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    public bool isGameover; // 게임 오버 상태


    public GameObject playerPrefab; //생성할 게임플레이어 


    //주기적으로 자동 실행되는 동기화 메서드
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        //로컬 부분이라면 쓰기 부분이 실행
        if (stream.IsWriting)
        {
            //네트워크를 통해 score값 보내기
            //stream.SendNext(score);
            stream.SendNext(guninstance.bulletRemain);
        }
        else
        {
            //리모트 오브젝트라면 읽기 부분이 실행됨
            //네트워크를 통해 score값 받기
            //score = (int)stream.ReceiveNext();
            guninstance.bulletRemain = (int)stream.ReceiveNext();
        }
        // UIManager.instance.UpdateScoreText(score);
    }

    void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }
    void Start()
    {
   
        Vector3 randomPos;

        randomPos.x = 88.2153f;
        randomPos.y = 4.39109f;
        randomPos.z = 453.567f;
 
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);

       
        
    }

}
