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
                StartCoroutine(CameraShake.Shake());
               
            }
        
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                _enumerator = CameraShake.VariableShake(1f, 0.2f);
                StartCoroutine(_enumerator);
            }
        }
    }
}