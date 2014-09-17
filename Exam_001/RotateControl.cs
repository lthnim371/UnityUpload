using UnityEngine;
using System.Collections;

public class RotateControl : MonoBehaviour {

    public float rotSpeed = 90.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //회전량
        float rotDelta = this.rotSpeed * Time.deltaTime;

        /*
        if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.Rotate(0.0f, -rotDelta, 0.0f);
        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.Rotate(0.0f,  rotDelta, 0.0f);
        if (Input.GetKey(KeyCode.UpArrow))
            this.transform.Rotate(-rotDelta, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.DownArrow))
            this.transform.Rotate(rotDelta, 0.0f, 0.0f);
	    */

        Vector3 rotVec = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            rotVec.y -= rotDelta;
        if (Input.GetKey(KeyCode.RightArrow))
            rotVec.y += rotDelta;
        if (Input.GetKey(KeyCode.UpArrow))
            rotVec.x -= rotDelta;
        if (Input.GetKey(KeyCode.DownArrow))
            rotVec.x += rotDelta;


        this.transform.Rotate(rotVec);


	}
}
