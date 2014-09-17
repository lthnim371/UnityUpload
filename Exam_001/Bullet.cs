using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    //뷸렛 초당 이동 속도
    public float moveSpeed = 100.0f;

    //뷸렛 사정거리
    public float moveDistance = 150.0f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //이번 프레임의 이동량
        float moveDelta = this.moveSpeed * Time.deltaTime;

        //자신이 바라보는 방향 정면으로 날라간다.
        this.transform.Translate(0, 0, moveDelta);


        //이동량 깐다.
        this.moveDistance -= moveDelta;

        //사정거리가 다되었다면...
        if (this.moveDistance < 0.0f)
        {
            //소멸......
            //Destroy(this);            //this 를 쓰면 자기자신의 컴포넌트만 파괴된다.
            Destroy(this.gameObject);   //이렇게 쓰면 자신이 붙어있는 게임오브젝트가 파괴된다.

            
        }

	
	}
}
