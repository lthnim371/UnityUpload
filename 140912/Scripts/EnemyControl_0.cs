using UnityEngine;
using System.Collections;

[RequireComponent( typeof( AirPlane ) )]
public class EnemyControl_0 : MonoBehaviour {

    private AirPlane myPlane;
    private bool bFireDesire = false;       //총을 쏘고싶은 욕망
    public float fireToggleInterval = 1.0f;     //총쏘는 간격 1초

    private float sideAngle = 0.0f;
    private float sideAngleSpeed = 90.0f;

    public float liveTime = 10.0f;      //10 초 동안 살아있다.


    void Awake()
    {
        //보통 Awake 함수내에서 GetComponent 같은것을 쓴다.
        this.myPlane = this.GetComponent<AirPlane>();

    }


	// Use this for initialization
	void Start () {

        StartCoroutine("FireToggle");

        //너는 어차피 죽을운명
        Destroy(this.gameObject, this.liveTime);

	}

    IEnumerator FireToggle()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.fireToggleInterval);

            bFireDesire = !bFireDesire;
        }
    }



	// Update is called once per frame
	void Update () {

        //사이드 앵글 증가
        this.sideAngle += this.sideAngleSpeed * Time.deltaTime;

        //사이드 앵글에 따른 Cos
        float cos = Mathf.Cos(this.sideAngle * Mathf.Deg2Rad);



        //주구장창 앞으로 간다.
        this.myPlane.Move_Order(new Vector3(cos, 0, 1));
	
        //주구장창 총쏜다.
        if( bFireDesire )
            this.myPlane.FireAllGun();

	}
}
