using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private Player player;
    [SerializeField] private EnemyAI enemy;

    public void EndGame()
    {
        uiController.ShowRestartDisplay();

    }

    public void StartGame()
    {
        uiController.HideStartDisplay();
        enemy.Restart();
        player.Restart();
    }

    public void RestartGame()
    {
        player.Restart();
        enemy.Restart();
        uiController.HideRestartDisplay();
    }
}
