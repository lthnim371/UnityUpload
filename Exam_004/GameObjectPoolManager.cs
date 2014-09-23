using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPoolManager : MonoBehaviour {

    private static GameObjectPoolManager sInstance;
    public static GameObjectPoolManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newObject = new GameObject("_GameObjectPoolManager");
                sInstance = newObject.AddComponent<GameObjectPoolManager>();
            }

            return sInstance;
        }
    }

    //풀 Table
    private Dictionary<string, GameObjectPool> poolTable;
    
    void Awake()
    {
        //풀 Table 생성
        this.poolTable = new Dictionary<string, GameObjectPool>();

        //씬이 교체되어도 나는 안파괴되게
        DontDestroyOnLoad(this.gameObject);
    }

    /*
    public GameObjectPool GetPool(string name)
    {
        return this.poolTable[name];
    }*/


    //인덱스 프로퍼티 
    public GameObjectPool this[string name]
    {
        get
        {
            //해당 name 의 풀이 없다면...
            if (this.poolTable.ContainsKey(name) == false)
            {
                return this.ReadyPool(name, 100);
            }

            //있으면 기존대로...
            return this.poolTable[name];
        }
    }

    

    //풀을 준비한다
    public GameObjectPool ReadyPool(string name, int poolNum)
    {
        //새로운 게임오브젝트를 만든다.
        GameObject newObject = new GameObject(string.Format("GameObjectPool_{0}", name));
        
        //거기에 GameObjectPool 컴포넌트를 붙인다
        GameObjectPool newPool = newObject.AddComponent<GameObjectPool>();

        //풀준비한다.
        if (newPool.ReadyPool(name, poolNum))
        {
            //풀준비 성공
           
            //풀오브젝트 자식으로
            newObject.transform.parent = this.transform;

            //table 에 참조시킨다.
            poolTable.Add(name, newPool);


            return newPool;
        }

        //실패 했다면..
        return null;
    }





}
