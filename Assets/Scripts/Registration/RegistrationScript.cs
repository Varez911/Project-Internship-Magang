using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RegistrationScript : MonoBehaviour
{
    [Header("Input Registrasi")]
    public TMP_InputField namaLengkap;
    public TMP_InputField alamat;
    public TMP_InputField noHandphone;
    public TMP_InputField email;

    [Header("Alert")] 
    public GameObject alert;

    private List<string> listMessages = new List<string>();
    public void checkValidation()
    {
        listMessages.Clear();
        
        if (String.IsNullOrEmpty(namaLengkap.text))
        {
            listMessages.Add("Nama Lengkap");
        }
        if (String.IsNullOrEmpty(alamat.text))
        {
            listMessages.Add("Alamat");
        }
        if (String.IsNullOrEmpty(noHandphone.text))
        {
            listMessages.Add("No Handphone");
        }
        if (String.IsNullOrEmpty(email.text))
        {
            listMessages.Add("Email");                                       
        }

        if (listMessages.Count > 0)
        {
            ShowAlert("Registrasi Gagal", _message: ConstructMessage());
        }
        else
        {
            ShowAlert("Registrasi Berhasil", "Data anda telah di simpan!");
        }
    }

    public void CloseAlert()
    {
        alert.SetActive(false);
    }
    
    private void ShowAlert(string _status, string _message)
    {
        alert.SetActive(true);

        alert.transform.Find("Alert").transform.Find("Status").GetComponent<TMP_Text>().text = _status;
        alert.transform.Find("Alert").transform.Find("Detail").GetComponent<TMP_Text>().text = _message;
    }

    private string ConstructMessage()
    {
        string newMessage = "";
        if (listMessages.Count > 1)
        {
            string lastMessage = listMessages.Last();
            foreach (string message in listMessages)
            {
                if (message.Equals(lastMessage))
                {
                    newMessage += "dan " + message;
                }
                else
                {
                    newMessage += message + ", ";
                }
            }
        }
        else
        {
            newMessage += listMessages.Last();
        }
        newMessage += " tidak boleh kosong!";

        return newMessage;
    }
}
