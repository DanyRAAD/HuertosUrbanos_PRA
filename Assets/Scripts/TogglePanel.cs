using UnityEngine;
using UnityEngine.UI;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel; 
    public Button button;    

    void Start()
    {
        
        panel.SetActive(false);

        
        button.onClick.AddListener(TogglePanelVisibility);
    }

    
    public void TogglePanelVisibility()
    {
        
        panel.SetActive(!panel.activeSelf);
    }
}
