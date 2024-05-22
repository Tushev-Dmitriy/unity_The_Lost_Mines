using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightJoystick : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private RectTransform joystick;
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 joystickStartPos = Vector2.zero;
    public GameObject target;

    void Start()
    {
        joystick = transform.GetComponent<RectTransform>();
        joystickStartPos = joystick.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.parent as RectTransform,
            eventData.position, eventData.pressEventCamera, out position))
        {
            joystick.anchoredPosition = position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.parent as RectTransform,
            eventData.position, eventData.pressEventCamera, out position))
        {
            Vector2 offset = position - joystickStartPos;
            offset = Vector2.ClampMagnitude(offset, joystick.sizeDelta.x / 2);

            joystick.anchoredPosition = joystickStartPos + offset;

            moveDirection = new Vector2(offset.x / (joystick.sizeDelta.x / 2), offset.y / (joystick.sizeDelta.y / 2));
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joystick.anchoredPosition = joystickStartPos;
        moveDirection = Vector2.zero;
    }

    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            MoveTarget(moveDirection);
        }
    }

    private void MoveTarget(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Vector3 newRotation = new Vector3(0, angle, 0);
        target.transform.rotation = Quaternion.Euler(newRotation);
    }
}
