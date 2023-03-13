using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List Characters", menuName = "CharactersList", order = 51)]
public class CharactersList : ScriptableObject
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
