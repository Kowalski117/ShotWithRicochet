using UnityEngine;

namespace Source.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class RotationPlayer : MonoBehaviour
    {

        private FixedJoystick _joystick;
        private Rigidbody _rigidbody;
        private float _speedRun = 0.0001f;

        private void Start()
        {
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

        public void SetJoystickAndRaycastReflection(FixedJoystick joystick)
        {
            _joystick = joystick;
        }
    }
}