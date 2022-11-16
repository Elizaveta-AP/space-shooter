using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SolidObject : MonoBehaviour
{
    [SerializeField] protected Animator DamageAnimation;
    protected int MaxHealth, CurrentHealth;
    protected float Speed;

    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        DamageAnimation.SetTrigger("TakeDamage");

        if (CurrentHealth <= 0) { Death(); }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
