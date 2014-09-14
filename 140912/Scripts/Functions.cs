using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour {


    //인스턴스가 만들어질때 최초로 실행이 된다.
    //생성자 대신사용한다.
    //하나의 인스턴스에 한번이상 실행될일 없다
    //만약 인스턴스자체가 비활성화 된 상태에서 시작하면 호출되지 않는다 
    //게임 실행중 최초로 활성화 될때 실행이 된다....
    void Awake()
    {
        print("Awake Call");


        
    }

    //인스턴스가 활성화될때 실행이 된다.
    void OnEnable()
    {
        print("OnEnable Call");
    }


    //최초 업데이트 전에 딱한번 실행이 된다.
    //하나의 인스턴스에 한번이상 실행될일 없다
	void Start ()
    {
        print("Start Call");        //Console 창에 문자열 출력
	}
	
	
    //매업데이트 때 마다 실행이된다.
	void Update () 
    {
        //게임오브젝트 활성화 비활성화 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //자신의 게임오브젝트가 활성화 되어있다면....
            if (this.gameObject.activeSelf)
            {
                //비활성화 시켜라....
                this.gameObject.SetActive(false);
            }

            //자신의 게임오브젝트가 비활성화 되어있다면... ( 어차피 들어올일 없다 비활성화 되어있으면 Update 자체가 실행이 안되기때문이다 )
            else
            {
                //활성화 시켜라
                this.gameObject.SetActive(true);
            }

        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            //자신이 활성화 되어있다면....
            if (this.enabled)
            {
                //자신의 컴포넌트를 비활성화 시켜라.
                this.enabled = false;
            }

             //자신이 비활성화 되어있다면....
            else
            {
                //자신의 컴포넌트를 활성화 시켜라.
                this.enabled = true;
            }

        }


       


        print("Update Call");
	}

    //매업데이트 때 마다 실행이 되는데 
    //모든 Update 실행후 실행이 된다.
    void LateUpdate()
    {
        print("LateUpdate Call");
    }

    //고정 프레임 주기로 실행이 된다.
    //보통 FixedUpdate 함수내에서 물리 관련 조작을 하게 되는데
    //이는 FixedUpdate 함수 호출주기가 물리 업데이트 주기와 같기 때문이다.
    //고정프레임 주기는 Edit->Project Setting->Time->Fixed TimeStep 에서 설정할 수 있다.
    //참고
    //차후 고정프레임 주기 설정 만 잘해도 최적화를 쉽게 할수 있는데...
    //Fixed TimeStep 값이 클수록 물리 업데이트 주기도 길어져 CPU 물리처리에 부담이 덜하지만 물리 정확도가 부정확해지고
    //Fixed TimeStep 값이 작을수록 물리 업데이트 주기도 짧아져 CPU 물리처리에 부담이 가지만 물리 정확도가 정확해진다.
    void FixedUpdate()
    {
        print("FixedUpdate Call");
    }


    //어플리케이션이 종료될때 호출된다.
    //단중요한건 인스턴스가 활성화 되어있는 상태에서만 호출이 된다.
    void OnApplicationQuit()
    {
        print("OnApplicationQuit Call");
    }



    //해당 인스턴스가 비활성화 될때 실행이 된다.
    void OnDisable()
    {
        print("OnDisable Call");
    }

    //해당 인스턴스가 파괴될때 실행이 된다.
    void OnDestroy()
    {
        print("OnDestroy Call");
    }

}
