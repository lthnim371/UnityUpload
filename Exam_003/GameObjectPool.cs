using UnityEngine;
using System.Collections;

public class GameObjectPool : MonoBehaviour {

    private GameObject srcGameObject;            //풀링할 게임오브젝트( 프리펩 )
    private int poolNum = 100;                   //풀링갯수

    private GameObject[] cloneObjects;          //클론오브젝트 참조 배열
    private int activeCount = 0;                //Active 순번


    void Awake()
    {
    }

    //하나의 오브젝트를 활성화 시킨다.
    public GameObject ActiveObject(Vector3 pos, Quaternion rot)
    {
        /*
        for (int i = 0; i < this.poolNum; i++)
        {
            //해당번째의 활성화 되어있지 않다면...
            if (this.cloneObjects[i].activeSelf == false)
            {
                this.cloneObjects[i].SetActive(true);
                this.cloneObjects[i].transform.position = pos;
                this.cloneObjects[i].transform.rotation = rot;

                //현재 활성화 된 오브젝트 참조를 리턴한다.
                return cloneObjects[i];
            }

        }

        //여기까지오면 활성화 시킬게 부족하다
        return null;
        */

  
        //활성화 될놈
        GameObject newActive = this.cloneObjects[this.activeCount++];

        //활성화 시킨다.
        newActive.SetActive(true);

        newActive.transform.position = pos;
        newActive.transform.rotation = rot;

        if (this.activeCount >= this.poolNum)
            this.activeCount = 0;

        return newActive;
    }


    public bool ReadyPool( string objectName, int poolNum )
    {
        //풀갯수 대입
        this.poolNum = poolNum;

        //오브젝트 이름
        //Resouces/GameObjects 폴더에있는 objectName 를 로드하고 로드된 GameObject 프리펩을  srcGameObject 가 참조한다.
        srcGameObject = Resources.Load("GameObjects/" + objectName) as GameObject;

        //리소스(Resource) 폴더에 있는 경로의 Asset 을 로드한다.
        //Resources.Load( 경로 )
        //만약 Resource/BGM/Test.mp3      이렇게 저장되어있다면...
        //Resources.Load("BGM/Test");     이렇게 불러와야 한다...

        //못찾으면 false 리턴
        if (srcGameObject == null)
            return false;


        //배열 생성
        this.cloneObjects = new GameObject[this.poolNum];

        //GameObjectPool 은 자식들의 Transform 위치를 
        //월드 위치와 동일하게 하기 위해 자신의 Transform 을 초기화한다.
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
        this.transform.localScale = new Vector3(1, 1, 1);

        //풀링할 갯수만큼 사본을 미리 만들어 놓는다.
        for (int i = 0; i < this.poolNum; i++)
        {
            GameObject newClone = Instantiate(
                this.srcGameObject,
                Vector3.zero,
                Quaternion.identity) as GameObject;

            //만들어진 놈은 바로 비활성화 시킨다.
            newClone.SetActive(false);

            //만들어진 놈을 내자식으로.....
            newClone.transform.parent = this.transform;

            //만들어진놈을 배열 순번에 맞게 참조시킴
            this.cloneObjects[i] = newClone;
        }


        //재대로 만들어 졌다
        return true;
    }



}
