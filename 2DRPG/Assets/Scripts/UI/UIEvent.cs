using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEvent : MonoBehaviour, IPointerClickHandler, IDragHandler, IDropHandler, IBeginDragHandler
{
    public Action<PointerEventData> beginDragAction;
    public Action<PointerEventData> onDragAction;
    public Action<PointerEventData> dropAction;
    public Action<PointerEventData> clickAction;


    public void OnBeginDrag(PointerEventData eventData)
    {
        beginDragAction.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        onDragAction.Invoke(eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        dropAction.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickAction.Invoke(eventData);
    }
}
