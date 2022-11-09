using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Sprite[] _images = new Sprite[2];
    private  List<GameObject> BGs = new List<GameObject>();
    private SpriteRenderer _BG0_0, _BG0_1, _BG1_0, _BG1_1;
    private int _currentImage;


    void Start()
    {
        _currentImage = -1;
        BGs.Add(this.gameObject.transform.GetChild(0).gameObject);
        _BG0_0 = BGs[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
        _BG0_1 = BGs[0].transform.GetChild(1).GetComponent<SpriteRenderer>();

        BGs.Add(this.gameObject.transform.GetChild(1).gameObject);
        _BG1_0 = BGs[1].transform.GetChild(0).GetComponent<SpriteRenderer>();
        _BG1_1 = BGs[1].transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        foreach (GameObject bg in BGs)
        {
            bg.transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.fixedDeltaTime);
            if (bg.transform.position.x < -18) bg.transform.position = bg.transform.position + new Vector3(36, 0, 0);
        }

        if (((_currentImage == -1) && (Score.CurrentScore.GetScore() >= 5000)) || ((_currentImage == 0) && (Score.CurrentScore.GetScore() >= 15000))
        || (((_currentImage == 1) && (Score.CurrentScore.GetScore() >= 30000))))
        {
            _currentImage += 1;
            StartCoroutine(ChangeBackground());
        }
    }

    private IEnumerator ChangeBackground()
    {
        while (true)
        {
            yield return null;

            if (_currentImage == 0)
            {
                _BG0_0.color = _BG0_0.color - new Color(0, 0, 0, 0.1f) * Time.fixedDeltaTime;
                _BG1_0.color = _BG0_0.color - new Color(0, 0, 0, 0.1f) * Time.fixedDeltaTime;
                if (_BG0_0.color.a <= 0)
                {
                    _BG0_0.sprite = _images[0];
                    _BG1_0.sprite = _images[0];
                    yield break;
                }
            }

            else if (_currentImage == 1)
            {
                _BG0_0.color = _BG0_0.color + new Color(0, 0, 0, 0.1f) * Time.fixedDeltaTime;
                _BG1_0.color = _BG0_0.color + new Color(0, 0, 0, 0.1f) * Time.fixedDeltaTime;
                if (_BG0_0.color.a >= 1)
                {
                    _BG0_1.sprite = _images[1];
                    _BG1_1.sprite = _images[1];
                    yield break;
                }
            }

            else
            {
                _BG0_0.color = _BG0_0.color - new Color(0, 0, 0, 0.1f) * Time.fixedDeltaTime;
                _BG1_0.color = _BG0_0.color - new Color(0, 0, 0, 0.1f) * Time.fixedDeltaTime;
                if (_BG0_0.color.a <= 0)
                {
                    yield break;
                }
            }
        }
    }
}
