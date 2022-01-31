
using UnityEngine;
using Cinemachine;
using Pixelplacement;
namespace Core.Character
{
    public class CamController : MonoBehaviour
    {
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        private float shakeTime;
        private void Awake()
        {
            cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        }
        public void ShakeCamera(float intensity, float time)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                 cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            shakeTime = time;
                
        }

        private void Update()
        {
            shakeTime -= Time.deltaTime;
            if( shakeTime <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                 cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;

            }
        }
    }
}