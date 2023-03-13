using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List Weapons", menuName = "WeaponsList", order = 51)]
public class WeaponsList : ScriptableObject
{
    [SerializeField] private List<GameObject> _list;

    public List<GameObject> List => _list;

    public GameObject TakeOneObject(int index)
    {
        if (index >= 0 && index < _list.Count)
            return _list[index];
        else
        {
            Debug.Log(index);
            return null;
        }
    }
}
