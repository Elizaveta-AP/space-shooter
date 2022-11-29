using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : MonoBehaviour
{
    private Transform _transform;
    private Animator _animator;
    private float _diametr, _speed;
    private int _damage;

    void Start()
    {
        _transform = gameObject.transform;
        _animator = transform.GetComponent<Animator>();

        _diametr = GameSettings.CurrentSettings.GetMissileDamageDiametr();
        _animator.SetFloat("Diametr", _diametr);

        _damage = GameSettings.CurrentSettings.GetMissileDamage();
        
        StartCoroutine(Death());
    }

    
    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy" || other.tag == "Meteor")
        {
            other.GetComponent<SolidObject>().TakeDamage(_damage);
        }
    }
}
