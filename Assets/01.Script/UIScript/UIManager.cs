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
    public GameObject damagedUI; // 데미지시 활성화할 UI 
    [SerializeField]
    public Image itemImage1; //아이템 1 이미지
    [SerializeField]
    public Image itemImage2; //아이템 2 이미지

    [SerializeField]
    public Text actionText;
    [SerializeField]
    public Text openText;

    public GameObject friendImage1;
    public GameObject friendImage2;
    public GameObject friendImage3;
    public GameObject friendImage4;
    public GameObject friendImage5;

    public void getitem(string name)
    {
        actionText.text = name + " 획득 " + "<color=yellow>" + "(E)" + "</color>";


    }
    public void openitem(string name)
    {
        openText.text = name + " 열기/닫기 " + "<color=yellow>" + "(Q)" + "</color>";

    }
    public void friendfind(string name)
    {
        actionText.text = name + "를 찾았다! " + "<color=yellow>" + "(E)" + "</color>"+"를 눌러!";
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


    public void UpdateHPSlider(int hp)
    {
        hpslider.value = hp;
    }

    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

    // 데미지 UI 활성화
    public void SetActiveDamagerUI(bool active)
    {
        damagedUI.SetActive(active);
    }

    // 게임 재시작
    //public void GameRestart()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}


    //이미지 투명도 조절 (이미지 비어있을땐 투명하게 한다)
    public void SetColor(float _alpha,Image _image)
    {
        Color color = _image.color;
        color.a = _alpha;
        _image.color = color;
    }

    public void AddItem1(Item _item)
    {
        itemImage1.sprite = _item.itemImage;
        SetColor(1, itemImage1); //아이템 보여준다.
    }

    public void AddItem2(Item _item)
    {
        itemImage2.sprite = _item.itemImage;
        SetColor(1, itemImage2); //아이템 보여준다.
    }
    public void UseItem1()
    {
        itemImage1.sprite = null;
        SetColor(0, itemImage1);
    }

    public void MoveItem2()
    {
        itemImage2.sprite = null;
        SetColor(0, itemImage2);
    }

    public void updateFriend(int n)
    {
        if (n == 1)
        {
            friendImage1.SetActive(true);
        }
        else if (n == 2)
        {
            friendImage2.SetActive(true);
        }
        else if (n == 3)
        {
            friendImage3.SetActive(true);
        }
        else if (n == 4)
        {
            friendImage4.SetActive(true);
        }
        else if (n == 5)
        {
            friendImage5.SetActive(true);
        }
    }
}