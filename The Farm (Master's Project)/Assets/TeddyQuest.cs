using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeddyQuest : MonoBehaviour
{

    [SerializeField] private GameObject controllerHolder;
    private GameController controller;

    private Animator anim;

    [SerializeField] private TextMeshProUGUI QuestText;
    [SerializeField] private GameObject panel;

    public int questStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = controllerHolder.GetComponent<GameController>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(questStage == 0)
        {

        }
        else if (questStage == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                panel.SetActive(false);
            }
        }
        if(controller.teddyCollected == true)
        {
            questStage = 2;
        }
    }

    /*
    public void Interacted()
    {
        if(questStage == 0)
        {
            GiveQuest();
        }
        if(questStage == 1)
        {
            QuestIncomplete();
        }
        if(questStage == 2)
        {
            CompleteQuest();
        }
    }
    */

    public void GiveQuest()
    {
        panel.SetActive(true);
        QuestText.text = "... My teddy won't stop running away... please help me catch it...";
        questStage = 1;

    }

    public void QuestIncomplete()
    {
        panel.SetActive(true);
        QuestText.text = "..have you found my teddy yet?";
    }

    public void CompleteQuest()
    {
        panel.SetActive(true);
        QuestText.text = "Yayy! Thank you!";
    }
}
