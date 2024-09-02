using Source.Scripts.Empty;
using UnityEngine;

namespace Source.Scripts.Weapons
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _label;
        [SerializeField] private int _price;
        [SerializeField] private bool _isBuyed;
        [SerializeField] protected Bullet Bullet;
        
        protected AudioSource ShotSound;
        protected Transform _shotPoint;

        public int Price => _price;

        private void Start()
        {
            _shotPoint = GetComponentInChildren<ShotPoint>().transform;
            ShotSound = GetComponent<AudioSource>();
        }

        public abstract void Shot();

    }
}