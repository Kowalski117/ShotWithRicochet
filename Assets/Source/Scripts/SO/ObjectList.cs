using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.SO
{
    [CreateAssetMenu(fileName = "New List Object", menuName = "ObjectList", order = 51)]
    public class ObjectList : ScriptableObject
    {
        [SerializeField] private List<GameObject> _list;

        public List<GameObject> List => _list;

        public GameObject TakeOneObject(int index)
        {
            if (index >= 0 && index < _list.Count)
            {
                return _list[index];
            }
            else
            {
                return null;
            }
        }
    }
}