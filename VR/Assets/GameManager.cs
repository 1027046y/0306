using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject lightgroup;
    [Header("會動的椅子")]
    public Transform chest;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("木板上滑動音效")]
    public AudioClip soundWoodMove;
    [Header("鐵製品移動音效")]
    public AudioClip soundMetalMove;
    [Header("敲門音效")]
    public AudioClip soundKnock;
    [Header("開門音效")]
    public AudioClip soundOpen;
    [Header("門的動畫控制器")]
    public Animator aniDoor;

    private int countDoor;

    private int countChest;


    public void LookDoor()
    {
        countDoor++;

        if (countDoor==1)
        {
            aud.PlayOneShot(soundKnock, 5);
        }
        else if (countDoor==2)
        {
            aud.PlayOneShot(soundOpen, 4.5f);
            aniDoor.SetTrigger("開門觸發器");
        }
    }
    public  IEnumerator Effectlight()
    {
        lightgroup.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        lightgroup.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lightgroup.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        lightgroup.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lightgroup.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        lightgroup.SetActive(true);
    }
   public void StartMoveChest()
    {
        StartCoroutine(MoveChest());
    }
    public IEnumerator MoveChest()
    {
        chest.GetComponent<CapsuleCollider>().enabled = false;
        for (int i = 0; i < 30; i++)
        {
            chest.position -= chest.forward * 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
       

        aud.PlayOneShot(soundWoodMove, 2.5f);

    }
    private void Start()
    {
        StartCoroutine(Effectlight());
    }
}
