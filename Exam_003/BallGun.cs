using UnityEngine;
using System.Collections;

public class BallGun : MonoBehaviour {

    public GameObject ball;


    public Transform fireTransform;


    public float Power = 1000.0f;

    private int ballNum = 10;

    public TextMesh textMehs;


	// Use this for initialization
	void Start () {


        this.textMehs.text = string.Format("Ball Count {0}", this.ballNum);
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Fire();
        }
    

	}


    void Fire()
    {
        if (this.ballNum == 0) return;

        GameObject newBall = Instantiate(
            this.ball,
            this.fireTransform.position,
            this.fireTransform.rotation) as GameObject;


        //만들어진 볼에 Rigidbody 가 붙어있다면...
        if (newBall.rigidbody != null)
        {
            //파워 준다
            newBall.rigidbody.AddForce(
                this.fireTransform.forward * Power );
        }

        ballNum--;
        this.textMehs.text = string.Format("Ball Count {0}", this.ballNum);
    }
}
