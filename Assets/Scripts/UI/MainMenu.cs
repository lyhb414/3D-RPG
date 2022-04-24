using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button newGameBtn;
    private Button continueBtn;
    private Button quitBtn;
    private PlayableDirector director;

    private void Awake()
    {
        newGameBtn = transform.GetChild(1).GetComponent<Button>();
        continueBtn = transform.GetChild(2).GetComponent<Button>();
        quitBtn = transform.GetChild(3).GetComponent<Button>();

        director = FindObjectOfType<PlayableDirector>();
        director.stopped += NewGame;

        newGameBtn.onClick.AddListener(playTimeline);
        continueBtn.onClick.AddListener(ContinueGame);
        quitBtn.onClick.AddListener(QuitGame);
    }

    private void playTimeline()
    {
        director.Play();
    }

    private void NewGame(PlayableDirector obj)
    {
        PlayerPrefs.DeleteAll();
        //转换场景
        SceneController.Instance.TransitionToFirstLevel();

    }

    private void ContinueGame()
    {
        //转换场景，读取进度
        SceneController.Instance.TransitionToContinueGame();
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
