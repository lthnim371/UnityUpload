using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter 객체를 사용하기위한 Using
using System.IO;               //MemoryStream 을 사용하기 위한 Using
using System;                   //Convert 를 사용하기 위한 Using 
    

//저장정보로 사용될 구의 정보
[System.Serializable]       //저장되는 Class 로 사용하려면 System.Serializable 이 태그가 붙어있어야한다...
public class SaveInfo
{
    //맴버로 Vector3 못쓴다... ㅠㅠ
    //Vector3 pos;

    public float posX;
    public float posY;
    public float posZ;

    public string name;

    public float scaleX;
    public float scaleY;
    public float scaleZ;
}


public class SaveSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "SaveInfo"))
        {
            SaveSphereInfo();
        }

        if (GUI.Button(new Rect(0, 50, 100, 50), "LoadInfo"))
        {
            LoadSphereInfo();
        }
    
    }

    //현재 정보를 저장
    void SaveSphereInfo()
    {
        //정보를 저장하기위한 클래스 생성
        SaveInfo saveInfo = new SaveInfo();
        saveInfo.posX = this.transform.position.x;
        saveInfo.posY = this.transform.position.y;
        saveInfo.posZ = this.transform.position.z;

        saveInfo.scaleX = this.transform.localScale.x;
        saveInfo.scaleY = this.transform.localScale.y;
        saveInfo.scaleZ = this.transform.localScale.z;

        saveInfo.name = this.gameObject.name;

        //메모리를 2진데이터로 바꿔준다.
        BinaryFormatter formatter = new BinaryFormatter();

        //2진데이터화 된 메모리를 저장할 공간.
        MemoryStream memStream = new MemoryStream();

        //BinaryFormatter 인스턴스를 통해 saveInfo 의 메모리블럭을 2진데이터화하여 memStream 에 저장
        formatter.Serialize(memStream, saveInfo);

        //저장된 메모리스트림에 있는 메모리를 문자로 강제 치환
        string memStr = Convert.ToBase64String(memStream.GetBuffer());

        print(memStr);

        //플레이어프리펩에 문자열 자체로 저장
        PlayerPrefs.SetString("SphereInfo", memStr);
    }

    //저장된 정보를 로드
    void LoadSphereInfo()
    {
        if (PlayerPrefs.HasKey("SphereInfo") == false) return;

        //얻어온다.
        string memStr = PlayerPrefs.GetString("SphereInfo");
        
        //문자열 메모리 바이트를 얻는다.
        byte[] memByte = Convert.FromBase64String(memStr);

        //위에서 얻은 메모리 바이트로 메모리 스트림 준비됨
        MemoryStream memStream = new MemoryStream(memByte);

        //메모리를 2진데이터로 바꿔준다.
        BinaryFormatter formatter = new BinaryFormatter();

        //메모리 스트림에 저장된 내용을 풀어 인스턴스 생성 ( 강제로 형변환 )
        SaveInfo saveInfo = (SaveInfo)formatter.Deserialize(memStream);

        //로드된 인스턴스로 정보 갱신
        this.transform.position = new Vector3(
            saveInfo.posX,
            saveInfo.posY,
            saveInfo.posZ);
        this.transform.localScale = new Vector3(
            saveInfo.scaleX,
            saveInfo.scaleY,
            saveInfo.scaleZ);

        this.gameObject.name = saveInfo.name;




    }
    

}
