using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Transform _pistolPoint;
    [SerializeField] private WeaponsList _weapons;
    private FixedJoystick _joystick;
    private Rigidbody _rigidbody;

    private float _speedRun;
    private GameObject _weapon;

    private void Awake()
    {
        _weapon = Instantiate(_weapons.TakeOneObject(Save.GetWeapon()),_pistolPoint.transform.position,_pistolPoint.transform.rotation);
        _weapon.transform.SetParent(transform);   
    }

    private void Start()
    {
        _speedRun = 0.0001f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speedRun, _rigidbody.velocity.y, _joystick.Vertical * _speedRun);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }

    public void SetJoystickAndRaycastReflection(FixedJoystick joystick,RaycastReflection reflection)
    {
        _joystick= joystick;
    }
}
