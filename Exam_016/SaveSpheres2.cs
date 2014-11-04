using UnityEngine;
using System.Collections;
using System;       //System 를 Using 하고 Random 을사용하면 UnityEngine 의 Random 과 충돌난다. 왜냐 System 도 Random 을가지고 있기때문이다.
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveSpheres2 : MonoBehaviour {

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

        //버퍼에 있는 내용을 파일에 그대로 써재낀다.
        byte[] memArr = memStream.GetBuffer();

        //Application.persistentDataPath 유니티 Application 에 할당된 로컬 저장 경로 ( 여기에 파일저장하면 Save Load 아무문제 없다 )
        string savePath = Application.persistentDataPath + "/SaveFile.Dat";

        //파일스트림 생성
        FileStream fileStream = new FileStream(
                                savePath,                   //파일경로 ( 파일경로에 폴더가 만들어지지 않았다면 DirectoryNotFoundException 가 발생한다 )
                                FileMode.Create,            //파일모드
                                FileAccess.Write            //파일접근 권한
                                );

        //파일스트림에 쓴다.
        fileStream.Write(memArr, 0, memArr.Length);

        //파일스트림 닫는다.
        fileStream.Close();
        
        print(savePath + "에 저장완료!!!!!");

    }

    void LoadSpheres()
    {
        //일어올 경로
        string loadPath = Application.persistentDataPath + "/SaveFile.Dat";

         FileStream fileStream = null;
         try
         {
             fileStream = new FileStream(
                        loadPath,
                        FileMode.Open,
                        FileAccess.Read);

             byte[] memByte = new byte[fileStream.Length];
             fileStream.Read(memByte, 0, (int)fileStream.Length);
             fileStream.Close();



             //위에서 얻은 메모리 바이트로 메모리 스트림 준비됨
             MemoryStream memStream = new MemoryStream(memByte);

             //메모리를 2진데이터로 바꿔준다.
             BinaryFormatter formatter = new BinaryFormatter();

             //메모리 스트림에 저장된 내용을 풀어 인스턴스 생성 ( 강제로 형변환 )
             //List 준비
             List<SaveInfo> saveList = (List<SaveInfo>)formatter.Deserialize(memStream);


             print(loadPath + "에 로드 완료!!!!!");

             for (int i = 0; i < saveList.Count; i++)
             {
                 //기본 형오브젝트를 그냥 생성시켜준다.
                 GameObject newSphere =
                     GameObject.CreatePrimitive(PrimitiveType.Sphere);


                 newSphere.transform.position = new Vector3(
                     saveList[i].posX, saveList[i].posY, saveList[i].posZ);


                 newSphere.transform.localScale = new Vector3(
                     saveList[i].scaleX, saveList[i].scaleY, saveList[i].scaleZ);

                 newSphere.name = saveList[i].name;


                 //Tag 부여
                 newSphere.tag = "SaveSphere";
             }



         }
         catch (Exception e)
         {
             print(e.Message);
         }




        

    }

}
