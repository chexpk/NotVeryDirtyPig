using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;
    [SerializeField] private GameObject foodPrefab;

    void Start()
    {
        CreatFoodOnRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatFoodOnRandomPosition()
    {
        var position = GetRandomPosition();
        CreatFood(position);
    }

    void CreatFood(Vector2 position)
    {
        var go = Instantiate(foodPrefab, position, Quaternion.identity);
        go.GetComponent<Food>().SetFoodSpawner(this);
    }

    Vector2 GetRandomPosition()
    {
        int maxIndexOfArr = transforms.Length - 1;
        int randomIndex = Random.Range(0, maxIndexOfArr);
        return transforms[randomIndex].position;
    }
}
