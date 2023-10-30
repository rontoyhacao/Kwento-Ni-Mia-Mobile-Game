using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControl : MonoBehaviour
{
    public bool HasTransition, NoTransition;

    string SaveNameScene;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        if (HasTransition && NoTransition)
        {
            gameObject.SetActive(false);
        }
    }

    public void BtnSound(int id)
    {
        SoundCollection.instance.CallSfx(0);
    }
    public void BtnMove(string name)
    {
        this.gameObject.SetActive(true);
        SaveNameScene = name;
        GetComponent<Animator>().Play("end");
    }
    public void BtnRetry(string name)
    {
        SaveNameScene = SceneManager.GetActiveScene().name;
        GetComponent<Animator>().Play("end");
    }
    public void Move()
    {
        SceneManager.LoadScene(SaveNameScene);
    }

    public void BtnQuitGame()
    {
        Application.Quit();
    }
}
