using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        //게임 시작전 풀준비
        GameObjectPoolManager.Instance.ReadyPool("Bullet", 30);
        GameObjectPoolManager.Instance.ReadyPool("RedBullet", 20);
        GameObjectPoolManager.Instance.ReadyPool("Ball", 10);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
