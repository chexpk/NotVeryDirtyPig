using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] UnityEvent playerEndGame;
    private PlayerMovement playerMovement;
    private int countOfEatedFood = 0;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCountOfEatenFood()
    {
        countOfEatedFood++;
    }

    public void WasCatched()
    {
        playerMovement.SetIsMove(false);
        playerEndGame.Invoke();
        //endGame
    }

    public void Restart()
    {
        playerMovement.SetIsMove(true);
        playerMovement.PutToSpawnPosition();
    }
}
