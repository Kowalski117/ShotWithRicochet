using TMPro;
using UnityEngine;

public class PanelWin : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraPositionsWin;
    [SerializeField] private TMP_Text _Text;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _win;

    private void Start()
    {
        _game.SetActive(false);
        _win.SetActive(true);
        _Text.text = Save.Coins().ToString();
    }

    private void Update()
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _cameraPositionsWin.position, Time.deltaTime);
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation,_cameraPositionsWin.rotation, Time.deltaTime);
    }
}
