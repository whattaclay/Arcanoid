using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public event Action OnLaunched;
    [SerializeField] private float _launchSpeed = 1f;
    [SerializeField] private Rigidbody2D _ball;
    [SerializeField] private AimInputProviderBase _aimInputProvider;

    private void Start()
    {
        _aimInputProvider.OnLaunch += Launch;
        _ball.transform.parent = transform;
    }

    private void Launch()
    {
        _aimInputProvider.OnLaunch -= Launch;
        var shootDirection = _aimInputProvider.GetAimTarget() - _ball.position;
        shootDirection.Normalize();
        shootDirection *= _launchSpeed;
        _ball.transform.parent = null;
        _ball.AddForce(shootDirection, ForceMode2D.Impulse);
        
        OnLaunched?.Invoke();
    }

    /*private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.color = Color.red;

        var targetPos = _aimInputProvider.GetAimTarget();
        var initialPos = transform.position;
        Gizmos.DrawLine(initialPos, targetPos);
    }*/
}
