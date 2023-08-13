using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildChase2 : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    
    private Animator anim;
    private bool firstDone = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collider)
    {

        StartCoroutine(RunAway());
       
    }

    private IEnumerator RunAway()
    {
        anim.Play("NPC_Chase_2");
        yield return new WaitForSeconds(2.5f);
        
        Destroy(NPC);
    }
}
