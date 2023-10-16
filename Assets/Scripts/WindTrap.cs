using System.Collections.Generic;
using UnityEngine;

public class WindTrap : MonoBehaviour
{
    private bool activated = false;
    private List<GameObject> playersOnTrap = new List<GameObject>();

    public float windStrength = 4f;
    private Vector3 windDirection = Vector3.right;
    public float windChangeInterval = 2f;

    private void Start()
    {
        windDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        InvokeRepeating("ChangeWindDirection", 0f, windChangeInterval);
    }

    private void Update()
    {
        if (activated)
        {
            MoveCharacters();
        }
    }

    private void ChangeWindDirection()
    {
        windDirection = new Vector3(Random.Range(-1f, 1f), 0f , Random.Range(-1f, 1f)).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersOnTrap.Add(collision.gameObject);
            if (!activated)
            {
                activated = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersOnTrap.Remove(collision.gameObject);
            if (playersOnTrap.Count == 0)
            {
                activated = false;
            }
        }
    }

    private void MoveCharacters()
    {
        foreach (var player in playersOnTrap)
        {
            Transform characterTransform = player.transform;
            characterTransform.position += windStrength * windDirection * Time.deltaTime;
        }
    }
}
