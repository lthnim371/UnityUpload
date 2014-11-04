using UnityEngine;
using System.Collections;

public class MouseEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //
    // 마우스 관련 이벤트 ( 이벤트가 발생되려면 Collider 가 있어야한다 )
    //

    void OnMouseDown()          //마우스왼쪽 버튼 다운되었을때 발생
    {
        print("마우스 다운");
    }

    void OnMouseDrag()          //OnMouseDown 이후 OnMouseUp 되기 전까지 계속 호출 ( collider 영역을 벗어난 상태에서 업해도 일어남 )
    {
        print("마우스 위에서 누르고 있을때 ");
    }

    void OnMouseUp()            //마우스왼쪽 버튼 업 외었을때 발생 ( collider 영역을 벗어난 상태에서 업해도 일어남 )
    {
        print("마우스 업");
    }

    void OnMouseEnter()         //마우스커서가 Collider 영역에 들어오면
    {
        print("마우스 들어옴");
    }

    void OnMouseOver()          //마우스커서가 Collider 영역에 올라가있으면 계속 호출
    {
        print("마우스 위에있음");
    }

    void OnMouseExit()          //마우스커서가 Collider 영역에 나가면
    {
        print("마우스 나감");
    }


    


    

}
