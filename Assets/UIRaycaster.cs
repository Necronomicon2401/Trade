using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRaycaster : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster _raycaster;
    [SerializeField] private EventSystem _eventSystem;

    private PointerEventData _pointerEventData;

    public List<RaycastResult> results;

#if UNITY_EDITOR
    private void Reset()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = FindObjectOfType<EventSystem>();

        if (_raycaster == null || _eventSystem == null)
        {
            EditorUtility.DisplayDialog("UI Raycaster", "Please add UI Raycaster on Canvas only", "OK");
            DestroyImmediate(this);
        }
    }
#endif

    private void FixedUpdate()
    {
        _pointerEventData = new PointerEventData(_eventSystem)
        {
            position = Input.mousePosition
        };

        var result = new List<RaycastResult>();
        _raycaster.Raycast(_pointerEventData, result);

        this.results = result;
    }
}