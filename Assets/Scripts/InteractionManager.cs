using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public float radius;
    private GameObject _nearest;

    private void Update()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, radius);
        if (hitColliders.Length == 0)
        {
            _nearest = null;
            return;
        }
        var nearestCollider = hitColliders
            .Where(col => IsInteractable(col.gameObject))
            .OrderBy(col => Vector3.Distance(col.transform.position, transform.position))
            .FirstOrDefault();
        if (nearestCollider is null) return;
        _nearest = nearestCollider.gameObject;
        _nearest.GetComponent<MeshRenderer>().material.color = Color.red;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            _nearest.GetComponent<IInteractable>().Interact();
        }
    }

    private bool IsInteractable(GameObject go)
    {
        return go.GetComponent<IInteractable>() != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 1f, 0.3f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}
