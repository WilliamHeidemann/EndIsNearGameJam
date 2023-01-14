using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHigh : MonoBehaviour
{
    [SerializeField] private FloatValue mushroom;
    [Range(0, 1)] public float controlledMushroom;

    private void Update()
    {
        mushroom.value = controlledMushroom;
    }
}
