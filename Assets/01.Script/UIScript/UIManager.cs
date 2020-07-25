using UnityEngine;
using UnityEngine.UI; // UI 관련 코드

// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIManager : MonoBehaviour
{
    // 싱글톤 접근용 프로퍼티
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수

    [SerializeField]
    public Slider hpslider; //hp슬라이더 
    [SerializeField]
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 
    [SerializeField]
    public GameObject BulletUI; //bulletUI 
    public GameObject bulletImage1;
    public GameObject bulletImage2;
    public GameObject bulletImage3;
    public GameObject bulletImage4;
    public GameObject bulletImage5;

    [SerializeField]
    public Text actionText;
    [SerializeField]
    public Text openText;

    private Inventory theInventory;

    public void getitem(string name)
    { 
     actionText.text = name + " 획득 " + "<color=yellow>" + "(E)" + "</color>";


    }
    public void openitem(string name)
    { 
        openText.text = name + " 열기/닫기 " + "<color=yellow>" + "(Q)" + "</color>";

    }
    public void onactiontxt()
    {
        actionText.gameObject.SetActive(true);    
    }
    public void offactiontxt()
    {
        actionText.gameObject.SetActive(false);
    }
    public void onopentxt()
    {
        openText.gameObject.SetActive(true);
    }
    public void offopentxt()
    {
        openText.gameObject.SetActive(false);
    }


    public void updateBullet(int sb)
    {

        if (sb == 5)
        {

        }
        else if (sb == 4)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(true);
            bulletImage4.SetActive(true);
            bulletImage5.SetActive(false);
        }
        else if (sb == 3)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(true);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 2)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 1)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(false);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 0)
        {
            bulletImage1.SetActive(false);
            bulletImage2.SetActive(false);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }


    }
    public void UpdateHPSlider(int hp)
    {
        hpslider.value = hp;
    }

    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

    // 게임 재시작
    //public void GameRestart()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}