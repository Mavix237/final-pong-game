using UnityEngine;

public class MakeExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnDestroy(){
        if(gameObject.scene.isLoaded){
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
