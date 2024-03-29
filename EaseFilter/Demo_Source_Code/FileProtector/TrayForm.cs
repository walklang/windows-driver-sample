﻿///////////////////////////////////////////////////////////////////////////////
//
//    (C) Copyright 2012 EaseFilter Technologies Inc.
//    All Rights Reserved
//
//    This software is part of a licensed software product and may
//    only be used or copied in accordance with the terms of that license.
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using EaseFilter.CommonObjects;

namespace FileProtector
{
    public partial class TrayForm: Form
    {
        ProtectorForm protectorForm = new ProtectorForm();

        public TrayForm()
        {
            Utils.CopyOSPlatformDependentFiles();
            InitializeComponent();

            EventManager.ShowNotificationDlgt showNotificationDlgt = new EventManager.ShowNotificationDlgt(ShowNotification);
            EventManager.showNotificationDlgt = showNotificationDlgt;
        }

        private void TrayForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.notifyIcon.Visible = true;
            protectorForm.ShowDialog();
            Utils.ToDebugger("ShowDialog");
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!protectorForm.Visible)
            {
                protectorForm.StartPosition = FormStartPosition.CenterScreen;
                protectorForm.ShowDialog();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm();
            settingForm.StartPosition = FormStartPosition.CenterScreen;
            settingForm.ShowDialog();
        }

        private void helpTopicsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.easefilter.com/Forums_Files/FileMonitor.htm");
        }

        private void reportAProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.easefilter.com/ReportIssue.htm");
        }

    
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GlobalConfig.Stop();
            protectorForm.Close();

            Application.Exit();
        }

        private void sdkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.easefilter.com/info/easefilter_manual.pdf");
        }

     
        private void openProtectorSourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            string AssemblyPath = Path.Combine(Path.GetDirectoryName(assembly.Location), "Demo");
            System.Diagnostics.Process.Start("explorer.exe", AssemblyPath);
        }

        private void uninstallDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterAPI.UnInstallDriver();
        }

        private void ShowNotification(string message, bool isErrorMessage)
        {
            if (!GlobalConfig.EnableNotification)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new EventManager.ShowNotificationDlgt(ShowNotification), new Object[] { message, isErrorMessage });
            }
            else
            {
                popupNotifier1.ShowInternalImage(isErrorMessage, !isErrorMessage);
                popupNotifier1.TitleText = "";
                popupNotifier1.ContentText = message;
                popupNotifier1.Popup();
            }

        }
    
    }
}
