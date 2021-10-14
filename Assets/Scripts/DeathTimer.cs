using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    public float HitTimer;
    float HitTimerInstance;
    // Start is called before the first frame update
    void Start()
    {
        HitTimerInstance = HitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        HitTimer -= Time.deltaTime;
        if (HitTimer <= 0)
        {
            Destroy(gameObject);
            HitTimer = HitTimerInstance;
        }
    }
}
