using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    static Test instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    async void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            await MessageBox.EnableMessageBox("Xyz");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GoalScreen.EnableGoalScreen();
        }
    }
}
