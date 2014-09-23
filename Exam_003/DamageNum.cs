using UnityEngine;
using System.Collections;

public class DamageNum : MonoBehaviour {

    //자식 TextMesh Transform 
    private Transform childTextMeshTrans;


    void Awake()
    {
        this.childTextMeshTrans = this.transform.FindChild("TextMesh");
    }

    void OnEnable()
    {
        Invoke("AutoDisable", Random.Range(3.0f, 4.0f));
    }

    void AutoDisable()
    {
        this.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
	
	}


    void OnDisable()
    {
        this.rigidbody.velocity = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {


        //카메라를 항상 바라보게
        this.childTextMeshTrans.rotation = Camera.main.transform.rotation;
	
	}

    
}
