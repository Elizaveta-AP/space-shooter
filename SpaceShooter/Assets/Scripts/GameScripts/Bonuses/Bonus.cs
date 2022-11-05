using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected int Speed;
    protected Rigidbody2D _rb;
    public virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Speed = 3;
    }


    protected void FixedUpdate()
    {
        _rb.MovePosition(transform.position - new Vector3(Speed, 0, 0) * Time.fixedDeltaTime);

        if (transform.position.x < -11) Destroy(this.gameObject);
    }

    public virtual void GetBonus(GameObject player)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            GetBonus(other.gameObject);
        }
    }
}
