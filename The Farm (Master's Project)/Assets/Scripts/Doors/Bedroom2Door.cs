using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bedroom2Door : MonoBehaviour, IInteractable
{

    public GameObject controller;
    private GameController gameController;
    public TextMeshProUGUI locked;
    private float fadeDuration = 4f;

    Animator anim;
    private bool doorOpen = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        gameController = controller.GetComponent<GameController>();
    }

    public void Interact()
    {
        if (gameController.bedroom2Open == true)
        {
            if (doorOpen == false)
            {
                anim.Play("Door1 open");
                doorOpen = true;
            }
            else
            {
                anim.Play("Door1 close");
                doorOpen = false;
            }
        }
        else
        {
            StartCoroutine(doorLocked());
        }
        Debug.Log("Working");
    }

    private IEnumerator doorLocked()
    {
        locked.gameObject.SetActive(true);



        float elapsedTime = 0f;
        Color startColor = locked.color;

        while (elapsedTime < fadeDuration)
        {

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            locked.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        locked.color = new Color(startColor.r, startColor.g, startColor.b, 0f);


    }

    public void SpiritWorld(bool status)
    {
        if(status == true)
        {
            anim.Play("Door1 open");
        }

        if(status == false)
        {
            anim.Play("Door1 close");
        }
    }


}