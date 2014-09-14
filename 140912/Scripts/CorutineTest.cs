using UnityEngine;
using System.Collections;

public class CorutineTest : MonoBehaviour {

    private Vector3 moveVector = Vector3.zero;

    public float myUpdatePerSec = 10.0f;        //나의 업데이트는 초당 10 번 실행이된다.

    private bool myUpdateLoop = false;


	// Use this for initialization
	void Start () {

        //Invoke("TestFunction", 3.0f);

        //코루틴함수를 실행시키는건 2 가지
        //StartCoroutine( TestFunction() );       //직접 함수를 호출시킴
        StartCoroutine("TestFunction");           //함수 이름으로 호출시킴
        StartCoroutine("MoveFunction");
        StartCoroutine("MyUpdateLoop");
	}

    //void TestFunction()
    //{
    //    print("3초가 지났다");
    //}


    //코루틴 함수
    IEnumerator TestFunction()
    {
        //3초만 기달려라.
        yield return new WaitForSeconds(3.0f);  //일단 이구문을 만나면 함수가 종료된다.

       

        //3초뒤에 함수가 자동호출되며 여기서 부터 시작한다.
        print("3초가 지났다");
    }



    IEnumerator MoveFunction()
    {
        while (true)
        {
            this.moveVector = new Vector3(0, 0, 1);

            yield return new WaitForSeconds(5.0f);

            this.moveVector = new Vector3(1, 0, 0);

            //return
            //yield break;        //코루틴 함수를 종료할때 리턴대신 사용

            yield return new WaitForSeconds(3.0f);

            this.moveVector = new Vector3(0, 0, -1);

            yield return new WaitForSeconds(10.0f);
        }

    }

    IEnumerator MyUpdateLoop()
    {
        myUpdateLoop = true;
        while (myUpdateLoop)
        {
            yield return new WaitForSeconds(1.0f / this.myUpdatePerSec);
            this.MyUpdate();
        }

    }


	// Update is called once per frame
	void Update () {

        this.transform.Translate(
            this.moveVector * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StopCoroutine("MyUpdateLoop");
            myUpdateLoop = false;
            
            StopCoroutine("MoveFunction");

        }
	}


    void MyUpdate()
    {
        print("MyUpdateCall");
    }
}
