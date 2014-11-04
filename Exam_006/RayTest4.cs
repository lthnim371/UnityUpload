using UnityEngine;
using System.Collections;

public class RayTest4 : MonoBehaviour {

    public float distance;          //거리

    private RaycastHit[] hits;      //충돌된 충돌 정보들

    public LayerMask layerMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //내전방 Ray
        Ray ray = new Ray( this.transform.position, this.transform.forward );

        //Ray 로 hit 정보 모두 싹다 가져온다.
        //이때 하나도 걸리는게 없으면 0 개의 배열이 리턴 된다. ( 이때 다행인건 가까운순으로 리턴된다 )
        hits = Physics.RaycastAll(ray, this.distance, layerMask.value  );

        if (hits.Length > 0)
        {
            /*
            for (int i = 0; i < hits.Length; i++)
            {
                print(hits[i].distance.ToString());

            }*/

            //print(hits.Length + " 개의 Hit 정보가 있다");
        }


	}

    void OnDrawGizmos()
    {
        if (this.hits == null  || this.hits.Length == 0)      //충돌 되지 않을때...
        {
            //rayDistance 만큼 Ray 를 쏜다.
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * this.distance);
        }

        else
        {
            for (int i = 0; i < this.hits.Length; i++)
            {
                //히트 정보 
                RaycastHit hit = this.hits[i];


                //충돌지점까지 빨가색선
                Gizmos.color = Color.red;
                Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * hit.distance);

                //충돌위치에 작은 점
                Gizmos.DrawSphere( hit.point, 0.1f);

                //충돌지점 노말
                Gizmos.DrawLine( hit.point,  hit.point +  hit.normal * 1.0f);



            }
        }



    }
}
