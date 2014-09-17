using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float moveSpeed = 30.0f;
    public float moveDistance = 60.0f;

    private float destroyTime = 0.0f;

	// Use this for initialization
	void Start () {

        //이동속도 와 이동거리 대비 몇초뒤에 파괴되는지
        float destroyTime = this.moveDistance / this.moveSpeed;
        Destroy(this.gameObject, destroyTime);  //destroyTime 초뒤에 파괴된다.
        
        //Destroy(this.gameObject, 3.0f );    //3.0 초뒤에 파괴된다.
	
	}
	
	// Update is called once per frame
	void Update () {

        float moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(0, 0, moveDelta);
	
	}
}
