using UnityEngine;
using System.Collections;

public class Gun_Direction : Gun {

    public float sideInterval = 0.4f;       //사이드 간격 

    protected override void FireProcess()
    {
        //좌측 이동량
        float leftDistance = (this.powerLevel - 1) * 0.5f * this.sideInterval;

        //발사 시작 위치
        Vector3 firePos = this.transform.position + -this.transform.right * leftDistance;

        for (int i = 0; i < this.powerLevel; i++)
        {
            //총알 발사 
            Instantiate(
                this.srcbullet,
                firePos,
                this.transform.rotation);


            firePos += this.transform.right * sideInterval;
        }
    }
}
