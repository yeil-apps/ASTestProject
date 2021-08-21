using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextFade : MonoBehaviour
{
    [SerializeField] private Text[] _textToFadeOnStart;
    [SerializeField] private float _fadeDuration = 3;
    private void Start()
    {
        foreach (Text text in _textToFadeOnStart)
        {
            text.DOFade(1, _fadeDuration);
        }
    }
}
