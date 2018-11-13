using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleEmailOpen : MonoBehaviour {

    public GameObject messageGO;
    public GameObject fromGO;
    public GameObject recipientsGO;
    public GameObject subjectGO;
    public GameObject sentTimeGO;

    private Text message;
    private Text from;
    private Text recipients;
    private Text subject;
    private Text sentTime;


	// Use this for initialization
	void Start () {
        message = messageGO.GetComponent<Text>();
        from = fromGO.GetComponent<Text>();
        recipients = recipientsGO.GetComponent<Text>();
        subject = subjectGO.GetComponent<Text>();
        sentTime = sentTimeGO.GetComponent<Text>();
	}
	

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="from"></param>
    /// <param name="recipients"></param>
    /// <param name="subject"></param>
    /// <param name="sentTime"></param>
	public void PopulateFields(string message, string from, string[] recipients, string subject, DateAndTime sentTime)
    {
        this.message.text = message;
        this.from.text = from;

        this.recipients.text = "";
        for (int i = 0; i < recipients.Length; i++)
        {
            this.recipients.text += (recipients[i] + " ");
        }

        this.subject.text = subject;
        this.sentTime.text = sentTime.ToString();
    }
}
