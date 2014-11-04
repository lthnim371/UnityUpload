using UnityEngine;
using System.Collections;

public class UVScroll : MonoBehaviour {

    public float speedU = 0.1f;     //가로 진행 속도
    public float speedV = 0.1f;     //세로 진행 속도

    public string texProperty = "";     //스크롤진행될 Texture 프로퍼티 네임


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //현재 Material 의 texProperty 이름의 Texture 의 Offset 을 얻는다.
        Vector2 nowUV = this.renderer.material.GetTextureOffset(texProperty);
        
        //속도에 따른 증가
        nowUV.x += Time.deltaTime * speedU;
        nowUV.y += Time.deltaTime * speedV;

        //다시셋팅
        this.renderer.material.SetTextureOffset(texProperty, nowUV);

        //셋팅된 Skybox 메터리얼에 접근
        //RenderSettings.skybox
        //RenderSettings.skybox.SetFloat( 
	
	}
}
