using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] List<TrashType> trashTypes;
    [SerializeField] Animator anim;
    [SerializeField] float timeBeforeAngry;
    [SerializeField] float timeBetweenNotifications;
    bool angry;
    bool fed;

    void OnEnable()
    {
        fed = false;
        StopAllCoroutines();
        //StartCoroutine(AskingCor());
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
                }
            }
            yield return null;
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

    }

    void WrongFoodReaction()
    {

    }
}
