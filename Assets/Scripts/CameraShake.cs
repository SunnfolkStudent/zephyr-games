using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SimpleCamShake
{
    public class CameraShake : MonoBehaviour
    {
        private static Camera _cam;
        private IEnumerator _enumerator;

        public float duration = 0.1f;
        public float magnitude = 0.5f;

        private static float _duration = 0.1f;
        private static float _magnitude = 0.5f;

        private void Awake() => _cam = Camera.main;

        private void FixedUpdate() => SetShakeValues();

        private void SetShakeValues()
        {
            _duration = duration;
            _magnitude = magnitude;
        }

        public static IEnumerator Shake()
        {
            Vector3 originalPos = _cam.transform.localPosition;

            float elapsedTime = 0f;

            while (elapsedTime < _duration)
            {
                float xOffset = Random.Range(-0.5f, 0.5f) * _magnitude;
                float yOffset = Random.Range(-0.5f, 0.5f) * _magnitude;

                _cam.transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            _cam.transform.localPosition = originalPos;
        }

        public static IEnumerator VariableShake(float duration, float magnitude)
        {
            Vector3 originalPos = _cam.transform.localPosition;

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
                float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

                _cam.transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            _cam.transform.localPosition = originalPos;
        }
    }
}