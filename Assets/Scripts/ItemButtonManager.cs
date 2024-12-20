using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButtonManager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;
    private ARInteractionManager interactionManager;

    public string ItemName
    {
        set { itemName = value; }
    }
    public string ItemDescription
    {
        set { itemDescription = value; }
    }
    public Sprite ItemImage
    {
        set { itemImage = value; }
    }
    public GameObject Item3DModel
    {
        set { item3DModel = value; }
    }

    // 
    void Start()
    {
        // 
        var nameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        var imageComponent = transform.GetChild(1).GetComponent<RawImage>();
        var descriptionText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        if (nameText != null) nameText.text = itemName;
        if (imageComponent != null) imageComponent.texture = itemImage?.texture;
        if (descriptionText != null) descriptionText.text = itemDescription;

        var button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                GameManager.instance?.ARPosition();
                Create3DModel();
            });
        }

        interactionManager = FindObjectOfType<ARInteractionManager>();
    }

    private void Create3DModel()
    {
        if (item3DModel != null)
        {
            interactionManager.Item3DModel = Instantiate(item3DModel);
        }
    }
}
