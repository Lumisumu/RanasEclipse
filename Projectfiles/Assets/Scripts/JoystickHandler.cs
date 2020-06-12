using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoystickHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image jstickContainer;
    private Image joystick;

    public bool thisbool = true;
    public Vector3 InputDirection;

    void Start()
    {
        thisbool = true;
        jstickContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData pointereventdata)
    {
        if (thisbool == true)
        {
            Vector2 position = Vector2.zero;

            //To get InputDirection
            RectTransformUtility.ScreenPointToLocalPointInRectangle
                    (jstickContainer.rectTransform,
                    pointereventdata.position,
                    pointereventdata.pressEventCamera,
                    out position);

            position.x = (position.x / jstickContainer.rectTransform.sizeDelta.x);
            position.y = (position.y / jstickContainer.rectTransform.sizeDelta.y);

            float moveX = (jstickContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
            float moveY = (jstickContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

            InputDirection = new Vector3(moveX, moveY, 0);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            //to define the area in which joystick can move around
            joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (jstickContainer.rectTransform.sizeDelta.x / 3)
                                                                   , InputDirection.y * (jstickContainer.rectTransform.sizeDelta.y) / 3);
        }
    }

    public void OnPointerDown(PointerEventData pointereventdata)
    {
        
            OnDrag(pointereventdata);
        
    }

    public void OnPointerUp(PointerEventData pointereventdata)
    {

        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}