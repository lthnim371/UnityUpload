using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class NightVision : MonoBehaviour {

	public Shader effectShader;
	private Material effectMaterial;
	public Material EffectMaterial{
		get{
			if( effectMaterial == null )
			{
				effectMaterial = new Material( this.effectShader );
				effectMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			
			return effectMaterial;
		}
	}


	public Texture2D vignetteTex;
	public Texture2D scanLineTex;
	public Texture2D noiseTex;
	public float noiseXSpeed = 100.0f;
	public float noiseYSpeed = 100.0f;
	public float scanLineTileAmount = 4.0f;
	public float distortion = 0.2f;
	public float contrast = 2.0f;
	public float brightness = 1.0f;
	public Color nightVisionColor = Color.white;

	private float randomValue = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		contrast = Mathf.Clamp(contrast, 0f,4f);
		brightness = Mathf.Clamp(brightness, 0f, 2f);
		randomValue = Random.Range(-1f,1f);
		distortion = Mathf.Clamp(distortion, -1f,1f);
	
	}

	void OnRenderImage( RenderTexture srcTexture, RenderTexture dstTexture )
	{
		this.EffectMaterial.SetFloat("_distortion", this.distortion);
		this.EffectMaterial.SetFloat("_Contrast", this.contrast);
		this.EffectMaterial.SetFloat("_Brightness", this.brightness);
		this.EffectMaterial.SetColor("_NightVisionColor", this.nightVisionColor);
		this.EffectMaterial.SetFloat("_RandomValue", this.randomValue);

		this.EffectMaterial.SetTexture("_VignetteTex", this.vignetteTex);

		this.EffectMaterial.SetTexture("_ScanLineTex", this.scanLineTex);
		this.EffectMaterial.SetFloat("_ScanLineTileAmount", scanLineTileAmount);

		this.EffectMaterial.SetTexture("_NoiseTex", this.noiseTex);
		this.EffectMaterial.SetFloat("_NoiseXSpeed", this.noiseXSpeed);
		this.EffectMaterial.SetFloat("_NoiseYSpeed", this.noiseYSpeed);

		Graphics.Blit (srcTexture, dstTexture, this.EffectMaterial);
	}


}
