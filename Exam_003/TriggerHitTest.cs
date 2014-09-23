using UnityEngine;
using System.Collections;

public class TriggerHitTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //
    // Trigger 충돌체크 3총사 함수
    // 

    // 아래와 같은 함수들이 호출될 조건
    // A 와 B 의 오브젝트가 있다고 가정한다.
    // 1. A 와 B 의 게임오브젝트에 둘다 Collider 컴포넌트가 존재해야한다.
    // 2. A 와 B 의 Collider 컴포넌트중 적어도 하나라도 IsTrigger 가 체크되어있어여 한다 ( 둘다 IsTrigger 가 체크되어있어도 무방하다 )
    // 3. A 와 B 의 게임오브젝트 중 적어도 하나라도 Rigidbody 컴포넌트를 
    //  가지고 있어야 하는데 이때 움직이는 놈이 Rigidbody 를 가지고 있는 놈이여햐 한다.
    //  이때 IsKinematic 의 체크여부는 무방하다.

    // 참고로 TiggerEvent 는 A 와 B 상방으로 전달된다.




    //참고 Collider 에 IsTrigger 체크되어있으면 유령충돌체 다른물체와 겹칠수 있다.

    //참고 Rigidbody 에 
    //IsKinematic 체크되어있으면 비강체 물체이고  
    //IsKinematic 체크해제 되어있으면 강체이다 ( 강체는 물리적 영향을 받는 물체가된다 )

    //특정대상과 충돌겹침이 시작되었을 때 호출된다 ( 이때 매개변수로 충돌된 대상의 Collider 인스턴스가 들어온다 )
    void OnTriggerEnter(Collider col)
    {
        print( col.gameObject.name + " 놈과 겹칩이 시작되었다");
        //print("OnTriggerEnter");
    }


    //특정대상과 충돌겹칩 중일 때 계속호출된다 ( 이때 매개변수로 충돌겹칩중인 대상의 Collider 인스턴스가 들어온다 )
    void OnTriggerStay(Collider col)
    {
        print(col.gameObject.name + " 놈과 겹칩중 이다");
        //print("OnTriggerStay");
    }


    //특정대상과 충돌겹칩이 끝났을때 호출된다 ( 이때 매개변수로 충돌겹칩중이 끝난 대상의 Collider 인스턴스가 들어온다 )
    void OnTriggerExit(Collider col)
    {
        print(col.gameObject.name + " 놈과 겹칩이 끝났다");
        //print("OnTriggerExit");
    }



}
