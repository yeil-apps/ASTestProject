using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ClickReceiver : MonoBehaviour, IPointerClickHandler
{
    private string _identifier;
    private TaskChanger _taskChanger;
    private Spawner _spawner;
    private ShakeEffects _bounce;
    private Cell _cell;

    void Start()
    {
        _identifier = GetComponent<Cell>().Identifier;
        _taskChanger = FindObjectOfType<TaskChanger>();
        _spawner = FindObjectOfType<Spawner>();
        _bounce = GetComponent<ShakeEffects>();
        _cell = GetComponent<Cell>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_taskChanger.TaskIdentifier == _identifier)
        {
            if (_spawner.NeedBounceEffect)
                _spawner.NeedBounceEffect = false;

            _bounce.CorrectClickShake();
            _cell.SpawnparticleEffect();
            StartCoroutine(LoadNextLevel());
        }
        else
        {
            _bounce.WrongClickShake();
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        _spawner.NextLevel();
    }
}
