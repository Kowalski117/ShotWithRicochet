using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pistol : Weapon
{
    public override void Shot()
    {
        Instantiate(Bullet, _shotPoint.position, _shotPoint.rotation);
    }
}

