using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

    public float moveSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float moveZ = 0.0f;
        if (Input.GetKey(KeyCode.T))
            moveZ = 1.0f;
        else if (Input.GetKey(KeyCode.G))
            moveZ = -1.0f;


        this.transform.Translate(
            Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,
            Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime,
            moveZ * moveSpeed * Time.deltaTime );


	}


    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "SavePos"))
        {

            //자신의 위치를 Local 파일에 저장
            PlayerPrefs.SetFloat("PosX", this.transform.position.x);
            PlayerPrefs.SetFloat("PosY", this.transform.position.y);
            PlayerPrefs.SetFloat("PosZ", this.transform.position.z);

            //Save 적용
            PlayerPrefs.Save();

            print("저장 완료");
        }

        if (GUI.Button(new Rect(0, 50, 100, 50), "LoadPos"))
        {
            //자신의 위치를 Load
            Vector3 pos = this.transform.position;

            if (PlayerPrefs.HasKey("PosX"))
                pos.x = PlayerPrefs.GetFloat("PosX");

            if (PlayerPrefs.HasKey("PosY"))
                pos.y = PlayerPrefs.GetFloat("PosY");

            if (PlayerPrefs.HasKey("PosZ"))
                pos.z = PlayerPrefs.GetFloat("PosZ");


            this.transform.position = pos;

            print("로드 완료");
        }


        if (GUI.Button(new Rect(0, 100, 100, 50), "DeltePosX"))
        {
            if (PlayerPrefs.HasKey("PosX"))
                PlayerPrefs.DeleteKey("PosX");
        }


        if (GUI.Button(new Rect(0, 150, 100, 50), "Delete All"))
        {
            PlayerPrefs.DeleteAll();
        }

    }
}
