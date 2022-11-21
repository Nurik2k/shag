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
    public class Program
    {
        ConnectServer connect = new ConnectServer();
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MainMenu();
            
        }

        
        
    }  
}

