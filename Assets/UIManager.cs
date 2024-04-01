using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image[] uiImages;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void UpdateUI(List<GameObject> objects)
    {
        for (int i = 0; i < uiImages.Length; i++)
        {
            if (i < objects.Count)
            {
                Sprite objectImage = Resources.Load<Sprite>($"Images/{objects[i].name}");
                uiImages[i].sprite = objectImage;
                uiImages[i].gameObject.SetActive(true);
            }
            else
            {
                uiImages[i].gameObject.SetActive(false);
            }
        }
    }
}
