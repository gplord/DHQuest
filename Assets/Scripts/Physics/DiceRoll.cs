using UnityEngine;
using System.Collections;

public class DiceRoll : MonoBehaviour {
    
    // Original gravity is -9.81
    
    public float force;    
    public int rollValue;    
    private Vector3 startPoint = new Vector3(1,3,-8);
    
    public DiceController controller;
    
    void Awake() {
        transform.rotation = Random.rotation;
    }

	// Use this for initialization
	void Start () {
        StartCoroutine("Roll");
	}
    
    // http://answers.unity3d.com/questions/8524/dice-animation-and-face-determination.html
    // Jaap Kreijkamp -- values moved around to fit existing die model orientation, gpl
    int CalcSideUp() {
        float dotFwd = Vector3.Dot(transform.forward, Vector3.up);
        if (dotFwd > 0.99f) return 6;
        if (dotFwd < -0.99f) return 1;
        float dotRight = Vector3.Dot(transform.right, Vector3.up);
        if (dotRight > 0.99f) return 2;
        if (dotRight < -0.99f) return 5;
        float dotUp = Vector3.Dot(transform.up, Vector3.up);
        if (dotUp > 0.99f) return 3;
        if (dotUp < -0.99f) return 4;
        return 0;
    }
    void Update() {
    }
    
    void EndRoll() {
        if (rollValue > 0) {
            controller.ReceiveRollValue(rollValue);
        } else {
            StopCoroutine("Roll");
            transform.rotation = Random.rotation;
            transform.position = startPoint;
            StartCoroutine("Roll");                
        }
    }
    
    IEnumerator Roll() {
	    GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Impulse);     
	    GetComponent<Rigidbody>().AddForce(Vector3.right * force / 2, ForceMode.Impulse);       
	    GetComponent<Rigidbody>().AddTorque(Vector3.forward * 500, ForceMode.Force);
	    GetComponent<Rigidbody>().AddTorque(Vector3.right * 50, ForceMode.Impulse);
        for (;;) {
            if (!GetComponent<Rigidbody>().IsSleeping()) {
                yield return new WaitForSeconds(0.1f);
            } else {
                rollValue = CalcSideUp();
                if (rollValue > 0) {
                    // Debug.Log(gameObject.name + " rolled a " + rollValue + " | " + Time.timeSinceLevelLoad);
                } else { 
                    // Debug.LogError("<color=red>"+gameObject.name + " rolled a " + rollValue + "</color>");
                }
                EndRoll();
                yield break;
            }
        }
    }
    
}
