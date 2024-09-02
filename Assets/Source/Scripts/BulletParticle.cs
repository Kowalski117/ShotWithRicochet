using UnityEngine;

namespace Source.Scripts
{
    public class BulletParticle : MonoBehaviour
    {
        [SerializeField] private int _price;

        public int Price => _price;
    }
}