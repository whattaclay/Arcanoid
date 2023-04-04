using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimInputProvider : IAimInputProvider
{
    public event Action OnLaunch;
    private Vector3 _aimTarget;
    
    public void OnUpdate()
    {
        ProcessLaunchInput();
        ProcessAimInput();
    }

    private void ProcessAimInput()
    {
        _aimTarget = Input.mousePosition;
        _aimTarget = Camera.main.ScreenToWorldPoint(_aimTarget);
    }

    private void ProcessLaunchInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            OnLaunch?.Invoke();
        }
    }

    public Vector2 GetAimTarget()
    {
        return _aimTarget;
    }
}
