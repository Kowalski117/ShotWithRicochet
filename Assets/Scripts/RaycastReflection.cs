using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class RaycastReflection : MonoBehaviour
{
    [SerializeField] private int _reflections;
    [SerializeField] private float _maxLength;
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _target;

    private Transform _shootPoint;
    private LineRenderer _lineRenderer;
    private Ray _ray;
    private RaycastHit _hit;

    public int Reflections => _reflections;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _shootPoint = _player.GetComponentInChildren<MovePlayer>().GetComponentInChildren<Weapon>().GetComponentInChildren<ShotPoint>().transform;

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
                {
                    _target.gameObject.SetActive(true);
                    _target.transform.position = _hit.collider.gameObject.GetComponent<Enemy>().transform.position;
                    break;
                }
                else if (_hit.collider.gameObject.GetComponent<Item>())
                {
                    _target.gameObject.SetActive(true);
                    _target.transform.position = _hit.collider.gameObject.GetComponent<Item>().transform.position;
                    _target.transform.position = new Vector3(_target.transform.position.x,0.03f, _target.transform.position.z); 
                    break;
                }
            }
            else
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _ray.origin + _ray.direction * remainingLength);
            }

            if(i == _reflections-1)
            {
                _target.gameObject.SetActive(false);
            }
        }
    }
}
