using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] int progressToFinish;
    public bool finished;
    public int currentProgress;

    void OnEnable()
    {
        currentProgress = 0;
        finished = false;
    }

    public void AddProgress(int amount)
    {
        if (finished)
            return;

        currentProgress+=amount;
        progressBar.fillAmount = (float)currentProgress / (float)progressToFinish;
        if (currentProgress>=progressToFinish)
        {
            finished = true;
        }
    }

}
