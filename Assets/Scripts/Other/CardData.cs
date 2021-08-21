using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CardData 
{
    public string Identifier => _identifier;
    [SerializeField] private string _identifier;

    public Sprite Sprite => _sprite;
    [SerializeField] private Sprite _sprite;

}
