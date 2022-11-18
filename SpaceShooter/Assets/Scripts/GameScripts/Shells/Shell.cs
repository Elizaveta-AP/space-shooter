using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shell : MonoBehaviour
{
    private Rigidbody2D ThisRigidbody;
    protected Transform ThisTransform;
    protected float Speed;
    protected int Damage;
    protected Vector3 forvard;
    protected string MyTag;

    protected virtual void Start()
    {
        ThisRigidbody = transform.GetComponent<Rigidbody2D>();
        ThisTransform = gameObject.transform;
        
        forvard = ThisTransform.up;
    }
    
    protected void Move()
    {
        ThisRigidbody.MovePosition(ThisTransform.position + forvard * Speed * Time.fixedDeltaTime);
        if ((ThisTransform.position.x > 10) || (ThisTransform.position.x < -10)) Death();
    }
    
    protected void Death(){
        Destroy(gameObject);
    }
}
