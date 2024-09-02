using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.Ui
{
    public class ModeMenu : MonoBehaviour
    {
        [SerializeField] private Button _characterButton;
        [SerializeField] private Button _weaponButton;
        [SerializeField] private Button _bulletButton;

        [SerializeField] private GameObject _character;
        [SerializeField] private GameObject _weapon;
        [SerializeField] private GameObject _bullet;

        [SerializeField] private Sprite _buttonCharacter;
        [SerializeField] private Sprite _onClickButtonCharacter;
        [SerializeField] private Sprite _buttonBullet;
        [SerializeField] private Sprite _onClickButtonBullet;
        [SerializeField] private Sprite _buttonWeapon;
        [SerializeField] private Sprite _onClickButtonWeapon;

        private void OnEnable()
        {
            _characterButton.onClick.AddListener(OnClickCharacterButton);
            _weaponButton.onClick.AddListener(OnClickWeaponButton);
            _bulletButton.onClick.AddListener(OnClickBulletButton);
        }

        private void OnDisable()
        {
            _characterButton.onClick.RemoveListener(OnClickCharacterButton);
            _weaponButton.onClick.RemoveListener(OnClickWeaponButton);
            _bulletButton.onClick.RemoveListener(OnClickBulletButton);
        }


        private void OnClickCharacterButton()
        {
            _character.SetActive(true);
            _weapon.SetActive(false);
            _bullet.SetActive(false);

            _characterButton.GetComponent<Image>().sprite = _onClickButtonCharacter;
            _weaponButton.GetComponent<Image>().sprite = _buttonWeapon;
            _bulletButton.GetComponent<Image>().sprite = _buttonBullet;

        }

        private void OnClickWeaponButton()
        {
            _character.SetActive(false);
            _weapon.SetActive(true);
            _bullet.SetActive(false);

            _characterButton.GetComponent<Image>().sprite = _buttonCharacter;
            _weaponButton.GetComponent<Image>().sprite = _onClickButtonWeapon;
            _bulletButton.GetComponent<Image>().sprite = _buttonBullet;
        }

        private void OnClickBulletButton()
        {
            _character.SetActive(false);
            _weapon.SetActive(false);
            _bullet.SetActive(true);

            _characterButton.GetComponent<Image>().sprite = _buttonCharacter;
            _weaponButton.GetComponent<Image>().sprite = _buttonWeapon;
            _bulletButton.GetComponent<Image>().sprite = _onClickButtonBullet;
        }
    }
}