using Source.Scripts;
using Source.Scripts.SO;
using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    [SerializeField] private Transform _pistolPoint;
    [SerializeField] private ObjectList _weapons;
    [SerializeField] private int _price;

    private GameObject _weapon;

    public int Price => _price;

    private void Awake()
    {
        _weapon = Instantiate(_weapons.TakeOneObject(Save.GetWeapon()), _pistolPoint.transform.position, _pistolPoint.transform.rotation);
        _weapon.transform.SetParent(transform);
    }
}