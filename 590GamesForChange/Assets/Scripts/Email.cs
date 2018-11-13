using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email{

    public string subject;
    public string from;
    public string[] recipients;
    public string message;
    public DateAndTime dateAndTime;
    public List<string> responses;

    public Email()
    {
        this.responses = new List<string>();
    }

    public Email(string from, string subject, string[] recipients, string message, DateAndTime dateAndTime)
    {
        this.from = from;
        this.subject = subject;
        this.recipients = recipients;
        this.message = message;
        this.dateAndTime = dateAndTime;
    }

    public void AddResponse(string response)
    {
        this.responses.Add(response);
    }



    
}
