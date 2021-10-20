using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    private bool showNotebook = false;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            showNotebook = !showNotebook;
            if (showNotebook)
            {
                PullOut();
            }
            else
            {
                Hide();
            }
        }
    }

    void PullOut()
    {
        animator.SetTrigger("PullOut");
    }

    void Hide()
    {
        animator.SetTrigger("Hide");
    }
}
