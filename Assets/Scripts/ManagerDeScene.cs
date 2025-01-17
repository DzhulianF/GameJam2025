using System.Collections;
using System.Collections.Generic;
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

    public void SceneFinale()
    {
        SceneManager.LoadScene(3);
    }


    public void Accueil()
    {
        SceneManager.LoadScene(0);
    }
}
