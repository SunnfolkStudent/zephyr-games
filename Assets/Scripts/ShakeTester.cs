using System.Collections;
using UnityEngine;

namespace SimpleCamShake
{
    public class ShakeTester : MonoBehaviour
    {
        private IEnumerator _enumerator;
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(CameraShake.Shake());
            }
        
            if (Input.GetKeyDown(KeyCode.D))
            {
                _enumerator = CameraShake.VariableShake(1f, 0.2f);
                StartCoroutine(_enumerator);
            }
        }
    }
}