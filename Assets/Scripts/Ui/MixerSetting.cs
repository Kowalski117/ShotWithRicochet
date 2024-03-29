using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerSetting : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Button _music;
    [SerializeField] private Button _sound;
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private Sprite _musicOff;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Image _iconMusic;
    [SerializeField] private Image _iconSound;

    private string _musicVolumeName = "MusicVolume";
    private string _soundVolumeName = "SoundVolume";
    private bool _isOnMusic;
    private bool _isOnSound;
    private float _maxVolume = 0;
    private float _minVolume = -80;

    private void Start()
    {
        _isOnMusic = Save.GetMusicIsOn();
        _isOnSound = Save.GetSoundIsOn();
        Load();
    }

    private void OnEnable()
    {
        _music.onClick.AddListener(OnClickMusic);
        _sound.onClick.AddListener(OnClickSound);
    }

    private void OnDisable()
    {
        _music.onClick.RemoveListener(OnClickMusic);
        _sound.onClick.RemoveListener(OnClickSound);
    }

    public void Mute()
    {
        _mixer.audioMixer.SetFloat(_soundVolumeName, _minVolume);
        _mixer.audioMixer.SetFloat(_musicVolumeName, _minVolume);
    }

    public void Load()
    {
        ChangeVolume(_isOnMusic, _musicVolumeName);
        ChangeVolume(_isOnSound, _soundVolumeName);
    }

private void OnClickMusic()
    {
        if (_isOnMusic)
        {
            _isOnMusic = false;
        }
        else
        {
            _isOnMusic = true;
        }
        Save.SetMusicIsOn(_isOnMusic);
        ChangeVolume(_isOnMusic,_musicVolumeName);
    }

    private void OnClickSound()
    {
        if (_isOnSound)
        {
            _isOnSound = false;
        }
        else
        {
            _isOnSound = true;
        }
        Save.SetSoundIsOn(_isOnSound);
        ChangeVolume(_isOnSound,_soundVolumeName);
    }
    
    private void ChangeVolume(bool value,string name)
    {
        if (value)
        {
            _mixer.audioMixer.SetFloat(name, _maxVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(name, _minVolume);
        }
        ChangeButtonSprite();
    }

    private void ChangeButtonSprite()
    {
        if (_isOnMusic)
        {
            _iconMusic.sprite = _musicOn;
        }
        else
        {
            _iconMusic.sprite = _musicOff;
        }
        
        if (_isOnSound)
        {
            _iconSound.sprite = _soundOn;
        }
        else
        {
            _iconSound.sprite = _soundOff;
        }
    }
}
