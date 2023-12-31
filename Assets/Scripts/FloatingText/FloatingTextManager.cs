using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    static FloatingTextManager instance = null;
    public FloatingText prototype;
    public float textLifetime = 10.0f;

    public void Spawn(Vector3 position, string text)
    {
        FloatingText result = Instantiate(instance.prototype, position, Quaternion.identity);
        result.lifetime = instance.textLifetime;
        result.text = text;
    }

    void Start()
    {
        if (instance is null)
        {
            instance = this;
        }
    }
}
