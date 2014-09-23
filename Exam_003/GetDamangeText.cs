using UnityEngine;
using System.Collections;

public class GetDamangeText : MonoBehaviour {

    public GameObject texObect;

	// Use this for initialization
	void Start () {

        GameObjectPoolManager.Instance.ReadyPool(
             "DamageText", 5);
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*
            GameObject newTextObject = Instantiate(
                this.texObect,
                this.transform.position,
                Quaternion.identity) as GameObject;
            */

            GameObject newTextObject = GameObjectPoolManager.Instance[
                "DamageText"].ActiveObject(this.transform.position, Quaternion.identity);





            //3D TextMesh 컴포넌트를 받는다.
            TextMesh tm = newTextObject.GetComponentInChildren<TextMesh>();
            if (tm != null)
            {
                tm.text = Random.Range(300, 500).ToString();
            }


            //리지드 바디가 있다면..
            if (newTextObject.rigidbody != null)
            {
                //포스준다.
                Vector3 force = new Vector3(
                    Random.Range(-10, 10),
                    Random.Range(30, 50),
                    Random.Range(-10, 10));
                newTextObject.rigidbody.AddForce(force, ForceMode.Impulse);

            }

            



        }
        
	
	}
}
