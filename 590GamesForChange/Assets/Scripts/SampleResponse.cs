using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleResponse : MonoBehaviour {

    public GameObject messageGO;
    public GameObject subjectGO;

    private Text message;
    private Text subject;

    // Use this for initialization
    void Start()
    {
        message = messageGO.GetComponent<Text>();
        subject = subjectGO.GetComponent<Text>();
    }

    public void PopulateFields(string message, string subject)
    {
        this.message.text = message;

        this.subject.text = subject;
    }
}
