using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] UnityEvent playerEndGame;
    private PlayerMovement playerMovement;
    private int countOfEatedFood = 0;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void IncreaseCountOfEatenFood()
    {
        countOfEatedFood++;
    }

    public void WasCatched()
    {
        playerMovement.SetIsMove(false);
        playerEndGame.Invoke();
    }

    public void Restart()
    {
        playerMovement.SetIsMove(true);
        playerMovement.PutToSpawnPosition();
    }
}
