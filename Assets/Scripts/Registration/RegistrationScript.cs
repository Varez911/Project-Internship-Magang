using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityTemplateProjects.Class;

public class RegistrationScript : MonoBehaviour
{
    [Header("Input Registrasi")]
    public TMP_InputField namaLengkap;
    public TMP_InputField alamat;
    public TMP_InputField noHandphone;
    public TMP_InputField email;

    [Header("Button")] public GameObject saveButton;
    public GameObject updateButton;
    
    [Header("Alert")] 
    public GameObject alert;

    private List<string> listMessages = new List<string>();

    private void Start()
    {
        namaLengkap.text = PlayerPrefs.GetString("NamaLengkap");
        alamat.text = PlayerPrefs.GetString("Alamat");
        noHandphone.text = PlayerPrefs.GetString("NoHp");
        email.text = PlayerPrefs.GetString("Email");
        if (PlayerPrefs.HasKey("NamaLengkap"))
        {
            ShowUpdateButton();
        }
    }

    public void checkValidation()
    {
        listMessages.Clear();
        string _alertMessage = "";
        
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
        else if (noHandphone.text.Length < 5 || !noHandphone.text.StartsWith("0"))
        {
            _alertMessage += "No Handphone tidak valid. ";
        }
        
        if (String.IsNullOrEmpty(email.text))
        {
            listMessages.Add("Email");                                       
        }
        else if (!email.text.Contains("@"))
        {
            _alertMessage += "Email tidak valid. ";
        }

        if (listMessages.Count > 0)
        {
            // ShowAlert("Registrasi Gagal", _message: ConstructMessage());
            _alertMessage += ConstructMessage();
        }

        if (String.IsNullOrEmpty(_alertMessage))
        {
            SaveDataPlayer(); 
        }
        else
        {
            ShowAlert("Registrasi Gagal", _message: _alertMessage);

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

    private void SaveDataPlayer()
    {
        ShowAlert("Registrasi Berhasil", "Data anda telah di simpan!");
        PlayerPrefs.SetString("NamaLengkap", namaLengkap.text);
        PlayerPrefs.SetString("Alamat", alamat.text);
        PlayerPrefs.SetString("NoHp", noHandphone.text);
        PlayerPrefs.SetString("Email", email.text);
        PlayerPrefs.Save();
        ShowUpdateButton();
    }
    
    private void ShowUpdateButton()
    {
        saveButton.SetActive(false);
        updateButton.SetActive(true);
    }
}
