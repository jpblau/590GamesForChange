using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject middleBarPopUp;
    public GameObject popUpEmail;
    public GameObject sampleRes1;
    public GameObject sampleRes2;
    public GameObject sampleRes3;

    public GameObject open;

    private EmailManager EMM;
    private int closedEmailX;
    private int[] closedEmailYs;

    private Vector3 OPENEMAILLOCATION_OPEN = new Vector3(500, 730, 0);
    private Vector3 OPENEMAILLOCATION_CLOSED = new Vector3(-1463, 185, 0);


    private void Start()
    {
        EMM = GameObject.FindGameObjectWithTag("EmailManager").GetComponent<EmailManager>();
        closedEmailX = 43;
        //closedEmailYs = [0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280, 300];
    }


    public void RefreshInbox()
    {
        for (int i = EMM.listOfInboxEmails.Count - 1; i >= 0; i--)
        {
            EMM.listOfInboxEmails[i].GetComponent<Transform>().position = new Vector3(700, 848 + (-70 * i), i);
            
        }
    }

    public void ToggleInboxVisibility()
    {
        Debug.Log("Made it here");
        for (int i = EMM.listOfInboxEmails.Count - 1; i >= 0; i--)
        {
            Debug.Log("Toggling to: " + EMM.listOfInboxEmails[i].active);
            EMM.listOfInboxEmails[i].SetActive(!EMM.listOfInboxEmails[i].active); 
        }
    }





    public void ToggleMiddlePopUp()
    {
        middleBarPopUp.SetActive(!middleBarPopUp.active);
    }
    

    /// <summary>
    /// Populate all the fields in 
    /// </summary>
    /// <param name="email"></param>
    public void PopulateSampleEmail(Email email)
    { 
        popUpEmail.GetComponent<SampleEmailOpen>().PopulateFields(email.message, email.from, email.recipients, email.subject, email.dateAndTime);

        GameObject response = null;
        // then populate any responses
        for (int i = 0; i < email.responses.Count; i++)
        {
            switch (i)
            {
                case 0:
                    response = sampleRes1;
                    break;
                case 1:
                    response = sampleRes2;
                    break;
                case 2:
                    response = sampleRes3;
                    break;
            }

            //response.GetComponent<SampleResponse>().PopulateFields(email.responses[i].message, email.responses[i].subject);
        }
    }

    /// <summary>
    /// Button numbers go as follows: Inbox=0, Trash=1, Sent=2
    /// </summary>
    /// <param name="buttonNumber"></param>
    public void LeftBarButtonClicked(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 0:
                //DisplayEmails(EMM.listOfInboxEmails);
                break;
            case 1:
                DisplayEmails(EMM.listOfTrashEmails);
                break;
            case 2:
                DisplayEmails(EMM.listOfSentEmails);
                break;
        }
    }

    /// <summary>
    /// Display emails in the middle column
    /// </summary>
    /// <param name="listOfEmails"></param>
    public void DisplayEmails(List<emailPrefab> listOfEmails)
    {
        // First, close any pop-ups
        if (middleBarPopUp.active)
        {
            ToggleMiddlePopUp();
        }

        // Then, populate the rest of the bar with closed emails
        for (int i = 0; i < listOfEmails.Count; i++)
        {
            // Do we instantiate here, or loop through a list of already created emails?
        }
    }

    public void MoveOpenEmailToLocation()
    {
        open.transform.position = OPENEMAILLOCATION_OPEN;
    }

    public void MoveOpenEmailOutOfLocation()
    {
        open.transform.position = OPENEMAILLOCATION_CLOSED;
    }

    /// <summary>
    /// Set the user's potential responses
    /// </summary>
    /// <param name="responses"></param>
    public void setResponses(List<string> responses)
    {
        Debug.Log("setting responses " + responses.Count);
        sampleRes1.SetActive(false);
        sampleRes2.SetActive(false);
        sampleRes3.SetActive(false);
        if (responses.Count >= 1)
        { 
            sampleRes1.SetActive(true);
            sampleRes1.GetComponent<Text>().text = responses[0];
        }
        if (responses.Count >= 2)
        {
            sampleRes2.SetActive(true);
            sampleRes2.GetComponent<Text>().text = responses[1];
        }
        if (responses.Count >= 3)
        {
            sampleRes3.SetActive(true);
            sampleRes3.GetComponent<Text>().text = responses[2];
        }
    }
}
