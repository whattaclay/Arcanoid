using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float _launchSpeed = 1f;
    [SerializeField] private Rigidbody2D _ball;
    private IAimInputProvider _aimInputProvider;

    private void Start()
    {
        _aimInputProvider = new AimInputProvider();
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
    }

    private void Update()
    {
        _aimInputProvider.OnUpdate();
    }
}
