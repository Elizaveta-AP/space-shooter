using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Transform _transform;
    private List<Rigidbody2D> MagnetizedObjects = new List<Rigidbody2D>();
    private int _magnetizedSpeed = 10;

    void Start()
    {
        _transform = gameObject.transform;

    }


    private void FixedUpdate() 
    {
        if (MagnetizedObjects.Count > 0)
        {
            for (int i = 0; i < MagnetizedObjects.Count; i++)
            {
                if(MagnetizedObjects[i] == null)
                {
                    MagnetizedObjects.Remove(MagnetizedObjects[i]);
                    i--;
                    continue;
                }

                Vector3 position = MagnetizedObjects[i].transform.position;
                Vector3 direction = _transform.position - position;

                MagnetizedObjects[i].MovePosition(position + direction.normalized * _magnetizedSpeed * Time.fixedDeltaTime);
            }
        }
        
    }

    private void OnDisable() 
    {
        foreach (Rigidbody2D magnetizedObject in MagnetizedObjects)
        {
            magnetizedObject.GetComponent<Coin>().StartMoveCoroutine();
        }
    }



    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Coin"))
        {
            other.GetComponent<Coin>().StopMoveCoroutine();
            //other.transform.parent = this.transform;
            MagnetizedObjects.Add(other.GetComponent<Rigidbody2D>());
        }
    }


}
