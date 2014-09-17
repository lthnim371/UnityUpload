using UnityEngine;
using System.Collections;

public class AirPlane : MonoBehaviour {

    public float moveSpeed = 5.0f;

    private Gun[] guns;         //자신에 게 물린 건


    void Awake()
    {
        //자신 뿐만 아니라 자신의 게임오브젝트 계층구조 자식으로 붙어있는 게임오브젝트
        //까지 싹다 검사하여 Gun 컴포넌트를 배열로 싹다 가져온다.
        this.guns = this.GetComponentsInChildren<Gun>();


        //출생신고
        PlaneManager.Instance.AddPlane(this);
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
    }


    public void FireAllGun()
    {
        //자신이 가지고 있는 총 모두 발사
        for (int i = 0; i < this.guns.Length; i++)
            this.guns[i].Fire();
    }


}
