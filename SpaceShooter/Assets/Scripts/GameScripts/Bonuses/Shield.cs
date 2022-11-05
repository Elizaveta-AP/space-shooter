using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int _workTime;
    void Start()
    {
        _workTime = 15;

        GameObject lastShield = transform.parent.Find("Shield(Clone)").gameObject;
        if (lastShield != this.gameObject) { Destroy(lastShield); }
        
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        yield return new WaitForSeconds(_workTime);

        Destroy(this.gameObject);
    }
}
