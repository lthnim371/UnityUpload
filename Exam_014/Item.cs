using UnityEngine;
using System.Collections;


//아이템 정보 클래스
public class ItemInfo{
    public int type = 0;            //아이템 타입이 어떻게 되는가?
    public string name = "";        //아이템 이름


    public static string[] ItemType = {
                                          "Orc Armor - Shoulders",
                                          "Orc Armor - Boots",
                                          "Orc Armor - Bracers"
                                      };
}

public class Item : MonoBehaviour {

    public ItemInfo itemInfo;                   //자신에게 물린 아이템 정보
    private UISprite itemImageSprite;            //아이템 이미지 스프라이트
    private UILabel itemNameLabel;               //아이템 이름 라벨

    void Awake()
    {
        this.itemNameLabel = this.transform.FindChild("ItemName").GetComponent<UILabel>();
        this.itemImageSprite = this.transform.FindChild("ItemImage").GetComponent<UISprite>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetItemInfo(ItemInfo item)
    {
        //셋팅되는 아이템
        this.itemInfo = item;

        //아이템 타입에 따라 이미지를 결정한다.
        this.itemImageSprite.spriteName = ItemInfo.ItemType[this.itemInfo.type];

        //위에서 문자열로 사용되는 이미지를 결정하고 아래의 명령을 실행시키면..
        //셋팅된이미지의 원본 크기로 자동으로 맞춰준다.
        //this.itemImageSprite.MakePixelPerfect();


        //아이템 이름도 셋팅
        this.itemNameLabel.text = this.itemInfo.name;


    }

    //아이템 삭제시 실행.....
    public void DelteItem()
    {
        //자신의 부모에게 자신을 죽일것을 요청
        //Destroy(this.gameObject);

        ItemList itemList = this.transform.parent.GetComponent<ItemList>();

        if (itemList != null)
        {
            itemList.DeleteItem(this);
        }
    }
}
