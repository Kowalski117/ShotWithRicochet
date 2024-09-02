using Source.Scripts.SO;
using Source.Scripts.Weapons;
using UnityEngine;

namespace Source.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharactersList _character;
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private RaycastReflection _reflection;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _aim;
        [SerializeField] private AudioClip _shot;

        private static string IsAimText = "isAim";
        private static string WinText = "Win";
        private Quaternion AngleRotationY = new Quaternion(0, 180, 0, 0);

        private MovePlayer _player;
        private GameObject _playerTemplate;
        private int _bullets;
        private Weapon _weapon;
        private Animator _animator;

        public int Bullets => _bullets;

        private void Awake()
        {
            _playerTemplate = Instantiate(_character.TakeOneObject(Save.GetCharacter()), transform.position,
                transform.rotation);
            _playerTemplate.transform.SetParent(transform);
            _player = _playerTemplate.GetComponent<MovePlayer>();
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
            _animator.SetBool(IsAimText, true);
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

            _animator.SetBool(IsAimText, false);
            _reflection.gameObject.SetActive(false);
            _weapon.gameObject.SetActive(false);
        }

        public void Win()
        {
            transform.rotation = AngleRotationY;
            _animator.SetBool(WinText, true);
        }

        public void SetBullets(int value)
        {
            _bullets = value;
        }
    }
}