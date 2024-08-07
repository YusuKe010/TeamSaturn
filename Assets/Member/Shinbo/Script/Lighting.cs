using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Lighting : MonoBehaviour
{
    [SerializeField] GameObject[] _lights;
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        _lights[0].SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time > 25)
        {
            _lights[3].SetActive(false);
            _lights[4].SetActive(true);
        }
        else if (_time > 20 && _time <= 25)
        {
            _lights[2].SetActive(false);
            _lights[3].SetActive(true);
        }
        else if (_time > 15 && _time <= 20)
        {
            _lights[1].SetActive(false);
            _lights[2].SetActive(true);
        }
        else if (_time > 10 && _time <= 15)
        {
            _lights[0].SetActive(false);
            _lights[1].SetActive(true);
        }
    }
}
