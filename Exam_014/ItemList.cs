using UnityEngine;
using System.Collections;
using System.Xml;
using System;


[RequireComponent( typeof( UIGrid ) )]
public class ItemList : MonoBehaviour {

    public GameObject itemObject;           //List 에 붙을 아이템 원본

    private UIGrid grid;

    void Awake()
    {
        this.grid = this.GetComponent<UIGrid>();
    }


	// Use this for initialization
	void Start () {

        //로드
        XmlReader xmlReader = null;

        //로드 경로
        string loadPath = Application.persistentDataPath + "/SaveData.xml";

        try
        {
            xmlReader = XmlReader.Create(loadPath);
        }
        catch (Exception e)
        {
            return;
        }


        //읽는다
        while (xmlReader.Read())
        {
            if (xmlReader.Name.CompareTo("Item") == 0 &&
                xmlReader.NodeType == XmlNodeType.Element)
            {
                ItemInfo newItemInfo = new ItemInfo();

                newItemInfo.name = xmlReader.GetAttribute("Name");

                newItemInfo.type = int.Parse( xmlReader.GetAttribute("Type") );

                this.AddItem(newItemInfo);

            }

        }

        xmlReader.Close();

	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	
	}


    public void AddRandomItem()
    {

        // 랜덤하게 아이템 정보 셋팅
        int rand = UnityEngine.Random.Range(0, 3);
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



        GameObject newItemInstance = Instantiate(
            this.itemObject,
            this.transform.position,
            Quaternion.identity) as GameObject;

        //새로만들어지진 놈 내자식으로.
        newItemInstance.transform.parent = this.transform;

        //붙이고 나서 스케일 맞춘다.
        newItemInstance.transform.localScale = new Vector3(1, 1, 1);


        //아이템 정보 물린다.
        Item item = newItemInstance.GetComponent<Item>();
        if (item != null)
        {
            item.SetItemInfo(newItemInfo);
        }




        //아이템 추가하고 난뒤 정렬
        this.grid.Reposition();
    }


    public void AddItem( ItemInfo itemInfo )
    {

        GameObject newItemInstance = Instantiate(
            this.itemObject,
            this.transform.position,
            Quaternion.identity) as GameObject;

        //새로만들어지진 놈 내자식으로.
        newItemInstance.transform.parent = this.transform;

        //붙이고 나서 스케일 맞춘다.
        newItemInstance.transform.localScale = new Vector3(1, 1, 1);


        //아이템 정보 물린다.
        Item item = newItemInstance.GetComponent<Item>();
        if (item != null)
        {
            item.SetItemInfo(itemInfo);
        }




        //아이템 추가하고 난뒤 정렬
        this.grid.Reposition();

    }

    //아이템 삭제....
    public void DeleteItem(Item item)
    {
        GameObject.Destroy(item.gameObject);

        //아이템 삭제하고 난뒤 정렬 ( 이시점에 정렬을 하면 아직 남아있는 상태이기때문에 안된다, 다음 프레임에 정렬하자 )
        //this.grid.Reposition();
        StartCoroutine("RepositionCo");
    }

    IEnumerator RepositionCo()
    {
        yield return null;
        this.grid.Reposition();
    }


    //자동 저장 ( 프로그램이 종료 될때 )
    void OnApplicationQuit()
    {
        Item[] childItems = this.GetComponentsInChildren<Item>();

        //저장 경로
        string savePath = Application.persistentDataPath + "/SaveData.xml";

        //XmlWriter 준비
        XmlWriter xmlWriter = null;
        try
        {
            xmlWriter = XmlWriter.Create(savePath);

        }
        catch (Exception e)
        {
            return;
        }

        //저장
        xmlWriter.WriteStartElement("ItemList");

        for (int i = 0; i < childItems.Length; i++)
        {
            xmlWriter.WriteStartElement("Item");

            xmlWriter.WriteAttributeString("Name", childItems[i].itemInfo.name);
            xmlWriter.WriteAttributeString("Type", childItems[i].itemInfo.type.ToString());


            xmlWriter.WriteEndElement();
        }


        xmlWriter.WriteEndElement();


        xmlWriter.Close();



    }

    
}
