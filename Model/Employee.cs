﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RSCProgerss.Model
{
    public abstract class Employee
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }


        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string? firstName;

        public string? FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string? secondName;

        public string? SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        private DateTime? experiance;

        public DateTime? Experiance
        {
            get { return experiance; }
            set { experiance = value; }
        }
        private byte[]? photo;

        public byte[]? Photo
        {
            get { return photo; }
            set { photo = value; }
        }





    }
}
