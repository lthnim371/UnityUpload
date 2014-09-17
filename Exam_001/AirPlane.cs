using UnityEngine;
using System.Collections;

public class AirPlane : MonoBehaviour {

    public float maxSpeed = 30.0f;      //최고 이동속도
    public float minSpeed = 1.0f;       //최소 이동속도

    public float accelateSpeed = 10.0f; //스피드 가속량
    public float breakSpeed = 10.0f;    //브레이크 파워
    public float releasSpeed = 5.0f;    //속도 해제량

    private float nowSpeed = 0.0f;      //현재 이동속도

    public float yawSpeed = 90.0f;      //Yaw 최고 회전 능력
    public float pitchSpeed = 90.0f;    //Pitch 최고 회전 능력

    //비행기 모델에 대한 Transform
    public Transform childModelTrasform;

    //비행기 회전프로펠러
    public Transform[] pros;


    //자신이 가지고 있는 건
    private Gun[] guns;



	// Use this for initialization
	void Start () {

        //내가붙은 게임오브젝트뿐만 아니라 계층구조에서 나포함 내자식오브젝트까지 
        //싹다 검사하여 게임오브젝트들에 붙어있는 Gun 컴포넌트를 배열로 싹다 가져온다.
        //만약 없다면 0 개의 배열이 리턴된다.
        this.guns = this.gameObject.GetComponentsInChildren<Gun>();
	
	}
	
	// Update is called once per frame
	void Update () {

        //자신의 Speed 만큼 앞으로 전진
        this.transform.Translate(0, 0, this.nowSpeed * Time.deltaTime);


        //프로 펠러 회전 속도
        float rotSpeed = this.nowSpeed * 720.0f * Time.deltaTime;
        for (int i = 0; i < this.pros.Length; i++)
            this.pros[i].Rotate(0, 0, rotSpeed, Space.Self);
	

	}

    //스피드 조작 ( t 가 1 이면 악셀을 최대로 밝은거고, t 가 -1 이면 브레이크를 최대로 밝은거, 0 이면 아무조작도 안한거 )
    public void Accelate(float t)
    {
        //스피드 증가
        if (t > 0.0f)
            this.nowSpeed += Time.deltaTime * this.accelateSpeed * t;

        //브레이크
        else if (t < 0.0f)
        {
            //브레이트 빠지는 량
            float breakPower =  this.breakSpeed * t;


            //브레이크 파워가 정지량 보다 작으면 문제가 된다.
            if( breakPower < this.releasSpeed )
            {
                //정지력으로 정지시킴
                this.nowSpeed -= Time.deltaTime * this.releasSpeed;
            }

            else
            {
                //브레이크 파워로 정지시킴
                this.nowSpeed += Time.deltaTime * breakPower;
            }
        }

        //속도 저항
        else
            this.nowSpeed -= Time.deltaTime * this.releasSpeed;

        //속도의 한계 를 맞추자.
        /*
        if (this.nowSpeed > this.maxSpeed)
            this.nowSpeed = this.maxSpeed;
        else if (this.nowSpeed < this.minSpeed)
            this.nowSpeed = this.minSpeed;
        */
        //nowSpeed 를 this.minSpeed ~ this.maxSpeed clamp 한다.
        this.nowSpeed = Mathf.Clamp(this.nowSpeed, this.minSpeed, this.maxSpeed);

    }

    //비행기를 Yaw Pitch 회전 시킨다.
    public void RotYawPitch(float yaw, float pitch)
    {
        this.transform.Rotate(
            pitch * this.pitchSpeed * Time.deltaTime,
            yaw * this.yawSpeed * Time.deltaTime,
            0.0f);

        //차일드 비행기 모델이 자식으로 존재한다면...
        if (this.childModelTrasform != null)
        {
            //Yaw 입력에 따라 로컬 Roll 회전을 방향에 맞춰 최대 45 도 회전
            this.childModelTrasform.localRotation =
                Quaternion.Euler(0.0f, 0.0f, 45.0f * -yaw); 
        }

    }


    //비행기가 가진 총 발사
    public void FireGun()
    {
        for (int i = 0; i < this.guns.Length; i++)
            this.guns[i].Fire();
    }
}
