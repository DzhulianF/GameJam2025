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
        ice,
        arbreB
    };

    public objetsInteractable interactable;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator nuitJour;
    private Collider2D[] collidersDesArbres; 

    public void interact()
    {
        switch (interactable)
        {




                case objetsInteractable.torche:
                anim.SetTrigger("FlammeTorche");
                anim.SetBool("IsTorchBurning", true);
                switchAlaNuit();
                break;




                case objetsInteractable.arbre:
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }

                anim.SetBool("isTreeFalling", true);

                collidersDesArbres = GetComponents<Collider2D>();

                foreach (Collider2D colliderIndividuel in collidersDesArbres)
                {
                    colliderIndividuel.isTrigger = false;
                }
                StartCoroutine(ChangeArbre());
                break;
                
                case objetsInteractable.arbreB:

                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                anim.SetBool("isTreeFalling", true);

                collidersDesArbres = GetComponents<Collider2D>();

                foreach (Collider2D colliderIndividuel in collidersDesArbres)
                {
                    colliderIndividuel.isTrigger = false;
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

    private void switchAlaNuit()
    {
        nuitJour.SetBool("isItNight", false);
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
