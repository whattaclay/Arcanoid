using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHorizontalInputProvider
{
    public void OnUpdate();
    public float GetCurrentInput();
}
