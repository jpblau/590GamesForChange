using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// This script handles the creation of new emails, based on what is stored in the json/excel file
/// </summary>
public class EmailManager : MonoBehaviour {

    public GameObject sampleEmail;
    public GameObject middlePopUp;
    public GameObject UIM;
    public GameObject MiddleBar;

    public List<GameObject> listOfInboxEmails;
    public List<emailPrefab> listOfTrashEmails;
    public List<emailPrefab> listOfSentEmails;


    // Complete email lists
    public List<Email> listOfBobbyEmails;


    // Whenever something is added to one of these lists, it needs to be removed from the list of GameObject UI emails, and moved to the appropriate list

	// Use this for initialization
	void Start () {
        listOfBobbyEmails = new List<Email>();

        createEmails();
        sendToInbox();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // actually run through all of our data, and create emails based on all of it. 
    private void createEmails()
    {
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        using (var reader = new StreamReader(@"D:\Yr3Sem1\GamesForChange\FrancineEmailsTab.tsv"))
        {
            string line;
            while ((line=reader.ReadLine()) != null) //!reaader.EndOfStream
            {
                var values = line.Split('\t');
                Debug.Log(values[0]);
                // If we encounter the word "Subject" or "X" we just need to move to the next line
                if (values[0].Equals("Subject") || values[1].Equals(""))
                {
                    continue;
                }

                // make the initial large e-mail
                Email newEmail = new Email();
                newEmail.from = values[0];
                newEmail.subject = values[1];
                newEmail.message = values[2];

                if (values.Length >= 5)
                {
                    newEmail.AddResponse(values[4]);
                }
                if (values.Length >= 7)
                {
                    newEmail.AddResponse(values[6]);
                }
                if (values.Length >= 9)
                {
                    newEmail.AddResponse(values[8]);
                }

                listOfBobbyEmails.Add(newEmail);
                GenerateEmailGO(newEmail);
            }

            reader.Close();
        }
        Debug.Log(listOfBobbyEmails.Count);
    }

    private void GenerateEmailGO(Email email)
    {
        // Create our new email Game Object and place it in the scene at the proper location
        GameObject newInboxMessage = GameObject.Instantiate<GameObject>(sampleEmail, new Vector3(0, 0, 0), Quaternion.identity);
        newInboxMessage.transform.parent = MiddleBar.transform;
        newInboxMessage.GetComponent<emailPrefab>().SetEmail(email);
        listOfInboxEmails.Add(newInboxMessage);

        // give the UIManager a notice that something has changed in the inbox?
        UIM.GetComponent<UIManager>().RefreshInbox();

        // Make sure to have the emailGO set it's values
    }

    private void sendToInbox()
    {
        //GameObject newInboxMessage = GameObject.Instantiate<emailPrefab>(listOfInboxEmails[i], new Vector3(0, 0, 0), Quaternion.identity);
        //newInboxMessage.GetComponent<emailPrefab>().SetEmail(listOfBobbyEmails[0]);
        //listOfInboxEmails.Add(newInboxMessage);

        //for (int i=0; i < listOfInboxEmails.Count; i++)
        //{
            //GameObject.Instantiate<emailPrefab>(listOfInboxEmails[i], new Vector3(0, 0, 0), Quaternion.identity);
        //}
        
    }
}
