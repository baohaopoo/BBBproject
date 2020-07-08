﻿using UnityEngine;

// 주어진 Gun 오브젝트를 쏘거나 재장전
public class PlayerShooter : MonoBehaviour
{
    GameObject playerGrabPoint;
    public Gun gun; // 사용할 총

    private PlayerController playerController;
    private Animator playerAnimator; // 애니메이터 컴포넌트

    private void Start()
    {
        // 사용할 컴포넌트들을 가져오기
        playerGrabPoint = GameObject.FindGameObjectWithTag("grabPoint"); //플레이어 총잡을 부분 객체 소환

        playerController = GetComponent<PlayerController>();
        //playerAnimator = GetComponent<Animator>();
    }

   // private void OnEnable()
   // {
   //     // 슈터가 활성화될 때 총도 함께 활성화
   //     gun.gameObject.SetActive(true);
   //}

   // private void OnDisable()
   // {
   //     // 슈터가 비활성화될 때 총도 함께 비활성화
   //     gun.gameObject.SetActive(false);
   // }

    private void Update()
    {
        if (playerController.isUseGun)
        {
            gun.gameObject.SetActive(true);
            gun.transform.SetParent(playerGrabPoint.transform);
            gun.transform.localPosition = new Vector3(-0.53f, -0.82f, 0.22f);
            gun.transform.rotation = FindObjectOfType<PlayerController>().transform.rotation;

        }
        if (playerController.isUseGun == false)
        {
            gun.gameObject.SetActive(false);
        }
    }

    // 탄약 UI 갱신
    private void UpdateUI()
    {
        //if (gun != null && UIManager.instance != null)
        //{
        //    // UI 매니저의 탄약 텍스트에 탄창의 탄약과 남은 전체 탄약을 표시
        //    UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);
        //}
    }

}