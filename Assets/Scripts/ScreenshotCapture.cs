using System.Collections;
using UnityEngine;
using UnityEngine.UI;  
using System.IO;

public class ScreenshotCapture : MonoBehaviour
{
    private bool isTakingScreenshot = false;

    
    public Text messageText;

    public void TakeScreenshot()
    {
        if (!isTakingScreenshot)
        {
            StartCoroutine(CaptureScreenshot());
        }
    }

    private IEnumerator CaptureScreenshot()
    {
        isTakingScreenshot = true;
        yield return new WaitForEndOfFrame();

        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();

        
        string screenshotName = $"Screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        NativeGallery.SaveImageToGallery(screenshot, "MyApp Screenshots", screenshotName);
        Debug.Log("Captura de pantalla guardada en la galería");

       
        messageText.text = "Captura guardada en la galería";
        messageText.enabled = true;  

   
        yield return new WaitForSeconds(3);

        
        messageText.enabled = false;

       
        Destroy(screenshot);

        isTakingScreenshot = false;
    }
}
