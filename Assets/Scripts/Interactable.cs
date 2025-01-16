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
    public void interact()
    {
        switch (interactable)
        {
                case objetsInteractable.torche:


                break;

                case objetsInteractable.arbre:


                rotationPoint.transform.eulerAngles = Vector3.forward * -90;
                break;

                case objetsInteractable.vignes:

                break;


                case objetsInteractable.ice: 
                
                break;

        }
    }
}
