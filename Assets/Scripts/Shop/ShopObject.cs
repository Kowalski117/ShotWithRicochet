using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public abstract class ShopObject : MonoBehaviour
{
    [SerializeField] private ScriptableTest _listSO;
    [SerializeField] private Button _left;
    [SerializeField] private Button _right;
    [SerializeField] private Button _select;
    [SerializeField] private Button _buy;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private TMP_Text _textCoins;

    protected GameObject Template;
    protected int Value;
    protected int Price;
    protected bool IsBuyed;

    private int _usingTemplate;
    private List<GameObject> _list;

    private void Start()
    {
        GetSaveValueSelect();
        _list = _listSO.List;
        _usingTemplate = Value;
        Set();
        SetCoins();
        SetActiveButton();
    }

    private void OnEnable()
    {
        SetActiveButton();
        _left.onClick.AddListener(OnClickLeftButton);
        _right.onClick.AddListener(OnClickRigthButton);
        _select.onClick.AddListener(OnClickSelectButton);
        _buy.onClick.AddListener(OnClickByeButton);
    }

    private void OnDisable()
    {
        _left.onClick.RemoveListener(OnClickLeftButton);
        _right.onClick.RemoveListener(OnClickRigthButton);
        _select.onClick.RemoveListener(OnClickSelectButton);
        _buy.onClick.RemoveListener(OnClickByeButton);
    }

    public abstract void GetSaveValueSelect();
    public abstract void SetSaveValueSelect();
    public abstract void GetSaveValueBye();
    public abstract void SetSaveValueBye();

    public virtual void Set()
    {
        Template = Instantiate(_list[Value], transform.position, transform.rotation);
        Template.transform.SetParent(transform);
        SetPrice();
    }

    public virtual void SetPrice()
    {
        _textPrice.text = Price.ToString();
    }

    private void SetCoins()
    {
        _textCoins.text = Save.GetCoins().ToString();
    }

    private void OnClickLeftButton()
    {
        Destroy(Template);
        Value--;
        Set();
        SetActiveButton();
    }

    private void OnClickRigthButton()
    {
        Destroy(Template);
        Value++;
        Set();
        SetActiveButton();
    }

    private void OnClickSelectButton()
    {
        _usingTemplate = Value;
        SetSaveValueSelect();
        GetSaveValueSelect();
        SetActiveButton();
    }

    private void OnClickByeButton()
    {
        int coins = Save.GetCoins() - Price;
        Save.SetCoins(coins);
        SetCoins();
        SetSaveValueBye();
        SetActiveButton();
        OnClickSelectButton();
    }

    private void SetActiveButton()
    {
        GetSaveValueBye();
        if (_listSO.List.Count - 1 > 0)
        {
            if (Value <= 0)
            {
                _left.gameObject.SetActive(false);
                _right.gameObject.SetActive(true);
            }
            else if (Value >= _list.Count - 1)
            {
                _right.gameObject.SetActive(false);
                _left.gameObject.SetActive(true);
            }
            else
            {
                _left.gameObject.SetActive(true);
                _right.gameObject.SetActive(true);
            }
        }
        else
        {
            _left.gameObject.SetActive(false);
            _right.gameObject.SetActive(false);
        }

        if (_usingTemplate != Value && IsBuyed == true)
        {
            _select.gameObject.SetActive(true);
        }
        else
        {
            _select.gameObject.SetActive(false);
        }

        if (IsBuyed == false)
        {
            SetPrice();
            _buy.gameObject.SetActive(true);

            if(Price<=Save.GetCoins())
            {
                _buy.interactable = true;
            }
            else
            {
                _buy.interactable = false;
            }
        }
        else
        {
            _buy.gameObject.SetActive(false);
        }
    }
}
