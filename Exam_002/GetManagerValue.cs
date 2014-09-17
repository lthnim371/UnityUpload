using UnityEngine;
using System.Collections;

public class GetManagerValue : MonoBehaviour {

    public GameObject managerObject;

    public SingletonManager singletonManager;

	// Use this for initialization
	void Start () {

 

	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
            SingletonManager sm = managerObject.GetComponent<SingletonManager>();

            if (sm != null)
                print(sm.number);*/
            
            //print(singletonManager.number);
            
            
            print(SingletonManager.Instance.number);

           

        }
	
	}
}
