using UnityEngine;
using UnityEngine.Events;

public class Wall : MonoBehaviour
{
    public event UnityAction BulletCrashed;

    public void BulletBroke()
    {
        BulletCrashed?.Invoke();
    }
}
