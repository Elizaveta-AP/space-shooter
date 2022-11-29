using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : SolidObject
{
    [SerializeField] protected GameObject Bullet;
    protected float ShootDelay;
    protected List<Transform> BulletHolders = new List<Transform>();
    protected AudioSource ShotAudio;

    protected override void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if (child.CompareTag("HolderBullet") && (child.gameObject.activeInHierarchy))
            {
                BulletHolders.Add(child);
            }
            else if (child.CompareTag("HolderBullet") && GameSettings.CurrentSettings.GetHasAdditionalGuns())
            {
                child.gameObject.SetActive(true);
                BulletHolders.Add(child);
            }
        }

        ShotAudio = gameObject.transform.Find("Laser").GetComponent<AudioSource>();
        base.Start();
    }


    protected IEnumerator ShootBullet()
    {
        while(true)
        {
            yield return new WaitForSeconds(ShootDelay);

            foreach (Transform bulletHolder in BulletHolders)
            {
                ShotAudio.Play();
                Instantiate(Bullet, bulletHolder.position, bulletHolder.rotation);
            }  
        }
    }
}
