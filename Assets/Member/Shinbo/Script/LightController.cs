using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
