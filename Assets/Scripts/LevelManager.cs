using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The LevelManager from the Week 6 Lecture
 */
public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public GameObject pointEffectorSourceGO;

    private void Awake()
    {
        // set the instance property/variable to this object
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EnablePointEffector();
        }
    }

    private void EnablePointEffector()
    {
        // Check to make sure we have initialised the pointEffectorSourceGO before
        // we call the GetComponent function on it, otherwise we will get a null
        // pointer error
        if (pointEffectorSourceGO != null)
        {
            // Get the PointEffector2D component off the PointEffectorSource game object
            PointEffector2D pe2D = pointEffectorSourceGO.GetComponent<PointEffector2D>();

            // Set the force magnitude of the PointEffector2D component to 10
            pe2D.forceMagnitude = 10;
        }
        else
        {
            Debug.LogError("*** You need to initialise the pointEffectorSourceGO property ***");
        }
    }

}
