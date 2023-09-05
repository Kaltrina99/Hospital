﻿using Hospital.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ContactViewModel() { }
        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Email = model.Email;
            Phone = model.Phone;
            HospitalId = model.HospitalId;

        }
        public Contact ConvertViewModel(ContactViewModel model)
        {

            return new Contact
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                HospitalId = model.HospitalId,
            };
        }
    }
}
