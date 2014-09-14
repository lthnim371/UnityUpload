using UnityEngine;
using System.Collections;

public class Homming : MonoBehaviour {

    //추적할 타겟 Tag 가 누구니?
    public string targetTag;

    //타겟 게임오브젝트
    private GameObject target;

    //초당 180 도 회전
    public float rotSpeed = 180.0f;


    void Awake()
    {
        //처음 시작시 셋팅된 Tag 명의 적을 찾는다.
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        if (targets.Length > 0)
        {
            //찾은 적중 랜덤
            this.target = targets[Random.Range(0, targets.Length)];
        }

        else
        {
            this.target = null;
        }


    }


	// Use this for initialization
	void Start () {
	
    }
	
	// Update is called once per frame
	void Update () {

        //적이 없으면 실행되지 않는다.
        if (this.target == null) return;

        //타겟방향
        Vector3 dirToTarget = this.target.transform.position - this.transform.position;

        //노말라이즈
        dirToTarget.Normalize();

        //타겟까지의 각차
        float distToAngle =
            Mathf.Acos(Mathf.Clamp(Vector3.Dot(dirToTarget, this.transform.forward), -1, 1)) * Mathf.Rad2Deg;

        //타겟까지의 각도 차가 0.1 도 이상나면 유도
        if (distToAngle > 0.1f)
        {
            //이번 업데이트에 허용된 회전량
            float rotDelta = this.rotSpeed * Time.deltaTime;

            //각차와 회전량의 비율
            float factor = Mathf.Clamp01( rotDelta / distToAngle );

            //타겟을 바라보기위해 충분하다.
            if (factor >= 1.0f)
            {
                this.transform.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up);
            }

            else
            {
                //바라볼 방향을 factor 값에의해 구면보간한다.
                Vector3 dir = Vector3.Slerp(this.transform.forward, dirToTarget, factor );

                this.transform.rotation = Quaternion.LookRotation(dir, Vector3.up );


            }




        }







       
	
	}
}
