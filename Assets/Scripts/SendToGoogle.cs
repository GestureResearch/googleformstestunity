using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{

    public GameObject dedicatedto;
    public GameObject songname;
    public GameObject qr;
    public GameObject phone;
    public GameObject whatsappurl;
    public GameObject email;

    private string dedicatedtotext;
    private string songnametext;
    private string qrtext;
    private string phonetext;
    private string whatsappurltext;
    private string emailotext;


    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/4/d/e/1FAIpQLSdkUUvGvFhHmyWBf0GVEwF5W2SYbH4Jgccwpf8l4HLsc_k8sw/formResponse";

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.965759182", dedicatedtotext);
        form.AddField("entry.503931887", songnametext);
        form.AddField("entry.1504303801", qrtext);
        form.AddField("entry.41641842", phonetext);
        form.AddField("entry.1869660751", whatsappurltext);
        form.AddField("entry.2121017376", emailotext);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    public void Send() 
    {
        dedicatedtotext = dedicatedto.GetComponent<InputField>().text;
        songnametext = songname.GetComponent<InputField>().text;
        qrtext = qr.GetComponent<InputField>().text;
        phonetext = phone.GetComponent<InputField>().text;
        whatsappurltext = whatsappurl.GetComponent<InputField>().text;
        emailotext = email.GetComponent<InputField>().text;
        StartCoroutine(Post());
    }
}