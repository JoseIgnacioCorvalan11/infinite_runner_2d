using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruyeMonedas : MonoBehaviour
{
    public static DestruyeMonedas Instance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InfiniteRun_GameManager.Instance.GainScore();
        Destroy(gameObject);
        Debug.Log(gameObject);
    }
}
