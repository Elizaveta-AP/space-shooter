using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : SolidObject
{
    [SerializeField] protected GameObject Bullet;
    protected float ShootDelay;
    [SerializeField] protected List<Transform> BulletHolders = new List<Transform>();
    protected AudioSource ShotAudio;

    protected override void Start()
    {
        ShotAudio = gameObject.transform.Find("Laser").GetComponent<AudioSource>();
        base.Start();
    }


    protected IEnumerator ShootBullet(int shootAngle){
        while(true){
            yield return new WaitForSeconds(ShootDelay);
            foreach (Transform bulletHolder in BulletHolders){
                ShotAudio.Play();
                Instantiate(Bullet, bulletHolder.position, Quaternion.Euler(0, 0, shootAngle));}}
    }
}
