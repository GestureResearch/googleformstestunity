using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{

    public GameObject email;
    public GameObject phone;
    public GameObject photoid;
    public GameObject whatsapplink;

    private string emailtext;
    private string phonetext;
    private string photoidtext;
    private string whatsapplinktext;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/4/d/e/1FAIpQLSd8mRFdMQ6ZbfqllD14cclt90kljkIt8nEH_lC3rolwlCE_zg/formResponse";

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.198461343", emailtext);
        form.AddField("entry.72452270", phonetext);
        form.AddField("entry.334833718", photoidtext);
        form.AddField("entry.1082840494", whatsapplinktext);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    public void Send() 
    {
        emailtext = email.GetComponent<InputField>().text;
        phonetext = phone.GetComponent<InputField>().text;
        photoidtext = photoid.GetComponent<InputField>().text;
        whatsapplinktext = whatsapplink.GetComponent<InputField>().text;
        StartCoroutine(Post());
    }
}