using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextStageManager : MonoBehaviour
{
    public string StageName;
    private bool ActiveTransition = false;

    public Image Transition;

    // Update is called once per frame
    void Update()
    {
        if (ActiveTransition) Transition.fillAmount += 0.01f;
        if (Transition.fillAmount >= 1) SceneManager.LoadScene(StageName);
    }

    public void NextStage()
    {
        ActiveTransition = true;
    }

}
