using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    private float speed = 10.0f;
    [SerializeField] private Animator anim;

    public void RespawnNow()
    {
     transform.position = respawnPoint;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "TriggerMort")
        {
            {

                StartCoroutine(AnimationMort());
                
            }
        }


    }

   public IEnumerator AnimationMort()
    {
        yield return new WaitForSeconds(2.45f);
        RespawnNow();
    }



}