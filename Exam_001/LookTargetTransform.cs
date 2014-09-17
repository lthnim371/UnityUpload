using UnityEngine;
using System.Collections;

public class LookTargetTransform : MonoBehaviour {

    public GameObject target;       //바라볼 타겟 게임오브젝트

    public float rotSpeed = 90.0f;      //타겟까지 초당 90 도를 회전한다.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //타겟이 물려 있지 않으면 실행되지 않는다.
        if (this.target == null) return;

        //타겟까지의 방향벡터 ( 타겟의 위치 빼기 자신의 위치 )
        Vector3 dirToTarget = 
            this.target.transform.position - this.transform.position;

        //정규화
        dirToTarget.Normalize();
        

         

        float dot = Mathf.Clamp( Vector3.Dot(this.transform.forward, dirToTarget), -1.0f, 1.0f );       
        //내적결과값으로 각도를 구할때는 반듯이 -1 ~ 1 사이의 범위로 나와야한다.
        //부동소수점오차로 조금이라도 위의 범위를 벗어나면 Acos() 의 계산 불능이 나온다.
        //그래서 -1 ~ 1 사이의 값으로 Clamp 해주는 습관을 들이자.

        //타겟까지의 각도차 
        float distToAngle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //각도차가 0.1 도 이상이면유도 
        if (distToAngle > 0.1f)
        {
            //이번 프레임에 내가 회전할수 있는 회전량
            float deltaRot = this.rotSpeed * Time.deltaTime;

            //회전 비율값 ( 0 ~ 1 )
            float factor = Mathf.Clamp01( deltaRot / distToAngle );


            //타겟까지 충분히 회전 할수 있다.
            if (factor == 1.0f)
            {
                //타겟방향을 바로 바라봐라...
                this.transform.rotation = Quaternion.LookRotation(dirToTarget);
            }

            else
            {
                //위의 회전 비율값으로 나의 정면벡터와 타겟방향까지의 보간한 벡터를 얻는다.
                Vector3 dir = Vector3.Slerp(this.transform.forward, dirToTarget, factor);

                //dir 방향을 바라보게 한다.
                this.transform.rotation = Quaternion.LookRotation(dir);
            }
           

        }



	
	}
}
