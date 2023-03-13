using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;

    private void Start()
    {
        _coins.text = Save.Coins().ToString();
    }
}
