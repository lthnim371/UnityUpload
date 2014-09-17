using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject srcBuller;        //뷸렛게임오브젝트 원본 프리펩 
    //( 주의 할점 이것을 계속해서 찍어내기 위해서는 씬에 배치된 
    //게임오브젝트가 아니라 Asset 의 자원화된 프리펩 게임오브젝트를 참조시켜야 한다 )

    public float firePerSec = 10;           //초당 10 발 발사
    private bool IsReadyShot = true;        //발사준비가 되었니?

    public float errorAngle = 1.0f;         //오차각 ( 1 도 )




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        /*
        if (this.IsReadyShot == false )
        {
            //재발사 남은시간 깐다.
            this.leftReadyShot -= Time.deltaTime;

            //재발사 남은시간 다되었으면 준비완료.
            if (this.leftReadyShot <= 0.0)
                this.IsReadyShot = true;
        }*/

        
	
	}

    //발사 함수
    public void Fire()
    {
        //발사 준비가 안되었다면 발사안된다.
        if (IsReadyShot == false) return;

        this.IsReadyShot = false;


        //for (int i = 0; i < 12; i++)
        //{

            //명중 오차각에 의한 발사 회전 사원수 계산

            //0 ~ 360 도의 랜덤 라디안 각
            float angleRad = Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad;
            Vector3 randVector = new Vector3(
                Mathf.Cos(angleRad),
                Mathf.Sin(angleRad),
                0.0f);
            
            //위의 랜덤 각에 의한 축회전 사원수를 구한다.
            Quaternion rotError = Quaternion.AngleAxis(
                Random.Range(0.0f, this.errorAngle),
                randVector);





            //특정 게임오브젝트의 클론을 만들어 씬에 배치 하고 
            //새롭게 배치된 클론의 뷸렛을 newBullet 이 참조한다.
            GameObject newBullet = Instantiate(
                this.srcBuller,     //원본 게임오브젝트 ( 보통은 프리펩을 참조시킨다 )
                this.transform.position,    //배치될 씬의 월드 위치 ( 내위치로 배치한다 )
                this.transform.rotation * rotError     //배치될 씬의 회전 값사원수 (나의 회전위치와 동일하게 )
                ) as GameObject;

            //새롭게 만들어진 뷸렛에 lookTarget 컴포넌트가 있니?
            LookTargetTransform lookTarget = newBullet.GetComponent<LookTargetTransform>();
            if (lookTarget != null)
            {
                //에네미 캐논을 다 찾는다.
                GameObject[] targets = GameObject.FindGameObjectsWithTag("EnemyCannon");

                //그중에 랜덤
                int randIdx = Random.Range(0, targets.Length);  //Random.Range(0, 4 ) => 0, 1, 2, 3

                lookTarget.target = targets[randIdx];
            }


            //다음 발사까지 남은시간
            //1.0f / this.firePerSec;


        //}

        Invoke( "RefireReady", 1.0f / this.firePerSec );


    }


    void RefireReady()
    {
        this.IsReadyShot = true;
    }

}
