using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {

    public int _band;
    public float _startScale, _scaleMultipli;
    public bool _useBuffer;
    Material _material;
	// Use this for initialization
	void Start () {
        _material = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if(_useBuffer)
        {
            
            transform.localScale = new Vector3(transform.localScale.x, (AudioPear._bandBuffer[_band] * _scaleMultipli) + _startScale, transform.localScale.z);
            Color _color = new Color(AudioPear._bandBuffer[_band], AudioPear._bandBuffer[_band], AudioPear._bandBuffer[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer)
        {
            //transform.localScale = new Vector3(transform.localScale.x, (AudioPear._audioBand[_band] * _scaleMultipli) + _startScale, transform.localScale.z);
            //Color _color = new Color(AudioPear._audioBand[_band], AudioPear._audioBand[_band], AudioPear._audioBand[_band]);
           // _material.SetColor("_EmissionColor", _color);
        }
    }
}
