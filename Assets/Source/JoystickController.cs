using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IController, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform center;
    [SerializeField] RectTransform stick;
    [SerializeField] float size;
    Vector2 input;
    public Vector2 Input() => input;
    public void OnPointerDown(PointerEventData data)
    {
        input = Input(data);
        stick.anchoredPosition = input * size;
    }
    public void OnPointerUp(PointerEventData data)
    {
        input = Vector2.zero;
        stick.anchoredPosition = Vector2.zero;
    }
    public void OnBeginDrag(PointerEventData data)
    {
        input = Input(data);
        stick.anchoredPosition = input * size;
    }
    public void OnDrag(PointerEventData data)
    {
        input = Input(data);
        stick.anchoredPosition = input * size;
    }
    public void OnEndDrag(PointerEventData data)
    {
        input = Vector2.zero;
        stick.anchoredPosition = Vector2.zero;
    }
    
    Vector2 Input(PointerEventData data)
    { 
        return Vector2.ClampMagnitude(data.position - (Vector2)center.position, size) / size;
    }
}
