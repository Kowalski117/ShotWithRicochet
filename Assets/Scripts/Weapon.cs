using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed;
    [SerializeField] protected Transform _shotPoint;
    [SerializeField] protected Bullet _bullet;

    public abstract void Shot();

}
