using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Interactable : MonoBehaviour
{
 
    public enum objetsInteractable
    {
        torche,
        arbre,
        vignes,
        ice,
        arbreB
    };

    public objetsInteractable interactable;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private Animator anim;
    BoxCollider2D [] collidersPourArbre;

    public void interact()
    {
        switch (interactable)
        {




                case objetsInteractable.torche:
                anim.SetTrigger("FlammeTorche");
                anim.SetBool("IsTorchBurning", true);
                StartCoroutine(FlammeTorche());
                break;




                case objetsInteractable.arbre:
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                rotationPoint.transform.eulerAngles = Vector3.forward * -90;
                 collidersPourArbre =  GetComponents<BoxCollider2D>();
                foreach(BoxCollider2D colliderDarbre in collidersPourArbre){
                    colliderDarbre.isTrigger = false;
                }
                StartCoroutine(ChangeArbre());
                break;

                case objetsInteractable.arbreB:
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                rotationPoint.transform.eulerAngles = Vector3.forward * 90;
                collidersPourArbre = GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D colliderDarbre in collidersPourArbre)
                {
                    colliderDarbre.isTrigger = false;
                }
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

    public IEnumerator FlammeTorche()
    {
        yield return new WaitForSeconds(30f);
        anim.SetBool("IsTorchBurning" , false);

    }

    public IEnumerator ChangeArbre()
    {
        transform.gameObject.tag = "Ground";
        gameObject.layer = 6;
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
