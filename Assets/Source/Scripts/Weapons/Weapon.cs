using Source.Scripts.Empty;
using UnityEngine;

namespace Source.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private int _price;
        [SerializeField] protected Bullet Bullet;

        protected Transform _shotPoint;

        public int Price => _price;

        private void Start()
        {
            _shotPoint = GetComponentInChildren<ShotPoint>().transform;
        }

        public abstract void Shot();
    }
}