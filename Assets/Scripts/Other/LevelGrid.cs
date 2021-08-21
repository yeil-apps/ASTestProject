using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelGrid 
{
    public int HorizontalCount => _horizontalCount;
    [SerializeField] private int _horizontalCount;
    public int VerticalCount => _verticalCount;
    [SerializeField] private int _verticalCount;
}
