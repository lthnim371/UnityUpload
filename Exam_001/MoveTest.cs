using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour {

    //public 접근 제한자의 인스턴스 맴버 변수는 
    //인스펙터 뷰에 노출이 되어 셋팅이 가능하다.
    //이때 주의 할점은 코드에 쓴 초기화 값은 최초로 해당 스크립트를 
    //게임오브젝트에 붙였을때 셋팅되는 값이고
    //이미한번 셋팅되고난 후에는 스크립트값을 아무리고쳐봤자.
    //적용되지 않고 인스펙터에 셋팅된 값으로 인식이된다.
    public float moveSpeed = 10.0f;         //초당 이동 속도

    public bool IsWorldMove = false;

    public Vector3 moveDir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //아래로 이동시키는 방법은 위치값 자체를 바꾸는 방법으로 
        //별로 권장하지 않는다.
        //Vector3 nowPos = this.transform.position;
        //nowPos.z += 0.1f;
        //this.transform.position = nowPos;
	
        //transform 의 이동 전용함수 이용
        //this.transform.Translate(0.0f, 0.0f, 0.1f); //이렇게 움직이면 로컬축기준으로 움직인다.
        //this.transform.Translate(0.0f, 0.0f, 0.1f, Space.World);        //이렇게 움직이면 월드축기준으로 움직인다.
        //this.transform.Translate(0.0f, 0.0f, 0.1f, Space.Self);         //이렇게 움직이면 로컬축기준으로 움직인다. ( 안쓴거랑 똑같다 )


        

        //이번프레임의 움직임량
        float moveDelta = this.moveSpeed * Time.deltaTime;      //Time.deltaTime 이전프레임과 현제프레임간의 시간차를 초단위로 알려준다.

        //월드 축기준으로 움직인다.
        //this.transform.Translate(0.0f, 0.0f, moveDelta, Space.World);

        //IsWorldMove true 면 월드로 움직이고 false 면 로컬로 움직인다
        //this.transform.Translate(0.0f, 0.0f, moveDelta,
        //    (this.IsWorldMove) ? Space.World : Space.Self);


        //방향타로 움직여보자
        //Vector3 moveDir = new Vector3(1, 0, 0);

        //정규화된 방향에 이동량 곱한다.
        Vector3 move = this.moveDir.normalized * moveDelta;

        // this.moveDir.normalized  moveDir 벡터의 정규화 벡터를 얻는더,

        //벡터로 움직여 보자
        this.transform.Translate(move, (this.IsWorldMove) ? Space.World : Space.Self); 


	}
}
