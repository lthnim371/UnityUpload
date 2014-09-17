using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {

    public Vector3 rotateAxis;

    public float rotateSpeed = 90.0f;       //초당 90 도 회전 
    public bool isWorldRoate = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //이번 프레임의 회전량
        float rotDelta = this.rotateSpeed * Time.deltaTime;

        //Rotate 는 Degree
        //this.transform.Rotate(0.0f, 0.0f, rotDelta, 
        //    (this.isWorldRoate)? Space.World : Space.Self );
	

        //정규화 방향에 회전 전값을 먹이면 그축으로의 해당 회전량을 얻을수 있다.
        if (this.rotateAxis != Vector3.zero)
        {
            Vector3 rotVec = rotateAxis.normalized * rotDelta;

            this.transform.Rotate(rotVec, (this.isWorldRoate) ? Space.World : Space.Self);
            
        }

	}
}
