using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    public string Identifier => _identifier;
    private string _identifier;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] private GameObject _particleEffects;

    private void Awake()
    {
        FindObjectOfType<CardsOnScene>().AddCard(transform.gameObject);
        BundleSelection bundleSelection = FindObjectOfType<BundleSelection>();
        CardData _card = bundleSelection.CutRandomCellFromCurrentList();

        _sprite.sprite = _card.Sprite;
        _identifier = _card.Identifier;
    }

    private void Start()
    {
        ShakeEffects bounce = GetComponent<ShakeEffects>();
        if (bounce != null)
        {
            bounce.StartBounceEffect();
        }
    }

    public void SpawnparticleEffect()
    {
        if (_particleEffects!=null)
            Instantiate(_particleEffects, _sprite.transform.position, Quaternion.identity);
    }

}
