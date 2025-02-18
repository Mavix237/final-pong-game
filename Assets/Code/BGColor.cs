using UnityEngine;
using System.Collections;

public class BGColor : MonoBehaviour
{
    private Color color1;
    public Color color2;
    public Color colorEnd;
    public float fadeSpeed = 2f;

    SpriteRenderer spriteRenderer;
    

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        color1 = spriteRenderer.color;
        colorEnd = new Color32(125, 25, 25, 255);
        
    }

    // when the brick is destroyed, start the fade
    public void StartFade(){
        StartCoroutine(FadeColor());
    }

    public void GameEnd(){
        StartCoroutine(GameOver());
    }

    IEnumerator FadeColor(){
        // t is time
        float t = 0;
        float fadeSpeed = 2f;
        while(t < 1){
            t += Time.deltaTime * fadeSpeed;
            // color lerp - fade from one color to another
            spriteRenderer.color = Color.Lerp(color1, color2, t);
            yield return null;
        }

        t = 0;
        while(t < 1){
            t += Time.deltaTime * fadeSpeed;
            spriteRenderer.color = Color.Lerp(color2, color1, t);
            yield return null;
        }
    }

    IEnumerator GameOver(){
        float t = 0;
        while(t < 1){
            t += Time.deltaTime * fadeSpeed;
            spriteRenderer.color = Color.Lerp(color1, colorEnd, t);
            yield return null;
        }
    }

    
    
}
