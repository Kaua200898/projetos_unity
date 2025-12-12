using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextStageManager : MonoBehaviour
{
    public string StageName;
    private bool ActiveTransition = false;

    public Image TransitionStart;
    public Image TransitionEnd;

    void Start()
    {
        TransitionStart.fillAmount = 0;
        TransitionEnd.fillAmount = 1;
    }
    void Update()
    {
        if (TransitionEnd.fillAmount > 0) TransitionEnd.fillAmount -= 0.05f;

        if (ActiveTransition) TransitionStart.fillAmount += 0.05f;
        if (TransitionStart.fillAmount >= 1) SceneManager.LoadScene(StageName);
    }

    public void NextStage()
    {
        ActiveTransition = true;
    }

}
