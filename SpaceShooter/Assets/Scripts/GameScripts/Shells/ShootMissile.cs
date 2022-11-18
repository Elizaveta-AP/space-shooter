using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootMissile : MonoBehaviour
{
    [SerializeField] private GameObject _missile;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _loadAnimator;
    private Transform _transform;
    private int _missilesCount, _loadingTime;
    private bool _isLoaded;

    void Start()
    {
        _isLoaded = false;
        _transform = gameObject.transform;
        _missilesCount = 50;
        _loadingTime = 5;
        SetText();

        TryToLoad();
    }


    void Update()
    {
        if (_isLoaded && Input.GetButtonUp("Fire2")) { Shoot(); }
    }

    private IEnumerator Loading()
    {
        _loadAnimator.SetTrigger("LoadMissile");
        
        yield return new WaitForSeconds(_loadingTime);

        _isLoaded = true;
    }

    private void Shoot()
    {
        _missilesCount -= 1;
        SetText();

        Instantiate(_missile, _transform.position + new Vector3 (0.5f,0f,0f), _transform.rotation);

        _isLoaded = false;
        TryToLoad();
    }

    private void SetText()
    {
        _text.text = $"{_missilesCount}";
    }

    private void TryToLoad()
    {
        if (_missilesCount > 0) { StartCoroutine(Loading()); }
        else { _loadAnimator.SetTrigger("Unloaded"); }        
    }
}
