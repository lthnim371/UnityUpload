using UnityEngine;
using System.Collections;

public class CamPostionChange : MonoBehaviour {

    //외부에서 Transform 셋팅가능
    public Transform camTransform1;
    public Transform camTransform2;


    private Transform tagetTransform;

	// Use this for initialization
	void Start () {

        this.tagetTransform = camTransform1;

	
	}
	
	// Update is called once per frame
	void Update () {

        //1번 키를 누르면 1번위치로...
        if (Input.GetKeyDown("1"))
        {
            /*
            //월드 위치 대입
            this.transform.position = camTransform1.position;

            //월드 회전 대입
            this.transform.rotation = camTransform1.rotation;
            */


            this.tagetTransform = this.camTransform1;
        }

        //2번 키를 누르면 2번 위치로...
        else if (Input.GetKeyDown("2"))
        {
            /*
            //월드 위치 대입
            this.transform.position = camTransform2.position;

            //월드 회전 대입
            this.transform.rotation = camTransform2.rotation;
            */

            this.tagetTransform = this.camTransform2;
        }


        //타겟트랜스폼까지 보간
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            this.tagetTransform.position,
            Time.deltaTime * 5.0f);

        this.transform.rotation = Quaternion.Slerp(
            this.transform.rotation,
            this.tagetTransform.rotation,
            Time.deltaTime * 5.0f);

	
	}
}
