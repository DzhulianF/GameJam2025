using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerDeScene : MonoBehaviour
{
    public void   SceneExplication()
    {
        SceneManager.LoadScene(1);
    }

    public void SceneJeu()
    {
        SceneManager.LoadScene(2);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(3);
    }


    public void Accueil()
    {
        SceneManager.LoadScene(0);
    }
}
