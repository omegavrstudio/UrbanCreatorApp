using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Interfaces.UI;
using UnityEngine.UI;

public class ViewBase : MonoBehaviour, IView
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Hide()
    {
        SetCanvasGrourpAlpha(0);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        SetCanvasGrourpAlpha(1);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void SetCanvasGrourpAlpha(float newAlpha)
    {
        float canvasGroupAlpha = _canvasGroup.alpha;
        LeanTween.value(canvasGroupAlpha, newAlpha, 1).setOnUpdate((float value) => { _canvasGroup.alpha = value; });

    }
}
