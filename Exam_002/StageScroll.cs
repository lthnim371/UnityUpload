using UnityEngine;
using System.Collections;

public class StageScroll : MonoBehaviour {

    //Stage 2 개의 Transform
    public Transform topTransform;
    public Transform bottomTransform;

    public float scrollSpeed = 10.0f;       //초당 Scroll Speed;

    private float defaultDistance = 0.0f;   //초기 Top Bottom 간격
    private float scrollDelta = 0.0f;       //스크롤 된량....

    void Awake()
    {
        //Top 과 Bottom 거리 기억
        this.defaultDistance = Vector3.Distance(
            this.topTransform.position, this.bottomTransform.position);

    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //움직인 량
        float moveDelta = this.scrollSpeed * Time.deltaTime;

        //2개의 StageTransform 을 움직인다.
        this.topTransform.Translate(0.0f, 0.0f, -moveDelta);
        this.bottomTransform.Translate(0.0f, 0.0f, -moveDelta);

        //스크롤 된 량을 쌓는다.
        this.scrollDelta += moveDelta;
  
        //교체 순간
        while (this.scrollDelta >= this.defaultDistance)
        {
            //아래있는 놈을 위로 보낸다.
            //위로 보낼량은 거리 2배 
            this.bottomTransform.Translate(0.0f, 0.0f, defaultDistance * 2.0f);

            //스크롤 량 초기화
            this.scrollDelta -= this.defaultDistance;

            //아래있던 놈을 위로보냈으니 Swap
            Transform temp = this.topTransform;
            this.topTransform = this.bottomTransform;
            this.bottomTransform = temp;
        }

	
	}
}
