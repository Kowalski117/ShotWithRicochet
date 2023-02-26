using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class RaycastReflection : MonoBehaviour
{
    [SerializeField] private int _reflections;
    [SerializeField] private float _maxLength;
    [SerializeField] private Player _player;

    private Transform _shootPoint;
    private LineRenderer _lineRenderer;
    private Ray _ray;
    private RaycastHit _hit;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _reflections = 5;
        _maxLength = 200;
    }

    private void Update()
    {
        _shootPoint = _player.GetComponentInChildren<Weapon>().GetComponentInChildren<ShotPoint>().transform;

        _ray = new Ray(_shootPoint.position, _shootPoint.forward);

        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, _shootPoint.position);
        float remainingLength = _maxLength;

        for (int i = 0; i < _reflections; i++)
        {
            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, remainingLength))
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _hit.point);
                remainingLength -= Vector3.Distance(_ray.origin, _hit.point);
                _ray = new Ray(_hit.point, Vector3.Reflect(_ray.direction, _hit.normal));

                if (_hit.collider.gameObject.GetComponent<Enemy>())
                    break;
            }

            else
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _ray.origin + _ray.direction * remainingLength);
            }
        }
    }
}