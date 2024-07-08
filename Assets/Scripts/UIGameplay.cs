using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [Header("Gameplay Buttons")]

    public Button buttonResume;

    public Button buttonPause;

    public Button buttonMenu;

   


    private void Start()
    {
        buttonMenu.onClick.AddListener(() => GameManager.Instance.ChangeScene(0));
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        if(GameManager.Instance.isPaused)
        {
            GameManager.Instance.Resume();
            buttonPause.gameObject.SetActive(true);
            buttonResume.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.Pause();
            buttonPause.gameObject.SetActive(false);
            buttonResume.gameObject.SetActive(true);
        }
    }
}
