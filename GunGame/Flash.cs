using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flash : MonoBehaviour
{
    Image _img;

    void Start()
    {
        _img = GetComponent<Image>();
        _img.color = Color.clear;
    }

    void Update()
    {
        if (true) {
                this._img.color = new Color(1.0f, 0f, 0f, 0.7f);
        } else { 
               this._img.color = Color.Lerp(this._img.color, Color.clear, Time.deltaTime);
        }
    }
}
