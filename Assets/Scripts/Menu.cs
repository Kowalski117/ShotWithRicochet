using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private Save _save;

    private void Start()
    {
        _player.enabled = false;
        _coins.text = _save.Coins().ToString();
    }
}
