using UnityEngine;
using System.Collections;
using System;       //System 를 Using 하고 Random 을사용하면 UnityEngine 의 Random 과 충돌난다. 왜냐 System 도 Random 을가지고 있기때문이다.
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveSpheres : MonoBehaviour {



	// Use this for initialization
	void Start () {

        LoadSpheres();
	    
	}
	
	// Update is called once per frame
	void Update () {

        //구 랜덤으로 생성
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //기본 형오브젝트를 그냥 생성시켜준다.
            GameObject newSphere = 
                GameObject.CreatePrimitive(PrimitiveType.Sphere );

            
            //충돌때문에 Random 을 사용하려면   UnityEngine.Random 사용하자.....

            //위치 랜덤
            newSphere.transform.position = new Vector3(
                UnityEngine.Random.Range(-30.0f, 30.0f),
                UnityEngine.Random.Range(-30.0f, 30.0f),
                UnityEngine.Random.Range(-10.0f, 30.0f));

            //스케일 랜덤
            newSphere.transform.localScale = new Vector3(
                UnityEngine.Random.Range(0.5f, 10.0f),
                UnityEngine.Random.Range(0.5f, 10.0f),
                UnityEngine.Random.Range(0.5f, 10.0f));

            //이름랜덤
            int randName = UnityEngine.Random.Range(0, 4);

            string name = "";

            switch (randName)
            {
                case 0:
                    name = "태진아";
                    break;

                case 1:
                    name = "현철";
                    break;

                case 2:
                    name = "주현미";
                    break;

                case 3:
                    name = "김국환";
                    break;
            }

            newSphere.name = name;

            //Tag 부여
            newSphere.tag = "SaveSphere";




        }


        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject[] spheres = GameObject.FindGameObjectsWithTag("SaveSphere");
            //Random 으로 하나 제거
            if (spheres.Length > 0)
            {
                int rand = UnityEngine.Random.Range(0, spheres.Length);

                Destroy(spheres[rand]);

            }


        }
	
	}



    //자동 저장
    void OnApplicationQuit()
    {
        GameObject[] spheres = GameObject.FindGameObjectsWithTag("SaveSphere");

        //List 준비
        List<SaveInfo> saveList = new List<SaveInfo>();

        for (int i = 0; i < spheres.Length; i++)
        {
            SaveInfo saveInfo = new SaveInfo();

            saveInfo.posX = spheres[i].transform.position.x;
            saveInfo.posY = spheres[i].transform.position.y;
            saveInfo.posZ = spheres[i].transform.position.z;

            saveInfo.scaleX = spheres[i].transform.localScale.x;
            saveInfo.scaleY = spheres[i].transform.localScale.y;
            saveInfo.scaleZ = spheres[i].transform.localScale.z;

            saveInfo.name = spheres[i].name;

            saveList.Add(saveInfo);

        }

        //메모리를 2진데이터로 바꿔준다.
        BinaryFormatter formatter = new BinaryFormatter();

        //2진데이터화 된 메모리를 저장할 공간.
        MemoryStream memStream = new MemoryStream();

        //BinaryFormatter 인스턴스를 통해 saveList 의 메모리블럭을 2진데이터화하여 memStream 에 저장
        formatter.Serialize(memStream, saveList);

        //저장된 메모리스트림에 있는 메모리를 문자로 강제 치환
        string memStr = Convert.ToBase64String(memStream.GetBuffer());

        print(memStr);

        //플레이어프리펩에 문자열 자체로 저장
        PlayerPrefs.SetString("SphereInfos", memStr);


    }

    void LoadSpheres()
    {
        if (PlayerPrefs.HasKey("SphereInfos") == false) return;

        //얻어온다.
        string memStr = PlayerPrefs.GetString("SphereInfos");

        //문자열 메모리 바이트를 얻는다.
        byte[] memByte = Convert.FromBase64String(memStr);

        //위에서 얻은 메모리 바이트로 메모리 스트림 준비됨
        MemoryStream memStream = new MemoryStream(memByte);

        //메모리를 2진데이터로 바꿔준다.
        BinaryFormatter formatter = new BinaryFormatter();

        //메모리 스트림에 저장된 내용을 풀어 인스턴스 생성 ( 강제로 형변환 )
        //List 준비
        List<SaveInfo> saveList = (List<SaveInfo>)formatter.Deserialize(memStream);


        for (int i = 0; i < saveList.Count; i++)
        {
            //기본 형오브젝트를 그냥 생성시켜준다.
            GameObject newSphere =
                GameObject.CreatePrimitive(PrimitiveType.Sphere);


            newSphere.transform.position = new Vector3(
                saveList[i].posX, saveList[i].posY, saveList[i].posZ);


            newSphere.transform.localScale = new Vector3(
                saveList[i].scaleX, saveList[i].scaleY, saveList[i].scaleZ );

            newSphere.name = saveList[i].name;


            //Tag 부여
            newSphere.tag = "SaveSphere";
        }

    }

}
