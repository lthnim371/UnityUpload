using UnityEngine;
using System.Collections;


public class ItemSlot : MonoBehaviour {

    private UISprite itemImage;
    public ItemInfo itemInfo;          //셋팅된 아이템 정보 ( null 이면 아이템이 해재된거 )

    private bool bCatched = false;     //너가 잡혀진 상태니?

    private TweenScale tweenScale;
   
    void Awake()
    {
        //Item UISprite 를 얻는다.
        this.itemImage = 
            this.transform.FindChild("ItemImage").GetComponent<UISprite>();


        int rand2 = Random.Range(0, 2);

        //빈아이템으로...
        if (rand2 == 0)
        {
            this.SetItemInfo(null);
        }

        //아이템 무작위 세팅
        else
        {
            // 랜덤하게 아이템 정보 셋팅
            int rand = Random.Range(0, 3);
            ItemInfo newItemInfo = new ItemInfo();


            if (rand == 0)
            {
                newItemInfo.name = "송대관의 빽구두";
                newItemInfo.type = 1;
            }

            else if (rand == 1)
            {
                newItemInfo.name = "송해의 어깨뽕";
                newItemInfo.type = 0;
            }

            else if (rand == 2)
            {
                newItemInfo.name = "태진아의 금팔찌";
                newItemInfo.type = 2;
            }

            this.SetItemInfo(newItemInfo);
        }


        this.tweenScale = this.GetComponent<TweenScale>();
        if (this.tweenScale != null)
            this.tweenScale.enabled = false;
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void SetItemInfo( ItemInfo itemInfo )
    {
        //셋팅된 아이템 정보 물린다.
        this.itemInfo = itemInfo;

        //아이템이 해제되었다면..
        if (this.itemInfo == null)
        {
            this.itemImage.enabled = false;
        }

        //아이템이 셋팅되었다면..
        else
        {
            //ㅅ활성화 시키고
            this.itemImage.enabled = true;

            //셋팅된 아이템 이미지로 교체
            this.itemImage.spriteName =
                ItemInfo.ItemType[this.itemInfo.type];

        }
        

    }


    //마우스로 해당 UIWidget 를 다운하거나 업했을때 호출하는 함수 ( NGUI UIWidget 전용 이벤트 )
    void OnPress(bool bDown)
    {
        if (bDown)
        {
            //아이템이 있는 스롯이니?
            if (this.itemInfo != null)
            {
                //아이템드레그 패널에 자신의 아이템 전송
                ItemDrag.Instance.CatchSlot(this);

                //나는 아이템 뺀다.
                this.SetItemInfo(null);


                bCatched = true;
            }



        }


        else
        {
            if (bCatched == true)
            {
                ItemDrag.Instance.ReleseSlot();
                this.bCatched = false;
            }
        }

    }


    public void TargetOn()
    {
        if (this.tweenScale != null)
        {
            this.tweenScale.PlayForward();      //앞방향으로 플레이
        }
    }

    public void TargetOff()
    {
        if (this.tweenScale != null)
        {
            this.tweenScale.PlayReverse();      //앞방향으로 플레이
        }
    }




}
