using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingUIScript : MonoBehaviour
{
    public BuildingData BuildingData;
    [SerializeField] TMP_Text NameTextField;
    [SerializeField] TMP_Text AddressTextField;

    public string Name {  get; private set; }
    public string Address { get; private set; }
    public int BuildingID { get; private set; }

    private void Start()
    {
        Name = BuildingData.Name;
        BuildingID = BuildingData.BuildingID;
        Address = CompileAddress();
        SetUIInfo();
    }

    void SetUIInfo()
    {
        NameTextField.text = Name;
        AddressTextField.text = Address;
    }

    string CompileAddress()
    {
        string appartmentnumber = BuildingData.ApartmentNmber;
        string address = "";

        address += $"{BuildingData.StreetName} {BuildingData.BuildingNumber}";
        if (appartmentnumber != null && appartmentnumber != "")
            address += $"/{appartmentnumber} ";
        address += $",\n{BuildingData.PostalCode} {BuildingData.CityName}";
        return address;
    }
}
