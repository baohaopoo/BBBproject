using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName; //아이템이름
    public ItemType itemType; //아이템 유형
    public Sprite itemImage; //아이템 이미지
    public GameObject itemPrefab; //아이템 프리팹

    public string weaponType; //무기 유형

    public enum ItemType { 
    
        Attack,
        Equipment,
        Etc
    
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
