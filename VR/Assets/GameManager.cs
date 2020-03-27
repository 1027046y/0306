using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject lightgroup;
    [Header("會動的椅子")]
    public Transform chest;
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
        for (int i = 0; i < 30; i++)
        {
            chest.position -= chest.forward * 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        chest.GetComponent<CapsuleCollider>().enabled = false;



    }
    private void Start()
    {
        StartCoroutine(Effectlight());
    }
}
