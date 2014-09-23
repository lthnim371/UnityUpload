using UnityEngine;
using System.Collections;

public class MoveControl : MonoBehaviour {

    public float moveSpeed = 1.0f;  //초당 이동속도
    public bool isMoveWorld = true; //월드 기준으로 움직이니?

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        //키보드 입력 //숫자는 "1" 이런식으로 ( ) 안에 문자열로 써야 한다.
        //if (Input.GetKeyDown(KeyCode.S))
        //{
            //S 를 한번 눌렀을때 실행
        //}

        //if (Input.GetKeyUp(KeyCode.S))
        //{
            //S 를 한번 눌렀다 뗏을때 한번 실행
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
            //S 를 누르고 있을때 계속 실행
        //}


        Vector3 moveVec = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
            moveVec.z += 1;
        if (Input.GetKey(KeyCode.S))
            moveVec.z -= 1;
        if (Input.GetKey(KeyCode.A))
            moveVec.x -= 1;
        if (Input.GetKey(KeyCode.D))
            moveVec.x += 1;
        
        //벡터가 제로가 아니라면...
        //if (moveVec != new Vector3(0, 0, 0))
        if (moveVec != Vector3.zero)    
        {
            //정규화 
            //moveVec.normalized        //정규화 된 벡터를 참조한다.
            //moveVec.Normalize();        //지스스로 정규화 시켜라.
            moveVec = moveVec.normalized;   //지스스로 정규화 시켜라.
        }






        //방향과 이동 적용
        moveVec *= this.moveSpeed * Time.deltaTime;

        if (this.isMoveWorld)
            this.transform.Translate(moveVec, Space.World);
        else
            this.transform.Translate(moveVec, Space.Self);
	
	}
}
