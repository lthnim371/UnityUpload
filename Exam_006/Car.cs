using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float rotSpeed = 90.0f;          //초당 회전 속도

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(0, 0, this.moveSpeed * Time.deltaTime);

	}

    //-1 이면 핸들 왼쪽 이빠이
    //1 이면 핸들 오른쪽 이빠이
    public void SteerControl(float value)
    {
        float rotDelta = value * Time.deltaTime * this.rotSpeed;

        this.transform.Rotate(0, rotDelta, 0);
    }
}
