using UnityEngine;
using System.Collections;

public class CircleMove : MonoBehaviour {

    public float angleUpSpeed = 90.0f;      //초당 90 도의 각도 증가

    //private 맴버는 인스펙터뷰에 노출되지 않는다.
    private float nowAngle = 0.0f;

    public float raius = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //각도 증가
        this.nowAngle += this.angleUpSpeed * Time.deltaTime;

        //반지름도 증가
        //this.raius += Time.deltaTime;


        //라디안 = 디그리각 * Mathf.Deg2Rad;
        //디그리각 = 라디안 * Mathf.Rad2Deg;
        //Mathf.Cos( 라디안각 ) = Cos 결과 값
        //Mathf.Sin( 라디안각 ) = Sin 결과 값

        //현제 nowAngle 을 디그리 체계인데 이것을 라이안체계값으로 얻는다.
        float radNowAngle = this.nowAngle * Mathf.Deg2Rad;

        //방향에 대한 벡터값
        Vector3 dir = new Vector3(
            Mathf.Cos(radNowAngle),
            Mathf.Sin(radNowAngle),
            0.0f);

        //벡터값을 바로 위치값으로...
        //this.transform.position = dir * raius;

        this.transform.localPosition = dir * raius;

	}
}
