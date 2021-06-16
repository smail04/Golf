using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationBar : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Spectator spectator;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        float horizontalPosition = Input.mousePosition.x - Screen.width / 2f;
        spectator.Rotate(new Vector3(0, -horizontalPosition, 0), 0.1f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
