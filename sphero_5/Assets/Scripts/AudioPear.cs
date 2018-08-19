using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPear : MonoBehaviour {

    private AudioSource _audioSource;
    public static float[] _samples= new float[512];
    public static float[] _frecBands = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _freqBandHighest = new float[8];
    float[] _bufferDecese = new float[8];
    
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];
    void Start () {
        _audioSource = GetComponent<AudioSource>();
        

    }
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
	}

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {

            if (_frecBands[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _frecBands[i];

            }

            if (_freqBandHighest[i] == 0)
            {
                _audioBandBuffer[i] = 0;
            }
            else
            {
                float aux = (_bandBuffer[i] / _freqBandHighest[i]);
                if (aux < 0) { _audioBandBuffer[i] = 0; }
                else
                { _audioBandBuffer[i] = aux; }
                _audioBand[i] = (_frecBands[i] / _freqBandHighest[i]);
            }


        }
    }
    //esta funcion obtiene los datos del espetro sonoro de la cancion
    // y lo guarda en el array de muestras 
    private void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples,0,FFTWindow.Blackman);
    }
    //Crea un buffer en el cual mientras no se ingrse un valor de valor de frecuencia mayor al valor del buffer el buffer ira restando 
    //progresivamente el valor para que la barra no caiga inmediatamnte
    void BandBuffer()
    {
        for(int g=0;g<8; g++)
        {
            if(_frecBands[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _frecBands[g];
                _bufferDecese[g] = 0.005f;
            }
            if (_frecBands[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecese[g];
                _bufferDecese[g] *= 1.2f;
            }
        }
    }

    private void MakeFrequencyBands()
    {
        int cont = 0;
        for(int i=0;i<8;i++)
        {
            float averge = 0;
            int _sampleCount = (int)Mathf.Pow(2, i) * 2;
            if(i==7)
            { _sampleCount += 2; }
            for(int j=0;j<_sampleCount;j++)
            {
                averge += _samples[cont] *(cont+1);
                cont++;
            }

            averge /= cont;
            _frecBands[i] = averge * 10 ;
        }
    }
}
