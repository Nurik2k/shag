using Azure.Core;
using Finaldb.Data;
using Finaldb.Models;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using Finaldb;

namespace FinalDb
{
    internal class Program
    {
        const string ConnectionString = "Server=NURIK;Database=ChatDb;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MainMenu();
        }

        
        
    }  
}

