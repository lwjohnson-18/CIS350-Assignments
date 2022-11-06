using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    protected override void Awake()
    {
        base.Awake();
        damage = 20;
    }
}
