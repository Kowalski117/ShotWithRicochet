using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Source.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Button))]
    public class SoundButtonClick : MonoBehaviour, IPointerDownHandler
    {
        private AudioSource _audioSource;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_button.interactable)
                _audioSource.Play();
        }
    }
}