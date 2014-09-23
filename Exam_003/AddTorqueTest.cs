using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody ) )]
public class AddTorqueTest : MonoBehaviour
{

    public Vector3 force = Vector3.zero;        //얼만큼 Force 를 줄건지...

    //아무리 기본컴포넌트라고 해도 미리 물어놓고 사용하면 효과적이다. ( 오버헤드 방지 )
    private Transform _transform;
    private Rigidbody _rigidbody;

    private bool bDownKey = false;

    public bool bApplyMess = false;         //질량의 영향을 받니?
    public bool bContinueForce = false;     //지속적인 힘이니?

    public GUIStyle guiStyle;

    void Awake()
    {
        //this.transform;
        //this.GetComponent<Transform>();

        //기본 컴포넌트 미리 참조 시켜 놓는다.
        this._transform = this.transform;
        this._rigidbody = this.rigidbody;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.bDownKey = true;
        }

       
	
	}

    void FixedUpdate()
    {
        //특정강체의 회전힘인 Torque 는 최고 토크량이 정해져있다.
        //따라서 Edit->Project Setting->Physics Manager 에서 Max Angluar Velocity 를 설정해주면 최고 토크량을 지정할수 있다.


        
        //지속적인 힘의 처리라면...
        if (this.bContinueForce)
        {
            //키를 누르고 있을때 처리
            if (Input.GetKey(KeyCode.Space))
            {
                this._rigidbody.AddTorque(force, (bApplyMess) ? ForceMode.Force : ForceMode.Acceleration);
            }
        }

        else
        {
            //한번만 눌렸을때 처리
     
            
            //Input.GetKeyDown 같은 경우 FixedUpdate 에서 정확한 값을 얻을수 없다.
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //      this._rigidbody.AddForce(force);
            //}

            if (this.bDownKey)
            {

                this._rigidbody.AddTorque(force, (bApplyMess) ? ForceMode.Impulse : ForceMode.VelocityChange);
                this.bDownKey = false;
            }

        }

        //                              용도                              질량 영향
        //ForceMode.Force               지속적으로힘을 가할때             질량 영향 받음
        //ForceMode.Acceleration        지속적으로힘을 가할때             질량 영향 무시
        //ForceMode.Impulse             단타로 힘을 가할때                질량 영향 받음
        //ForceMode.VelocityChange      단타로 힘을 가할때                질량 영향 무시


    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 30, 300, 30), string.Format("AngularVelocity : {0}", this._rigidbody.angularVelocity), this.guiStyle);

        //rigidbody.angularVelocity 
        //Rigidbody 의 초당 월드 Torque(회전) 속도를 알려준다. ( 참고로 대입이 가능 )
    }

}
