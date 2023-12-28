using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.Common;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PowerUpsController : MonoBehaviour
{

    public ParticleSystem ShieldParticlesystem;
    [SerializeField] public bool isShieldActive = false;
    SpriteRenderer spriteRenderer;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isShieldActive)
            {

                isShieldActive = true;
                ShieldParticlesystem.Play();

                StartCoroutine(StopParticleSystemAfterDelay(5f)); // Stop the particle system after 10 seconds

                spriteRenderer.enabled = false;
            }
        }
    }


    IEnumerator StopParticleSystemAfterDelay( float delay)

    {
      
        yield return new WaitForSeconds(delay); // Wait for the specified delay
 
        ShieldParticlesystem.Stop();
        isShieldActive = false;

        Destroy(gameObject);

    }

}
