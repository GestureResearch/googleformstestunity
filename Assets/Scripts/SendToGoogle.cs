using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{

    public GameObject storename;
    public Transform location;
    public Transform status;
    public Transform fixturetype;
    public GameObject notes;

    private string storenametext;
    private string locationtext;
    private string statustext;
    private string fixturetypetext;
    private string notestext;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfpormSRr0aQScVTeLxHtzCgXj6Lpo3Z2jN1ClEjDFiinhXwA/formResponse";

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.45538906", storenametext);
        form.AddField("entry.652813880", locationtext);
        form.AddField("entry.1774739367", statustext);
        form.AddField("entry.1809101848", fixturetypetext);
        form.AddField("entry.1920164014", notestext);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    public void Send() 
    {
        storenametext = storename.GetComponent<InputField>().text;
        locationtext = location.GetComponent<Dropdown>().options[location.GetComponent<Dropdown>().value].text;
        statustext = status.GetComponent<Dropdown>().options[status.GetComponent<Dropdown>().value].text;
        fixturetypetext = fixturetype.GetComponent<Dropdown>().options[fixturetype.GetComponent<Dropdown>().value].text;
        notestext = notes.GetComponent<InputField>().text;
        StartCoroutine(Post());
    }
}