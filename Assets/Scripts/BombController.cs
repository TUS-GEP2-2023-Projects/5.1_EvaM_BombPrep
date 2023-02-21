using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{ private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            StartCoroutine("FadeCoroutine");
        }
    
    }
private IEnumerator FadeCoroutine() { 
        for (float f = 1; f >= 0; f -= 0.1f){
        Color c = spriteRenderer.color;
            c.a = f;
            spriteRenderer.color = c;
         
            yield return new WaitForSeconds(5f);

            ResetSpriteRenderer();
        }
    }
    void ResetSpriteRenderer()
    {
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }

}
