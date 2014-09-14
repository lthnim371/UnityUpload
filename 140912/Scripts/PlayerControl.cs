using UnityEngine;
using System.Collections;

//이태그를 붙이면 해당 스트립트의 컴포넌트를 사용하기위해서는 반듯이 AirPlane 의 컴포넌트가 붙어있여햐 한다는 보장이 생긴다.
[RequireComponent( typeof( AirPlane ) )]        
public class PlayerControl : MonoBehaviour {

    private AirPlane myPlane;

    void Awake()
    {
        //보통 Awake 함수내에서 GetComponent 같은것을 쓴다.
        this.myPlane = this.GetComponent<AirPlane>();

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Input Axis 에 등록된 "Horizontal" 셋팅 값을 -1 에서 1 사이값으로 가져온다.
        //Default :
        //a 키, 왼쪽화살표 = -1
        //d 키, 오른쪽화살표 = 1
        float inputH = Input.GetAxis("Horizontal");

        //Input Axis 에 등록된 "Vertical" 셋팅 값을 -1 에서 1 사이값으로 가져온다.
        //Default :
        //w 키, 위쪽화살표 = 1
        //s 키, 아래쪽화살표 = -1
        float inputV = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(
            inputH, 0.0f, inputV);

        this.myPlane.Move_Order(moveDir);



        if (Input.GetKey(KeyCode.Space))
            this.myPlane.FireAllGun();
	
	}
}
