using UnityEngine;

public class ShopBullet : ShopObject
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _rotate;

    private void Awake()
    {
        _bullet.GetComponent<Bullet>().enabled = false;
        _bullet.SetActive(true);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, _rotate, 0);
    }

    public override void GetSaveValueSelect()
    {
        Value = Save.GetBulletParticle();
    }

    public override void SetSaveValueSelect()
    {
        Save.SetBulletParticle(Value);
    }

    public override void GetSaveValueBye()
    {
        IsBuyed = Save.GetBulletParticleBuyed(Value);
    }

    public override void SetSaveValueBye()
    {
        Save.SetBulletParticleBuyed(Value, true);
    }

    public override void SetPrice()
    {
        Price = Template.GetComponent<BulletParticle>().Price;
        base.SetPrice();
    }

    public override void Set()
    {
        base.Set();
        Template.transform.SetParent(_bullet.transform);
        Template.transform.position = _bullet.transform.position;
    }

}
