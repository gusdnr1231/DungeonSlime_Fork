using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FD.Dev;

public class CameraManager : MonoBehaviour
{

    private CinemachineVirtualCamera cvcam;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    public static CameraManager instance;

    private void Awake()
    {
        //Vcam은 여러씬에 있으므로 디스트로이에 올리면 복잡해짐
        instance = this;

    }

    public void ShackCamera(float amplitudeGain, float frequencyGain, float duration)
    {

        cbmcp.m_AmplitudeGain += amplitudeGain;
        cbmcp.m_FrequencyGain += frequencyGain;

        FAED.InvokeDelay(() =>
        {

            cbmcp.m_AmplitudeGain -= amplitudeGain;
            cbmcp.m_FrequencyGain -= frequencyGain;

        }, duration);

    }

}
