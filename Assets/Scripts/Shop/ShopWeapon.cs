using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeapon : ShopObject
{
    public override void GetSaveValueSelect()
    {
        Value = Save.GetWeapon();
    }

    public override void SetSaveValueSelect()
    {
        Save.SetWeapon(Value);
    }

    public override void GetSaveValueBye()
    {
        IsBuyed = Save.GetWeaponBuyed(Value);
    }

    public override void SetSaveValueBye()
    {
        Save.SetWeaponBuyed(Value, true);
    }

    public override void SetPrice()
    {
        Price = Template.GetComponent<Weapon>().Price;
        base.SetPrice();
    }

    public override void Set()
    {
        base.Set();
        Template.transform.localScale = new Vector3(2f, 2f, 2f);
    }

}
