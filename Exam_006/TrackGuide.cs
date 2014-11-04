using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Car ))]
public class TrackGuide : MonoBehaviour {

    private Car car;

    public float sideRayAngle = 45.0f;          //양사이드 Ray 각
    public float sideRayDistance = 50.0f;       //양사이드 Ray Distance 

    private Ray leftRay;
    private Ray rightRay;


    public Transform frontRayTransform;


    void Awake()
    {
        this.car = this.GetComponent<Car>();

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float InputH = Input.GetAxis("Horizontal");

        this.frontRayTransform.localRotation = Quaternion.Euler(0, InputH * -30.0f, 0);


        //각도 대로 Ray 를 만든다.

        //왼쪽 Ray 만들기
        float leftAngle = (90.0f + this.sideRayAngle) * Mathf.Deg2Rad;
        Vector3 leftDir = new Vector3(Mathf.Cos(leftAngle), 0.0f, Mathf.Sin(leftAngle));
        leftDir = this.frontRayTransform.TransformDirection(leftDir);  //로컬방향을 월드로...     
        this.leftRay.origin = this.frontRayTransform.position;
        this.leftRay.direction = leftDir;


        //오른쪽 Ray 만들기
        float rightAngle = (90.0f - this.sideRayAngle) * Mathf.Deg2Rad;
        Vector3 rightDir = new Vector3(Mathf.Cos(rightAngle), 0.0f, Mathf.Sin(rightAngle));
        rightDir = this.frontRayTransform.TransformDirection(rightDir);   //로컬방향을 월드로...     
        this.rightRay.origin = this.frontRayTransform.position;
        this.rightRay.direction = rightDir;

        //좌우로 Ray 쏜다
        RaycastHit leftHit;
        RaycastHit rightHit;

        //좌우 레이 히트 Distance
        float leftHitDistance = this.sideRayDistance;
        float rightHitDistance = this.sideRayDistance;

        //좌우 레이체크 해서 Hit 거리 갱신
        if (Physics.Raycast(this.leftRay, out leftHit, this.sideRayDistance))
            leftHitDistance = leftHit.distance;
        if (Physics.Raycast(this.rightRay, out rightHit, this.sideRayDistance))
            rightHitDistance = rightHit.distance;

        //레이 hit delta 
        float delta = rightHitDistance - leftHitDistance;

        //좌우 Stree 욕망
        float steerDesire = Mathf.Clamp(delta / this.sideRayDistance, -1.0f, 1.0f);

        this.car.SteerControl(steerDesire);
	
	}


    void OnDrawGizmos()
    {
        //양사이드 레이를 그려보자
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(this.leftRay.origin, this.leftRay.origin + this.leftRay.direction * this.sideRayDistance);
        Gizmos.DrawLine(this.rightRay.origin, this.rightRay.origin + this.rightRay.direction * this.sideRayDistance);

    }
}
