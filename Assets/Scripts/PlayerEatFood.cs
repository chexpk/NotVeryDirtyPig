using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEatFood : MonoBehaviour
{
    [SerializeField] private UnityEvent foodEaten;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.GetComponent<Food>()) return;
        other.GetComponent<Food>().WasEaten();
        foodEaten.Invoke();
    }
}
