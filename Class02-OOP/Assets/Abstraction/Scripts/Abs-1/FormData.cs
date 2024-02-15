using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormData : MonoBehaviour
{
    public Person applicant;

    public string applicantName;
    public int applicantAge;

    public Text formText;

    // Start is called before the first frame update
    void Start()
    {
        FillForm();
        ShowFormData();
    }

    // These functions also abstract away their inner workings from the rest of the class!!
    // Start() calls FillForm() but has no idea what it actually does
    public void FillForm()
    {
        applicantName = applicant.GetFullName();
        applicantAge = applicant.GetAge();
    }

    public void ShowFormData()
    {
        formText.text = $"The applicant's full name is:\n" +
                        $"{applicantName}\n\n" +
                        $"Their age is: {applicantAge}";
    }
}
