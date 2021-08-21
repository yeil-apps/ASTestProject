using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskChanger : MonoBehaviour
{

    [SerializeField] private Text _textToTask;
    private string _taskIdentifier;
    public string TaskIdentifier => _taskIdentifier;
    public void ChangeTask()
    {
        _taskIdentifier = FindObjectOfType<CardsOnScene>().GetRandomCardIdentifier();
        FindObjectOfType<BundleSelection>().AddToCardIdentifierIgnore(_taskIdentifier);
        _textToTask.text = _taskIdentifier;
    }
}
