using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SimpleCamShake
{
    public class CameraShakeBasic : MonoBehaviour
    {
        private IEnumerator _enumerator;
        public float _duration = 0.1f;
        public float _magnitude = 0.5f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _enumerator = Shake(_duration, _magnitude);
                StartCoroutine(_enumerator);
            }
        }

        public IEnumerator Shake(float duration, float magnitude)
        {
            Vector3 originalPos = transform.localPosition;

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
                float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

                transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos;
        }
    }
}