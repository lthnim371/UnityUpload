using UnityEngine;
using System.Collections;

public class SingletonManager : MonoBehaviour {

    private static SingletonManager sInstance;

    //static 프로퍼티
    public static SingletonManager Instance
    {
        get
        {
            //아직 인스턴스가 준비 되지 않았다면...
            if (sInstance == null)
            {
                //빈게임 오브젝트를 만든다.
                GameObject newGameObject = new GameObject("_SingletonManager");

                //만들어지 빈게임오브젝트에 SingletonManager 컴포넌트를 붙이고 
                //붙은 컴포넌트 인스턴스를 sInstance 에 저장한다.
                sInstance = newGameObject.AddComponent<SingletonManager>();

            }


            return sInstance;
        }
    }




    public int number = 30;

    void Awake()
    {
        //메니져 같은 거 만들때 써주는데...
        //참고로 씬이 변경되어도 파괴되지 말라는 명령임
        DontDestroyOnLoad(this.gameObject);

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
