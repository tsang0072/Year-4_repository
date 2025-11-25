using UnityEngine;

public class Level1Puzzle : MonoBehaviour
{
    Animator bottunController;
    AudioManager audioManager;
    bool buttonPress_1 = false;
    bool buttonPress_2 = false;
    bool door1Open=false;
    bool door2Open=true;

    void Start()
    {
        bottunController = GetComponent<Animator>();
        audioManager=AudioManager.instance;
    }
    void Update()
    {
        if (buttonPress_1 && Input.GetKeyDown(KeyCode.E))
        {
            audioManager.PlayButtonSFX();
            audioManager.PlayDoorSFX();
            bottunController.SetTrigger("TrPress");
            if (!door1Open)
            {
                GameObject.Find("Door1").GetComponent<Animator>().SetTrigger("TrOpen");
                door1Open = true;
            }
            else if (door1Open)
            {
                GameObject.Find("Door1").GetComponent<Animator>().SetTrigger("TrClose");
                door1Open = false;
            }
            if (door2Open)
            {
                GameObject.Find("Door2").GetComponent<Animator>().SetTrigger("TrClose");
                door2Open = false;
            }
            else if (!door2Open)
            {
                GameObject.Find("Door2").GetComponent<Animator>().SetTrigger("TrOpen");
                door2Open = true;
            }
        }
        if (buttonPress_2 && Input.GetKeyDown(KeyCode.E))
        {
            bottunController.SetTrigger("TrPress");
            audioManager.PlayDoorSFX();
            if (door2Open)
            {
                Debug.Log("door2"+door2Open);
                GameObject.Find("Door2").GetComponent<Animator>().SetTrigger("TrOpen");
                door2Open = false;
            }
            else if (!door2Open)
            {
                Debug.Log("door2"+door2Open);
                GameObject.Find("Door2").GetComponent<Animator>().SetTrigger("TrClose");
                door2Open = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Can press E");
            if (this.gameObject.name == "Button1")
                buttonPress_1 = true;
            if(this.gameObject.name=="Button2")
            buttonPress_2 = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        buttonPress_1 = false;
        buttonPress_2=false;   
    }
}
