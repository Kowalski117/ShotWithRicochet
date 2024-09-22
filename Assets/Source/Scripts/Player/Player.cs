using Source.Scripts.SO;
using Source.Scripts.Weapons;
using UnityEngine;

namespace Source.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private ObjectList _character;
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private RaycastReflection _reflection;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _aim;
        [SerializeField] private AudioClip _shot;

        private Quaternion _angleRotationY = new Quaternion(0, 180, 0, 0);

        private RotationPlayer _player;
        private GameObject _playerTemplate;
        private int _bullets;
        private Weapon _weapon;
        private Animator _animator;

        private void Awake()
        {
            _playerTemplate = Instantiate(_character.TakeOneObject(Save.GetCharacter()), transform.position, transform.rotation);
            _playerTemplate.transform.SetParent(transform);
            _player = _playerTemplate.GetComponent<RotationPlayer>();
        }

        private void Start()
        {
            _animator = _player.GetComponent<Animator>();
            _weapon = _player.GetComponentInChildren<Weapon>();
            _player.SetJoystickAndRaycastReflection(_joystick);
            _weapon.gameObject.SetActive(false);
        }

        public void TakeAim()
        {
            _animator.SetBool(ValueConstants.IsAim, true);
            _weapon.gameObject.SetActive(true);
            _reflection.gameObject.SetActive(true);
            _audioSource.PlayOneShot(_aim);
        }

        public void Shot()
        {
            if (_bullets > 0)
            {
                _bullets--;
                _weapon.Shot();
                _audioSource.PlayOneShot(_shot);
            }

            _animator.SetBool(ValueConstants.IsAim, false);
            _reflection.gameObject.SetActive(false);
            _weapon.gameObject.SetActive(false);
        }

        public void Win()
        {
            transform.rotation = _angleRotationY;
            _animator.SetBool(ValueConstants.Win, true);
        }

        public void SetBullets(int value)
        {
            _bullets = value;
        }
    }
}