using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _areaSize;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private LevelGrid[] _levelGrid;
    private int _currentLevel = 0;
    private BundleSelection _bundleSelection;
    private CardsOnScene _cardOnScene;

    public bool NeedBounceEffect = true;

    void Start()
    {
        _bundleSelection = FindObjectOfType<BundleSelection>();
        _cardOnScene = FindObjectOfType<CardsOnScene>();

        _currentLevel = -1;
        NextLevel();
    }

    public void SpawnObjectsGrid(int horizontalQuantity, int verticalQuantity)
    {
        float horizontalDistanceBtwCells = _areaSize / horizontalQuantity;
        float verticalDistanceBtwCells = _areaSize / verticalQuantity;

        float xStartPos = transform.position.x - _areaSize / 2 + horizontalDistanceBtwCells/2;
        float yStartPos = transform.position.y + _areaSize / 2 - verticalDistanceBtwCells/2;

        for (int i = 0; i < verticalQuantity; i++)
        {
            for (int j = 0; j < horizontalQuantity; j++)
            {
                Vector3 posForCellSpawn = new Vector3(xStartPos + j * horizontalDistanceBtwCells, yStartPos - i * verticalDistanceBtwCells, 0);
                Instantiate(_cardPrefab, posForCellSpawn, Quaternion.identity);
            }
        }
        FindObjectOfType<TaskChanger>().ChangeTask();
    }

    public void NextLevel()
    {
        if (_currentLevel < _levelGrid.Length-1)
        {
            _currentLevel++;
            _cardOnScene.DeleteAllCardGameObject();

            LevelGrid levelGrid = _levelGrid[_currentLevel];
            if (_bundleSelection.CanCreateRequredDataList(levelGrid.HorizontalCount * levelGrid.VerticalCount))
                _bundleSelection.CreateDataList();
            else
                return;
             SpawnObjectsGrid(levelGrid.HorizontalCount, levelGrid.VerticalCount);
        }
        else
        {
            _cardOnScene.DeleteAllCardGameObject();
            FindObjectOfType<EndOfTheGame>().ShowRestartPanel();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_areaSize, _areaSize, 0));
    }
}
