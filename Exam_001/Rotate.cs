using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float rotSpeed = 90.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Transform 의 위치 관련 Properties

        //this.transform.position           월드 위치 
        //this.transform.localPosition      로컬 위치 ( 부모가 없는경우 월드 위치와 같은 값 )

        //this.transform.eulerAngles        현제 Transform 의 월드 Euler 각 Degree 
        //this.transform.localEulerAngles   현제 Transform 의 로컬 Euler 각 Degree ( 부모가 없는경우 월드 Euler 와 같은 값 )

        //this.transform.rotation           현제 Transform 월드 회전 정보 사원수
        //this.transform.localRotation      현제 Transform 로컬 회전 정보 사원수 ( 부모가 없는경우 월드 Euler 와 같은 값 )

        //this.transform.localScale         현제 Transform 로컬 스케일 값 ( 스케일에 월드 개념은 없다 )


        float rotDelta = this.rotSpeed * Time.deltaTime;
        
        //오일러 각에 접근하여 회전 ( 절대로 하지마라 )
        //Vector3 nowEuler = this.transform.eulerAngles;
        //nowEuler.x += rotDelta;
        //this.transform.eulerAngles = nowEuler;

        //로테이트 함수를 이용하여 회전
        this.transform.Rotate(rotDelta, 0, 0, Space.World);
    	
        //만약 특정 각도에 대한 셋팅을 하고싶다면... 아래와 같은 사원수를 이용하여 월드 각을 셋팅해야한다.
        //this.transform.rotation = Quaternion.Euler(135.0f, 0.0f, 0.0f);
 


	}
}
