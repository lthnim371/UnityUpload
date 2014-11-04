using UnityEngine;
using System.Collections;

public class RayTest : MonoBehaviour {

    public float rayDistance = 100.0f;          //레이 체크 거리

    //레이 Hit 정보를 받아올 구조체
    private RaycastHit hit; 
  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //나의 위치에서 나의 위치 전방으로에대한 레이구조체 준비
        Ray ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
        
        //레이 Hit 정보를 받아올 구조체
        //RaycastHit hit;   

        //RayCast ( Ray Cast 의 대상은 Collider 가 존재해야 한다 )
        if (Physics.Raycast(
            ray,                    //Ray 구조체
            out this.hit,                //RaycastHit 충돌정보를 out 으로 받아온다.
            this.rayDistance        //Ray 거리
            ))
        {
           
            //hit.collider                  //Ray 에 충돌된 Collider
            //hit.collider.gameObject       //Ray 에 충돌된 Collider 의 게임오브젝트
            //hit.transform                 //Ray 에 충돌된 Collider 의 최상위 오브젝트의 Transform ( 단 최상위 오브젝트에 Rigidbody 가 있을때 )
            //hit.transform.gameObject      //Ray 에 충돌된 Collider 의 최상위 오브젝트의 게임오브젝트 ( 단 최상위 오브젝트에 Rigidbody 가 있을때 )

            //hit.distance                  //Ray 의 원점과 충돌지점까지의 거리
            //hit.point                     //충돌 지점
            //hit.normal                    //충돌 표면의 Normal

            //충돌지점의UV 도 알수 있지만 Primitve 도형은 안되고 외부에 불러온 메쉬만 된다....
            //hit.textureCoord
            //hit.textureCoord1
            //hit.textureCoord2

            print("Ray 가 " + hit.collider.gameObject.name + " 에 충돌하였다");
            //print("Ray 가 " + hit.transform.gameObject.name + " 에 충돌하였다");
        }

	}


    void OnDrawGizmos()
    {
        if (this.hit.collider == null)      //충돌 되지 않을때...
        {
            //rayDistance 만큼 Ray 를 쏜다.
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * this.rayDistance);
        }

        else
        {
            //충돌지점까지 빨가색선
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * this.hit.distance );

            //충돌위치에 작은 점
            Gizmos.DrawSphere(this.hit.point, 0.1f);

            //충돌지점 노말
            Gizmos.DrawLine(this.hit.point, this.hit.point + this.hit.normal * 1.0f);

            //정반사벡터
           
            Vector3 InVector =  this.transform.forward.normalized;          //입사 벡터 ( 정규화 되어있음 )
            Vector3 Normal = this.hit.normal.normalized;                    //표면 법선 ( 정규화 돠어있음 )

            /*
           float dot = Vector3.Dot(Normal, InVector);
           Vector3 project = Normal * dot;             //InVector 를 Normal 로 투영한벡터

           Vector3 reflect = -2 * project + InVector;   //InVector 가 Normal 방향으로 정방사된 벡터
           reflect.Normalize();
           */

            Vector3 reflect = Vector3.Reflect(InVector, Normal);



            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(this.hit.point, this.hit.point + reflect * 1.0f);

        }


    }

}
