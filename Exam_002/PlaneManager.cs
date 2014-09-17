using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //List 사용하기 위해

public class PlaneManager : MonoBehaviour {

    private static bool sIsAppQuit = false;
    public static bool IsAppQuit {
        get
        {
            return sIsAppQuit;
        }
    }

    private static PlaneManager sInstance;

    //static 프로퍼티
    public static PlaneManager Instance
    {
        get
        {
            //아직 인스턴스가 준비 되지 않았다면...
            if (sInstance == null)
            {
                //빈게임 오브젝트를 만든다.
                GameObject newGameObject = new GameObject("_PlaneManager");

                //만들어지 빈게임오브젝트에 PlaneManager 컴포넌트를 붙이고 
                //붙은 컴포넌트 인스턴스를 sInstance 에 저장한다.
                sInstance = newGameObject.AddComponent<PlaneManager>();

            }


            return sInstance;
        }
    }


    //List<AirPlane> 도 public 으로 있으면 외부 인스펙터뷰에 배열처럼 노출된다.
    //public List<AirPlane> airPlaneList = new List<AirPlane>();
    //public List<AirPlane> aliencePlaneList = new List<AirPlane>();
    //public List<AirPlane> enemyPlaneList = new List<AirPlane>();


    //Dictionary Use
    private Dictionary<string, List<AirPlane>> airplaneMap = 
        new Dictionary<string, List<AirPlane>>();


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //세상이 멸망하니?
    void OnApplicationQuit()
    {
        sIsAppQuit = true;
    }



    //플레인 출생신고
    public void AddPlane(AirPlane plane)
    {
        //지금추가되는 AirPlane 의 Tag 명
        string tagName = plane.gameObject.tag;

        //기존에 없는 Key 니?
        if (this.airplaneMap.ContainsKey(tagName) == false)
        {
            //새로운리스트 만든다.
            List<AirPlane> newList = new List<AirPlane>();

            //리스트에 AirPlane 추가
            newList.Add(plane);

            //새로운리스트 Map 에 추가
            this.airplaneMap.Add(tagName, newList);

        }

        //기존에 있는키니?
        else
        {
            //기존키에 푸쉬
            this.airplaneMap[tagName].Add(plane);
        }
  
        /*
        if (plane.gameObject.tag == "Alience")
            this.aliencePlaneList.Add(plane);

        else if (plane.gameObject.tag == "Enemy")
            this.enemyPlaneList.Add(plane);
        */
    }

    //비행기 사망신고
    public void RemovePlane(AirPlane plane)
    {
        //지금 삭제 되는 AirPlane 의 Tag 명
        string tagName = plane.gameObject.tag;

        //기존에 있는 Key 니?
        if (this.airplaneMap.ContainsKey(tagName))
        {
            //기존키에서 삭제
            this.airplaneMap[tagName].Remove(plane);
        }

        /*
        if (plane.gameObject.tag == "Alience")
            this.aliencePlaneList.Remove(plane);

        else if (plane.gameObject.tag == "Enemy")
            this.enemyPlaneList.Remove(plane);*/

    }


    public List<AirPlane> GetPlaneList(string tag)
    {
        
        //기존에 있는 Key 니?
        if (this.airplaneMap.ContainsKey(tag))
        {
            return this.airplaneMap[tag];
        }

        return null;
    }


    public List<AirPlane> this[string tag]
    {
        get
        {
            //기존에 있는 Key 니?
            if (this.airplaneMap.ContainsKey(tag))
            {
                return this.airplaneMap[tag];
            }

            return null;
        }
    }



}
