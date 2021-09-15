using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject joystickGO;
    [SerializeField] GameObject buttonGO;
    [SerializeField] GameObject restartGO;
    [SerializeField] GameObject startGO;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowControlUI(bool show)
    {
        joystickGO.SetActive(show);
        buttonGO.SetActive(show);
    }

    public void HideStartDisplay()
    {
        startGO.SetActive(false);
    }

    public void ShowRestartDisplay()
    {
        restartGO.SetActive(true);
        ShowControlUI(false);
    }

    public void HideRestartDisplay()
    {
        restartGO.SetActive(false);
        ShowControlUI(true);
    }
}
