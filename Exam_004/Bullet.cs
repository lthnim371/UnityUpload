using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float moveSpeed = 30.0f;
    public float moveDistance = 60.0f;

    private float destroyTime = 0.0f;

    public float damage = 10.0f;

	// Use this for initialization
	void Start () {


	}

    void OnEnable()
    {

        //이동속도 와 이동거리 대비 몇초뒤에 파괴되는지
        float destroyTime = this.moveDistance / this.moveSpeed;

        //풀링으로 사용될 게임오브젝트는 게임이 종료 될때 까지 절대로 파괴되지 않는다.
        //Destroy(this.gameObject, destroyTime);  //destroyTime 초뒤에 파괴된다.
        //Destroy(this.gameObject, 3.0f );    //3.0 초뒤에 파괴된다.


        //파괴 대신에 비활성화 시킨다.
        Invoke("BulletDisable", destroyTime);
    }

    //뷸렛 비활성화
    void BulletDisable()
    {
        this.gameObject.SetActive(false);     
    }



	
	// Update is called once per frame
	void Update () {

        float moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(0, 0, moveDelta);
	
	}

    
}
