using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingame_Object : MonoBehaviour
{
    [SerializeField] int object_Number;
    [SerializeField] bool AllowDrag;

    public void OnDrag() { if (!AllowDrag) All_In_One.ALO.Drag_Image(object_Number); }
    public void OnDrop() { AllowDrag = All_In_One.ALO.Drop_Image(object_Number); }
}