using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Scripts.Ui
{
    [RequireComponent(typeof(Button))]
    public class ButtonLanguages : MonoBehaviour
    {
        private Button _button;
        private int _value = 0;
        private List<string> _languages = new List<string>() {StaticText.En,StaticText.Ru,StaticText.Tr};

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ChangeLanguages);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(ChangeLanguages);
        }

        private void ChangeLanguages()
        {
            string text = Save.GetLanguage();

            for (int i = 0; i < _languages.Count; i++)
            {
                if (_languages[i] == text)
                {
                    _value = i;
                    break;
                }
            }

            if (_value < _languages.Count - 1)
            {
                _value++;
            }
            else
            {
                _value = 0;
            }

            switch (_value)
            {
                case 0:
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(StaticText.English);
                    break;

                case 1:
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(StaticText.Russian);
                    break;

                case 2:
                    Lean.Localization.LeanLocalization.SetCurrentLanguageAll(StaticText.Turkish);
                    break;
            }
            Save.SetLanguage(_languages[_value]);
        }
    }
}