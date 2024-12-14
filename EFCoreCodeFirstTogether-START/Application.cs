using EFCoreCodeFirstTogether_START.Controllers;
using EFCoreCodeFirstTogether_START.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether_START
{
    public class Application
    {
        public void Run()
        {

            var buildApp = new Build();
            var dbContext = buildApp.BuildApp();

            var userChoise = new MainMenu();

            var userMainMenuChoise= userChoise.DisplayMainMenu();

            switch(userMainMenuChoise)
            {
                case 1:
                    var create = new Create(dbContext);
                    create.RunCreate();
                    break;
                case 2:
                    var read = new Read(dbContext);
                    read.RunRead();
                    break;

            }
           
        }
    }
}
