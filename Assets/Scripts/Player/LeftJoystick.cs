using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftJoystick : MonoBehaviour, IDragHandler, IEndDragHandler
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

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick, 
            eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = Mathf.Clamp(position.x / (joystick.sizeDelta.x / 2), -1f, 1f);
            position.y = Mathf.Clamp(position.y / (joystick.sizeDelta.y / 2), -1f, 1f);

            Vector2 inputVector = new Vector2(position.x, position.y);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            //joystick.anchoredPosition = new Vector2(inputVector.x * (joystick.sizeDelta.x / 3),
            //    inputVector.y * (joystick.sizeDelta.y / 3));

            moveDirection = inputVector;
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
        target.transform.Translate(new Vector3(direction.x, 0, direction.y)
            * Time.deltaTime * 2.5f, Space.World);
    }
}
