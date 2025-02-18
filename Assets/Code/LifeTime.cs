using UnityEngine;

public class LifeTime : MonoBehaviour
{
    void Start()
    {
        //destroy the game object after 0.5 seconds
        //to make the explosion only happen once
        Destroy(gameObject, .6f);
    }

}
