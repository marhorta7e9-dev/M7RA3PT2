using UnityEngine;

public class save : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveGame()
    {
        PlayerPrefs.Save(); // Guarda los datos en PlayerPrefs de forma persistente.
    }
}
