using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject aikalabel;
    public GameObject aika;
    public GameObject alcoholText;
    public GameObject projectText;
    public GameObject socialText;
    public GameObject hungerText;
    
    private float timer = 0.0f;
    private float delay = 1.0f;
    private float death_time = 0.0f;
    
    private int alcohol = 20;
    private int hunger = 20;
    private int social = 20;
    private int project = 20;
    private int gameTime = 0;
    
    private bool areYouDeadYet = false;
    private bool victory = false;
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
            if (areYouDeadYet == false)
            {
                LogStats();
            }
            if (areYouDeadYet == true) {
                if (death_time == 0.0f) {
                    death_time = gameTime;
                    Debug.Log("Aika asetettu");
                }
                
                if (gameTime - death_time > 3.0)
                {
                    Debug.Log("uudelleen!");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
                }
            }
            CheckStats();

        }
    }

    private void DegradeStats()
    {
        if (alcohol > 0) {
            alcohol -= 1;
        }

        hunger += 1;
        social -= 1;
        gameTime += 1;
    }
    
    private void LogStats() {
        aika.GetComponent<TMPro.TextMeshProUGUI>().text = gameTime.ToString();
        Debug.Log("Alc: " + alcohol);
        alcoholText.GetComponent<TMPro.TextMeshProUGUI>().text = alcohol.ToString();
        Debug.Log("Hunger: " + hunger);
        hungerText.GetComponent<TMPro.TextMeshProUGUI>().text = hunger.ToString();
        Debug.Log("Social: " + social);
        socialText.GetComponent<TMPro.TextMeshProUGUI>().text = social.ToString();
        Debug.Log("Project: " + project);
        if (victory == false) {
 
            projectText.GetComponent<TMPro.TextMeshProUGUI>().text = project.ToString();
            Debug.Log("Time: " + gameTime);
        }
        else
        {
            projectText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
        
    }
        
    
    private void CheckStats()
    {
        if ((alcohol <= 0 || social <= 0 || hunger >= 100 || project <= 0) && victory == false)
        {
            Debug.Log("Kuolit saatana.");
            aikalabel.GetComponent<TMPro.TextMeshProUGUI>().text = "Menit nukkumaan :(";
            aika.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            areYouDeadYet = true;
        }
        
        if (gameTime > 100 && areYouDeadYet == false)
        {
            aikalabel.GetComponent<TMPro.TextMeshProUGUI>().text = "VOITIT JO";
            victory = true;
            Debug.Log("VOITOTOTOTOTOTTOTO");
        }
    }
    
    public void TestFunction()
    {
        Debug.Log("MOI");
    }
    
    public void drink()
    {
        alcohol += 10;
        social += 6;
        hunger += 2;
        if (alcohol > 30) {
            project = project / 2;
        }
    }
    
    public void eat()
    {
        alcohol -= 5;
        hunger -= 11;
        project -= 5;
    }
    
    public void do_project()
    {
        if (alcohol > 30) {
            project = project / 2;
        
        } else {
            alcohol -= 5;
            hunger += 3;
            project += 10;
            social -= 10;
        }
    }
    
    public void do_social()
    {
        hunger += 4;
        project -= 5;
        social += 10;
    }
    
}
