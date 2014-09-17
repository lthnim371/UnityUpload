using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    //따라가야될 Target Transform
    public Transform targetTransform;

    //따라가가는 속도
    public float followSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //서서히 선형보간하면서 위치 따라간다.
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            this.targetTransform.position,
            this.followSpeed * Time.deltaTime);

        //서서히 구면보간하면서 회전 따라간다.
        this.transform.rotation = Quaternion.Slerp(
            this.transform.rotation,
            this.targetTransform.rotation,
            this.followSpeed * Time.deltaTime);
	}
}
