using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScene : MonoBehaviour
{
    private Canvas canvas;

    //mostramos ui
    public void Show()
    {
        canvas.enabled = true;
    }

    //escondemos ui
    public void Hide()
    {
        canvas.enabled = false;
    }

}
