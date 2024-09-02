using UnityEngine;
using UnityEngine.Events;

namespace Source.Scripts
{
    public class Wall : MonoBehaviour
    {
        public event UnityAction BulletCrashed;

        public void BulletBroke()
        {
            BulletCrashed?.Invoke();
        }
    }
}
