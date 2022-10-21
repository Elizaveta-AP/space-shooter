using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Shell : MonoBehaviour
{
    
    protected float Speed;
    [SerializeField] protected int Damage;
    protected Vector3 forvard;
    protected string MyTag;
    


    protected virtual void Start()
    {
        
    }

    
    protected void Move(Rigidbody2D rb)
    {
        rb.MovePosition(transform.position + forvard * Speed * Time.fixedDeltaTime);
        if ((transform.position.x > 10) || (transform.position.x < -10)) Death();
    }
    
    protected void Death(){
        Destroy(gameObject);
    }
}
