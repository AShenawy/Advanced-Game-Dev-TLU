using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public Student student;

    public string studentUsername;
    public string studentPassword;
    

    void Start()
    {
        // Encapsulation allows us to move classes around our code as a collection of data
        // Much more convenient than passing a single data type one at a time
        NewStudentSignIn(student);


        // This won't work, because we added a check against empty
        // usernames. Hit Play in Unity to see the console message!
        student.Username = "";
    }

    public void NewStudentSignIn(Student newStudent)
    {
        studentUsername = newStudent.Username;
        studentPassword = newStudent.GetPassword();
    }
}
