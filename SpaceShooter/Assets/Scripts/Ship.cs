using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : SolidObject
{
    [SerializeField] protected GameObject Bullet;
    protected int ShootDelay;
    [SerializeField] protected Transform LeftBullet, RightBullet;

    protected override void Start()
    {
        base.Start();
    }


    protected IEnumerator ShootBullet(int shootAngle){
        while(true){
            yield return new WaitForSeconds(ShootDelay);
            Instantiate(Bullet, LeftBullet.position, Quaternion.Euler(0, 0, shootAngle));
            Instantiate(Bullet, RightBullet.position, Quaternion.Euler(0, 0, shootAngle));}
    }
}
