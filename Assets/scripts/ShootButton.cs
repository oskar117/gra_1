using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ShootButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isButtonClicled = true;

    public virtual void OnPointerEnter(PointerEventData data)
    {
        isButtonClicled = true;
    }
    public virtual void OnPointerExit(PointerEventData data)
    {
        isButtonClicled = false;
    }
}
