using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    static public GameManagerX instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [Header("Blackhole")]
    public float m_BlackholeGravityForce = 100f;
    public GameObject m_Blackhole;
}
