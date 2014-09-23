using UnityEngine;
using System.Collections;


public class Gun : MonoBehaviour {

    //public GameObject srcbullet;            //뷸렛 원본 프리펩
    //public GameObjectPool bulletPool;           //뷸렛 풀


    public string bulletName;                   //뷸렛이름


    public float firePerSec = 10.0f;        //초당 발사속도

    public float powerLevel = 1;            //파워 레벨
    

    private bool FireReady = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
            this.Fire();
	
	}


    public void Fire()
    {
        if (this.FireReady == false) return;
        this.FireReady = false;

        //발사 로직 실행
        this.FireProcess();

        //발사 속도 시간대비 다시 발사준비
        Invoke("ReFireReady", 1.0f / this.firePerSec);
    }


    void FireProcess()
    {
        CreateBullet(this.transform.position, this.transform.rotation);
    }
   

    void ReFireReady()
    {
        this.FireReady = true;
    }


    //뷸렛 생성
    protected void CreateBullet(Vector3 position, Quaternion rotation)
    {
        /*
        //만들어진 뷸렛이 참조된다....
        GameObject newBulletObject = Instantiate(
                this.srcbullet,
                position,
                rotation) as GameObject;*/


        //뷸렛풀에서 하나 활성화 하고 활성화된 놈 참조됨
        GameObject newBulletObject = 
            GameObjectPoolManager.Instance[ this.bulletName ].ActiveObject( position, rotation );

        if (newBulletObject == null) return;



        //자신의 최상위 부모 Transform 에 접근한다.
        Transform root = this.transform;

        //최상위 부모까지 타고 올라간다.
        while( root.parent != null )
            root = root.parent;

        //뷸렛의 Tag 명을 최상위 부모 GameObject 로 셋팅
        newBulletObject.tag = root.gameObject.tag;

        //생성된 게임오브젝트에 레이어를 부여하는 방법
        //newBulletObject.layer = 8;          
        //newBulletObject.layer = LayerMask.NameToLayer("Bullet");

    }
    
}
