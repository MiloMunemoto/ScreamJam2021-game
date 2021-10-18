using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool highlighted;

    public virtual void Highlight()
    {
        highlighted = true;
    }   

    public virtual void Unhighlight()
    {
        highlighted = false;
    }

    public abstract void Interact();
}