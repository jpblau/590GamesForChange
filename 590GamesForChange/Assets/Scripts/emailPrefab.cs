using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emailPrefab : MonoBehaviour { 

    private Email email;
    private UIManager UIM;

    public GameObject closedSubjectText;
    public GameObject closedFrom;
    public GameObject closedSentTime;

    
    public GameObject open;
    public Text openMessage;
    public Text openFrom;

    // Use this for initialization
    void Start () {
        UIM = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        open = GameObject.FindGameObjectWithTag("EmailOpen");
        openMessage = GameObject.FindGameObjectWithTag("openMessage").GetComponent<Text>();
        openFrom = GameObject.FindGameObjectWithTag("openFrom").GetComponent<Text>();
        // When we read in that we need another email created, we will create an emailPrefab, and assign one of emailManager's Email's (in the email list) to be 
        // this prefab's email
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEmail(Email email)
    {
        this.email = email;

        // set all the values
        closedSubjectText.GetComponent<Text>().text = email.subject;
        closedFrom.GetComponent<Text>().text = email.from;
        closedSentTime.GetComponent<Text>().text = "December 15, 2018";
    }

    public void SampleEmailClosedClicked()
    {
        UIM.ToggleMiddlePopUp();
        UIM.PopulateSampleEmail(email);
    }

    public void ToggleInboxVisibilityP()
    {
        UIM.ToggleInboxVisibility();
    }

    public void PopulatePopUpEmailData()
    {
        // Move the email to a location
        UIM.MoveOpenEmailToLocation();

        // set all the open email's values
        openMessage.text = email.message;
        openFrom.text = email.from;
        UIM.setResponses(email.responses);


        open.SetActive(true);
    }
}
