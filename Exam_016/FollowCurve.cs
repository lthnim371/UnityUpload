using UnityEngine;
using System.Collections;

public class FollowCurve : MonoBehaviour {

    public BezierCurve curve;

    private float Factor = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
            Factor += Time.deltaTime;

        else if (Input.GetKey(KeyCode.DownArrow))
            Factor -= Time.deltaTime;

        Factor = Mathf.Clamp01(Factor);


        //내위치를 커브위치로..
        this.transform.position = curve.GetPosition(Factor);

        //회전을 커브 값으로
        this.transform.rotation = curve.GetRotation(Factor);
	
	}
}
