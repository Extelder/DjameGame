using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHealth : Health
{
    public event Action ObjectDestroyed;
    
    public override void Death()
    {
        ObjectDestroyed?.Invoke();
    }
}
