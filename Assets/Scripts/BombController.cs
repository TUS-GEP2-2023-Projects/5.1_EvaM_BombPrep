using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{ private SpriteRenderer spriteRenderer;
    public Animator BombAN;
    public bool BombArmed;
    public PointEffector2D thePoint;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        BombAN = GetComponent<Animator>();
        BombAN.Play("Idle");
           BombAN.SetBool("Boom", false);
        BombArmed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
           
            StartCoroutine("FadeCoroutine");
            
        }
    if (BombArmed == true)
        {
            thePoint.forceMagnitude = 500;
        }
    }
private IEnumerator FadeCoroutine() { 
        for (float f = 1; f >= 0; f -= 0.1f){
        Color c = spriteRenderer.color;
            c.a = f;
            spriteRenderer.color = c;
            BombAN.SetBool("Boom", true);
            yield return new WaitForSeconds(1f);

            
        }
        ResetSpriteRenderer();
    }
    void ResetSpriteRenderer()
    {
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character" && BombAN == true) {
            BombArmed = true;
        }
    }

}
