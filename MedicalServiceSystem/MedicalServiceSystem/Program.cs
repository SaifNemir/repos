﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalServiceSystem
{
    namespace My
    {

        //NOTE: This file is auto-generated; do not modify it directly.  To make changes,
        // or if you encounter build errors in this file, go to the Project Designer
        // (go to Project Properties or double-click the My Project node in
        // Solution Explorer), and make changes on the Application tab.
        //
        public partial class MyApplication : global::Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
        {
            [STAThread]
            static void Main()
            {

                (new MyApplication()).Run(new string[] { });


            }

            [global::System.Diagnostics.DebuggerStepThrough()]
            public MyApplication() : base(global::Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            {



                this.IsSingleInstance = false;
                this.EnableVisualStyles = true;
                this.SaveMySettingsOnExit = true;
                this.ShutdownStyle = global::Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterAllFormsClose;
            }

            [global::System.Diagnostics.DebuggerStepThroughAttribute()]
            protected override void OnCreateMainForm()
            {
                this.MainForm = global::MedicalServiceSystem.SystemSetting.LoginForm.Default;
            }
        }
    }
}
