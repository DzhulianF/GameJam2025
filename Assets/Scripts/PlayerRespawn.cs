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
        AnimationRebirth();
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "TriggerMort")
        {
            {

                StartCoroutine(AnimationMortQuick());
                
            }
        }


    }

    public IEnumerator AnimationMortQuick()
    {
        yield return new WaitForSeconds(1f);
        RespawnNow();
    }

    public IEnumerator AnimationMort()
    {
        yield return new WaitForSeconds(2.2f);
        RespawnNow();
    }

    private void AnimationRebirth()
    {
        anim.SetTrigger("Rebirth");
      
    }

}