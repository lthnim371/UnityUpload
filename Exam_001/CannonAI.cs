using UnityEngine;
using System.Collections;

public class CannonAI : MonoBehaviour {

    private Transform headTransform;
    public Gun[] guns;

    private GameObject enemyTarget;     //적 타겟


	// Use this for initialization
	void Start () {

        //내직속자식중 Head 의 이름을 가진 게임오브젝트의 Transform 을 찾아온다 없으면 NULL 리턴
        this.headTransform = this.transform.FindChild("Head");

        //주의 할건 나의 직속 자식만 가져온다. 예를 들어 건을 가지고 온다면 다음과 같이 써야 한다.
        //this.transform.FindChild("Head").FindChild("Gun");
        //this.transform.FindChild("Head/Gun");

        //내총 가가지고 온다.
        guns = this.GetComponentsInChildren<Gun>();

        //만약 Target 이 설정 되어있지 않다면....
        if (this.enemyTarget == null)
        {
            //적을 찾는다.

            //씬에 배치된 게임오브젝트 중에 "PlayerPlane" 이름의 게임오브젝틀 찾고 
            //없다면 Null 이 리턴된다.
            //여러게 있다면 그중하나다..... ( 무거우니 사용을 지양하자... )
            //this.enemyTarget = GameObject.Find("PlayerPlane");
            
            //Tag 로 적을 찾는다.
            this.enemyTarget = GameObject.FindGameObjectWithTag("PlayerPlane");
 

            //찾은 적을 Head 에 LookTargetTarget 에 타겟으로 전달
            //LookTargetTransform lookTraget = this.GetComponentInChildren<LookTargetTransform>();

            //해당 Transform 으로도 GetComponent 컴포넌트를 사용할수 있다.
            //이렇게 되면 해당 Transform 이물린 게임오브젝트의 컴포넌트를 가지고 오게 된다.
            LookTargetTransform lookTraget = this.headTransform.GetComponent<LookTargetTransform>();


            if (lookTraget != null)
                lookTraget.target = this.enemyTarget;


        }

	}
	
	// Update is called once per frame
	void Update () {


        if (this.enemyTarget != null)
        {
            //자신의 headTransform 의 정면과 
            //적까지의 방향벡터의 각도차
            
            //this.transform.position - this.enemyTarget.transform.position
            Vector3 dirToTarget = this.enemyTarget.transform.position - this.headTransform.position;

            //각도 차가 10 도미만이면 총쏜다.
            float distToAngle = Vector3.Angle(dirToTarget.normalized, this.headTransform.forward);
            if (distToAngle < 30.0f)
            {
                //자신이 물고있는총 다쏴재낀다.
                for (int i = 0; i < this.guns.Length; i++)
                {
                    this.guns[i].Fire();
                }
            }

        }



	}
}
