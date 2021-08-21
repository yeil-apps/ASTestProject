using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsOnScene: MonoBehaviour
{
    private List<GameObject> _cardsGameOjbects = new List<GameObject>();

    public List<GameObject> CardsGameOjbects => _cardsGameOjbects;
    public void AddCard(GameObject card)
    {
        _cardsGameOjbects.Add(card);
    }

    public string GetRandomCardIdentifier()
    {
        Cell cell = _cardsGameOjbects[Random.Range(0, _cardsGameOjbects.Count)].GetComponent<Cell>();
        return cell.Identifier;
    }

    public void DeleteAllCardGameObject()
    {
        foreach (GameObject gameObject in _cardsGameOjbects)
        {
            Destroy(gameObject);
        }
        _cardsGameOjbects.Clear();
    }
}
