using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public event Action OnLaunched;
    
    [SerializeField] private float _launchSpeed = 1f;
    [SerializeField] private float _delayBetweenLaunches = 0.2f;
    [SerializeField] private int _ballsPerLaunch = 10;
    [SerializeField] private Rigidbody2D _ballPrefab;
    [SerializeField] private AimInputProviderBase _aimInputProvider;

    private void Start()
    {
        _aimInputProvider.OnLaunch += Launch;
    }

    private void Launch()
    {
        _aimInputProvider.OnLaunch -= Launch;

        StartCoroutine(LaunchAllBalls());
        
        OnLaunched?.Invoke();
    }

    private IEnumerator LaunchAllBalls()
    {
        for (int i = 0; i < _ballsPerLaunch; i++)
        {
            var ball = Instantiate(_ballPrefab);
            ball.position = transform.position;
        
            var shootDirection = _aimInputProvider.GetAimTarget() - ball.position;
            shootDirection.Normalize();
            shootDirection *= _launchSpeed;
        
            ball.transform.parent = null;
            ball.AddForce(shootDirection, ForceMode2D.Impulse);
            yield return new WaitForSeconds(_delayBetweenLaunches);
        }
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
