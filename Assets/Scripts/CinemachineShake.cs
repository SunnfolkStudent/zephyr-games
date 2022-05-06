using System.Collections;
using Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    private string camName;

    private CinemachineBrain _brain;
    
    private void Awake()
    {
        Instance = this;
        //cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _brain = GetComponent<CinemachineBrain>();
        
        if (cinemachineVirtualCamera == null)
        {
            cinemachineVirtualCamera = _brain.ActiveVirtualCamera as CinemachineVirtualCamera;
        }
    }
   private  IEnumerator Start()
    {
        yield return null;
        if (cinemachineVirtualCamera == null)
        {
            cinemachineVirtualCamera = _brain.ActiveVirtualCamera as CinemachineVirtualCamera;
        }
    }
   

    public void ShakeCamera(float intensity, float time)
    {
        print("Iscalled");
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    
        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
}

    private void Update()
    {
        if (cinemachineVirtualCamera == null) return;
        
        if (cinemachineVirtualCamera.name !=_brain.ActiveVirtualCamera.VirtualCameraGameObject.name)
        {
            cinemachineVirtualCamera = _brain.ActiveVirtualCamera as CinemachineVirtualCamera;
        }
        
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1-(shakeTimer / shakeTimerTotal));
        }
    }
}
