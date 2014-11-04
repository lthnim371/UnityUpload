using UnityEngine;
using System.Collections;

public class LaserCannon : MonoBehaviour {

    public float range = 100.0f;

    private LineRenderer[] lineRenderers;
    public GameObject pointSphere;

    public GameObject hitEffect;

    void Awake()
    {
        this.lineRenderers = this.GetComponentsInChildren<LineRenderer>();


    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //화면 마우스 위치로 캐논 회전
        
        //마우스 레이
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit, this.range))
        {
            Vector3 dirToLook = hit.point - this.transform.position;

            dirToLook.Normalize();
            this.transform.rotation = Quaternion.LookRotation(dirToLook, Vector3.up);

            //히트된놈에 Rigid body 가 있다면..
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(this.transform.forward * 30.0f, ForceMode.Acceleration);

            }

            Instantiate(
                this.hitEffect,
                hit.point,
                Quaternion.LookRotation(hit.normal));

        }

        else
        {
            Vector3 targetPos = mouseRay.origin + mouseRay.direction * this.range;

            Vector3 dirToLook = targetPos - this.transform.position;

            dirToLook.Normalize();
            this.transform.rotation = Quaternion.LookRotation(dirToLook, Vector3.up);


        }








        //정면 레이
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        
        if (Physics.Raycast(ray, out hit, this.range))
        {
            //사정거리 내로 충돌이 되었다면...
            //LineRender 포지션셋팅
            if (this.lineRenderers.Length > 0 )
            {
                for (int i = 0; i < this.lineRenderers.Length; i++)
                {
                    //월드 기준으로
                    this.lineRenderers[i].useWorldSpace = true;

                    this.lineRenderers[i].SetPosition(0, this.transform.position);
                    this.lineRenderers[i].SetPosition(1, hit.point);

                }

                //포인트 구 히트 위치로
                this.pointSphere.SetActive(true);
                this.pointSphere.transform.position = hit.point;
            }
        }

        else
        {
            if (this.lineRenderers.Length > 0)
            {
                for (int i = 0; i < this.lineRenderers.Length; i++)
                {
                    //월드 기준으로
                    this.lineRenderers[i].useWorldSpace = true;

                    this.lineRenderers[i].SetPosition(0, this.transform.position);
                    this.lineRenderers[i].SetPosition(1, this.transform.position + this.transform.forward * this.range);

                }
                this.pointSphere.SetActive(false);

            }
        }

	
	}
}
