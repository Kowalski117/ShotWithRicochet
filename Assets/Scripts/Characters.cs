using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    [SerializeField] private CharactersList _charactersList;
    [SerializeField] private Button _left;
    [SerializeField] private Button _right;
    [SerializeField] private Button _play;


    private List<GameObject> _characters;
    private GameObject _template;

    private void Start()
    {
        _characters = _charactersList.List;
        Set(Save.GetCharacter());
        SetActiveButton();
    }

    private void OnEnable()
    {
        _left.onClick.AddListener(OnClickLeftButton);
        _right.onClick.AddListener(OnClickRigthButton);
        _play.onClick.AddListener(OnClickSelectButton);
    }

    private void OnDisable()
    {
        _left.onClick.RemoveListener(OnClickLeftButton);
        _right.onClick.RemoveListener(OnClickRigthButton);
        _play.onClick.RemoveListener(OnClickSelectButton);
    }

    private void Set(int value)
    {
        _template = Instantiate(_characters[value], transform.position, transform.rotation);
        _template.transform.SetParent(transform);
        _template.GetComponent<MovePlayer>().enabled = false;
        _template.GetComponentInChildren<Weapon>().gameObject.SetActive(false);
        Save.SetCharacter(value);
    }

    private void OnClickLeftButton()
    {
        Destroy(GetComponentInChildren<MovePlayer>().gameObject);
        Set(Save.GetCharacter() - 1);
        SetActiveButton();
    }

    private void OnClickRigthButton()
    {
        Destroy(GetComponentInChildren<MovePlayer>().gameObject);
        Set(Save.GetCharacter() + 1);
        SetActiveButton();
    }

    private void OnClickSelectButton()
    {

    }

    private void SetActiveButton()
    {
        if (Save.GetCharacter() <= 0)
        {
            _left.gameObject.SetActive(false);
        }
        else if (Save.GetCharacter() >= _characters.Count - 1)
        {
            _right.gameObject.SetActive(false);
        }
        else
        {
            _left.gameObject.SetActive(true);
            _right.gameObject.SetActive(true);
        }

       /* if (Save.GetSkinBuyed(Save.GetCharacters()) == false)
        {
            _play.interactable = false;
        }
        else
        {
            _play.interactable = true;
        }*/
    }
}
