﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class User
    {
        private int id { get; set; }
        private string username;
        private string password;
        public User(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
        public int GetId()
        {
            return id;
        }
        public string GetUername()
        {
            return username;
        }
        public string GetPassword()
        {
            return password;
        }
    }
}
