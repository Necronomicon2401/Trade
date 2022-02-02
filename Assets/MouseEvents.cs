using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class MouseEvents : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;
    public RectTransform baseRectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        baseRectTransform = _rectTransform;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("begin");
        _canvasGroup.alpha = 0.8f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("end drag");
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        baseRectTransform = _rectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    private void OnCollisionEnter(Collision other)
    {
        print("Collision");
        if (other.gameObject.CompareTag("Item"))
        {
            _rectTransform = baseRectTransform;
        }
    }
}