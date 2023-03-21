﻿using System.Collections.Generic;
using System.ComponentModel.Design;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels;

public class Entity
{
    public string EntityIdentifierCode { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string Address4 { get; set; }
    public string City { get; set; }
    public string ProvinceState { get; set; }
    public string Country { get; set; }
    public string PostalZip { get; set; }
    public string IdentificationCodeQualifier { get; set; }
    public string IdentificationCode { get; set; }

    public List<Contact> Contacts { get; set; } = new();

    public void AddContact(G61_Contact g61)
    {
        this.Contacts.Add(Contact.FromG61(g61));
    }

    public void Add(N3_PartyLocation n3)
    {
        if (Address1 == null)
        {
            Address1 = n3.AddressInformation;
            Address2 = n3.AddressInformation2;
        }
        else
        {
            Address3 = n3.AddressInformation;
            Address4 = n3.AddressInformation2;
        }
            
    }
}