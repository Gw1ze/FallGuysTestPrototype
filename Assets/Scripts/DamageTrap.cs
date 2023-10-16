using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    private bool activated = false;
    private Renderer trapRenderer;
    private float activationDelay = 1f;
    private float activationDelay2 = 0.5f;
    private float resetDelay = 5f;
    public int damageCount = 20;
    private List<GameObject> playersOnTrap = new List<GameObject>();

    void Start()
    {
        trapRenderer = GetComponent<Renderer>();
        trapRenderer.material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        playersOnTrap.Add(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!activated)
            {
                StartCoroutine(ActivateTrap());
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersOnTrap.Remove(collision.gameObject);
        }
    }

    private IEnumerator ActivateTrap()
    {
        activated = true;
        trapRenderer.material.color = Color.yellow;

        yield return new WaitForSeconds(activationDelay);

        trapRenderer.material.color = Color.red;

        if (activated && trapRenderer.material.color == Color.red)
        {
            Debug.Log("da");
            DealDamageToPlayers();
        }

        yield return new WaitForSeconds(activationDelay2);
        trapRenderer.material.color = Color.white;
        yield return new WaitForSeconds(resetDelay);
        
        activated = false;
    }

    private void DealDamageToPlayers()
    {
        foreach (var player in playersOnTrap)
        {
            PlayerManager.Damage(damageCount);
        }
    }
}
