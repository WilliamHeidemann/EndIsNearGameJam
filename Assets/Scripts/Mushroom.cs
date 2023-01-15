using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mushroom : MonoBehaviour, IInteractable
{
    private MushroomHighController _controller;
    public float Strength { get; set; }

    private void Start()
    {
        _controller = MushroomHighController.Instance;
    }

    public void Interact()
    {
        StartCoroutine(_controller.ConsumeMushroom(Strength));
        gameObject.SetActive(false);
    }
}
