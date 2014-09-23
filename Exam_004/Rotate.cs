using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float rotSpeed = 90.0f;

    public Vector3 rotAxis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        float rotDelta = rotSpeed * Time.deltaTime;
        
        //로테이트 함수를 이용하여 회전
        this.transform.Rotate(rotAxis * rotDelta , Space.Self);
    	


	}
}
