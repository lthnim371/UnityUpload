using UnityEngine;
using System.Collections;

public class AirPlane : MonoBehaviour {

    public float moveSpeed = 5.0f;

    private Gun[] guns;         //자신에 게 물린 건


    private Transform shipModel;            //ShipModelTransform;

    private float shipModelRoll;            //쉽모델 Roll 회전값
    private float shipModelRollDir;         //쉽모델 롤방향 -1 이면 왼쪽  1 이면 오른쪽
    private float shipModelMaxRoll = 45;    //최대 회전치


    void Awake()
    {
        //자신 뿐만 아니라 자신의 게임오브젝트 계층구조 자식으로 붙어있는 게임오브젝트
        //까지 싹다 검사하여 Gun 컴포넌트를 배열로 싹다 가져온다.
        this.guns = this.GetComponentsInChildren<Gun>();


        //출생신고
        PlaneManager.Instance.AddPlane(this);

        //바로 밑 자식의 갯수
        int childCount = this.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            //i번째 자식의 이름을 얻는다.
            string name = this.transform.GetChild(i).gameObject.name;

            //해당 이름에 Model 이 포함되어있으면...
            if (name.Contains("Model"))
            {
                this.shipModel = this.transform.GetChild(i);
                break;
            }

        }
        

    }



    // Use this for initialization
    void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update () {


        //초당 30 의 값으로 Roll 회전
        this.shipModelRoll += this.shipModelRollDir * Time.deltaTime * 30.0f;

        this.shipModelRoll = Mathf.Clamp(this.shipModelRoll,
            -this.shipModelMaxRoll,
            this.shipModelMaxRoll);


        this.shipModel.localRotation = Quaternion.Euler(0, 0, -shipModelRoll);


	}

    

    void OnDestroy()
    {
        //사망신고
        if( PlaneManager.IsAppQuit == false )       //프로그램이 종료되어서 파괴되는 것이 아닐때만...
            PlaneManager.Instance.RemovePlane(this);
    }

    public void Move_Order(Vector3 moveDir)
    {
        //매프래임 이동량
        float moveDelta = this.moveSpeed * Time.deltaTime;

        //이동 벡터
        Vector3 moveVec = moveDir * moveDelta;

        //자신의 축기준으로 이동 시킨다.
        this.transform.Translate(moveVec);


        //moveDir.x 좌우 이동
        this.shipModelRollDir = moveDir.x;



    }


    public void FireAllGun()
    {
        //자신이 가지고 있는 총 모두 발사
        for (int i = 0; i < this.guns.Length; i++)
            this.guns[i].Fire();
    }


}
