using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform fpsCamera;

    private Interactable targetObject = null;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(fpsCamera.position, fpsCamera.forward, out RaycastHit hit, 2f, interactableLayer) && hit.transform.GetComponent<Interactable>())
        {
            if (targetObject != null && targetObject != hit.transform.GetComponent<Interactable>())
                targetObject.Unhighlight();
            targetObject = hit.transform.GetComponent<Interactable>();
            targetObject.Highlight();
        }
        else
        {
            if (targetObject != null)
            {
                targetObject.Unhighlight();
                targetObject = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            targetObject?.Interact();
        }
    }
}
