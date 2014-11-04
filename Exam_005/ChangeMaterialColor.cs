using UnityEngine;
using System.Collections;

public class ChangeMaterialColor : MonoBehaviour {

    public Color changeColor;
    public Texture2D changeTexture;

    private MeshRenderer myRenderer;

   

    void Awake()
    {
        //Renderer 도 기본 컴포넌트이다.
        this.myRenderer = this.renderer as MeshRenderer;

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //renderer 의 material 프로퍼티로 접근하여 수정
            //새로운 material 인스턴스를 만들어서 그것을 수정하고 적용시킴 ( 드로우콜 증가 대신 나혼자만 바뀜)

     

            this.myRenderer.materials[0].SetColor(
                "_Color",               //바꿀컬러의 Shader Propertie 이름 ( Material 항목 우상단 Edit 버튼으로 확인가능 )
                this.changeColor        //바뀔컬러 값
                );


            this.myRenderer.materials[0].SetTexture(
                "_MainTex",
                this.changeTexture);
   


            /*
            //renderer 의 sharedMaterial 프로퍼티로 접근하여 수정
            //material 원본에 접근하여 그것을 수정 ( 드로우콜 증가없음 대신 같은 매터리얼쓰는 놈들 다바뀜 )


            this.myRenderer.sharedMaterial.SetColor(
               "_Color",               //바꿀컬러의 Shader Propertie 이름 ( Material 항목 우상단 Edit 버튼으로 확인가능 )
               this.changeColor        //바뀔컬러 값
               );


            this.myRenderer.sharedMaterial.SetTexture(
                "_MainTex",
                this.changeTexture);
            */

        }
	
	}
}
