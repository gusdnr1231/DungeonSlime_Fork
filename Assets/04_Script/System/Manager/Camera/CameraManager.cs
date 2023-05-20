using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FD.Dev;

public class CameraManager : MonoBehaviour
{

    private CinemachineVirtualCamera cvcam;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    private CinemachineConfiner2D confiner2D;

    public static CameraManager instance;

    private void Awake()
    {

        instance = this;

        cvcam = FindObjectOfType<CinemachineVirtualCamera>();
        confiner2D = FindObjectOfType<CinemachineConfiner2D>();

        cbmcp = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

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

    public void CameraTarget(Transform trm)
    {

        cvcam.Follow = trm;

    }
    
    public void SetCof(Collider2D col)
    {

        confiner2D.m_BoundingShape2D = col;

    }

}
