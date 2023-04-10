using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LaserPointerView : MonoBehaviour
    {
        [SerializeField] private AimInputProviderBase _aimInputProvider;
        private void Update()
        {
            Vector3 targetPoint = _aimInputProvider.GetAimTarget();
            var direction = targetPoint - transform.position;
            transform.up = direction;
        }
    }
}