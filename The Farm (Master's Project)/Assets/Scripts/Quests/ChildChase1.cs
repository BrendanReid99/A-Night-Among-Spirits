using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildChase1 : MonoBehaviour
{

    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject NPC2;
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
        anim.Play("NPC_Chase_1");
        yield return new WaitForSeconds(2.5f);
        NPC2.SetActive(true);
        Destroy(NPC);
    }
}