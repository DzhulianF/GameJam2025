using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
 
    public enum objetsInteractable
    {
        torche,
        arbre,
        vignes,
        ice
    };

    public objetsInteractable interactable;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private Animator anim;


    public void interact()
    {
        switch (interactable)
        {




                case objetsInteractable.torche:
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;




                case objetsInteractable.arbre:
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                rotationPoint.transform.eulerAngles = Vector3.forward * -90;
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                StartCoroutine(ChangeArbre());
                break;



                case objetsInteractable.vignes:
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                StartCoroutine(BruleVigne());
                break;





                case objetsInteractable.ice:
                anim.SetTrigger("Melt");
                StartCoroutine(MeltIce());
                break;






                default:
                Debug.Log("TuToucheARien");    
                break;


        }
    }

    public IEnumerator ChangeArbre()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    
    }
    public IEnumerator MeltIce()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("IsTheIceMelted", true);
        gameObject.SetActive(false);
     
    }
    public IEnumerator BruleVigne()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

      
    }

}
