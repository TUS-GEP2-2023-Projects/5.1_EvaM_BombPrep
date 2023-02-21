using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H))
        {
            Hide();
        }
	}

    void Hide()
    {
        Debug.Log("Starting the HideTimer.");

        StartCoroutine("HideTimer");

        Debug.Log("Finished starting the HideTimer.");
    }

    IEnumerator HideTimer()
    {
        spriteRenderer.enabled = false;

        Debug.Log("About to wait for 5 seconds");
        // Let's wait for 5 seconds
        yield return new WaitForSeconds(5.0f);


        Debug.Log("Finished waiting.");
        // This following line of code will be executed 5 seconds after the previous
        // line
        spriteRenderer.enabled = true;

    }
}
