using DG.Tweening;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private Transform _cameraTransformGame;
    [SerializeField] private Transform _cameraTransformAim;
    [SerializeField] private Transform _cameraTransformWin;
    [SerializeField] private float _duraction;

    private void Start()
    {
        _camera.transform.position= _cameraTransformGame.transform.position;
        _camera.transform.rotation = _cameraTransformGame.transform.rotation;
    }

    private void ChangePosition(Transform transform)
    {
        _camera.transform.DOMove(transform.position,_duraction,false);
        _camera.transform.DORotateQuaternion(transform.rotation, _duraction);
    }

    public void PositionAim()
    {
        ChangePosition(_cameraTransformAim);
    }

    public void PositionWin()
    {
        ChangePosition(_cameraTransformWin);
    }

    public void PositionGame()
    {
        ChangePosition(_cameraTransformGame);
    }



}
