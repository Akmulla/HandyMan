using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] List<TrashType> trashTypes;
    [SerializeField] Animator anim;
    [SerializeField] float timeBeforeAngry;
    [SerializeField] float timeBetweenNotifications;
    [SerializeField] GameObject popUpIcon;
    public bool angry { get; set; }
    bool fed;

    void OnEnable()
    {
        angry = false;
        fed = false;
        popUpIcon.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(AskingCor());
        StartCoroutine(PopUpCor());
    }

    IEnumerator AskingCor()
    {
        float startTime = Time.time;

        while (!fed)
        {
            if (!angry)
            {
                if (Time.time - startTime > timeBeforeAngry)
                {
                    angry = true;
                    anim.SetBool("Angry", true);
                }
            }
            yield return null;
        }

        yield return null;
    }

    IEnumerator PopUpCor()
    {
        while (!fed)
        {
            popUpIcon.SetActive(false);
            yield return new WaitForSeconds(timeBetweenNotifications);
            popUpIcon.SetActive(true);
            yield return new WaitForSeconds(timeBetweenNotifications);
        }
        yield return null;
    }

    void Update()
    {

    }

    public void Feed(TrashType fedType)
    {
        bool correct = false;
        foreach (var trashType in trashTypes)
        {
            if (trashType == fedType)
            {
                correct = true;
            }
        }

        if (correct)
        {
            CorrectFoodReaction();
        }
        else
        {
            WrongFoodReaction();
        }
    }

    void CorrectFoodReaction()
    {
        Toolbox.Instance.progressBar.AddProgress(10);
        gameObject.SetActive(false);
    }

    void WrongFoodReaction()
    {

    }
}
