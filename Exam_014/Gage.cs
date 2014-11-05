using UnityEngine;
using System.Collections;

public class Gage : MonoBehaviour {

    public UISprite gageSprite;
    private float nowGageFill = 1.0f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.nowGageFill = Mathf.Abs( Input.GetAxis("Horizontal") );


        this.gageSprite.fillAmount = nowGageFill;
	
	}
}
