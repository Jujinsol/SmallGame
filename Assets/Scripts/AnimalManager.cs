using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Animal curAnimal;

    public Transform canvas;

    public static AnimalManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnAnimal()
    {
        GameObject animalToSpawn = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
        GameObject obj = Instantiate(animalToSpawn, canvas);

        curAnimal = obj.GetComponent<Animal>();
    }

    public void ReplaceAnimal(GameObject animal)
    {
        Destroy(animal);
        SpawnAnimal();
    }
}
