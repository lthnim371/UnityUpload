using UnityEngine;
using System.Collections;


//
// Image Effect 는 반듯이 카메라에 붙여라.
//
[RequireComponent( typeof( Camera ) )]
[ExecuteInEditMode]
public class OutlineImageEffect : MonoBehaviour {

    public Shader outlineEffectShader;
	private Material effectMaterial;

    //메터티얼 접근 프로퍼티
    public Material EffectMaterial
    {
        get
        {
            if (this.effectMaterial == null)
            {
				this.effectMaterial = new Material(this.outlineEffectShader);
                //메터리얼 생성옵션 ( 보여지지도 안고 에셋으로 저장되지도 않는다 )
                this.effectMaterial.hideFlags = HideFlags.HideAndDontSave;

            }
            return this.effectMaterial;

        }
    }


	[Range( 0, 1.0f )]
	public float grayAmount = 1.0f;



	[Range( 1, 10.0f )]
	public float size = 1.0f;

	// Use this for initialization
	void Start () {

        //ImageEffect 가 지원이 안된다면....( ImageEffect 는 Pro 버젼만 된다 )
        if (!SystemInfo.supportsImageEffects)
        {
            this.enabled = false;
            return;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//최종 결과 화면이 화면에 랜더링 될때 실행된다. ( Pro 만 된다 )
	//srcTexture 랜더링 결과
	//dstTexture 화면에 찍을 결과 
	void OnRenderImage( RenderTexture srcTexture, RenderTexture dstTexture )
	{
		this.EffectMaterial.SetFloat( "_Size", this.size );
		Graphics.Blit( 
		              srcTexture, 				//예를  ( Shader _MainTex 에 물림) 
		              dstTexture, 				//여기에 복사
		              this.EffectMaterial		//이메터리얼의 셰이더를 통해서 
		              );
	}


    void OnDestroy()
    {
        if (this.effectMaterial != null)
        {
            DestroyImmediate(this.effectMaterial);
        }

    }

}







