using UnityEngine;
using System.Collections;

[RequireComponent( typeof( TweenPosition ) )]
public class ButtonPosition : MonoBehaviour {

    public Vector3 movePosition = Vector3.zero;         //처음위치에서 얼마나 움직일건지...

    private TweenPosition tweenPos;

    void Awake()
    {
        //TweenPosition 얻는다
        this.tweenPos = this.GetComponent<TweenPosition>();


        //처음위치 얻는다.
        Vector3 fromPosition = this.transform.localPosition;

        //타겟을
        Vector3 toPosition = fromPosition + movePosition;


        this.tweenPos.from = fromPosition;
        this.tweenPos.to = toPosition;


    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
