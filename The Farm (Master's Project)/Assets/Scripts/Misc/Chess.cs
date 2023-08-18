using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour, IInteractable
{
    private int moveCounter = 1;
    private Animator anim;
    [SerializeField] private Transform blackPawnTarget;
    [SerializeField] private Transform blackQueenTarget;
    [SerializeField] private Transform whitePawnTarget1;
    [SerializeField] private Transform whitePawnTarget2;

    [SerializeField] private GameObject blackPawn;
    [SerializeField] private GameObject blackQueen;
    [SerializeField] private GameObject whitePawn;
    [SerializeField] private GameObject whitePawn2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if(moveCounter == 1)
        {
            anim.Play("ChessMove1");
            moveCounter++;
            Debug.Log("Move1");
        }
        else if(moveCounter == 2)
        {
            whitePawn.transform.position = whitePawnTarget1.position;
            anim.Play("ChessMove2");
            moveCounter++;
            Debug.Log("Move2");
        }
        else if(moveCounter == 3)
        {
            blackPawn.transform.position = blackPawnTarget.position;
            anim.Play("ChessMove3");
            moveCounter++;
            Debug.Log("Move3");
        }
        else if(moveCounter == 4)
        {
            whitePawn2.transform.position = whitePawnTarget2.position;
            anim.Play("ChessMove4");
            moveCounter++;
            Debug.Log("Move4");
        }
        else if(moveCounter == 5)
        {
            blackQueen.transform.position = blackQueenTarget.position;
            Debug.Log("Checkmate!");
        }
    }
}
