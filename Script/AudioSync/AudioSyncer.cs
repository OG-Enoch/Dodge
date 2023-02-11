using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    private float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;

    float m_previousAudioValue;
    float m_audioValue;
    float m_timer;

    protected bool m_isBeat;
    void Start()
    {
        
    }

    void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        bias = (float)Random.Range(50, 100);
        m_previousAudioValue = m_audioValue;
        m_audioValue = AudioSpectrum.spectrumValue;
        
        if(m_previousAudioValue > bias && m_audioValue <= bias)
        {
            if(m_timer > timeStep)
            {
                OnBeat();
            }
        } 
        if(m_previousAudioValue <= bias && m_audioValue > bias)
        {
            if(m_timer > timeStep)
            {
                OnBeat();
            }
        }

        m_timer += Time.deltaTime;
    }
    public virtual void OnBeat()
    {
        //Debug.Log("beat");
        m_timer = 0;
        m_isBeat = true;
    }
}
