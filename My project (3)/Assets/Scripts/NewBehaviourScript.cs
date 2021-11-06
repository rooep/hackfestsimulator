using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float timer = 0.0f;
    private float delay = 1.0f;
    
    private int alcohol = 0;
    private int hunger = 0;
    private int social = 0;
    private int project = 0;
    private int gameTime = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay) {
            timer = 0.0f;
            DegradeStats();
            LogStats();

        }
    }

    private void DegradeStats()
    {
        if (alcohol > 0) {
            alcohol -= 1;
        }

        hunger += 1;
        gameTime += 1;
    }
    
    private void LogStats() {
        Debug.Log("Alc: " + alcohol);
        Debug.Log("Hunger: " + hunger);
        Debug.Log("Social: " + social);
        Debug.Log("Project: " + project);
        Debug.Log("Time: " + gameTime);
    }
        
    
    private void CheckStats()
    {
        
    }
    
    public void TestFunction()
    {
        Debug.Log("MOI");
    }
    
    public void drink()
    {
        alcohol += 10;
        social += 5;
        hunger += 5;
        project -= 5;
    }
    
    public void eat()
    {
        alcohol -= 5;
        hunger -= 5;
        project -= 5;
    }
    
    public void do_project()
    {
        alcohol -= 5;
        hunger += 5;
        project += 10;
    }
    
    public void do_social()
    {
        hunger += 5;
        project -= 5;
        social += 10;
    }
    
}
