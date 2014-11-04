using UnityEngine;
using System.Collections;

public class RayTest3 : MonoBehaviour {

    public Collider col;            //체크할 컬리더
    public float distance;          //거리
    public RaycastHit hit;  

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        Ray ray = new Ray(this.transform.position, this.transform.forward);

        //특정 대상과만 Ray 체크를 한다.
        if (col.Raycast(ray, out hit, this.distance))
        {
            print("대상과 충돌");
        }


	}

    void OnDrawGizmos()
    {
        if (this.hit.collider == null)      //충돌 되지 않을때...
        {
            //rayDistance 만큼 Ray 를 쏜다.
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * this.distance );
        }

        else
        {
            //충돌지점까지 빨가색선
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * this.hit.distance);

            //충돌위치에 작은 점
            Gizmos.DrawSphere(this.hit.point, 0.1f);

            //충돌지점 노말
            Gizmos.DrawLine(this.hit.point, this.hit.point + this.hit.normal * 1.0f);

            //정반사벡터

            Vector3 InVector = this.transform.forward.normalized;          //입사 벡터 ( 정규화 되어있음 )
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
