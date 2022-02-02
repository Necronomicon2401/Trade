using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas _canvas;
    private List<RaycastResult> _results;
    
    public void OnDrop(PointerEventData eventData)
    {
        print("Droped");
        _results = _canvas.GetComponent<UIRaycaster>().results;
        foreach (var result in _results)
        {
            print($"{result.gameObject.name}");
            if (result.gameObject.CompareTag("Item"))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position =
                    eventData.pointerDrag.GetComponent<MouseEvents>().baseRectTransform.position;
            }
        }
        
        if (eventData.pointerDrag != null )
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position =
                GetComponent<RectTransform>().position;
            if (this.gameObject.CompareTag("Player"))
            {
                if (_canvas.GetComponent<GameLogic>().traderItems.Contains(eventData.pointerDrag))
                {
                    _canvas.GetComponent<GameLogic>().traderItems.Remove(eventData.pointerDrag); 
                    _canvas.GetComponent<GameLogic>().playerItems.Add(eventData.pointerDrag); 
                    _canvas.GetComponent<GameLogic>().UpdateGold();
                }
            }
            
            if (this.gameObject.CompareTag("Trader"))
            {
                if (_canvas.GetComponent<GameLogic>().playerItems.Contains(eventData.pointerDrag))
                {
                    _canvas.GetComponent<GameLogic>().playerItems.Remove(eventData.pointerDrag); 
                    _canvas.GetComponent<GameLogic>().traderItems.Add(eventData.pointerDrag); 
                    _canvas.GetComponent<GameLogic>().UpdateGold();
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.2f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.3f);
    }
}
