using UnityEngine;
using System.Collections;

public class Hull : MonoBehaviour {

    public float hp = 100.0f;       //내구도


    public GameObject hitEffect;            
    public GameObject destroyEffeect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HaveDamage(float damage)
    {
        this.hp -= damage;


        //히트 Effect 존재한다면...
        if (this.hitEffect != null)
        {
            Instantiate(
                this.hitEffect,
                this.transform.position,
                Quaternion.identity);           //Quaternion.identity 회전량이 없는 사원수
        }


        if (this.hp <= 0.0f)
        {
            Destroy(this.gameObject);


            //파괴 Effect 존재한다면...
            if (this.destroyEffeect != null)
            {
                Instantiate(
                    this.destroyEffeect,
                    this.transform.position,
                    Quaternion.identity);           //Quaternion.identity 회전량이 없는 사원수
            }
        }
    }

}
