using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimInputProvider
{
    public event Action OnLaunch;
    public void OnUpdate();
    public Vector2 GetAimTarget();
}
