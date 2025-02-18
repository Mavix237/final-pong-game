using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Ball")){
            StartCoroutine(LoadNextScene());
            Destroy(other.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    IEnumerator LoadNextScene(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}
