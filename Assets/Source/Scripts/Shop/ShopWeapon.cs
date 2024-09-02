using Source.Scripts.Weapons;
using UnityEngine;

namespace Source.Scripts.Shop
{
    public class ShopWeapon : ShopObject
    {
        private static Vector3 Scale = new Vector3(2f, 2f, 2f);
        
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
            Template.transform.localScale = Scale;
        }
    }
}