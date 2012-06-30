using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace IISExpressManager
{
    public partial class Form1 : Form
    {
        private readonly IISExpressConfiguration _iisExpressConfig;
        private bool _exitFromNotification;
        internal bool ExitFromNotification { 
            get { return _exitFromNotification; }
            set { _exitFromNotification = value; }
        }
        private List<IISSites> _iisSites;
        private bool _isNotificationShown;

        public Form1()
        {
            InitializeComponent();
            
            _iisExpressConfig = new IISExpressConfiguration();
            SetStatusLabels();
            ListViewPropertySetter();
            ListViewCompleteReloadWithAssigningPID();
            textBox1.Text = "Double click on any item to start it!";
        }

        #region ListViewMethods

        private void ListViewInsertItems()
        {
            foreach (IISSites iisSite in _iisSites)
            {
                var item = new ListViewItem(iisSite.Id);
                item.SubItems.Add(iisSite.SiteName);
                item.SubItems.Add(iisSite.Status);
                item.SubItems.Add(iisSite.ProcessId);
                item.SubItems.Add(iisSite.Port);
                listView1.Items.Add(item);
                listView1.Items[listView1.Items.Count-1].UseItemStyleForSubItems = false;
                if(iisSite.Status.Equals("Started"))
                {
                    item.SubItems[2].ForeColor= Color.Green;
                }else
                {
                    item.SubItems[2].ForeColor = Color.Red;
                }
                //Console.WriteLine(/*String.Format("{0}, {1}, {2}, {3}"), */
                  //  item.SubItems[0].Text+item.SubItems[1].Text+ item.SubItems[2].Text+ item.SubItems[3].Text);
            }
        }

        private void ListViewPropertySetter()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
        }

        private void ListViewReInsertItems()
        {
            listView1.Items.Clear();
            ListViewInsertItems();
        }

        private int ListViewFindSelectedItem()
        {
            int selected = -1;
            foreach (int index in listView1.SelectedIndices)
            {
                selected = index;
            }
            return selected;
        }

        private void ListViewDoubleClickItem(object sender, EventArgs e)
        {
            int selected = ListViewFindSelectedItem();
            if (selected > -1)
            {
                if (_iisSites[selected].Status.Equals("Started"))
                {
                    CheckAttemptToStopSelectedApp();
                }
                else if (_iisSites[selected].Status.Equals("Stopped"))
                {
                    CheckAttemptToStartSelectedApp();
                }
            }
        }

        private void ListViewCompleteReloadMappedWithWebsiteList()
        {
            if (_iisExpressConfig.CheckIISExpressConfigExistence())
            {
                //_iisSites = IISConfigReader.ReadXmlFromConfig(_iisExpressConfig);
                ListViewPropertySetter();
                ListViewReInsertItems();
                textBox1.Text = "";
            }
        }

        private void ListViewCompleteReloadWithAssigningPID()
        {
            if (_iisExpressConfig.CheckIISExpressConfigExistence())
            {
                _iisSites = IISConfigReader.ReadXmlFromConfig(_iisExpressConfig);
                _iisSites = IISProcessManager.AssignProcessIds(_iisSites);
                ListViewReInsertItems();
                textBox1.Text = "";
            }
        }

        #endregion ListViewMethods

        private void SetStatusLabels()
        {
            SetStatusForIISExpressConfigFileExistence();
            SetStatusForIISExpressExistence();
        }

        #region Set Statuses
        private void SetStatusForIISExpressExistence()
        {
            if (_iisExpressConfig.CheckIISExpressExistence())
            {
                lblIISStatus.Text = "Found!";
                lblIISStatus.ForeColor = Color.Teal;
            }
            else
            {
                //DisableAllButtonsWhenIISError();
                lblIISStatus.ForeColor = Color.Red;
                textBox1.Text = "Please Install IIS Express";
            }
        }

        private void SetStatusForIISExpressConfigFileExistence()
        {
            if (_iisExpressConfig.CheckIISExpressConfigExistence())
            {
                lblIISConfigStatus.Text = "Found!";
                lblIISConfigStatus.ForeColor = Color.Teal;
            }
            else
            {
                //DisableAllButtonsWhenIISError();
                lblIISConfigStatus.ForeColor = Color.Red;
                textBox1.Text = "Please Install IIS Express";
            }
        }

        private void UpdateBoxStatus(int selected)
        {
            textBox1.Text = "Site Name: " + _iisSites[selected].SiteName;
            textBox1.Text += "\r\nStatus: " + _iisSites[selected].Status;
        }
        #endregion

        private bool IsAnswerYes(DialogResult dialogResult)
        {
            if (dialogResult == DialogResult.Yes)
                return true;
            return false;
        }

        private void FormClosingEvent(object sender, FormClosingEventArgs e)
        {
            if (_exitFromNotification)
            {
                e.Cancel = false;
                Application.Exit();
                return;
            }
            WindowState = FormWindowState.Minimized;
            Hide();
            e.Cancel = true;
            if (!_isNotificationShown)
            {
                notifyIcon1.BalloonTipTitle = "IISEM One time Notice";
                notifyIcon1.BalloonTipText = "Your IIS Express Manager is now minimized here.";
                notifyIcon1.ShowBalloonTip(800);
                _isNotificationShown = true;
            }
        }

        #region Notification Icon In System Tray

        private void NotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
        {
            _exitFromNotification = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void NotificationIconContextItem1Click(object sender, EventArgs e)
        {
            _exitFromNotification = true;
            Application.Exit();
        }

        #endregion Notification Icon In System Tray

        #region ApplicationManage

        private void StartSelectedApplication(int selected)
        {
            /*            int processId = */
            IISProcessManager.ExecuteProcess(
                _iisExpressConfig.IISExpressAddress, "/site:\""
                + _iisSites[selected].SiteName + "\"");
            /*_iisSites[selected].ProcessId = processId.ToString();*/
            _iisSites[selected].Status = "Started";
            ListViewCompleteReloadWithAssigningPID();
            notifyIcon1.ShowBalloonTip(700,
                                        "Application hosted",
                                        "Your application " +
                                        _iisSites[selected].SiteName +
                                        " is hosted", ToolTipIcon.Info);
        }

        private void StopSelectedApplication(int selected)
        {
            IISProcessManager.ExecuteProcess("taskkill", "/pid "
                + _iisSites[selected].ProcessId);
            /*IISProcessManager.RemoveProcessId(Int32.Parse(_iisSites[selected].ProcessId));*/
            _iisSites[selected].Status = "Stopped";
            _iisSites[selected].ProcessId = "Not Found";
            ListViewCompleteReloadMappedWithWebsiteList();
            notifyIcon1.ShowBalloonTip(700,
                                       "Application Stopped",
                                       "Your application " +
                                       _iisSites[selected].SiteName +
                                       " is now stopped.", ToolTipIcon.Info);
        }

        private void StopAllIISHostedApplications()
        {
            IISProcessManager.KillAllhostedApplications();
            ListViewCompleteReloadWithAssigningPID();
        }

        #endregion ApplicationManage

        private void CheckAttemptToStopSelectedApp()
        {
            int selected = ListViewFindSelectedItem();
            if (selected == -1) return;

            if (_iisSites[selected].Status.Equals("Stopped"))
            {
                MessageBox.Show(
                    "You can not stop an already stopped application.",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (selected >= 0)
            {
                StopSelectedApplication(selected);
                UpdateBoxStatus(selected);
            }
        }

        private void CheckAttemptToStartSelectedApp()
        {
            int selected = ListViewFindSelectedItem();
            if (selected == -1) return;

            if (_iisSites[selected].Status.Equals("Started"))
            {
                MessageBox.Show(
                    "You can not start an already started application",
                    "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (selected >= 0)
            {
                StartSelectedApplication(selected);
                UpdateBoxStatus(selected);
                /*ListViewReInsertItems();*/
            }
        }

        #region MenuItemActions
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +
                            "1. Double Click to Start/Stop any Application in the list!"
                            + "\n2. Press F5 to sync it with IIS Express",
                            "IISEM Help", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
                IsAnswerYes(
                    MessageBox.Show(
                        "Hi there!\nIISEM is a open source freeware initiated by Amit from Bangladesh." +
                        "\nIt is available in CodePlex.\nWant to check out the codeplex homepage?",
                        "About", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                const string target = "http://iisem.codeplex.com/";
                Process.Start(target);
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
              IsAnswerYes(
                  MessageBox.Show(
                      "Clicking this will:\n" +
                      "\n1. Stop all applications in IISExpress" +
                      "\n2. Refresh The list." +
                      "\n\nAre you sure you want to do this?",
                      "Reset IIS Express Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                StopAllIISHostedApplications();
                ListViewCompleteReloadMappedWithWebsiteList();
            }
        }

        private void stopAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAllIISHostedApplications();
            ListViewCompleteReloadMappedWithWebsiteList();
            textBox1.Text = "Stopped all applications.";
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewCompleteReloadWithAssigningPID();
        }

        private void runSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SayOops();
        }
        
        private void editSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SayOops();
        }

        #endregion


        private static void SayOops()
        {
            MessageBox.Show("Looks like it is not implemented yet.",
                            "Oops", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        
    }
}