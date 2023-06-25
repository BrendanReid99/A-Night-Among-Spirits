using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBedroomDoor : MonoBehaviour, IInteractable
{

    public GameObject controller;
    private GameController gameController;
    public TextMeshProUGUI locked;
    private float fadeDuration = 4f;
    Animator controlAnim;
    Animator anim;
    private bool doorOpen = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        gameController = controller.GetComponent<GameController>();
        controlAnim = controller.GetComponent<Animator>();
    }

    public void Interact()
    {
        if (gameController.playerBedroomKey == true) {
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

        controlAnim.SetTrigger("EnterHouseExit2");
    }
}
