using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas _canvas;
    private List<RaycastResult> _results;

    public void OnDrop(PointerEventData eventData)
    {
        var gl = _canvas.GetComponent<GameLogic>();
        var itemPosition = eventData.pointerDrag.GetComponent<RectTransform>();
        var itemBasicPosition = eventData.pointerDrag.GetComponent<MouseEvents>().basePosition;
        
        print("Droped");

        if (eventData.pointerDrag != null )
        {
            itemPosition.position =
                GetComponent<RectTransform>().position;
            
            int cost = Int32.Parse(eventData.pointerDrag.GetComponentInChildren<TextMeshProUGUI>().text);
            
            if (this.gameObject.CompareTag("Player") && gl.traderItems.Contains(eventData.pointerDrag))
            {
                if (gl.playerGold >= cost)
                {
                    gl.traderItems.Remove(eventData.pointerDrag); 
                    gl.playerItems.Add(eventData.pointerDrag);
                    gl.playerGold -= cost;
                    gl.traderGold += cost;
                    gl.UpdateGold();
                }
                else
                { 
                    itemPosition.position = itemBasicPosition;
                }
            }
            
            if (this.gameObject.CompareTag("Trader") && gl.playerItems.Contains(eventData.pointerDrag))
            {
                if (gl.traderGold >= cost)
                {
                    gl.playerItems.Remove(eventData.pointerDrag); 
                    gl.traderItems.Add(eventData.pointerDrag);
                    gl.traderGold -= cost;
                    gl.playerGold += cost;
                    gl.UpdateGold();
                }
                else
                {
                    itemPosition.position = itemBasicPosition;
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
