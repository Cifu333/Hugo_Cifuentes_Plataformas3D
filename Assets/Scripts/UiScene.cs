using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScene : MonoBehaviour
{
    private Canvas canvas;

    public void Show()
    {
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
    }

}
