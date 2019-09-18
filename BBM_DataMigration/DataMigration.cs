using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using BBM_DataMigration;
using System.Runtime.InteropServices;

namespace BBM_LicensceGenerator
{

    public partial class DataMigration : Form
    {
        BackgroundWorker bgWorker;
        SQLHelper objSQL;

        bool isCompleted;
        string MigrationStatus = "";
        String ServerName;
        String DatabaseName;
        String UserID;
        String UsrPasswor;

        [DllImport("user32.dll")]
        public static extern void DisableProcessWindowsGhosting();
        public DataMigration()
        {
            InitializeComponent();

            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
        }



        // On completed do the appropriate task
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //If it was cancelled midway
            if (e.Cancelled)
            {
                lblStatus.Text = "Task Cancelled.";
            }
            else if (e.Error != null)
            {
                lblStatus.Text = "Error while performing background operation.";
            }
            else
            {
                lblStatus.Text = "Task Completed...";
            }
            btnProcess.Enabled = true;
            btnCancel.Enabled = false;
        }



        /// Notification is performed here to the progress bar      
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here you play with the main UI thread
            if (e.ProgressPercentage <= 100)
            {
                PGDataMigration.Value = e.ProgressPercentage;
            }
            if (MigrationStatus == null || MigrationStatus != "")
            {
                if (PGDataMigration.Value > 100)
                {
                    lblStatus.Text = "Processing......" + PGDataMigration.Value.ToString() + "%";
                }
                else
                {
                    lblStatus.Text = "DATA MIGRATED SUCCESSFULLY";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            try
            {
                //for (int i = 1; i <= 90; i++)
                //{
                //    // Wait 100 milliseconds.
                //    Thread.Sleep(1000);
                //    // Report progress.
                //    bgWorker.ReportProgress(i);
                //}
                int n = 150;
                for (int i = 1; i <= n; i++)
                //for (int i = 1; i <= 150; i++)
                {

                    bgWorker.ReportProgress(i);

                    // Wait 100 milliseconds.
                    Thread.Sleep(900);
                    // Report progress.
                    if (isCompleted == true && MigrationStatus == "DATA MIGRATED SUCCESSFULLY")
                    {
                        break;
                    }
                    else if (MigrationStatus != "")
                    {
                        break;

                    }
                    n++;
                }

                //bgWorker.ReportProgress(5);
                //objSQL = new SQLHelper(ServerName, DatabaseName, UserID, UsrPasswor);
                //SqlDataReader objReader;
                //objReader = objSQL.GetReader("SP_DataMigration");

                //bgWorker.ReportProgress(100);

                lblStatus.Text = MigrationStatus;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void frmDataMigration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DisableProcessWindowsGhosting();
                // DatabaseName = "BBM";
                DatabaseName = "AlmaqarPOS";///First check the almaqarpos databse is created or not 
                //DatabaseConnectionChecking();//Created method for to check the datbase connection on 21 july 2014 //Modified on 23Sept2014 By Meena.R

                if (rdoCustom.Checked)
                {
                    if (!Validation())
                        return;
                }
                DatabaseConnectionChecking();
                objSQL = new SQLHelper(ServerName, DatabaseName, UserID, UsrPasswor);
                if (!objSQL.OpenConnection())
                {
                    MigrationStatus = "Connection Failed. Please check Server name and login credential";
                    if (DatabaseName == "AlmaqarPOS")
                    {
                        grpRestoreDB.Visible = true;
                    }
                    btnProcess.Enabled = true;
                    return;
                }
                DatabaseName = "BBM";//Once complete the almaqarpos databse restore connection to check the bbm datbase is created or not 
                DatabaseConnectionChecking();
                objSQL = new SQLHelper(ServerName, DatabaseName, UserID, UsrPasswor);

                if (!objSQL.OpenConnection())
                {
                    MigrationStatus = "Connection Failed. Please check Server name and login credential";
                    btnProcess.Enabled = true;
                    return;
                }


                if (MessageBox.Show("Before data migration, please takeup the database backup of ‘Almaqarpos’ and ‘BBM’ database. \n If you process the data migration then the existing BBM data will be erased and it will have only ‘Almaqarpos’ data in BBM database. \n Are you sure to data migrate from ‘Almaqarpos’ database to ‘BBM’?", "Bumedien Business Management", MessageBoxButtons.YesNo) == DialogResult.No)
                {

                    btnProcess.Enabled = true;
                    btnCancel.Enabled = true;
                    return;

                }

                Thread runsq = new Thread(runSql);

                runsq.Start();
                ////  ThreadInfo  threadInfo = new ThreadInfo();

                //  ThreadPool.QueueUserWorkItem(new WaitCallback(runSql), threadInfo);

                if (MigrationStatus == "Connection Failed. Please check Server name and login credential")
                    return;

                bgWorker.ReportProgress(3);
                int n = 150;

                for (int i = 3; i <= n; i++)
                //for (int i = 3; i <= 150; i++)
                {
                    Application.DoEvents();
                    // Wait 100 milliseconds.
                    Thread.Sleep(900);
                    // Report progress.
                    bgWorker.ReportProgress(i);

                    if (isCompleted == true && MigrationStatus == "DATA MIGRATED SUCCESSFULLY")
                    {
                        break;
                    }
                    else if (MigrationStatus != "")
                    {
                        break;

                    }
                    n++;
                }
                //Start the async operation here
                //bgWorker.RunWorkerAsync();
                //objSQL = new SQLHelper(ServerName, DatabaseName, UserID, UsrPasswor);
                //SqlDataReader objReader;
                //objReader = objSQL.GetReader("SP_DataMigration");

                bgWorker.ReportProgress(100);

                if (MigrationStatus == "DATA MIGRATED SUCCESSFULLY" || MigrationStatus == "")
                {
                    btnCancel.Text = "Finish";
                }
                else if (MigrationStatus != "DATA MIGRATED SUCCESSFULLY")
                {
                    if (MigrationStatus.Contains("\n"))
                    {
                        int indx = MigrationStatus.IndexOf("\n");
                        MigrationStatus = MigrationStatus.Substring(0, indx);
                    }

                    lblStatus.Text = MigrationStatus;
                    return;
                }

            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// To check the datbase Connection on 21 july 2014
        /// </summary>
        private void DatabaseConnectionChecking()
        {
            if (rdoDefault.Checked)
            {
                UserID = "sa";
                UsrPasswor = "puman#2000";
                ServerName = ".\\BBMSQLEXPRESS";
            }
            else
            {
                //if (!Validation())
                //    return;Modified by Meena.R on 23Sept2014 this validation mentioned in main methods.
                ServerName = cmbServerTo.Text;
                UserID = txtUserNameTo.Text;
                UsrPasswor = txtPasswordTo.Text;
            }

            btnProcess.Enabled = false;
            btnCancel.Enabled = true;


        }

        // This function is used for Data migration in background thread done by Praba on 06-Jun-2014
        private void runSql()
        {
            try
            {
                objSQL = new SQLHelper(ServerName, DatabaseName, UserID, UsrPasswor);
                SqlParameter sqlPara = new SqlParameter();
                sqlPara.ParameterName = "@ErrorReason";
                sqlPara.Direction = ParameterDirection.Output;
                sqlPara.SqlDbType = SqlDbType.VarChar;
                sqlPara.Size = 5000;
                MigrationStatus = objSQL.GetReader("SP_DataMigration", sqlPara);

                if (MigrationStatus == "DATA MIGRATED SUCCESSFULLY")
                {
                    isCompleted = true;
                }
                else
                {
                    isCompleted = false;
                }

            }
            catch (Exception ex)
            {
                MigrationStatus = "Data Migration is failed! due to : " + ex.Message;
            }
        }




        private bool Validation()
        {
            try
            {
                if (cmbServerTo.Text.Trim() == "")
                {
                    MessageBox.Show("Please select the 'Server Name' in drop down list", "Data Migration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbServerTo.Focus();
                    cmbServerTo.DroppedDown = true;
                    return false;
                }

                if (txtUserNameTo.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the 'User Name'", "Data Migration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserNameTo.Focus();
                    return false;
                }

                if (txtPasswordTo.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the 'Password'", "Data Migration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPasswordTo.Focus();
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<string> GetActiveServers()
        {
            try
            {
                List<string> list = new List<string>();
                DataTable dtServers = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
                if (dtServers != null && dtServers.Rows.Count > 0)
                {
                    foreach (DataRow oRow in dtServers.Rows)
                    {
                        string item = string.Empty;
                        if (oRow["InstanceName"].ToString() == string.Empty) item = oRow["ServerName"].ToString();
                        else item = oRow["ServerName"].ToString() + "\\" + oRow["InstanceName"].ToString();
                        if (!list.Contains(item)) list.Add(item);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw null;
            }

        }

        private void frmDataMigration_Load(object sender, EventArgs e)
        {
            //  initLoad();
        }

        //Load the all network SQL Database instance in the Drop down list done by Praba on 09-Jun-2014
        private void initLoad()
        {
            try
            {
                if (cmbServerFrom.Items.Count <= 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    List<string> listServers = GetActiveServers();
                    cmbServerFrom.Items.Clear();
                    cmbServerFrom.Items.AddRange(listServers.ToArray());

                    cmbServerTo.Items.Clear();
                    cmbServerTo.Items.AddRange(listServers.ToArray());

                    cmbServerTo.Text = "(local)\\SQLEXPRESS";
                    txtUserNameTo.Text = "sa";
                    this.Cursor = Cursors.Arrow;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtPasswordTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnProcess_Click(sender, e);

            }
        }

        private void rdoDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDefault.Checked == true)
            {
                GrpServDtl.Enabled = false;
                cmbServerTo.Text = "";
                txtUserNameTo.Text = "";
                txtPasswordTo.Text = "";
            }
            else
            {
                GrpServDtl.Enabled = true;
            }
        }

        private void rdoCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCustom.Checked == true)
            {
                GrpServDtl.Enabled = true;
                initLoad();
            }
            else
            {
                GrpServDtl.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRestore_Backup_Click(object sender, EventArgs e)
        {

            try
            {
                if (rdoCustom.Checked)
                {
                    if (!Validation())
                        return;
                }
                DatabaseConnectionChecking();
                objSQL = new SQLHelper(ServerName, DatabaseName, UserID, UsrPasswor);//This lines Include in 25_Sept_2014 to Fix when changing the Connection it not affected it still in existing connection
                this.Cursor = Cursors.WaitCursor;
                string strResult = RestoreMethod();
                if (strResult == "Failed")
                {

                    btnRestore_Backup.Enabled = true;
                    lblRestoreDBMessgae.Text = "DbRestoreFailed";
                }
                else if (strResult == "Success")
                {

                    btnRestore_Backup.Enabled = false;
                    lblRestoreDBMessgae.Text = "AlmaqarPOS Database Successfully Restored";

                    MessageBox.Show("AlmaqarPOS Database Successfully Restored. \n Application will restart now", "BBM");
                    this.Cursor = Cursors.Arrow;
                    Application.Restart();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database restore failed");

            }
            finally
            {
                this.Cursor = Cursors.Arrow;

            }

        }
        /// <summary>
        /// To create a almaqarpos database and restore the database  
        /// </summary>
        /// <returns></returns>

        private string RestoreMethod()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BAK(*.bak)|*.bak";
            string restoreFile = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                restoreFile = ofd.FileName;
            }
            else
                return string.Empty;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@FilePath", restoreFile);
                sqlparam[1] = new SqlParameter("@Option", true);
                sqlparam[2] = new SqlParameter("@DataBaseName", DatabaseName);


                var CreateDB = objSQL.CreateDB();///to create a db 
                if (CreateDB == "Success")
                {

                    Cursor = Cursors.WaitCursor;


                    //pictureboxpanel.Visible = true;
                    // pictureBox1.BringToFront();
                    var result = objSQL.GetRestoreDB(restoreFile);   // // calling function for Restoring the almaqarpos database done on 21-July-2014
                    //Thread.Sleep(8000);
                    Cursor = Cursors.Default;
                    //pictureboxpanel.Visible = false;
                    return result;
                }

                return "Failed";

            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Database 'AlmaqarPOS' already exists"))
                {
                    MessageBox.Show("Database 'AlmaqarPOS' already exists", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return String.Empty;
                }//this message Include on 25_sept_2014 if the database already existing means it does not shown the instead of it showing DBRestored Faild
                else
                {
                    MessageBox.Show("DbRestoreFailed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Failed";
                }
                
            }
        }



    }




}
