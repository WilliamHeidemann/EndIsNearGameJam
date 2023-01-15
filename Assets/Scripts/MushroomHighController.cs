using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHighController : MonoBehaviour
{
    [SerializeField] private FloatValue high; // Percentage (0% - 100%)

    public static MushroomHighController Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        high.value = 0f;
        StartCoroutine(SoberUp());
    }

    private void Update()
    {
        print(high.value);
    }

    private IEnumerator SoberUp()
    {
        while (true)
        {
            yield return new WaitUntil(IsHigh);
            high.value -= 0.001f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private bool IsHigh() => high.value > 0;

    public IEnumerator ConsumeMushroom(float strength)
    {
        float given = 0;
        while (given < strength)
        {
            high.value += 0.05f;
            given += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
