using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalInputController : IHorizontalInputProvider
{
    private float _horizontalInput;
    
    public void OnUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    public float GetCurrentInput()
    {
        return _horizontalInput;
    }
}
