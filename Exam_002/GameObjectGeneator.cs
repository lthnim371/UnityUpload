using UnityEngine;
using System.Collections;


//젠정보 클래스
[System.Serializable]       //이태그가 붙은 클래스는 인스펙터뷰에 노출된다.
public class GenInfo
{
    public GameObject genObject;        //젠될 원본오브젝트
    public float nextGenInterval;       //이놈이 젠되고 다음젠이 몇초뒤니?
}

public class GameObjectGeneator : MonoBehaviour {


    public GenInfo[] genInfos;

    //몇초뒤부터 젠할꺼니?
    public float startDelayTime = 5.0f;

    //젠주기가 몇번이니?
    public int genCircleNum = 3;        //0 으로 셋팅하면 무한젠

    private bool bStay = true;

	// Use this for initialization
	void Start () {

        StartCoroutine("GenLoop");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GenLoop()
    {
        //bStay 가 true 가 될때까지 기달려라
        while (this.bStay == false)
            yield return null;  //프레임만 계속 넘긴다.


        print("젠시작....!!!!!");


        //젠대기타임 기다리고 
        yield return new WaitForSeconds(startDelayTime);

        do
        {

            //젠사이클 시작
            for (int i = 0; i < this.genInfos.Length; i++)
            {
                //이번에 젠될 정보
                GenInfo genInfo = this.genInfos[i];

                Instantiate(
                    genInfo.genObject,
                    this.transform.position,
                    this.transform.rotation);

                yield return new WaitForSeconds(
                    genInfo.nextGenInterval);
            }

            //젠사이클을 하나 뺀다.
            this.genCircleNum--;

        } while (this.genCircleNum != 0);


        //넌 니할일을 다했으니 죽어라
        Destroy(this.gameObject);

    }


    //이스크립트가 붙은 게임오브젝에 추가적으로 간단한 Gizmo 를 그리기 위한 용도로 
    //호출되는 함수
    //이함수는 Play 모드가 아니라 Edit 모드에서도 호출된다.
    void OnDrawGizmos()
    {

        //자신의 위치에 반지름 1.0 인 구를 그린다.
        //Gizmos.DrawSphere(this.transform.position, 1.0f);
        Gizmos.DrawWireSphere(this.transform.position, 1.0f);

        //내정면 방향으로 직선을 그린다.
        Gizmos.DrawLine(this.transform.position,
            this.transform.position + this.transform.forward * 3.0f);


    }


}
