using UnityEngine;
using System.Collections;

public class PrevScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PrevSceneFunc()
    {
        Application.LoadLevel(0);
    }
}
