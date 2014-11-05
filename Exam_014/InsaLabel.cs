using UnityEngine;
using System.Collections;

[RequireComponent( typeof( UILabel ) )]
public class InsaLabel : MonoBehaviour {

    public string userName = "송대관";
    private string insaText = "안녕하세요 [{0:X6}]{1}[-] 님";

    public Color nameColor;


    private UILabel uiLabel;

    void Awake()
    {
        
        this.uiLabel = this.GetComponent<UILabel>();


        //무자열서식대로 문자 만들어준다.
        //string.Format("안녕하세요 {0} 님", userName);


        //컬러 숫자 값
        int colorNum =
            ((int)(255.0f * nameColor.r) << 16) |
            ((int)(255.0f * nameColor.g) << 8) |
            ((int)(255.0f * nameColor.b));

        //UILabel 의 text 를 셋팅한다.
        this.uiLabel.text = string.Format(insaText, colorNum, userName);

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
