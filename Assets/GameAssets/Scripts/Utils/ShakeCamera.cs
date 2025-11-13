using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using Cinemachine;


public class ShakeCamera : Singleton<ShakeCamera>
{

    public CinemachineVirtualCamera VirtualCamera;
    public float shakeTime;

    private CinemachineBasicMultiChannelPerlin _channelPerlin;

    [Header("Shake Values")]
    public float amplitude = 2f;
    public float frequency = 2f;
    public float time = .3f;

    [NaughtyAttributes.Button]
    public void Shake()
    {
        Shake(amplitude, frequency, time);
    }
    public void Shake(float amplitude, float frequency, float time)
    {
        //_channelPerlin = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _channelPerlin.m_AmplitudeGain = amplitude;
        _channelPerlin.m_FrequencyGain = frequency;
        shakeTime = time;

    }

    private void Start()
    {
        //_channelPerlin = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (shakeTime > 0) 
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            _channelPerlin.m_AmplitudeGain = 0f;
            _channelPerlin.m_FrequencyGain = 0f;
        }
    }

}
