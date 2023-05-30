using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [SerializeField]
    private Sprite _onUISprite;
    [SerializeField]
    private Sprite _offUISprite;

    [SerializeField]
    private Sprite _onBarUISprite;
    [SerializeField]
    private Sprite _offBarUISprite;

    private bool OnOff = true;
    private Image _onOffImage;
    private Image _onOffBarImage;

    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private string _audioType;

    private void Awake()
    {
        _onOffImage = GetComponent<Image>();
        _onOffBarImage = GameObject.Find($"{gameObject.name}/OnOff").GetComponent<Image>();     
    }

    public void ClickEvent()
    {
        OnOff = !OnOff;
        _onOffImage.sprite = (OnOff ? _onUISprite : _offUISprite);
        _onOffBarImage.sprite = (OnOff ? _onBarUISprite : _offBarUISprite);
        _audioMixer.SetFloat(_audioType, (OnOff ? 0.0f : -40.0f));
    }
}
