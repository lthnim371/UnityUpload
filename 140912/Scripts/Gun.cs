using UnityEngine;
using System.Collections;


//추상 클래스는 인스턴스화 될수 없기 때문에 
//게임오브젝트 컴포넌트로도 붙일수 없다.
public abstract class Gun : MonoBehaviour {

    public GameObject srcbullet;            //뷸렛 원본 프리펩
    public float firePerSec = 10.0f;        //초당 발사속도

    public float powerLevel = 1;            //파워 레벨
    

    private bool FireReady = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

    //추상함수
    protected abstract void FireProcess();
   

    void ReFireReady()
    {
        this.FireReady = true;
    }

    
}
