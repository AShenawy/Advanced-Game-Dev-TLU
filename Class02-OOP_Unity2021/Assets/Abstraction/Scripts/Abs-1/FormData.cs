using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormData : MonoBehaviour
{
    public Person applicant;

    public string fullName;
    public int age;

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
        fullName = applicant.GetFullName();
        age = applicant.GetAge();
    }

    public void ShowFormData()
    {
        print($"The person's full name is: {fullName}");
        print($"{fullName}'s age is: {age}");
    }
}
