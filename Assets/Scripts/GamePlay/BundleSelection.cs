using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundleSelection : MonoBehaviour
{
    [SerializeField] private CardBundleData[] _bundles;
    public List<CardData> CurrentDataList => _currentDataList;
    private List<CardData> _currentDataList = new List<CardData>();
    private List<string> _cardIdentifierIgnore = new List<string>();

    private List<int> requiredBundleIndexes = new List<int>();
    private int _bundleIndex = 0;
    public bool CanCreateRequredDataList(int requiredCount)
    {
        requiredBundleIndexes.Clear();
        for (_bundleIndex = 0; _bundleIndex < _bundles.Length; _bundleIndex++)
        {
            CreateDataList();
            if (_currentDataList.Count > requiredCount)
                requiredBundleIndexes.Add(_bundleIndex);
        }

        if (requiredBundleIndexes.Count > 0)
        {
            _bundleIndex = requiredBundleIndexes[Random.Range(0, requiredBundleIndexes.Count)];
            return true;
        }
        else
            return false;
    }
    public void CreateDataList()
    {
        _currentDataList.Clear();

        for (int i = 0; i < _bundles[_bundleIndex].CardData.Length; i++)
        {
            string cardIdentifier = _bundles[_bundleIndex].CardData[i].Identifier;
            bool cardIgnore = false;
            foreach (string ignoreIdentifier in _cardIdentifierIgnore)
            {
                if (ignoreIdentifier == cardIdentifier)
                    cardIgnore = true;
                    
            }
            if (!cardIgnore)
                _currentDataList.Add(_bundles[_bundleIndex].CardData[i]);
        }
    }
    public CardData CutRandomCellFromCurrentList()
    {
        int rndCard = Random.Range(0, _currentDataList.Count);
        CardData selectedCard = _currentDataList[rndCard];
        _currentDataList.RemoveAt(rndCard);
        return selectedCard;
    }
    public void AddToCardIdentifierIgnore(string cardIdentifier)
    {
        _cardIdentifierIgnore.Add(cardIdentifier);
    }

}
