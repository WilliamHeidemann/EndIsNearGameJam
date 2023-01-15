using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MushroomSpawner : MonoBehaviour
{
    [SerializeField] private Terrain terrain;
    [SerializeField] private Mushroom littleMushroom;
    [SerializeField] private Mushroom bigMushroom;
    [SerializeField] private Transform player;
    private readonly List<GameObject> _pooledObjects = new();
    [Range(0,100)] [SerializeField] private int mushroomDensity;

    private void Start()
    {
        StartCoroutine(RemoveDistantMushrooms());
        for (int i = 0; i < mushroomDensity; i++)
        {
            var mushroom = GetPooledObject();
            RelocateAroundPlayer(mushroom);
        }
    }
    
    private IEnumerator RemoveDistantMushrooms()
    {
        while (true)
        {
            foreach (var mushroom in _pooledObjects.Where(mushroom => Vector3.Distance(mushroom.transform.position, player.position) > 30))
            {
                RelocateAroundPlayer(mushroom);
            }
            yield return new WaitForSeconds(3);
        }
    }

    private void RelocateAroundPlayer(GameObject mushroom)
    {
        mushroom.SetActive(true);
        var position = GetNewPosition();
        mushroom.transform.position = position;
    }

    private Vector3 GetNewPosition()
    {
        var x = Random.Range(-1f, 1f);
        var z = Random.Range(-1f, 1f);
        var rand = new Vector3(x, 0, z);
        var randSized = rand.normalized * Random.Range(10, 20);
        var pos = player.position + randSized;
        var y = terrain.SampleHeight(new Vector3(pos.x, 0, pos.z));
        return new Vector3(pos.x, y, pos.z);;
    }

    private GameObject GetPooledObject()
    {
        return _pooledObjects.FirstOrDefault(poolObject => !poolObject.activeInHierarchy) ?? NewObject();
    }

    private GameObject NewObject()
    {
        var newObject = SpawnMushroom();
        _pooledObjects.Add(newObject);
        return newObject;
    }
    
    private GameObject SpawnMushroom()
    {
        var small = Random.value < .9f;
        Mushroom mushroom;
        if (small)
        {
            mushroom = Instantiate(littleMushroom);
            mushroom.Strength = Random.value * 0.2f + 0.1f;
        }
        else
        {
            mushroom = Instantiate(bigMushroom);
            mushroom.Strength = Random.value * 0.2f + 0.5f;
        }

        return mushroom.gameObject;
    }

}
