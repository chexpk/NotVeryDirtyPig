using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    FoodSpawner foodSpawner;

    public void WasEaten()
    {
        foodSpawner.CreatFoodOnRandomPosition();
        Destroy(gameObject);
    }

    public void SetFoodSpawner(FoodSpawner spawner)
    {
        foodSpawner = spawner;
    }
}
