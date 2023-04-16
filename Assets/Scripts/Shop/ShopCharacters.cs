public class ShopCharacters : ShopObject
{
    public override void GetSaveValueSelect()
    {
        Value = Save.GetCharacter();
    }

    public override void SetSaveValueSelect()
    {
        Save.SetCharacter(Value);
    }
    public override void GetSaveValueBye()
    {
        IsBuyed = Save.GetCharacterBuyed(Value);
    }

    public override void SetSaveValueBye()
    {
        Save.SetCharacterBuyed(Value, true);
    }

    public override void SetPrice()
    {
        Price = Template.GetComponent<MovePlayer>().Price;
        base.SetPrice();
    }

    public override void Set()
    {
        base.Set();
        Template.GetComponent<MovePlayer>().enabled = false;
        Template.GetComponentInChildren<Weapon>().gameObject.SetActive(false);
    }

}
