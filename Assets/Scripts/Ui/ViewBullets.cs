using UnityEngine;
using UnityEngine.UI;

public class ViewBullets : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Sprite _spriteGray;

    private int _numberColorChanges = 0;

    public void CreateBullets(int countBullets)
    {
        for (int i = 0; i < countBullets; i++)
        {
            Instantiate(_bullet, transform);
        }
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
