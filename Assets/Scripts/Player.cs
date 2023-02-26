using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private RaycastReflection _raycastReflection;
    [SerializeField] private int _bullets;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _speedRun;

    public int Bullets => _bullets;

    private void Start()
    { 
        _speedRun = 0.0001f;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speedRun, _rigidbody.velocity.y, _joystick.Vertical * _speedRun);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)

        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }

    public void GetBullets(int bullets)
    {
        _bullets= bullets;
    }

    public void TakeAim()
    {
        _animator.SetBool("isAim", true);
        _weapon.gameObject.SetActive(true);
        _raycastReflection.gameObject.SetActive(true);
    }

    public void Shot()
    {
        if (_bullets > 0)
        {
            _bullets--;
            _weapon.Shot();
        }
        _animator.SetBool("isAim", false);
        _raycastReflection.gameObject.SetActive(false);
        _weapon.gameObject.SetActive(false);
    }
}
