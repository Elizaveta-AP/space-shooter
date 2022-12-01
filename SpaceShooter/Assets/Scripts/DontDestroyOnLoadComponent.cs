using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadComponent : MonoBehaviour
{
    private string _createdTag;

    void Awake()
    {
        _createdTag = gameObject.name;

        GameObject obj = GameObject.FindWithTag(_createdTag);

        if (obj != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.tag = _createdTag;
            DontDestroyOnLoad(gameObject);
        }
    }

}
