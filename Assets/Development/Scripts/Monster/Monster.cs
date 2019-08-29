using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] List<TrashType> trashTypes;
    [SerializeField] Animator anim;
    [SerializeField] Animator appearAnim;
    [SerializeField] float timeBeforeAngry;
    [SerializeField] float timeBetweenNotifications;
    [SerializeField] GameObject popUpIcon;
    [SerializeField] AudioClip portalSound;
    [SerializeField] AudioClip getAngrySound;
    [SerializeField] AudioSource source;
    public bool angry { get; set; }
    bool fed;
   
    void Awake()
    {
        //source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        angry = false;
        fed = false;
        popUpIcon.SetActive(false);
        source.clip = portalSound;
        source.PlayDelayed(1.0f);
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
                    if (getAngrySound!=null)
                    {
                        source.PlayOneShot(getAngrySound);
                    }
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

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void CorrectFoodReaction()
    {
        Toolbox.Instance.progressBar.AddProgress(10);
        StopAllCoroutines();
        appearAnim.SetBool("Finish", true);
    }

    void WrongFoodReaction()
    {
        
    }
}
