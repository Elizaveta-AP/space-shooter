using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SolidObject : MonoBehaviour
{
    protected int MaxHealth, CurrentHealth;
    protected float Speed;
    protected virtual void Start(){
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(int damage){
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) Death();
    }

    public virtual void Death(){
        Destroy(gameObject);
    }
}
