using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SimpleCamShake
{
    public class ShakeTester : MonoBehaviour
    {
        private IEnumerator _enumerator;
    
        private void Update()
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                print("Clicked");
                //StartCoroutine(CameraShake.Shake());
                CinemachineShake.Instance.ShakeCamera(1f, 1f);
               
            }
        
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                _enumerator = CameraShake.VariableShake(1f, 0.2f);
                //StartCoroutine(_enumerator);
                
            }
        }
    }
}