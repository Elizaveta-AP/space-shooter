using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private  List<GameObject> BGs = new List<GameObject>();
    [SerializeField] private int _speed;
    void Start()
    {
        BGs.Add(this.gameObject.transform.GetChild(0).gameObject);
        BGs.Add(this.gameObject.transform.GetChild(1).gameObject);
    }

    void FixedUpdate()
    {
        foreach (GameObject bg in BGs)
        {
            bg.transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.fixedDeltaTime);
            if (bg.transform.position.x < -18) bg.transform.position = bg.transform.position + new Vector3(36, 0, 0);
        }
    }
}
