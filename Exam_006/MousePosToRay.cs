using UnityEngine;
using System.Collections;

public class MousePosToRay : MonoBehaviour {

    //어떤 카메라를 기준으로 할꺼냐?
    public Camera cam;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            //마우스 위치
            Vector3 mousePos = Input.mousePosition;

            //마우스는 화면위치이다.
            //현재화면을 뿌리는 카메라의 기준으로 월드 Ray 를 뽑아낸다.
            Ray ray = this.cam.ScreenPointToRay(mousePos);


            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //hit 된 물체 사라져라
                Destroy(hit.collider.gameObject);

            }



        }
	
	}
}
