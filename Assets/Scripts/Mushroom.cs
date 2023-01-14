using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Mushroom : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Eating mushroom");
        Destroy(gameObject);
    }
}
