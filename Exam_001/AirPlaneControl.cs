using UnityEngine;
using System.Collections;

public class AirPlaneControl : MonoBehaviour {

    private AirPlane airPlane;       //내가 컨트롤 할 AirPlane

    public GUIStyle guiStyle;

	// Use this for initialization
	void Start () {

        //내가붙은 게임오브젝트의 컴포넌트 중 AirPlane 타입의 컴포넌트 인스턴스를 얻어온다.
        //만약 없다면 null 이 리턴된다.
        //this.airPlane = this.gameObject.GetComponent<AirPlane>();

        //내가붙은 게임오브젝트의 컴포넌트 중 AirPlane 타입의 컴포넌트 인스턴스를 얻어온다.
        //이때 리턴되는 타입이 Component 이기때문에 AirPlane 으로 as 형변환을한다.
        //만약 없다면 null 이 리턴된다.
        this.airPlane = this.gameObject.GetComponent(typeof(AirPlane)) as AirPlane;



        
        

	}
	
	// Update is called once per frame
	void Update () {

        //자신한테 물린 AirPlane 의 인스턴스 Speed 를 컨트롤 한다.
        if (Input.GetKey(KeyCode.W))
            this.airPlane.Accelate(1.0f);
        else if (Input.GetKey(KeyCode.S))
            this.airPlane.Accelate(-1.0f);
        else
            this.airPlane.Accelate(0.0f);

        
        //AirPlane 회전 컨트롤
        float yaw = 0.0f;
        float pitch = 0.0f;
        
        //회전 컨트롤은 마우스로 하자
        //Input.mousePosition

        //마우스의 위치를 얻자
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        //마우스의 위치 범위를 0 ~ 1 로...
        float factorX = Mathf.Clamp01( mouseX / Screen.width );
        float factorY = Mathf.Clamp01( mouseY / Screen.height );

        // 0 ~ 1 의 범위를 -1 ~ 1 의 범위로 바꾸어 yaw pitch 에 대입
        yaw = (factorX * 2.0f) - 1.0f;
        pitch = (factorY * 2.0f) - 1.0f;


        this.airPlane.RotYawPitch(yaw, -pitch);


        /*
        if (Input.GetKey(KeyCode.LeftArrow))
            yaw = -1.0f;
        else if (Input.GetKey(KeyCode.RightArrow))
            yaw = 1.0f;

        if (Input.GetKey(KeyCode.UpArrow))
            pitch = -1.0f;
        else if (Input.GetKey(KeyCode.DownArrow))
            pitch = 1.0f;
        */


        //마우스 좌버튼을 누르면 계속 발사된다.
        if (Input.GetMouseButton(0))
        {
            this.airPlane.FireGun();
        }
	
	}

    //해당 게임오브젝트에대한 UI 출력을할때 자동으로 호출된다.
    //호출되는 원리는 그냥 OnGUI 라는 이름의 함수를 찾아 실행되는 방식이다 
    void OnGUI()
    {
        //문자열 화면 좌상단에 출력해보자 ( 출력내용은 마우스의 위치값 )
        GUI.Label(new Rect(0, 0, 300, 30), "Mouse Pos : " + Input.mousePosition.ToString(), guiStyle);
        GUI.Label(new Rect(0, 30, 300, 30), "Screen W : " + Screen.width, guiStyle);
        GUI.Label(new Rect(0, 60, 300, 30), "Screen H : " + Screen.height, guiStyle);
    }

}
