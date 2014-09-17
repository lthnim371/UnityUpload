using UnityEngine;
using System.Collections;

public class Gun_Radial : Gun {

    public float angleInterval = 10.0f;       //각도 간격 ( Degree )

    protected override void FireProcess()
    {
        /*
        Quaternion rot = Quaternion.Euler(20, 30, 10);
        Vector3 vec = new Vector3(1, 0, 0);
        Vector3 result;
        //result = vec * rot;      //Error
        result = rot * vec;       //ok
        */

        /*
        //각도 간격에 따른 회전량
        Quaternion rot = Quaternion.AngleAxis(this.angleInterval, this.transform.up);

        //시작시 왼쪽으로 돌릴량
        Quaternion startRot = Quaternion.AngleAxis(
            -( (this.powerLevel - 1) * 0.5f * this.angleInterval ),
            this.transform.up );

        //내정면의 앞방향
        Vector3 shotfront = startRot * this.transform.forward;

        for (int i = 0; i < this.powerLevel; i++)
        {
            Instantiate(
                this.srcbullet,
                this.transform.position,
                Quaternion.LookRotation(shotfront, this.transform.up ));


            //샷방향을 회전 시킨다.
            shotfront = rot * shotfront;

        }*/


        //각도 간격에 따른 회전량
        Quaternion rot = Quaternion.AngleAxis(this.angleInterval, this.transform.up);

        //시작시 왼쪽으로 돌릴량
        Quaternion startRot = Quaternion.AngleAxis(
            -((this.powerLevel - 1) * 0.5f * this.angleInterval),
            this.transform.up);

        //샷회전량
        Quaternion shorRot = this.transform.rotation * startRot;

        for (int i = 0; i < this.powerLevel; i++)
        {
            CreateBullet(this.transform.position, shorRot);

            //샷방향을 회전 시킨다.
            shorRot = shorRot * rot;

        }





    }
}
