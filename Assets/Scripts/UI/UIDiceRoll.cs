using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDiceRoll : MonoBehaviour {

    public RectTransform panel;
    
    public RectTransform images;
    public Text count;
    public Text sum;
    public RectTransform overlay;
    
    private int runningTotal = 0;
    
    public void AddNumber (int numValue) {
        
        GameObject dieImage = (GameObject) Instantiate(Resources.Load("Image-Die-" + numValue + "-Plain")) as GameObject;
        dieImage.transform.SetParent(images);
        
        runningTotal += numValue;
        
        sum.text = runningTotal.ToString();
        
    }
    
    public void Sum (int sumValue) {       
                
        sum.text = "<b><color=#00FF00>"+(sumValue.ToString())+"</color></b>";
        
    }
    
    public void Clear() {
        
        runningTotal = 0;
        sum.text = string.Empty;
        
        foreach (Transform child in images.transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in overlay.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
    
    public void Success() {
        GameObject image = (GameObject) Instantiate(Resources.Load("Image-Roll-Success")) as GameObject;
        image.transform.SetParent(overlay);
        image.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
    }    
    public void Failure() {
        GameObject image = (GameObject) Instantiate(Resources.Load("Image-Roll-Failure")) as GameObject;
        image.transform.SetParent(overlay);
        image.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
    }
    
    // IEnumerator ScrollToBottom() {
    //     yield return new WaitForEndOfFrame();        
    //     scroller.normalizedPosition = new Vector2(0,0);
    //     yield break;
    // }

}
