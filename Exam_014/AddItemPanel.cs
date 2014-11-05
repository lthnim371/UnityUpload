using UnityEngine;
using System.Collections;

public class AddItemPanel : MonoBehaviour {

    public ItemList itemList;
    public UIInput inputName;
    public UIPopupList inputPopup;

    private bool bAddAble = false;          //추가 가능한 상태니?


    void OnEnable()
    {
        this.bAddAble = true;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void AddItem()
    {
        if (this.bAddAble == false) return;

        //셋팅된 정보대로 ItemInfo 를 만든다.

        ItemInfo newItemInfo = new ItemInfo();

        newItemInfo.name = inputName.value;             //입력된 이름

        if (inputPopup.value.CompareTo("Type0") == 0 )
            newItemInfo.type = 0;

        else if (inputPopup.value.CompareTo("Type1") == 0)
            newItemInfo.type = 1;

        else if (inputPopup.value.CompareTo("Type2") == 0)
            newItemInfo.type = 2;


        this.itemList.AddItem(newItemInfo);


        //한번 추가된 이후로 중복 추가 안되게.
        this.bAddAble = false;



    }
}
