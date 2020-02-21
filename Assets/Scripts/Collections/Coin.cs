using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject Player;

    static private int Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(Player))
        {
            gameObject.SetActive(false);
            Count++;
        }
    }
}
