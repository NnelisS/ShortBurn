using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class EffectManager : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;

    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ScreenShake(float _time, float _frequency, float _amplitude)
    {
        StartCoroutine(Shake(_time, _frequency, _amplitude));
    }

    private IEnumerator Shake(float _shakeTime, float _frequency, float _amplitude)
    {
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = _frequency;
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = _amplitude;
        yield return new WaitForSeconds(_shakeTime);
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0.7f;
    }
}
