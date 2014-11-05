using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager sInstance;

    public static GameManager Instance
    {
        get
        {
            return sInstance;
        }
    }

    void Awake()
    {
        sInstance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //게임 종료
    public void Quit()
    {
        Application.Quit();
    }


    //1번씬으로씬
    public void LoadScene()
    {
        Application.LoadLevel(1);
    }
}
