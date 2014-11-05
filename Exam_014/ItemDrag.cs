using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDrag : MonoBehaviour {

    private static ItemDrag sInstance;
    public static ItemDrag Instance
    {
        get { return sInstance; }
    }



    private UISprite itemImage;
    private ItemInfo itemInfo;          //셋팅된 아이템 정보 ( null 이면 아이템이 해재된거 )

    private ItemSlot catchSlot;         //집은 슬롯이 누구니?

    public List<ItemSlot> targetList;   //놓았을때 들러갈 놈들 후보 ( 이중에 제일 거리가 작은 에슬롯에 들어간다 )

    private ItemSlot target;            //최종 걸리는 놈

    void Awake()
    {
        //sInstance 에 자신을 문다.
        sInstance = this;

        //Item UISprite 를 얻는다.
        this.itemImage =
            this.transform.FindChild("ItemImage").GetComponent<UISprite>();
        
        //비활성화로 시작한다.
        this.gameObject.SetActive(false);
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.targetList.Count != 0)
        {
            //제일 가까운놈을 찾아라....
            
            //일단 첫번째 놈....
            this.target = null;
            float miniumDistance = Mathf.Infinity;

            for (int i = 0 ; i < this.targetList.Count; i++)
            {
                this.targetList[i].TargetOff();

                //거리
                float nowDistance = (targetList[i].transform.position - this.transform.position).sqrMagnitude;

                //최초로 들어왔다면...
                if (this.target == null)
                {
                    target = targetList[i];
                    miniumDistance = nowDistance;
                }

                
                //기존에 저장된 놈보다 작다면 갱신
                else if (nowDistance < miniumDistance)
                {
                    target = targetList[i];
                    miniumDistance = nowDistance;
                }
            }

            //타겟으로 잡힌 놈만 PlayOn
            this.target.TargetOn();

        }

        else
        {
            this.target = null;
        }

	
	}


    public void CatchSlot( ItemSlot itemSlot )
    {
        //null 이 들어왔다면..
        if (itemSlot == null)
        {
            this.catchSlot = null;
            this.gameObject.SetActive(false);
        }
        else{

            //집은 슬롯기억
            this.catchSlot = itemSlot;

            //활성화 시키고
            this.gameObject.SetActive(true);

            //집은 슬롯위치로 이동한다.
            this.transform.position = this.catchSlot.transform.position;


            //집은 슬롯 셋팅된 아이템 정보 물린다.
            this.itemInfo = itemSlot.itemInfo;

         
            //셋팅된 아이템 이미지로 교체
            this.itemImage.spriteName =
                ItemInfo.ItemType[this.itemInfo.type];

            //타겟리스트 초기화
            this.targetList.Clear();

        }
    }

    //잡고 있는 아이템을 놓는다.
    public void ReleseSlot()
    {
        //타겟후보가 없다면...
        if (this.targetList.Count == 0)
        {
            //되돌린다.
            this.catchSlot.SetItemInfo(this.itemInfo);
        }

        else
        {
            if (this.target != null)
            {

                //target 제일 가까운 슬롯이 저장되어있다.....
                if (target.itemInfo != null)
                {
                    //Swap
                    this.catchSlot.SetItemInfo(target.itemInfo);
                    target.SetItemInfo(this.itemInfo);
                    target.TargetOff();

                }

                else
                {
                    target.SetItemInfo(this.itemInfo);
                    target.TargetOff();

                }

            }
        }


        //자신은 비활성화
        this.CatchSlot(null);
    }


    void OnTriggerEnter(Collider col)
    {
        //ItemSlot 이랑 충돌했다면...
        ItemSlot itemSlot = col.gameObject.GetComponent<ItemSlot>();

        if (itemSlot != null)
        {
            //타겟후보에 푸쉬
            this.targetList.Add(itemSlot);
        }

    }

    void OnTriggerExit(Collider col)
    {
        //ItemSlot 이랑 충돌끝났다면...
        ItemSlot itemSlot = col.gameObject.GetComponent<ItemSlot>();

        if (itemSlot != null)
        {
            itemSlot.TargetOff();

            //타겟후보에 제거
            this.targetList.Remove(itemSlot);
        }
    }
}
