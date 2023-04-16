using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewBullets : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Sprite _spriteGray;
    [SerializeField] private int _heightGainValue = 45;
    
    private int _numberColorChanges = 0;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    private void Start()
    {
        CreateBullets(_level.MaxBullets);
    }

    private void OnEnable()
    {
        _level.BulletCrashed += ChangeImage;
        _level.BulletAdded += AddBullet;
    }

    private void OnDisable()
    {
        _level.BulletCrashed -= ChangeImage;
        _level.BulletAdded -= AddBullet;
    }

    public void CreateBullets(int countBullets)
    {
        for (int i = 0; i < countBullets; i++)
        {
            _rectTransform.sizeDelta = new Vector2(_rectTransform.rect.width,_rectTransform.rect.height+_heightGainValue);
            Instantiate(_bullet, transform);
        }
    }

    public void AddBullet()
    {
        Instantiate(_bullet, transform);
    }
    

    public void ChangeImage()
    {
        _numberColorChanges++;
        int value = _numberColorChanges;

        foreach (var item in gameObject.GetComponentsInChildren<ImageBullet>())
        {
            if (value > 0)
            {
                item.GetComponent<Image>().sprite = _spriteGray;
                value--;
            }
        }
    }
}
