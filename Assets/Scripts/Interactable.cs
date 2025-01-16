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
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public void interact()
    {
        switch (interactable)
        {
                case objetsInteractable.torche:
                anim.SetTrigger("Fire");
                gameObject.SetActive(false);
                break;

                case objetsInteractable.arbre:
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                rotationPoint.transform.eulerAngles = Vector3.forward * -90;
                StartCoroutine(ChangeArbre());
                break;

                case objetsInteractable.vignes:
                //  anim.SetTrigger("Fire");
                gameObject.SetActive(false);

                break;


                case objetsInteractable.ice:
                //anim.SetTrigger("Steam");
                gameObject.SetActive(false);
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
        spriteRenderer.sprite = newSprite;
    }

}
