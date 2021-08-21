using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EndOfTheGame : MonoBehaviour
{
    [SerializeField] private Image _endOfGamePanel;
    [SerializeField] private Image _restartPanel;
    void Start()
    {
        SetActiveWithFade(_endOfGamePanel, false, 0, 0);
        SetActiveWithFade(_restartPanel, false, 0, 0);
    }

    public void ShowRestartPanel()
    {
        SetActiveWithFade(_endOfGamePanel, true, 1, 1);
    }

    public void Restart()
    {
        SetActiveWithFade(_endOfGamePanel, false, 0, 0);
        SetActiveWithFade(_restartPanel, true, 1, 0.7f);
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(0);
    }
    private void SetActiveWithFade(Image obj,bool activeValue, float endFadeValue, float fadeDuration)
    {
        obj.DOFade(endFadeValue, fadeDuration);
        obj.gameObject.SetActive(activeValue);
    }
}
