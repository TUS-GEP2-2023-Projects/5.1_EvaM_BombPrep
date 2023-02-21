using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            // Here I call a demo function called Fade. It reduces the alpha value of the material
            // used by the SpriteRenderer. 
            Fade();
        }

        if (Input.GetKeyDown("w"))
        {
            // Here is an example of starting a coroutine function by passing a sting value to
            // the StartCoroutine function which contains the name of the coroutine function
            // you want to start. While this is "handy" it takes unity a little longer to do
            // than the next example.
            StartCoroutine("FadeCoroutine");
        }

        if (Input.GetKeyDown("e"))
        {
            // All coroutine functions return an IEnumerator object. You can think if this as
            // an object that contains information about the coroutine function.

            // Fist I create a variable that can store an IEnumerator object
            IEnumerator theCoroutine;

            // Next I call the coroutine function and store the IEnumerator object it returns
            // in my theCouroutine variable. 
            // IMPORTANT: Usually when you call a function the code within the function gets
            // executed, however, when you call a coroutine function directly like I have in the
            // next line the code withing the coroutine function DOES NOT get executes. Instead,
            // the "computer" (the Unity/C# engine) collects information about the function and
            // returns it in the form on an IEnumerator object.
            theCoroutine = FadeCoroutine();

            // It is only when we use Unity's StartCoroutine function to call a coroutine function
            // that the actual code within the function gets executed.
            // The example below differs from the previous example as I don't pass the StartCoroutine
            // function a string value containing the name of the coroutine function, but rather I
            // pass it an IEnumerator object that contains information about the coroutine function
            // I want to call. 
            // This is the preferred way of starting a coroutine.
            StartCoroutine(theCoroutine);
        }

        // The following code allows me to reset the alpha value back to 1 for demo purposes (it has
        // nothing to do with coroutines).
        if (Input.GetKeyDown("r"))
        {
            ResetSpriteRenderer();
        }
    }

    void Fade()
    {
        // This for loop will execute within one update call i.e. Unity will detect that
        // 'q' key has been pressed and call this function which will execute this loop.
        
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = spriteRenderer.color;
            c.a = f;
            spriteRenderer.color = c;
        }

        // At this point the alpha value should be 0.0 but because floats don't EXACTLY match
        // decimal points and have issues with accuracy the alpha value may actually be
        // something like 0.0199. So I am going to set it to 0. Note also that I can't
        // use the variable name 'c' as I used it above.
        Color c2 = spriteRenderer.color;
        c2.a = 0.0f;
        spriteRenderer.color = c2;

        /*
            Would have just as easily replaced the above loop with the following code:
          
            Color c = spriteRenderer.color;
            c.a = 0;
            spriteRenderer.color = c;

            i.e. just sent the alpha value to 0 immediately rather then reducing it steps
            0.1 as the user won't see those intermediate steps anyway.
        */
    }

    IEnumerator FadeCoroutine()
    {
        Debug.Log("Starting to fade ...");

        for (float f = 1f; f >= 0.0f; f -= 0.1f)
        {
            Color c = spriteRenderer.color;
            c.a = f;
            spriteRenderer.color = c;

            Debug.Log("... alpha is : " + f);
            yield return new WaitForSeconds(1f);
        }

        // At this point the alpha value should be 0.0 but because floats don't EXACTLY match
        // decimal points and have issues with accuracy the alpha value may actually be
        // something like 0.0199. So I am going to set it to 0. Note also that I can't
        // use the variable name 'c' as I used it above.
        Color c2 = spriteRenderer.color;
        c2.a = 0.0f;
        spriteRenderer.color = c2;

        Debug.Log("Finished fading.");
    }

    void ResetSpriteRenderer()
    {
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
}
