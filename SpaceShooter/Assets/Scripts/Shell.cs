using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Shell : SolidObject
{
    protected override void Start()
    {
        base.Start();
    }

    
    protected void Move(Rigidbody2D rb)
    {
        rb.MovePosition(transform.position + new Vector3 (Speed, 0, 0) * Time.fixedDeltaTime);
        if (transform.position.x > 11) Destroy(gameObject);
    }
}
