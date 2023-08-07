using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public CanvasElementFader canvasElementFader;
    

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    private void OnButtonClicked()
    {
        
        canvasElementFader.FadeElements();
        
    }

}