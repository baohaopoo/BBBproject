using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Photon.Pun;
using UnityStandardAssets.Utility;

public class videoHadler : MonoBehaviour
{
    private GameObject FollowCam; //main camera
    public UnityStandardAssets.Utility.SmoothFollow maincam;
    public RawImage mScreen = null;
    public VideoPlayer mVideoPlayer = null;
    //public GameObject player;
    // public Scene city;
    // private bool isend = false;
    private int cnt = 0;
    private GameObject PlayerPibot;
    // Start is called before the first frame update
    void Start()
    {
        if (mScreen != null && mVideoPlayer != null)
        {
            // 비디오 준비 코루틴 호출
            StartCoroutine(PrepareVideo());
        }



    }
    protected IEnumerator PrepareVideo()
    {
        // 비디오 준비
        mVideoPlayer.Prepare();

        // 비디오가 준비되는 것을 기다림
        while (!mVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer의 출력 texture를 RawImage의 texture로 설정한다

        mScreen.texture = mVideoPlayer.texture;
    }
    //public void PlayVideo()
    //{
    //    if (mVideoPlayer != null && mVideoPlayer.isPrepared)
    //    {

    //        // 비디오 재생
    //        mVideoPlayer.Play();
    //        Debug.Log("비디오 재생중..");
    //        mScreen.gameObject.SetActive(true);



    //    }
    //}

    //public void ChangeScene()
    //{
    //    Debug.Log("체인지?");
    //    SceneManager.LoadScene("city3");
    //}
    //public void StopVideo()
    //{
    //    if (mVideoPlayer != null && mVideoPlayer.isPrepared)
    //    {
    //        // 비디오 멈춤
    //        mVideoPlayer.Stop();
    //        mScreen.gameObject.SetActive(false);


    //    }
    //}
    // Update is called once per frame
    void Update()
    {

        if (!mVideoPlayer.isPlaying)
        {
            cnt += 1;

        }
        if (cnt >= 10)
        {
           // if (photonView.IsMine)
           // {

                FollowCam = GameObject.Find("MainCamera");
                PlayerPibot = GameObject.Find("playerpivot");
                FollowCam.GetComponent<SmoothFollow>().target = PlayerPibot.transform;


            //}
            UIManager.instance.EndMovie();
        }



    }
}