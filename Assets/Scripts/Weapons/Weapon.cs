using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed;
    [SerializeField] protected Bullet _bullet;

    protected Transform _shotPoint;

    private void Start()
    {
        _shotPoint = GetComponentInChildren<ShotPoint>().transform;
    }

    public abstract void Shot();

}
