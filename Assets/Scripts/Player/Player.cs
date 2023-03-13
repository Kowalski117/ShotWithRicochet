using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharactersList _character;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private RaycastReflection _reflection;

    private MovePlayer _player;
    private GameObject _playerTemplate;
    private int _bullets;

    private Weapon _weapon;
    private Animator _animator;

    private string _isAim = "isAim";
    private string _win = "Win";

    public int Bullets => _bullets;

    private void Awake()
    {
        _playerTemplate = Instantiate(_character.TakeOneObject(Save.GetCharacter()), transform.position, transform.rotation);
        _playerTemplate.transform.SetParent(transform);
        _player = _playerTemplate.GetComponent<MovePlayer>();
    }

    private void Start()
    {
        _animator = _player.GetComponent<Animator>();
        _weapon = _player.GetComponentInChildren<Weapon>();
        _player.SetJoystickAndRaycastReflection(_joystick, _reflection);
        _weapon.gameObject.SetActive(false);
    }

    public void TakeAim()
    {
        _animator.SetBool(_isAim, true);
        _weapon.gameObject.SetActive(true);
        _reflection.gameObject.SetActive(true);
    }

    public void Shot()
    {
        if (_bullets > 0)
        {
            _bullets--;
            _weapon.Shot();
        }

        _animator.SetBool(_isAim, false);
        _reflection.gameObject.SetActive(false);
        _weapon.gameObject.SetActive(false);
    }

    public void Win()
    {
        transform.rotation = new Quaternion(0, 180, 0, 0);
        _animator.SetBool(_win, true);
    }

    public void SetBullets(int value)
    {
        _bullets= value;
    }
}
