
namespace HMI
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Move_X = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.ABS_POS1 = new System.Windows.Forms.Label();
            this.SPEED1 = new System.Windows.Forms.Label();
            this.ACC1 = new System.Windows.Forms.Label();
            this.DEC_1 = new System.Windows.Forms.Label();
            this.MAX_SPEED1 = new System.Windows.Forms.Label();
            this.MIN_SPEED1 = new System.Windows.Forms.Label();
            this.STATUS1 = new System.Windows.Forms.Label();
            this.STEP_MODE1 = new System.Windows.Forms.Label();
            this.Out_ABS_X = new System.Windows.Forms.TextBox();
            this.Out_Acc_X = new System.Windows.Forms.TextBox();
            this.Out_Dec_X = new System.Windows.Forms.TextBox();
            this.Out_Speed_X = new System.Windows.Forms.TextBox();
            this.Out_MINSpeed_X = new System.Windows.Forms.TextBox();
            this.Out_MAXSpeed_X = new System.Windows.Forms.TextBox();
            this.Out_StepMode_X = new System.Windows.Forms.TextBox();
            this.GetStatus_X = new System.Windows.Forms.Button();
            this.panel30 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel32 = new System.Windows.Forms.Panel();
            this.STEPLOSS_B_Flag_X = new System.Windows.Forms.Label();
            this.STEPLOSS_A_Flag_X = new System.Windows.Forms.Label();
            this.TH_SD_Flag_X = new System.Windows.Forms.Label();
            this.OCD_Flag_X = new System.Windows.Forms.Label();
            this.TH_WRN_Flag_X = new System.Windows.Forms.Label();
            this.WRONG_Flag_X = new System.Windows.Forms.Label();
            this.UVLO_Flag_X = new System.Windows.Forms.Label();
            this.motion = new System.Windows.Forms.Label();
            this.DIR_Flag_X = new System.Windows.Forms.Label();
            this.HIZ_Flag_X = new System.Windows.Forms.Label();
            this.BUSY_Flag_X = new System.Windows.Forms.Label();
            this.NOTPERF_Flag_X = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.Now_Status_X = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Now_StepMode_X = new System.Windows.Forms.Label();
            this.Now_MINSpeed_X = new System.Windows.Forms.Label();
            this.Now_MAXSpeed_X = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Now_Acc_X = new System.Windows.Forms.Label();
            this.Now_ABS_X = new System.Windows.Forms.Label();
            this.Now_Speed_X = new System.Windows.Forms.Label();
            this.Now_Dec_X = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.timecount = new System.Windows.Forms.Label();
            this.panelX = new System.Windows.Forms.Panel();
            this.Home_Reset_X = new System.Windows.Forms.Button();
            this.Run_value = new System.Windows.Forms.TextBox();
            this.GoTo_value = new System.Windows.Forms.TextBox();
            this.Move_value = new System.Windows.Forms.TextBox();
            this.Stop = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.GoTo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.HardHiZ = new System.Windows.Forms.RadioButton();
            this.SoftHiZ = new System.Windows.Forms.RadioButton();
            this.HardStop = new System.Windows.Forms.RadioButton();
            this.SoftStop = new System.Windows.Forms.RadioButton();
            this.Gohome = new System.Windows.Forms.Button();
            this.SETPAN = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.comname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comstop = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comdata = new System.Windows.Forms.ComboBox();
            this.Confirmbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.SETBTN = new System.Windows.Forms.Button();
            this.GetStatus_Y = new System.Windows.Forms.Button();
            this.panel43 = new System.Windows.Forms.Panel();
            this.STEPLOSS_B_Flag_Y = new System.Windows.Forms.Label();
            this.STEPLOSS_A_Flag_Y = new System.Windows.Forms.Label();
            this.TH_SD_Flag_Y = new System.Windows.Forms.Label();
            this.OCD_Flag_Y = new System.Windows.Forms.Label();
            this.TH_WRN_Flag_Y = new System.Windows.Forms.Label();
            this.motionY = new System.Windows.Forms.Label();
            this.WRONG_Flag_Y = new System.Windows.Forms.Label();
            this.UVLO_Flag_Y = new System.Windows.Forms.Label();
            this.DIR_Flag_Y = new System.Windows.Forms.Label();
            this.HIZ_Flag_Y = new System.Windows.Forms.Label();
            this.BUSY_Flag_Y = new System.Windows.Forms.Label();
            this.NOTPERF_Flag_Y = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.Now_Status_Y = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label90 = new System.Windows.Forms.Label();
            this.Now_StepMode_Y = new System.Windows.Forms.Label();
            this.Now_MAXSpeed_Y = new System.Windows.Forms.Label();
            this.Now_MINSpeed_Y = new System.Windows.Forms.Label();
            this.Now_Speed_Y = new System.Windows.Forms.Label();
            this.Now_Dec_Y = new System.Windows.Forms.Label();
            this.Now_Acc_Y = new System.Windows.Forms.Label();
            this.Now_ABS_Y = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.Out_MINSpeed_Y = new System.Windows.Forms.TextBox();
            this.Out_Speed_Y = new System.Windows.Forms.TextBox();
            this.Out_Dec_Y = new System.Windows.Forms.TextBox();
            this.Out_MAXSpeed_Y = new System.Windows.Forms.TextBox();
            this.Out_Acc_Y = new System.Windows.Forms.TextBox();
            this.Out_StepMode_Y = new System.Windows.Forms.TextBox();
            this.Out_ABS_Y = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panelY = new System.Windows.Forms.Panel();
            this.Home_Reset_Y = new System.Windows.Forms.Button();
            this.GoTo_Y_value = new System.Windows.Forms.TextBox();
            this.MoveY_value = new System.Windows.Forms.TextBox();
            this.Stop_Y = new System.Windows.Forms.Button();
            this.Move_Y = new System.Windows.Forms.Button();
            this.GoTo_Y = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.HardHiZ_Y = new System.Windows.Forms.RadioButton();
            this.SoftHiZ_Y = new System.Windows.Forms.RadioButton();
            this.HardStop_Y = new System.Windows.Forms.RadioButton();
            this.SoftStop_Y = new System.Windows.Forms.RadioButton();
            this.Gohome_Y = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.STEPLOSS_B_Flag_Z = new System.Windows.Forms.Label();
            this.STEPLOSS_A_Flag_Z = new System.Windows.Forms.Label();
            this.TH_SD_Flag_Z = new System.Windows.Forms.Label();
            this.OCD_Flag_Z = new System.Windows.Forms.Label();
            this.TH_WRN_Flag_Z = new System.Windows.Forms.Label();
            this.motionZ = new System.Windows.Forms.Label();
            this.WRONG_Flag_Z = new System.Windows.Forms.Label();
            this.UVLO_Flag_Z = new System.Windows.Forms.Label();
            this.DIR_Flag_Z = new System.Windows.Forms.Label();
            this.HIZ_Flag_Z = new System.Windows.Forms.Label();
            this.BUSY_Flag_Z = new System.Windows.Forms.Label();
            this.NOTPERF_Flag_Z = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.GetStatus_Z = new System.Windows.Forms.Button();
            this.Now_Status_Z = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.Out_ABS_Z = new System.Windows.Forms.TextBox();
            this.Out_Acc_Z = new System.Windows.Forms.TextBox();
            this.Out_MAXSpeed_Z = new System.Windows.Forms.TextBox();
            this.Out_StepMode_Z = new System.Windows.Forms.TextBox();
            this.Out_Dec_Z = new System.Windows.Forms.TextBox();
            this.Out_Speed_Z = new System.Windows.Forms.TextBox();
            this.Out_MINSpeed_Z = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.Now_StepMode_Z = new System.Windows.Forms.Label();
            this.Now_MINSpeed_Z = new System.Windows.Forms.Label();
            this.Now_MAXSpeed_Z = new System.Windows.Forms.Label();
            this.Now_Acc_Z = new System.Windows.Forms.Label();
            this.Now_ABS_Z = new System.Windows.Forms.Label();
            this.Now_Speed_Z = new System.Windows.Forms.Label();
            this.Now_Dec_Z = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.panelZ = new System.Windows.Forms.Panel();
            this.Home_Reset_Z = new System.Windows.Forms.Button();
            this.GoTo_Z_value = new System.Windows.Forms.TextBox();
            this.MoveZ_value = new System.Windows.Forms.TextBox();
            this.Stop_Z = new System.Windows.Forms.Button();
            this.Move_Z = new System.Windows.Forms.Button();
            this.GoTo_Z = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.HardHiZ_Z = new System.Windows.Forms.RadioButton();
            this.SoftHiZ_Z = new System.Windows.Forms.RadioButton();
            this.HardStop_Z = new System.Windows.Forms.RadioButton();
            this.SoftStop_Z = new System.Windows.Forms.RadioButton();
            this.Gohome_Z = new System.Windows.Forms.Button();
            this.motionU = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GetStatus_U = new System.Windows.Forms.Button();
            this.Now_Status_U = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.STEPLOSS_B_Flag_U = new System.Windows.Forms.Label();
            this.STEPLOSS_A_Flag_U = new System.Windows.Forms.Label();
            this.TH_SD_Flag_U = new System.Windows.Forms.Label();
            this.OCD_Flag_U = new System.Windows.Forms.Label();
            this.TH_WRN_Flag_U = new System.Windows.Forms.Label();
            this.WRONG_Flag_U = new System.Windows.Forms.Label();
            this.UVLO_Flag_U = new System.Windows.Forms.Label();
            this.DIR_Flag_U = new System.Windows.Forms.Label();
            this.HIZ_Flag_U = new System.Windows.Forms.Label();
            this.BUSY_Flag_U = new System.Windows.Forms.Label();
            this.NOTPERF_Flag_U = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.panelU = new System.Windows.Forms.Panel();
            this.Home_Reset_U = new System.Windows.Forms.Button();
            this.GoTo_U_value = new System.Windows.Forms.TextBox();
            this.MoveU_value = new System.Windows.Forms.TextBox();
            this.Stop_U = new System.Windows.Forms.Button();
            this.Move_U = new System.Windows.Forms.Button();
            this.GoTo_U = new System.Windows.Forms.Button();
            this.panel27 = new System.Windows.Forms.Panel();
            this.HardHiZ_U = new System.Windows.Forms.RadioButton();
            this.SoftHiZ_U = new System.Windows.Forms.RadioButton();
            this.HardStop_U = new System.Windows.Forms.RadioButton();
            this.SoftStop_U = new System.Windows.Forms.RadioButton();
            this.Gohome_U = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.Multiple_GoHome = new System.Windows.Forms.Button();
            this.Multiple_Stop = new System.Windows.Forms.Button();
            this.RESET = new System.Windows.Forms.Button();
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControlX = new System.Windows.Forms.TabControl();
            this.X = new System.Windows.Forms.TabPage();
            this.Y = new System.Windows.Forms.TabPage();
            this.Z = new System.Windows.Forms.TabPage();
            this.U = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Prepare_Y_Value = new System.Windows.Forms.TextBox();
            this.Prepare_U_Value = new System.Windows.Forms.TextBox();
            this.Prepare_Z_Value = new System.Windows.Forms.TextBox();
            this.Prepare_X_Value = new System.Windows.Forms.TextBox();
            this.Multiple_Move = new System.Windows.Forms.Button();
            this.Multiple_GoTo = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label51 = new System.Windows.Forms.Label();
            this.Home_reset_Speed = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.Home_Reset_step = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.Home_Reset_X_Dir_R = new System.Windows.Forms.RadioButton();
            this.Home_Reset_X_Dir_L = new System.Windows.Forms.RadioButton();
            this.label36 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.Home_Reset_Y_Dir_R = new System.Windows.Forms.RadioButton();
            this.Home_Reset_Y_Dir_L = new System.Windows.Forms.RadioButton();
            this.label41 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.Home_Reset_Z_Dir_R = new System.Windows.Forms.RadioButton();
            this.Home_Reset_Z_Dir_L = new System.Windows.Forms.RadioButton();
            this.label44 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.Home_Reset_U_Dir_R = new System.Windows.Forms.RadioButton();
            this.Home_Reset_U_Dir_L = new System.Windows.Forms.RadioButton();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HOME_X_R = new System.Windows.Forms.RadioButton();
            this.HOME_X_L = new System.Windows.Forms.RadioButton();
            this.label32 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.HOME_Y_R = new System.Windows.Forms.RadioButton();
            this.HOME_Y_L = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.HOME_Z_R = new System.Windows.Forms.RadioButton();
            this.HOME_Z_L = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HOME_U_R = new System.Windows.Forms.RadioButton();
            this.HOME_U_L = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxX = new System.Windows.Forms.GroupBox();
            this.X_limit = new System.Windows.Forms.GroupBox();
            this.labe1x = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.X_Lmax = new System.Windows.Forms.PictureBox();
            this.X_home = new System.Windows.Forms.PictureBox();
            this.labelx = new System.Windows.Forms.Label();
            this.X_Lmin = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Y_limit = new System.Windows.Forms.GroupBox();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.Y_Lmax = new System.Windows.Forms.PictureBox();
            this.Y_home = new System.Windows.Forms.PictureBox();
            this.label88 = new System.Windows.Forms.Label();
            this.Y_Lmin = new System.Windows.Forms.PictureBox();
            this.U_limit = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.U_Lmax = new System.Windows.Forms.PictureBox();
            this.U_home = new System.Windows.Forms.PictureBox();
            this.label43 = new System.Windows.Forms.Label();
            this.U_Lmin = new System.Windows.Forms.PictureBox();
            this.Z_limit = new System.Windows.Forms.GroupBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.Z_Lmax = new System.Windows.Forms.PictureBox();
            this.Z_home = new System.Windows.Forms.PictureBox();
            this.label85 = new System.Windows.Forms.Label();
            this.Z_Lmin = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.Now_StepMode_U = new System.Windows.Forms.Label();
            this.Now_MINSpeed_U = new System.Windows.Forms.Label();
            this.Now_MAXSpeed_U = new System.Windows.Forms.Label();
            this.Now_Acc_U = new System.Windows.Forms.Label();
            this.Now_ABS_U = new System.Windows.Forms.Label();
            this.Now_Speed_U = new System.Windows.Forms.Label();
            this.Now_Dec_U = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.Out_ABS_U = new System.Windows.Forms.TextBox();
            this.Out_Acc_U = new System.Windows.Forms.TextBox();
            this.Out_MAXSpeed_U = new System.Windows.Forms.TextBox();
            this.Out_StepMode_U = new System.Windows.Forms.TextBox();
            this.Out_Dec_U = new System.Windows.Forms.TextBox();
            this.Out_Speed_U = new System.Windows.Forms.TextBox();
            this.Out_MINSpeed_U = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.action = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label52 = new System.Windows.Forms.Label();
            this.Limit_Reset_step = new System.Windows.Forms.TextBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.U_Lmax_Reset = new System.Windows.Forms.Button();
            this.U_Lmin_Reset = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.Z_Lmax_Reset = new System.Windows.Forms.Button();
            this.Z_Lmin_Reset = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.Y_Lmax_Reset = new System.Windows.Forms.Button();
            this.Y_Lmin_Reset = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.X_Lmax_Reset = new System.Windows.Forms.Button();
            this.X_Lmin_Reset = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.S150 = new System.Windows.Forms.Button();
            this.panel30.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelX.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SETPAN.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panelY.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panelZ.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel34.SuspendLayout();
            this.panelU.SuspendLayout();
            this.panel27.SuspendLayout();
            this.tabControlX.SuspendLayout();
            this.X.SuspendLayout();
            this.Y.SuspendLayout();
            this.Z.SuspendLayout();
            this.U.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxX.SuspendLayout();
            this.X_limit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.X_Lmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_Lmin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Y_limit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Lmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Lmin)).BeginInit();
            this.U_limit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.U_Lmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.U_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.U_Lmin)).BeginInit();
            this.Z_limit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Z_Lmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_Lmin)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel29.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.action.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.ParityReplace = ((byte)(64));
            this.serialPort1.PortName = "COM4";
            this.serialPort1.ReceivedBytesThreshold = 10;
            this.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
            this.serialPort1.WriteBufferSize = 4096;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // Move_X
            // 
            this.Move_X.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Move_X.Location = new System.Drawing.Point(5, 5);
            this.Move_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Move_X.Name = "Move_X";
            this.Move_X.Size = new System.Drawing.Size(149, 50);
            this.Move_X.TabIndex = 0;
            this.Move_X.Text = "Move";
            this.Move_X.UseVisualStyleBackColor = true;
            this.Move_X.Click += new System.EventHandler(this.Move_X_Click);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 500;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ABS_POS1
            // 
            this.ABS_POS1.AutoSize = true;
            this.ABS_POS1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ABS_POS1.Location = new System.Drawing.Point(-1, 0);
            this.ABS_POS1.Name = "ABS_POS1";
            this.ABS_POS1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.ABS_POS1.Size = new System.Drawing.Size(74, 45);
            this.ABS_POS1.TabIndex = 1;
            this.ABS_POS1.Text = "ABS_POS";
            // 
            // SPEED1
            // 
            this.SPEED1.AutoSize = true;
            this.SPEED1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SPEED1.Location = new System.Drawing.Point(-3, 105);
            this.SPEED1.Name = "SPEED1";
            this.SPEED1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.SPEED1.Size = new System.Drawing.Size(56, 45);
            this.SPEED1.TabIndex = 3;
            this.SPEED1.Text = "SPEED";
            // 
            // ACC1
            // 
            this.ACC1.AutoSize = true;
            this.ACC1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ACC1.Location = new System.Drawing.Point(-1, 35);
            this.ACC1.Name = "ACC1";
            this.ACC1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.ACC1.Size = new System.Drawing.Size(38, 45);
            this.ACC1.TabIndex = 4;
            this.ACC1.Text = "ACC";
            // 
            // DEC_1
            // 
            this.DEC_1.AutoSize = true;
            this.DEC_1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DEC_1.Location = new System.Drawing.Point(-1, 70);
            this.DEC_1.Name = "DEC_1";
            this.DEC_1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.DEC_1.Size = new System.Drawing.Size(38, 45);
            this.DEC_1.TabIndex = 5;
            this.DEC_1.Text = "DEC";
            // 
            // MAX_SPEED1
            // 
            this.MAX_SPEED1.AutoSize = true;
            this.MAX_SPEED1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MAX_SPEED1.Location = new System.Drawing.Point(-3, 175);
            this.MAX_SPEED1.Name = "MAX_SPEED1";
            this.MAX_SPEED1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.MAX_SPEED1.Size = new System.Drawing.Size(100, 45);
            this.MAX_SPEED1.TabIndex = 6;
            this.MAX_SPEED1.Text = "MAX_SPEED";
            // 
            // MIN_SPEED1
            // 
            this.MIN_SPEED1.AutoSize = true;
            this.MIN_SPEED1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MIN_SPEED1.Location = new System.Drawing.Point(-1, 140);
            this.MIN_SPEED1.Name = "MIN_SPEED1";
            this.MIN_SPEED1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.MIN_SPEED1.Size = new System.Drawing.Size(95, 45);
            this.MIN_SPEED1.TabIndex = 7;
            this.MIN_SPEED1.Text = "MIN_SPEED";
            // 
            // STATUS1
            // 
            this.STATUS1.AutoSize = true;
            this.STATUS1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.STATUS1.Location = new System.Drawing.Point(3, 245);
            this.STATUS1.Name = "STATUS1";
            this.STATUS1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.STATUS1.Size = new System.Drawing.Size(67, 45);
            this.STATUS1.TabIndex = 9;
            this.STATUS1.Text = "STATUS";
            // 
            // STEP_MODE1
            // 
            this.STEP_MODE1.AutoSize = true;
            this.STEP_MODE1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.STEP_MODE1.Location = new System.Drawing.Point(-1, 210);
            this.STEP_MODE1.Name = "STEP_MODE1";
            this.STEP_MODE1.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.STEP_MODE1.Size = new System.Drawing.Size(99, 45);
            this.STEP_MODE1.TabIndex = 8;
            this.STEP_MODE1.Text = "STEP_MODE";
            // 
            // Out_ABS_X
            // 
            this.Out_ABS_X.Location = new System.Drawing.Point(5, 10);
            this.Out_ABS_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_ABS_X.Name = "Out_ABS_X";
            this.Out_ABS_X.Size = new System.Drawing.Size(100, 25);
            this.Out_ABS_X.TabIndex = 10;
            this.Out_ABS_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_ABS_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_ABS_X_KeyDown);
            // 
            // Out_Acc_X
            // 
            this.Out_Acc_X.Location = new System.Drawing.Point(5, 45);
            this.Out_Acc_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Acc_X.Name = "Out_Acc_X";
            this.Out_Acc_X.Size = new System.Drawing.Size(100, 25);
            this.Out_Acc_X.TabIndex = 12;
            this.Out_Acc_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Acc_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Acc_X_KeyDown);
            // 
            // Out_Dec_X
            // 
            this.Out_Dec_X.Location = new System.Drawing.Point(5, 80);
            this.Out_Dec_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Dec_X.Name = "Out_Dec_X";
            this.Out_Dec_X.Size = new System.Drawing.Size(100, 25);
            this.Out_Dec_X.TabIndex = 13;
            this.Out_Dec_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Dec_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Dec_X_KeyDown);
            // 
            // Out_Speed_X
            // 
            this.Out_Speed_X.Location = new System.Drawing.Point(5, 115);
            this.Out_Speed_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Speed_X.Name = "Out_Speed_X";
            this.Out_Speed_X.Size = new System.Drawing.Size(100, 25);
            this.Out_Speed_X.TabIndex = 21;
            this.Out_Speed_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Speed_X.Visible = false;
            this.Out_Speed_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Speed_X_KeyDown);
            // 
            // Out_MINSpeed_X
            // 
            this.Out_MINSpeed_X.Location = new System.Drawing.Point(5, 150);
            this.Out_MINSpeed_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MINSpeed_X.Name = "Out_MINSpeed_X";
            this.Out_MINSpeed_X.Size = new System.Drawing.Size(100, 25);
            this.Out_MINSpeed_X.TabIndex = 15;
            this.Out_MINSpeed_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MINSpeed_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MINSpeed_X_KeyDown);
            // 
            // Out_MAXSpeed_X
            // 
            this.Out_MAXSpeed_X.Location = new System.Drawing.Point(5, 185);
            this.Out_MAXSpeed_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MAXSpeed_X.Name = "Out_MAXSpeed_X";
            this.Out_MAXSpeed_X.Size = new System.Drawing.Size(100, 25);
            this.Out_MAXSpeed_X.TabIndex = 16;
            this.Out_MAXSpeed_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MAXSpeed_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MAXSpeed_X_KeyDown);
            // 
            // Out_StepMode_X
            // 
            this.Out_StepMode_X.Location = new System.Drawing.Point(5, 220);
            this.Out_StepMode_X.Margin = new System.Windows.Forms.Padding(3, 15, 3, 15);
            this.Out_StepMode_X.Name = "Out_StepMode_X";
            this.Out_StepMode_X.Size = new System.Drawing.Size(100, 25);
            this.Out_StepMode_X.TabIndex = 17;
            this.Out_StepMode_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_StepMode_X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_StepMode_X_KeyDown);
            // 
            // GetStatus_X
            // 
            this.GetStatus_X.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetStatus_X.Location = new System.Drawing.Point(5, 30);
            this.GetStatus_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetStatus_X.Name = "GetStatus_X";
            this.GetStatus_X.Size = new System.Drawing.Size(120, 45);
            this.GetStatus_X.TabIndex = 38;
            this.GetStatus_X.Text = "GetStatus_X";
            this.GetStatus_X.UseVisualStyleBackColor = true;
            this.GetStatus_X.Click += new System.EventHandler(this.GetStatus_X_Click);
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel30.Controls.Add(this.label40);
            this.panel30.Controls.Add(this.label16);
            this.panel30.Controls.Add(this.label17);
            this.panel30.Controls.Add(this.label78);
            this.panel30.Controls.Add(this.label21);
            this.panel30.Controls.Add(this.label79);
            this.panel30.Controls.Add(this.label25);
            this.panel30.Controls.Add(this.label26);
            this.panel30.Controls.Add(this.label27);
            this.panel30.Controls.Add(this.label28);
            this.panel30.Controls.Add(this.label29);
            this.panel30.Controls.Add(this.label31);
            this.panel30.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel30.Location = new System.Drawing.Point(5, 52);
            this.panel30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(140, 373);
            this.panel30.TabIndex = 24;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 161);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(67, 17);
            this.label40.TabIndex = 63;
            this.label40.Text = "WRONG";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 342);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 17);
            this.label16.TabIndex = 62;
            this.label16.Text = "STEPLOSS_B";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 17);
            this.label17.TabIndex = 1;
            this.label17.Text = "HIZ";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(5, 282);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(42, 17);
            this.label78.TabIndex = 59;
            this.label78.Text = "OCD";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 250);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 17);
            this.label21.TabIndex = 8;
            this.label21.Text = "TH_SD";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(5, 312);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(102, 17);
            this.label79.TabIndex = 61;
            this.label79.Text = "STEPLOSS_A";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 190);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(51, 17);
            this.label25.TabIndex = 7;
            this.label25.Text = "UVLO";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 220);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 17);
            this.label26.TabIndex = 6;
            this.label26.Text = "TH_WRN";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 108);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 17);
            this.label27.TabIndex = 5;
            this.label27.Text = "MOTION";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 17);
            this.label28.TabIndex = 2;
            this.label28.Text = "BUSY";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 78);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(36, 17);
            this.label29.TabIndex = 4;
            this.label29.Text = "DIR";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(5, 135);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(80, 17);
            this.label31.TabIndex = 3;
            this.label31.Text = "NOTPERF";
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel32.Controls.Add(this.STEPLOSS_B_Flag_X);
            this.panel32.Controls.Add(this.STEPLOSS_A_Flag_X);
            this.panel32.Controls.Add(this.TH_SD_Flag_X);
            this.panel32.Controls.Add(this.OCD_Flag_X);
            this.panel32.Controls.Add(this.TH_WRN_Flag_X);
            this.panel32.Controls.Add(this.WRONG_Flag_X);
            this.panel32.Controls.Add(this.UVLO_Flag_X);
            this.panel32.Controls.Add(this.motion);
            this.panel32.Controls.Add(this.DIR_Flag_X);
            this.panel32.Controls.Add(this.HIZ_Flag_X);
            this.panel32.Controls.Add(this.BUSY_Flag_X);
            this.panel32.Controls.Add(this.NOTPERF_Flag_X);
            this.panel32.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel32.Location = new System.Drawing.Point(5, 52);
            this.panel32.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(81, 373);
            this.panel32.TabIndex = 31;
            // 
            // STEPLOSS_B_Flag_X
            // 
            this.STEPLOSS_B_Flag_X.AutoSize = true;
            this.STEPLOSS_B_Flag_X.Location = new System.Drawing.Point(5, 342);
            this.STEPLOSS_B_Flag_X.Name = "STEPLOSS_B_Flag_X";
            this.STEPLOSS_B_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_B_Flag_X.TabIndex = 38;
            this.STEPLOSS_B_Flag_X.Text = "Null";
            // 
            // STEPLOSS_A_Flag_X
            // 
            this.STEPLOSS_A_Flag_X.AutoSize = true;
            this.STEPLOSS_A_Flag_X.Location = new System.Drawing.Point(5, 312);
            this.STEPLOSS_A_Flag_X.Name = "STEPLOSS_A_Flag_X";
            this.STEPLOSS_A_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_A_Flag_X.TabIndex = 36;
            this.STEPLOSS_A_Flag_X.Text = "Null";
            // 
            // TH_SD_Flag_X
            // 
            this.TH_SD_Flag_X.AutoSize = true;
            this.TH_SD_Flag_X.Location = new System.Drawing.Point(5, 252);
            this.TH_SD_Flag_X.Name = "TH_SD_Flag_X";
            this.TH_SD_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.TH_SD_Flag_X.TabIndex = 34;
            this.TH_SD_Flag_X.Text = "Null";
            // 
            // OCD_Flag_X
            // 
            this.OCD_Flag_X.AutoSize = true;
            this.OCD_Flag_X.Location = new System.Drawing.Point(5, 282);
            this.OCD_Flag_X.Name = "OCD_Flag_X";
            this.OCD_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.OCD_Flag_X.TabIndex = 35;
            this.OCD_Flag_X.Text = "Null";
            // 
            // TH_WRN_Flag_X
            // 
            this.TH_WRN_Flag_X.AutoSize = true;
            this.TH_WRN_Flag_X.Location = new System.Drawing.Point(5, 222);
            this.TH_WRN_Flag_X.Name = "TH_WRN_Flag_X";
            this.TH_WRN_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.TH_WRN_Flag_X.TabIndex = 33;
            this.TH_WRN_Flag_X.Text = "Null";
            // 
            // WRONG_Flag_X
            // 
            this.WRONG_Flag_X.AutoSize = true;
            this.WRONG_Flag_X.Location = new System.Drawing.Point(3, 162);
            this.WRONG_Flag_X.Name = "WRONG_Flag_X";
            this.WRONG_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.WRONG_Flag_X.TabIndex = 30;
            this.WRONG_Flag_X.Text = "Null";
            // 
            // UVLO_Flag_X
            // 
            this.UVLO_Flag_X.AutoSize = true;
            this.UVLO_Flag_X.Location = new System.Drawing.Point(4, 192);
            this.UVLO_Flag_X.Name = "UVLO_Flag_X";
            this.UVLO_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.UVLO_Flag_X.TabIndex = 32;
            this.UVLO_Flag_X.Text = "Null";
            // 
            // motion
            // 
            this.motion.AutoSize = true;
            this.motion.Location = new System.Drawing.Point(5, 108);
            this.motion.Name = "motion";
            this.motion.Size = new System.Drawing.Size(24, 17);
            this.motion.TabIndex = 37;
            this.motion.Text = "??";
            // 
            // DIR_Flag_X
            // 
            this.DIR_Flag_X.AutoSize = true;
            this.DIR_Flag_X.Location = new System.Drawing.Point(3, 78);
            this.DIR_Flag_X.Name = "DIR_Flag_X";
            this.DIR_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.DIR_Flag_X.TabIndex = 29;
            this.DIR_Flag_X.Text = "Null";
            // 
            // HIZ_Flag_X
            // 
            this.HIZ_Flag_X.AutoSize = true;
            this.HIZ_Flag_X.Location = new System.Drawing.Point(3, 14);
            this.HIZ_Flag_X.Name = "HIZ_Flag_X";
            this.HIZ_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.HIZ_Flag_X.TabIndex = 25;
            this.HIZ_Flag_X.Text = "Null";
            // 
            // BUSY_Flag_X
            // 
            this.BUSY_Flag_X.AutoSize = true;
            this.BUSY_Flag_X.Location = new System.Drawing.Point(3, 48);
            this.BUSY_Flag_X.Name = "BUSY_Flag_X";
            this.BUSY_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.BUSY_Flag_X.TabIndex = 26;
            this.BUSY_Flag_X.Text = "Null";
            // 
            // NOTPERF_Flag_X
            // 
            this.NOTPERF_Flag_X.AutoSize = true;
            this.NOTPERF_Flag_X.Location = new System.Drawing.Point(3, 132);
            this.NOTPERF_Flag_X.Name = "NOTPERF_Flag_X";
            this.NOTPERF_Flag_X.Size = new System.Drawing.Size(35, 17);
            this.NOTPERF_Flag_X.TabIndex = 27;
            this.NOTPERF_Flag_X.Text = "Null";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label48.Location = new System.Drawing.Point(7, 31);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 15);
            this.label48.TabIndex = 25;
            this.label48.Text = "狀態名稱";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label77.Location = new System.Drawing.Point(7, 35);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(71, 15);
            this.label77.TabIndex = 26;
            this.label77.Text = "當前狀態";
            // 
            // Now_Status_X
            // 
            this.Now_Status_X.AutoSize = true;
            this.Now_Status_X.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Now_Status_X.Location = new System.Drawing.Point(3, 245);
            this.Now_Status_X.Name = "Now_Status_X";
            this.Now_Status_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Status_X.Size = new System.Drawing.Size(16, 47);
            this.Now_Status_X.TabIndex = 36;
            this.Now_Status_X.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(105, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 15);
            this.label14.TabIndex = 34;
            this.label14.Text = "輸入";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.Out_ABS_X);
            this.panel8.Controls.Add(this.Out_Acc_X);
            this.panel8.Controls.Add(this.Out_MAXSpeed_X);
            this.panel8.Controls.Add(this.Out_StepMode_X);
            this.panel8.Controls.Add(this.Out_Dec_X);
            this.panel8.Controls.Add(this.Out_Speed_X);
            this.panel8.Controls.Add(this.Out_MINSpeed_X);
            this.panel8.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel8.Location = new System.Drawing.Point(108, 51);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(115, 296);
            this.panel8.TabIndex = 32;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.ABS_POS1);
            this.panel6.Controls.Add(this.STATUS1);
            this.panel6.Controls.Add(this.STEP_MODE1);
            this.panel6.Controls.Add(this.MIN_SPEED1);
            this.panel6.Controls.Add(this.MAX_SPEED1);
            this.panel6.Controls.Add(this.DEC_1);
            this.panel6.Controls.Add(this.ACC1);
            this.panel6.Controls.Add(this.SPEED1);
            this.panel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(5, 51);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(124, 296);
            this.panel6.TabIndex = 24;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.Now_Status_X);
            this.panel7.Controls.Add(this.Now_StepMode_X);
            this.panel7.Controls.Add(this.Now_MINSpeed_X);
            this.panel7.Controls.Add(this.Now_MAXSpeed_X);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.Now_Acc_X);
            this.panel7.Controls.Add(this.Now_ABS_X);
            this.panel7.Controls.Add(this.Now_Speed_X);
            this.panel7.Controls.Add(this.Now_Dec_X);
            this.panel7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(9, 51);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(99, 300);
            this.panel7.TabIndex = 31;
            // 
            // Now_StepMode_X
            // 
            this.Now_StepMode_X.AutoSize = true;
            this.Now_StepMode_X.Location = new System.Drawing.Point(3, 210);
            this.Now_StepMode_X.Name = "Now_StepMode_X";
            this.Now_StepMode_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_StepMode_X.Size = new System.Drawing.Size(35, 47);
            this.Now_StepMode_X.TabIndex = 33;
            this.Now_StepMode_X.Text = "Null";
            // 
            // Now_MINSpeed_X
            // 
            this.Now_MINSpeed_X.AutoSize = true;
            this.Now_MINSpeed_X.Location = new System.Drawing.Point(3, 140);
            this.Now_MINSpeed_X.Name = "Now_MINSpeed_X";
            this.Now_MINSpeed_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MINSpeed_X.Size = new System.Drawing.Size(35, 47);
            this.Now_MINSpeed_X.TabIndex = 30;
            this.Now_MINSpeed_X.Text = "Null";
            // 
            // Now_MAXSpeed_X
            // 
            this.Now_MAXSpeed_X.AutoSize = true;
            this.Now_MAXSpeed_X.Location = new System.Drawing.Point(3, 175);
            this.Now_MAXSpeed_X.Name = "Now_MAXSpeed_X";
            this.Now_MAXSpeed_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MAXSpeed_X.Size = new System.Drawing.Size(35, 47);
            this.Now_MAXSpeed_X.TabIndex = 32;
            this.Now_MAXSpeed_X.Text = "Null";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 105);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.label8.Size = new System.Drawing.Size(47, 47);
            this.label8.TabIndex = 67;
            this.label8.Text = "step/s";
            // 
            // Now_Acc_X
            // 
            this.Now_Acc_X.AutoSize = true;
            this.Now_Acc_X.Location = new System.Drawing.Point(3, 35);
            this.Now_Acc_X.Name = "Now_Acc_X";
            this.Now_Acc_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Acc_X.Size = new System.Drawing.Size(35, 47);
            this.Now_Acc_X.TabIndex = 29;
            this.Now_Acc_X.Text = "Null";
            // 
            // Now_ABS_X
            // 
            this.Now_ABS_X.AutoSize = true;
            this.Now_ABS_X.Location = new System.Drawing.Point(3, 0);
            this.Now_ABS_X.Name = "Now_ABS_X";
            this.Now_ABS_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_ABS_X.Size = new System.Drawing.Size(35, 47);
            this.Now_ABS_X.TabIndex = 25;
            this.Now_ABS_X.Text = "Null";
            // 
            // Now_Speed_X
            // 
            this.Now_Speed_X.AutoSize = true;
            this.Now_Speed_X.Location = new System.Drawing.Point(0, 105);
            this.Now_Speed_X.Name = "Now_Speed_X";
            this.Now_Speed_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Speed_X.Size = new System.Drawing.Size(20, 47);
            this.Now_Speed_X.TabIndex = 28;
            this.Now_Speed_X.Text = "0 ";
            // 
            // Now_Dec_X
            // 
            this.Now_Dec_X.AutoSize = true;
            this.Now_Dec_X.Location = new System.Drawing.Point(3, 70);
            this.Now_Dec_X.Name = "Now_Dec_X";
            this.Now_Dec_X.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Dec_X.Size = new System.Drawing.Size(35, 47);
            this.Now_Dec_X.TabIndex = 27;
            this.Now_Dec_X.Text = "Null";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(5, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 15);
            this.label18.TabIndex = 25;
            this.label18.Text = "名稱";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(5, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 15);
            this.label20.TabIndex = 26;
            this.label20.Text = "當前數值";
            // 
            // timecount
            // 
            this.timecount.AutoSize = true;
            this.timecount.Location = new System.Drawing.Point(997, 622);
            this.timecount.Name = "timecount";
            this.timecount.Size = new System.Drawing.Size(32, 15);
            this.timecount.TabIndex = 34;
            this.timecount.Text = "Null";
            // 
            // panelX
            // 
            this.panelX.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelX.Controls.Add(this.Home_Reset_X);
            this.panelX.Controls.Add(this.Run_value);
            this.panelX.Controls.Add(this.GoTo_value);
            this.panelX.Controls.Add(this.Move_value);
            this.panelX.Controls.Add(this.Stop);
            this.panelX.Controls.Add(this.Move_X);
            this.panelX.Controls.Add(this.Run);
            this.panelX.Controls.Add(this.GoTo);
            this.panelX.Controls.Add(this.panel3);
            this.panelX.Controls.Add(this.Gohome);
            this.panelX.Location = new System.Drawing.Point(5, 5);
            this.panelX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelX.Name = "panelX";
            this.panelX.Size = new System.Drawing.Size(540, 222);
            this.panelX.TabIndex = 23;
            // 
            // Home_Reset_X
            // 
            this.Home_Reset_X.Location = new System.Drawing.Point(140, 90);
            this.Home_Reset_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_X.Name = "Home_Reset_X";
            this.Home_Reset_X.Size = new System.Drawing.Size(105, 48);
            this.Home_Reset_X.TabIndex = 55;
            this.Home_Reset_X.Text = "Home_Rest";
            this.Home_Reset_X.UseVisualStyleBackColor = true;
            this.Home_Reset_X.Click += new System.EventHandler(this.Home_Reset_X_Click);
            // 
            // Run_value
            // 
            this.Run_value.Location = new System.Drawing.Point(7, 191);
            this.Run_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Run_value.Name = "Run_value";
            this.Run_value.Size = new System.Drawing.Size(107, 25);
            this.Run_value.TabIndex = 37;
            this.Run_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GoTo_value
            // 
            this.GoTo_value.Location = new System.Drawing.Point(165, 59);
            this.GoTo_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo_value.Name = "GoTo_value";
            this.GoTo_value.Size = new System.Drawing.Size(101, 25);
            this.GoTo_value.TabIndex = 36;
            this.GoTo_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Move_value
            // 
            this.Move_value.Location = new System.Drawing.Point(3, 59);
            this.Move_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Move_value.Name = "Move_value";
            this.Move_value.Size = new System.Drawing.Size(152, 25);
            this.Move_value.TabIndex = 30;
            this.Move_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(284, 5);
            this.Stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(199, 52);
            this.Stop.TabIndex = 22;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(7, 142);
            this.Run.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(107, 45);
            this.Run.TabIndex = 33;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // GoTo
            // 
            this.GoTo.Location = new System.Drawing.Point(167, 5);
            this.GoTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo.Name = "GoTo";
            this.GoTo.Size = new System.Drawing.Size(100, 50);
            this.GoTo.TabIndex = 32;
            this.GoTo.Text = "GoTo";
            this.GoTo.UseVisualStyleBackColor = true;
            this.GoTo.Click += new System.EventHandler(this.GoTo_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.HardHiZ);
            this.panel3.Controls.Add(this.SoftHiZ);
            this.panel3.Controls.Add(this.HardStop);
            this.panel3.Controls.Add(this.SoftStop);
            this.panel3.Location = new System.Drawing.Point(287, 66);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 53);
            this.panel3.TabIndex = 31;
            // 
            // HardHiZ
            // 
            this.HardHiZ.AutoSize = true;
            this.HardHiZ.Location = new System.Drawing.Point(5, 28);
            this.HardHiZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardHiZ.Name = "HardHiZ";
            this.HardHiZ.Size = new System.Drawing.Size(87, 21);
            this.HardHiZ.TabIndex = 28;
            this.HardHiZ.TabStop = true;
            this.HardHiZ.Text = "HardHiZ";
            this.HardHiZ.UseVisualStyleBackColor = true;
            // 
            // SoftHiZ
            // 
            this.SoftHiZ.AutoSize = true;
            this.SoftHiZ.Location = new System.Drawing.Point(101, 2);
            this.SoftHiZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftHiZ.Name = "SoftHiZ";
            this.SoftHiZ.Size = new System.Drawing.Size(79, 21);
            this.SoftHiZ.TabIndex = 27;
            this.SoftHiZ.TabStop = true;
            this.SoftHiZ.Text = "SoftHiZ";
            this.SoftHiZ.UseVisualStyleBackColor = true;
            // 
            // HardStop
            // 
            this.HardStop.AutoSize = true;
            this.HardStop.Location = new System.Drawing.Point(5, 6);
            this.HardStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardStop.Name = "HardStop";
            this.HardStop.Size = new System.Drawing.Size(91, 21);
            this.HardStop.TabIndex = 25;
            this.HardStop.TabStop = true;
            this.HardStop.Text = "HardStop";
            this.HardStop.UseVisualStyleBackColor = true;
            // 
            // SoftStop
            // 
            this.SoftStop.AutoSize = true;
            this.SoftStop.Location = new System.Drawing.Point(101, 29);
            this.SoftStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftStop.Name = "SoftStop";
            this.SoftStop.Size = new System.Drawing.Size(83, 21);
            this.SoftStop.TabIndex = 26;
            this.SoftStop.TabStop = true;
            this.SoftStop.Text = "SoftStop";
            this.SoftStop.UseVisualStyleBackColor = true;
            // 
            // Gohome
            // 
            this.Gohome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Gohome.Location = new System.Drawing.Point(7, 85);
            this.Gohome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gohome.Name = "Gohome";
            this.Gohome.Size = new System.Drawing.Size(107, 48);
            this.Gohome.TabIndex = 29;
            this.Gohome.Text = "Gohome";
            this.Gohome.UseVisualStyleBackColor = true;
            this.Gohome.Click += new System.EventHandler(this.Gohome_Click);
            // 
            // SETPAN
            // 
            this.SETPAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SETPAN.Controls.Add(this.label3);
            this.SETPAN.Controls.Add(this.comname);
            this.SETPAN.Controls.Add(this.label4);
            this.SETPAN.Controls.Add(this.comrate);
            this.SETPAN.Controls.Add(this.label5);
            this.SETPAN.Controls.Add(this.comstop);
            this.SETPAN.Controls.Add(this.label6);
            this.SETPAN.Controls.Add(this.comdata);
            this.SETPAN.Controls.Add(this.Confirmbtn);
            this.SETPAN.Controls.Add(this.Cancelbtn);
            this.SETPAN.Location = new System.Drawing.Point(23, 52);
            this.SETPAN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SETPAN.Name = "SETPAN";
            this.SETPAN.Size = new System.Drawing.Size(239, 150);
            this.SETPAN.TabIndex = 21;
            this.SETPAN.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "COM:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comname
            // 
            this.comname.FormattingEnabled = true;
            this.comname.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40"});
            this.comname.Location = new System.Drawing.Point(109, 2);
            this.comname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comname.Name = "comname";
            this.comname.Size = new System.Drawing.Size(121, 23);
            this.comname.TabIndex = 1;
            this.comname.Text = "4";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Baudrate:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comrate
            // 
            this.comrate.FormattingEnabled = true;
            this.comrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "31250",
            "38400",
            "57600",
            "115200"});
            this.comrate.Location = new System.Drawing.Point(109, 29);
            this.comrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comrate.Name = "comrate";
            this.comrate.Size = new System.Drawing.Size(121, 23);
            this.comrate.TabIndex = 3;
            this.comrate.Text = "115200";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "StopBits:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comstop
            // 
            this.comstop.FormattingEnabled = true;
            this.comstop.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.comstop.Location = new System.Drawing.Point(109, 56);
            this.comstop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comstop.Name = "comstop";
            this.comstop.Size = new System.Drawing.Size(121, 23);
            this.comstop.TabIndex = 7;
            this.comstop.Text = "1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Databits:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comdata
            // 
            this.comdata.FormattingEnabled = true;
            this.comdata.Items.AddRange(new object[] {
            "8",
            "16",
            "24",
            "32",
            "40",
            "48",
            "56"});
            this.comdata.Location = new System.Drawing.Point(109, 83);
            this.comdata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comdata.Name = "comdata";
            this.comdata.Size = new System.Drawing.Size(121, 23);
            this.comdata.TabIndex = 9;
            this.comdata.Text = "8";
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Location = new System.Drawing.Point(3, 110);
            this.Confirmbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(109, 22);
            this.Confirmbtn.TabIndex = 4;
            this.Confirmbtn.Text = "確認";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(118, 110);
            this.Cancelbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(111, 22);
            this.Cancelbtn.TabIndex = 5;
            this.Cancelbtn.Text = "取消";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // SETBTN
            // 
            this.SETBTN.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SETBTN.Location = new System.Drawing.Point(23, 11);
            this.SETBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SETBTN.Name = "SETBTN";
            this.SETBTN.Size = new System.Drawing.Size(87, 32);
            this.SETBTN.TabIndex = 22;
            this.SETBTN.Text = "Setting";
            this.SETBTN.UseVisualStyleBackColor = true;
            this.SETBTN.Click += new System.EventHandler(this.SETBTN_Click);
            // 
            // GetStatus_Y
            // 
            this.GetStatus_Y.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetStatus_Y.Location = new System.Drawing.Point(5, 76);
            this.GetStatus_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetStatus_Y.Name = "GetStatus_Y";
            this.GetStatus_Y.Size = new System.Drawing.Size(120, 45);
            this.GetStatus_Y.TabIndex = 41;
            this.GetStatus_Y.Text = "GetStatus_Y";
            this.GetStatus_Y.UseVisualStyleBackColor = true;
            this.GetStatus_Y.Click += new System.EventHandler(this.GetStatus_Y_Click);
            // 
            // panel43
            // 
            this.panel43.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel43.Controls.Add(this.STEPLOSS_B_Flag_Y);
            this.panel43.Controls.Add(this.STEPLOSS_A_Flag_Y);
            this.panel43.Controls.Add(this.TH_SD_Flag_Y);
            this.panel43.Controls.Add(this.OCD_Flag_Y);
            this.panel43.Controls.Add(this.TH_WRN_Flag_Y);
            this.panel43.Controls.Add(this.motionY);
            this.panel43.Controls.Add(this.WRONG_Flag_Y);
            this.panel43.Controls.Add(this.UVLO_Flag_Y);
            this.panel43.Controls.Add(this.DIR_Flag_Y);
            this.panel43.Controls.Add(this.HIZ_Flag_Y);
            this.panel43.Controls.Add(this.BUSY_Flag_Y);
            this.panel43.Controls.Add(this.NOTPERF_Flag_Y);
            this.panel43.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel43.Location = new System.Drawing.Point(7, 52);
            this.panel43.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(81, 373);
            this.panel43.TabIndex = 31;
            // 
            // STEPLOSS_B_Flag_Y
            // 
            this.STEPLOSS_B_Flag_Y.AutoSize = true;
            this.STEPLOSS_B_Flag_Y.Location = new System.Drawing.Point(5, 342);
            this.STEPLOSS_B_Flag_Y.Name = "STEPLOSS_B_Flag_Y";
            this.STEPLOSS_B_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_B_Flag_Y.TabIndex = 38;
            this.STEPLOSS_B_Flag_Y.Text = "Null";
            // 
            // STEPLOSS_A_Flag_Y
            // 
            this.STEPLOSS_A_Flag_Y.AutoSize = true;
            this.STEPLOSS_A_Flag_Y.Location = new System.Drawing.Point(5, 312);
            this.STEPLOSS_A_Flag_Y.Name = "STEPLOSS_A_Flag_Y";
            this.STEPLOSS_A_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_A_Flag_Y.TabIndex = 36;
            this.STEPLOSS_A_Flag_Y.Text = "Null";
            // 
            // TH_SD_Flag_Y
            // 
            this.TH_SD_Flag_Y.AutoSize = true;
            this.TH_SD_Flag_Y.Location = new System.Drawing.Point(4, 252);
            this.TH_SD_Flag_Y.Name = "TH_SD_Flag_Y";
            this.TH_SD_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.TH_SD_Flag_Y.TabIndex = 34;
            this.TH_SD_Flag_Y.Text = "Null";
            // 
            // OCD_Flag_Y
            // 
            this.OCD_Flag_Y.AutoSize = true;
            this.OCD_Flag_Y.Location = new System.Drawing.Point(5, 282);
            this.OCD_Flag_Y.Name = "OCD_Flag_Y";
            this.OCD_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.OCD_Flag_Y.TabIndex = 35;
            this.OCD_Flag_Y.Text = "Null";
            // 
            // TH_WRN_Flag_Y
            // 
            this.TH_WRN_Flag_Y.AutoSize = true;
            this.TH_WRN_Flag_Y.Location = new System.Drawing.Point(4, 222);
            this.TH_WRN_Flag_Y.Name = "TH_WRN_Flag_Y";
            this.TH_WRN_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.TH_WRN_Flag_Y.TabIndex = 33;
            this.TH_WRN_Flag_Y.Text = "Null";
            // 
            // motionY
            // 
            this.motionY.AutoSize = true;
            this.motionY.Location = new System.Drawing.Point(4, 109);
            this.motionY.Name = "motionY";
            this.motionY.Size = new System.Drawing.Size(24, 17);
            this.motionY.TabIndex = 42;
            this.motionY.Text = "??";
            // 
            // WRONG_Flag_Y
            // 
            this.WRONG_Flag_Y.AutoSize = true;
            this.WRONG_Flag_Y.Location = new System.Drawing.Point(3, 162);
            this.WRONG_Flag_Y.Name = "WRONG_Flag_Y";
            this.WRONG_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.WRONG_Flag_Y.TabIndex = 30;
            this.WRONG_Flag_Y.Text = "Null";
            // 
            // UVLO_Flag_Y
            // 
            this.UVLO_Flag_Y.AutoSize = true;
            this.UVLO_Flag_Y.Location = new System.Drawing.Point(4, 192);
            this.UVLO_Flag_Y.Name = "UVLO_Flag_Y";
            this.UVLO_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.UVLO_Flag_Y.TabIndex = 32;
            this.UVLO_Flag_Y.Text = "Null";
            // 
            // DIR_Flag_Y
            // 
            this.DIR_Flag_Y.AutoSize = true;
            this.DIR_Flag_Y.Location = new System.Drawing.Point(3, 78);
            this.DIR_Flag_Y.Name = "DIR_Flag_Y";
            this.DIR_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.DIR_Flag_Y.TabIndex = 29;
            this.DIR_Flag_Y.Text = "Null";
            // 
            // HIZ_Flag_Y
            // 
            this.HIZ_Flag_Y.AutoSize = true;
            this.HIZ_Flag_Y.Location = new System.Drawing.Point(3, 14);
            this.HIZ_Flag_Y.Name = "HIZ_Flag_Y";
            this.HIZ_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.HIZ_Flag_Y.TabIndex = 25;
            this.HIZ_Flag_Y.Text = "Null";
            // 
            // BUSY_Flag_Y
            // 
            this.BUSY_Flag_Y.AutoSize = true;
            this.BUSY_Flag_Y.Location = new System.Drawing.Point(3, 48);
            this.BUSY_Flag_Y.Name = "BUSY_Flag_Y";
            this.BUSY_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.BUSY_Flag_Y.TabIndex = 26;
            this.BUSY_Flag_Y.Text = "Null";
            // 
            // NOTPERF_Flag_Y
            // 
            this.NOTPERF_Flag_Y.AutoSize = true;
            this.NOTPERF_Flag_Y.Location = new System.Drawing.Point(3, 132);
            this.NOTPERF_Flag_Y.Name = "NOTPERF_Flag_Y";
            this.NOTPERF_Flag_Y.Size = new System.Drawing.Size(35, 17);
            this.NOTPERF_Flag_Y.TabIndex = 27;
            this.NOTPERF_Flag_Y.Text = "Null";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label176.Location = new System.Drawing.Point(9, 35);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(71, 15);
            this.label176.TabIndex = 26;
            this.label176.Text = "當前狀態";
            // 
            // Now_Status_Y
            // 
            this.Now_Status_Y.AutoSize = true;
            this.Now_Status_Y.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Now_Status_Y.Location = new System.Drawing.Point(3, 245);
            this.Now_Status_Y.Name = "Now_Status_Y";
            this.Now_Status_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Status_Y.Size = new System.Drawing.Size(16, 47);
            this.Now_Status_Y.TabIndex = 36;
            this.Now_Status_Y.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(124, 28);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 20);
            this.label23.TabIndex = 9;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel19.Controls.Add(this.Now_Status_Y);
            this.panel19.Controls.Add(this.label90);
            this.panel19.Controls.Add(this.Now_StepMode_Y);
            this.panel19.Controls.Add(this.Now_MAXSpeed_Y);
            this.panel19.Controls.Add(this.Now_MINSpeed_Y);
            this.panel19.Controls.Add(this.Now_Speed_Y);
            this.panel19.Controls.Add(this.Now_Dec_Y);
            this.panel19.Controls.Add(this.Now_Acc_Y);
            this.panel19.Controls.Add(this.Now_ABS_Y);
            this.panel19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel19.Location = new System.Drawing.Point(5, 51);
            this.panel19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(95, 296);
            this.panel19.TabIndex = 57;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(29, 105);
            this.label90.Name = "label90";
            this.label90.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.label90.Size = new System.Drawing.Size(47, 47);
            this.label90.TabIndex = 70;
            this.label90.Text = "step/s";
            // 
            // Now_StepMode_Y
            // 
            this.Now_StepMode_Y.AutoSize = true;
            this.Now_StepMode_Y.Location = new System.Drawing.Point(3, 210);
            this.Now_StepMode_Y.Name = "Now_StepMode_Y";
            this.Now_StepMode_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_StepMode_Y.Size = new System.Drawing.Size(35, 47);
            this.Now_StepMode_Y.TabIndex = 35;
            this.Now_StepMode_Y.Text = "Null";
            // 
            // Now_MAXSpeed_Y
            // 
            this.Now_MAXSpeed_Y.AutoSize = true;
            this.Now_MAXSpeed_Y.Location = new System.Drawing.Point(3, 175);
            this.Now_MAXSpeed_Y.Name = "Now_MAXSpeed_Y";
            this.Now_MAXSpeed_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MAXSpeed_Y.Size = new System.Drawing.Size(35, 47);
            this.Now_MAXSpeed_Y.TabIndex = 34;
            this.Now_MAXSpeed_Y.Text = "Null";
            // 
            // Now_MINSpeed_Y
            // 
            this.Now_MINSpeed_Y.AutoSize = true;
            this.Now_MINSpeed_Y.Location = new System.Drawing.Point(3, 140);
            this.Now_MINSpeed_Y.Name = "Now_MINSpeed_Y";
            this.Now_MINSpeed_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MINSpeed_Y.Size = new System.Drawing.Size(35, 47);
            this.Now_MINSpeed_Y.TabIndex = 33;
            this.Now_MINSpeed_Y.Text = "Null";
            // 
            // Now_Speed_Y
            // 
            this.Now_Speed_Y.AutoSize = true;
            this.Now_Speed_Y.Location = new System.Drawing.Point(0, 105);
            this.Now_Speed_Y.Name = "Now_Speed_Y";
            this.Now_Speed_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Speed_Y.Size = new System.Drawing.Size(20, 47);
            this.Now_Speed_Y.TabIndex = 32;
            this.Now_Speed_Y.Text = "0 ";
            // 
            // Now_Dec_Y
            // 
            this.Now_Dec_Y.AutoSize = true;
            this.Now_Dec_Y.Location = new System.Drawing.Point(3, 70);
            this.Now_Dec_Y.Name = "Now_Dec_Y";
            this.Now_Dec_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Dec_Y.Size = new System.Drawing.Size(35, 47);
            this.Now_Dec_Y.TabIndex = 31;
            this.Now_Dec_Y.Text = "Null";
            // 
            // Now_Acc_Y
            // 
            this.Now_Acc_Y.AutoSize = true;
            this.Now_Acc_Y.Location = new System.Drawing.Point(3, 35);
            this.Now_Acc_Y.Name = "Now_Acc_Y";
            this.Now_Acc_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Acc_Y.Size = new System.Drawing.Size(35, 47);
            this.Now_Acc_Y.TabIndex = 30;
            this.Now_Acc_Y.Text = "Null";
            // 
            // Now_ABS_Y
            // 
            this.Now_ABS_Y.AutoSize = true;
            this.Now_ABS_Y.Location = new System.Drawing.Point(3, 0);
            this.Now_ABS_Y.Name = "Now_ABS_Y";
            this.Now_ABS_Y.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_ABS_Y.Size = new System.Drawing.Size(35, 47);
            this.Now_ABS_Y.TabIndex = 26;
            this.Now_ABS_Y.Text = "Null";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label24.Location = new System.Drawing.Point(101, 28);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 15);
            this.label24.TabIndex = 34;
            this.label24.Text = "輸入";
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel18.Controls.Add(this.Out_MINSpeed_Y);
            this.panel18.Controls.Add(this.Out_Speed_Y);
            this.panel18.Controls.Add(this.Out_Dec_Y);
            this.panel18.Controls.Add(this.Out_MAXSpeed_Y);
            this.panel18.Controls.Add(this.Out_Acc_Y);
            this.panel18.Controls.Add(this.Out_StepMode_Y);
            this.panel18.Controls.Add(this.Out_ABS_Y);
            this.panel18.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel18.Location = new System.Drawing.Point(104, 51);
            this.panel18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(119, 296);
            this.panel18.TabIndex = 32;
            // 
            // Out_MINSpeed_Y
            // 
            this.Out_MINSpeed_Y.Location = new System.Drawing.Point(5, 150);
            this.Out_MINSpeed_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MINSpeed_Y.Name = "Out_MINSpeed_Y";
            this.Out_MINSpeed_Y.Size = new System.Drawing.Size(100, 25);
            this.Out_MINSpeed_Y.TabIndex = 25;
            this.Out_MINSpeed_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MINSpeed_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MINSpeed_Y_KeyDown);
            // 
            // Out_Speed_Y
            // 
            this.Out_Speed_Y.Location = new System.Drawing.Point(5, 115);
            this.Out_Speed_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Speed_Y.Name = "Out_Speed_Y";
            this.Out_Speed_Y.Size = new System.Drawing.Size(100, 25);
            this.Out_Speed_Y.TabIndex = 28;
            this.Out_Speed_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Speed_Y.Visible = false;
            this.Out_Speed_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Speed_Y_KeyDown);
            // 
            // Out_Dec_Y
            // 
            this.Out_Dec_Y.Location = new System.Drawing.Point(5, 80);
            this.Out_Dec_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Dec_Y.Name = "Out_Dec_Y";
            this.Out_Dec_Y.Size = new System.Drawing.Size(100, 25);
            this.Out_Dec_Y.TabIndex = 24;
            this.Out_Dec_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Dec_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Dec_Y_KeyDown);
            // 
            // Out_MAXSpeed_Y
            // 
            this.Out_MAXSpeed_Y.Location = new System.Drawing.Point(5, 185);
            this.Out_MAXSpeed_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MAXSpeed_Y.Name = "Out_MAXSpeed_Y";
            this.Out_MAXSpeed_Y.Size = new System.Drawing.Size(100, 25);
            this.Out_MAXSpeed_Y.TabIndex = 26;
            this.Out_MAXSpeed_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MAXSpeed_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MAXSpeed_Y_KeyDown);
            // 
            // Out_Acc_Y
            // 
            this.Out_Acc_Y.Location = new System.Drawing.Point(5, 45);
            this.Out_Acc_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Acc_Y.Name = "Out_Acc_Y";
            this.Out_Acc_Y.Size = new System.Drawing.Size(100, 25);
            this.Out_Acc_Y.TabIndex = 23;
            this.Out_Acc_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Acc_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Acc_Y_KeyDown);
            // 
            // Out_StepMode_Y
            // 
            this.Out_StepMode_Y.Location = new System.Drawing.Point(5, 220);
            this.Out_StepMode_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_StepMode_Y.Name = "Out_StepMode_Y";
            this.Out_StepMode_Y.Size = new System.Drawing.Size(100, 25);
            this.Out_StepMode_Y.TabIndex = 27;
            this.Out_StepMode_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_StepMode_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_StepMode_Y_KeyDown);
            // 
            // Out_ABS_Y
            // 
            this.Out_ABS_Y.Location = new System.Drawing.Point(5, 10);
            this.Out_ABS_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_ABS_Y.Name = "Out_ABS_Y";
            this.Out_ABS_Y.Size = new System.Drawing.Size(100, 25);
            this.Out_ABS_Y.TabIndex = 22;
            this.Out_ABS_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_ABS_Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_ABS_Y_KeyDown);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label42.Location = new System.Drawing.Point(11, 32);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(71, 15);
            this.label42.TabIndex = 26;
            this.label42.Text = "當前數值";
            // 
            // panelY
            // 
            this.panelY.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelY.Controls.Add(this.Home_Reset_Y);
            this.panelY.Controls.Add(this.GoTo_Y_value);
            this.panelY.Controls.Add(this.MoveY_value);
            this.panelY.Controls.Add(this.Stop_Y);
            this.panelY.Controls.Add(this.Move_Y);
            this.panelY.Controls.Add(this.GoTo_Y);
            this.panelY.Controls.Add(this.panel16);
            this.panelY.Controls.Add(this.Gohome_Y);
            this.panelY.Location = new System.Drawing.Point(5, 5);
            this.panelY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelY.Name = "panelY";
            this.panelY.Size = new System.Drawing.Size(540, 223);
            this.panelY.TabIndex = 23;
            // 
            // Home_Reset_Y
            // 
            this.Home_Reset_Y.Location = new System.Drawing.Point(5, 165);
            this.Home_Reset_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_Y.Name = "Home_Reset_Y";
            this.Home_Reset_Y.Size = new System.Drawing.Size(105, 48);
            this.Home_Reset_Y.TabIndex = 56;
            this.Home_Reset_Y.Text = "Home_Rest";
            this.Home_Reset_Y.UseVisualStyleBackColor = true;
            this.Home_Reset_Y.Click += new System.EventHandler(this.Home_Reset_Y_Click);
            // 
            // GoTo_Y_value
            // 
            this.GoTo_Y_value.Location = new System.Drawing.Point(165, 59);
            this.GoTo_Y_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo_Y_value.Name = "GoTo_Y_value";
            this.GoTo_Y_value.Size = new System.Drawing.Size(96, 25);
            this.GoTo_Y_value.TabIndex = 36;
            // 
            // MoveY_value
            // 
            this.MoveY_value.Location = new System.Drawing.Point(3, 59);
            this.MoveY_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveY_value.Name = "MoveY_value";
            this.MoveY_value.Size = new System.Drawing.Size(152, 25);
            this.MoveY_value.TabIndex = 30;
            // 
            // Stop_Y
            // 
            this.Stop_Y.Location = new System.Drawing.Point(277, 5);
            this.Stop_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Stop_Y.Name = "Stop_Y";
            this.Stop_Y.Size = new System.Drawing.Size(208, 52);
            this.Stop_Y.TabIndex = 22;
            this.Stop_Y.Text = "Stop";
            this.Stop_Y.UseVisualStyleBackColor = true;
            this.Stop_Y.Click += new System.EventHandler(this.Stop_Y_Click);
            // 
            // Move_Y
            // 
            this.Move_Y.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Move_Y.Location = new System.Drawing.Point(5, 5);
            this.Move_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Move_Y.Name = "Move_Y";
            this.Move_Y.Size = new System.Drawing.Size(149, 50);
            this.Move_Y.TabIndex = 0;
            this.Move_Y.Text = "Move";
            this.Move_Y.UseVisualStyleBackColor = true;
            this.Move_Y.Click += new System.EventHandler(this.Move_Y_Click);
            // 
            // GoTo_Y
            // 
            this.GoTo_Y.Location = new System.Drawing.Point(167, 5);
            this.GoTo_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo_Y.Name = "GoTo_Y";
            this.GoTo_Y.Size = new System.Drawing.Size(100, 50);
            this.GoTo_Y.TabIndex = 32;
            this.GoTo_Y.Text = "GoTo";
            this.GoTo_Y.UseVisualStyleBackColor = true;
            this.GoTo_Y.Click += new System.EventHandler(this.GoTo_Y_Click);
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.HardHiZ_Y);
            this.panel16.Controls.Add(this.SoftHiZ_Y);
            this.panel16.Controls.Add(this.HardStop_Y);
            this.panel16.Controls.Add(this.SoftStop_Y);
            this.panel16.Location = new System.Drawing.Point(277, 66);
            this.panel16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(207, 53);
            this.panel16.TabIndex = 31;
            // 
            // HardHiZ_Y
            // 
            this.HardHiZ_Y.AutoSize = true;
            this.HardHiZ_Y.Location = new System.Drawing.Point(5, 28);
            this.HardHiZ_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardHiZ_Y.Name = "HardHiZ_Y";
            this.HardHiZ_Y.Size = new System.Drawing.Size(87, 21);
            this.HardHiZ_Y.TabIndex = 28;
            this.HardHiZ_Y.TabStop = true;
            this.HardHiZ_Y.Text = "HardHiZ";
            this.HardHiZ_Y.UseVisualStyleBackColor = true;
            // 
            // SoftHiZ_Y
            // 
            this.SoftHiZ_Y.AutoSize = true;
            this.SoftHiZ_Y.Location = new System.Drawing.Point(115, 6);
            this.SoftHiZ_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftHiZ_Y.Name = "SoftHiZ_Y";
            this.SoftHiZ_Y.Size = new System.Drawing.Size(79, 21);
            this.SoftHiZ_Y.TabIndex = 27;
            this.SoftHiZ_Y.TabStop = true;
            this.SoftHiZ_Y.Text = "SoftHiZ";
            this.SoftHiZ_Y.UseVisualStyleBackColor = true;
            // 
            // HardStop_Y
            // 
            this.HardStop_Y.AutoSize = true;
            this.HardStop_Y.Location = new System.Drawing.Point(5, 6);
            this.HardStop_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardStop_Y.Name = "HardStop_Y";
            this.HardStop_Y.Size = new System.Drawing.Size(91, 21);
            this.HardStop_Y.TabIndex = 25;
            this.HardStop_Y.TabStop = true;
            this.HardStop_Y.Text = "HardStop";
            this.HardStop_Y.UseVisualStyleBackColor = true;
            // 
            // SoftStop_Y
            // 
            this.SoftStop_Y.AutoSize = true;
            this.SoftStop_Y.Location = new System.Drawing.Point(115, 28);
            this.SoftStop_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftStop_Y.Name = "SoftStop_Y";
            this.SoftStop_Y.Size = new System.Drawing.Size(83, 21);
            this.SoftStop_Y.TabIndex = 26;
            this.SoftStop_Y.TabStop = true;
            this.SoftStop_Y.Text = "SoftStop";
            this.SoftStop_Y.UseVisualStyleBackColor = true;
            // 
            // Gohome_Y
            // 
            this.Gohome_Y.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Gohome_Y.Location = new System.Drawing.Point(5, 101);
            this.Gohome_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gohome_Y.Name = "Gohome_Y";
            this.Gohome_Y.Size = new System.Drawing.Size(107, 48);
            this.Gohome_Y.TabIndex = 29;
            this.Gohome_Y.Text = "Gohome";
            this.Gohome_Y.UseVisualStyleBackColor = true;
            this.Gohome_Y.Click += new System.EventHandler(this.Gohome_Y_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(4, 193);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 15);
            this.label35.TabIndex = 32;
            this.label35.Text = "Null";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(4, 222);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 15);
            this.label33.TabIndex = 33;
            this.label33.Text = "Null";
            // 
            // panel40
            // 
            this.panel40.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel40.Controls.Add(this.STEPLOSS_B_Flag_Z);
            this.panel40.Controls.Add(this.STEPLOSS_A_Flag_Z);
            this.panel40.Controls.Add(this.TH_SD_Flag_Z);
            this.panel40.Controls.Add(this.OCD_Flag_Z);
            this.panel40.Controls.Add(this.TH_WRN_Flag_Z);
            this.panel40.Controls.Add(this.motionZ);
            this.panel40.Controls.Add(this.WRONG_Flag_Z);
            this.panel40.Controls.Add(this.UVLO_Flag_Z);
            this.panel40.Controls.Add(this.DIR_Flag_Z);
            this.panel40.Controls.Add(this.HIZ_Flag_Z);
            this.panel40.Controls.Add(this.BUSY_Flag_Z);
            this.panel40.Controls.Add(this.NOTPERF_Flag_Z);
            this.panel40.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel40.Location = new System.Drawing.Point(5, 52);
            this.panel40.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(81, 373);
            this.panel40.TabIndex = 31;
            // 
            // STEPLOSS_B_Flag_Z
            // 
            this.STEPLOSS_B_Flag_Z.AutoSize = true;
            this.STEPLOSS_B_Flag_Z.Location = new System.Drawing.Point(5, 342);
            this.STEPLOSS_B_Flag_Z.Name = "STEPLOSS_B_Flag_Z";
            this.STEPLOSS_B_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_B_Flag_Z.TabIndex = 38;
            this.STEPLOSS_B_Flag_Z.Text = "Null";
            // 
            // STEPLOSS_A_Flag_Z
            // 
            this.STEPLOSS_A_Flag_Z.AutoSize = true;
            this.STEPLOSS_A_Flag_Z.Location = new System.Drawing.Point(5, 312);
            this.STEPLOSS_A_Flag_Z.Name = "STEPLOSS_A_Flag_Z";
            this.STEPLOSS_A_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_A_Flag_Z.TabIndex = 36;
            this.STEPLOSS_A_Flag_Z.Text = "Null";
            // 
            // TH_SD_Flag_Z
            // 
            this.TH_SD_Flag_Z.AutoSize = true;
            this.TH_SD_Flag_Z.Location = new System.Drawing.Point(4, 252);
            this.TH_SD_Flag_Z.Name = "TH_SD_Flag_Z";
            this.TH_SD_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.TH_SD_Flag_Z.TabIndex = 34;
            this.TH_SD_Flag_Z.Text = "Null";
            // 
            // OCD_Flag_Z
            // 
            this.OCD_Flag_Z.AutoSize = true;
            this.OCD_Flag_Z.Location = new System.Drawing.Point(5, 282);
            this.OCD_Flag_Z.Name = "OCD_Flag_Z";
            this.OCD_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.OCD_Flag_Z.TabIndex = 35;
            this.OCD_Flag_Z.Text = "Null";
            // 
            // TH_WRN_Flag_Z
            // 
            this.TH_WRN_Flag_Z.AutoSize = true;
            this.TH_WRN_Flag_Z.Location = new System.Drawing.Point(4, 222);
            this.TH_WRN_Flag_Z.Name = "TH_WRN_Flag_Z";
            this.TH_WRN_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.TH_WRN_Flag_Z.TabIndex = 33;
            this.TH_WRN_Flag_Z.Text = "Null";
            // 
            // motionZ
            // 
            this.motionZ.AutoSize = true;
            this.motionZ.Location = new System.Drawing.Point(7, 108);
            this.motionZ.Name = "motionZ";
            this.motionZ.Size = new System.Drawing.Size(24, 17);
            this.motionZ.TabIndex = 45;
            this.motionZ.Text = "??";
            // 
            // WRONG_Flag_Z
            // 
            this.WRONG_Flag_Z.AutoSize = true;
            this.WRONG_Flag_Z.Location = new System.Drawing.Point(3, 162);
            this.WRONG_Flag_Z.Name = "WRONG_Flag_Z";
            this.WRONG_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.WRONG_Flag_Z.TabIndex = 30;
            this.WRONG_Flag_Z.Text = "Null";
            // 
            // UVLO_Flag_Z
            // 
            this.UVLO_Flag_Z.AutoSize = true;
            this.UVLO_Flag_Z.Location = new System.Drawing.Point(4, 192);
            this.UVLO_Flag_Z.Name = "UVLO_Flag_Z";
            this.UVLO_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.UVLO_Flag_Z.TabIndex = 32;
            this.UVLO_Flag_Z.Text = "Null";
            // 
            // DIR_Flag_Z
            // 
            this.DIR_Flag_Z.AutoSize = true;
            this.DIR_Flag_Z.Location = new System.Drawing.Point(3, 78);
            this.DIR_Flag_Z.Name = "DIR_Flag_Z";
            this.DIR_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.DIR_Flag_Z.TabIndex = 29;
            this.DIR_Flag_Z.Text = "Null";
            // 
            // HIZ_Flag_Z
            // 
            this.HIZ_Flag_Z.AutoSize = true;
            this.HIZ_Flag_Z.Location = new System.Drawing.Point(3, 14);
            this.HIZ_Flag_Z.Name = "HIZ_Flag_Z";
            this.HIZ_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.HIZ_Flag_Z.TabIndex = 25;
            this.HIZ_Flag_Z.Text = "Null";
            // 
            // BUSY_Flag_Z
            // 
            this.BUSY_Flag_Z.AutoSize = true;
            this.BUSY_Flag_Z.Location = new System.Drawing.Point(3, 48);
            this.BUSY_Flag_Z.Name = "BUSY_Flag_Z";
            this.BUSY_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.BUSY_Flag_Z.TabIndex = 26;
            this.BUSY_Flag_Z.Text = "Null";
            // 
            // NOTPERF_Flag_Z
            // 
            this.NOTPERF_Flag_Z.AutoSize = true;
            this.NOTPERF_Flag_Z.Location = new System.Drawing.Point(3, 132);
            this.NOTPERF_Flag_Z.Name = "NOTPERF_Flag_Z";
            this.NOTPERF_Flag_Z.Size = new System.Drawing.Size(35, 17);
            this.NOTPERF_Flag_Z.TabIndex = 27;
            this.NOTPERF_Flag_Z.Text = "Null";
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label150.Location = new System.Drawing.Point(5, 34);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(71, 15);
            this.label150.TabIndex = 26;
            this.label150.Text = "當前狀態";
            // 
            // GetStatus_Z
            // 
            this.GetStatus_Z.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetStatus_Z.Location = new System.Drawing.Point(127, 29);
            this.GetStatus_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetStatus_Z.Name = "GetStatus_Z";
            this.GetStatus_Z.Size = new System.Drawing.Size(120, 45);
            this.GetStatus_Z.TabIndex = 39;
            this.GetStatus_Z.Text = "GetStatus_Z";
            this.GetStatus_Z.UseVisualStyleBackColor = true;
            this.GetStatus_Z.Click += new System.EventHandler(this.GetStatus_Z_Click);
            // 
            // Now_Status_Z
            // 
            this.Now_Status_Z.AutoSize = true;
            this.Now_Status_Z.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Now_Status_Z.Location = new System.Drawing.Point(3, 245);
            this.Now_Status_Z.Name = "Now_Status_Z";
            this.Now_Status_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Status_Z.Size = new System.Drawing.Size(16, 47);
            this.Now_Status_Z.TabIndex = 36;
            this.Now_Status_Z.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(101, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "輸入";
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel22.Controls.Add(this.Out_ABS_Z);
            this.panel22.Controls.Add(this.Out_Acc_Z);
            this.panel22.Controls.Add(this.Out_MAXSpeed_Z);
            this.panel22.Controls.Add(this.Out_StepMode_Z);
            this.panel22.Controls.Add(this.Out_Dec_Z);
            this.panel22.Controls.Add(this.Out_Speed_Z);
            this.panel22.Controls.Add(this.Out_MINSpeed_Z);
            this.panel22.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel22.Location = new System.Drawing.Point(105, 51);
            this.panel22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(113, 296);
            this.panel22.TabIndex = 32;
            // 
            // Out_ABS_Z
            // 
            this.Out_ABS_Z.Location = new System.Drawing.Point(5, 10);
            this.Out_ABS_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_ABS_Z.Name = "Out_ABS_Z";
            this.Out_ABS_Z.Size = new System.Drawing.Size(100, 25);
            this.Out_ABS_Z.TabIndex = 10;
            this.Out_ABS_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_ABS_Z.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_ABS_Z_KeyDown);
            // 
            // Out_Acc_Z
            // 
            this.Out_Acc_Z.Location = new System.Drawing.Point(5, 45);
            this.Out_Acc_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Acc_Z.Name = "Out_Acc_Z";
            this.Out_Acc_Z.Size = new System.Drawing.Size(100, 25);
            this.Out_Acc_Z.TabIndex = 12;
            this.Out_Acc_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Acc_Z.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Acc_Z_KeyDown);
            // 
            // Out_MAXSpeed_Z
            // 
            this.Out_MAXSpeed_Z.Location = new System.Drawing.Point(5, 185);
            this.Out_MAXSpeed_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MAXSpeed_Z.Name = "Out_MAXSpeed_Z";
            this.Out_MAXSpeed_Z.Size = new System.Drawing.Size(100, 25);
            this.Out_MAXSpeed_Z.TabIndex = 16;
            this.Out_MAXSpeed_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MAXSpeed_Z.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MAXSpeed_Z_KeyDown);
            // 
            // Out_StepMode_Z
            // 
            this.Out_StepMode_Z.Location = new System.Drawing.Point(5, 220);
            this.Out_StepMode_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_StepMode_Z.Name = "Out_StepMode_Z";
            this.Out_StepMode_Z.Size = new System.Drawing.Size(100, 25);
            this.Out_StepMode_Z.TabIndex = 17;
            this.Out_StepMode_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_StepMode_Z.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_StepMode_Z_KeyDown);
            // 
            // Out_Dec_Z
            // 
            this.Out_Dec_Z.Location = new System.Drawing.Point(5, 80);
            this.Out_Dec_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Dec_Z.Name = "Out_Dec_Z";
            this.Out_Dec_Z.Size = new System.Drawing.Size(100, 25);
            this.Out_Dec_Z.TabIndex = 13;
            this.Out_Dec_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Dec_Z.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Dec_Z_KeyDown);
            // 
            // Out_Speed_Z
            // 
            this.Out_Speed_Z.Location = new System.Drawing.Point(5, 115);
            this.Out_Speed_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Speed_Z.Name = "Out_Speed_Z";
            this.Out_Speed_Z.Size = new System.Drawing.Size(100, 25);
            this.Out_Speed_Z.TabIndex = 21;
            this.Out_Speed_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Speed_Z.Visible = false;
            this.Out_Speed_Z.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Speed_Z_KeyDown);
            // 
            // Out_MINSpeed_Z
            // 
            this.Out_MINSpeed_Z.Location = new System.Drawing.Point(5, 150);
            this.Out_MINSpeed_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MINSpeed_Z.Name = "Out_MINSpeed_Z";
            this.Out_MINSpeed_Z.Size = new System.Drawing.Size(100, 25);
            this.Out_MINSpeed_Z.TabIndex = 15;
            this.Out_MINSpeed_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MINSpeed_Z.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MINSpeed_Z_KeyDown);
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel24.Controls.Add(this.Now_Status_Z);
            this.panel24.Controls.Add(this.label30);
            this.panel24.Controls.Add(this.Now_StepMode_Z);
            this.panel24.Controls.Add(this.Now_MINSpeed_Z);
            this.panel24.Controls.Add(this.Now_MAXSpeed_Z);
            this.panel24.Controls.Add(this.Now_Acc_Z);
            this.panel24.Controls.Add(this.Now_ABS_Z);
            this.panel24.Controls.Add(this.Now_Speed_Z);
            this.panel24.Controls.Add(this.Now_Dec_Z);
            this.panel24.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel24.Location = new System.Drawing.Point(7, 51);
            this.panel24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(95, 296);
            this.panel24.TabIndex = 31;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(29, 105);
            this.label30.Name = "label30";
            this.label30.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.label30.Size = new System.Drawing.Size(47, 47);
            this.label30.TabIndex = 69;
            this.label30.Text = "step/s";
            // 
            // Now_StepMode_Z
            // 
            this.Now_StepMode_Z.AutoSize = true;
            this.Now_StepMode_Z.Location = new System.Drawing.Point(3, 210);
            this.Now_StepMode_Z.Name = "Now_StepMode_Z";
            this.Now_StepMode_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_StepMode_Z.Size = new System.Drawing.Size(35, 47);
            this.Now_StepMode_Z.TabIndex = 33;
            this.Now_StepMode_Z.Text = "Null";
            // 
            // Now_MINSpeed_Z
            // 
            this.Now_MINSpeed_Z.AutoSize = true;
            this.Now_MINSpeed_Z.Location = new System.Drawing.Point(3, 140);
            this.Now_MINSpeed_Z.Name = "Now_MINSpeed_Z";
            this.Now_MINSpeed_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MINSpeed_Z.Size = new System.Drawing.Size(35, 47);
            this.Now_MINSpeed_Z.TabIndex = 30;
            this.Now_MINSpeed_Z.Text = "Null";
            // 
            // Now_MAXSpeed_Z
            // 
            this.Now_MAXSpeed_Z.AutoSize = true;
            this.Now_MAXSpeed_Z.Location = new System.Drawing.Point(3, 175);
            this.Now_MAXSpeed_Z.Name = "Now_MAXSpeed_Z";
            this.Now_MAXSpeed_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MAXSpeed_Z.Size = new System.Drawing.Size(35, 47);
            this.Now_MAXSpeed_Z.TabIndex = 32;
            this.Now_MAXSpeed_Z.Text = "Null";
            // 
            // Now_Acc_Z
            // 
            this.Now_Acc_Z.AutoSize = true;
            this.Now_Acc_Z.Location = new System.Drawing.Point(3, 35);
            this.Now_Acc_Z.Name = "Now_Acc_Z";
            this.Now_Acc_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Acc_Z.Size = new System.Drawing.Size(35, 47);
            this.Now_Acc_Z.TabIndex = 29;
            this.Now_Acc_Z.Text = "Null";
            // 
            // Now_ABS_Z
            // 
            this.Now_ABS_Z.AutoSize = true;
            this.Now_ABS_Z.Location = new System.Drawing.Point(3, 0);
            this.Now_ABS_Z.Name = "Now_ABS_Z";
            this.Now_ABS_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_ABS_Z.Size = new System.Drawing.Size(35, 47);
            this.Now_ABS_Z.TabIndex = 25;
            this.Now_ABS_Z.Text = "Null";
            // 
            // Now_Speed_Z
            // 
            this.Now_Speed_Z.AutoSize = true;
            this.Now_Speed_Z.Location = new System.Drawing.Point(0, 105);
            this.Now_Speed_Z.Name = "Now_Speed_Z";
            this.Now_Speed_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Speed_Z.Size = new System.Drawing.Size(20, 47);
            this.Now_Speed_Z.TabIndex = 28;
            this.Now_Speed_Z.Text = "0 ";
            // 
            // Now_Dec_Z
            // 
            this.Now_Dec_Z.AutoSize = true;
            this.Now_Dec_Z.Location = new System.Drawing.Point(3, 70);
            this.Now_Dec_Z.Name = "Now_Dec_Z";
            this.Now_Dec_Z.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Dec_Z.Size = new System.Drawing.Size(35, 47);
            this.Now_Dec_Z.TabIndex = 27;
            this.Now_Dec_Z.Text = "Null";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label47.Location = new System.Drawing.Point(7, 32);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(71, 15);
            this.label47.TabIndex = 26;
            this.label47.Text = "當前數值";
            // 
            // panelZ
            // 
            this.panelZ.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelZ.Controls.Add(this.Home_Reset_Z);
            this.panelZ.Controls.Add(this.GoTo_Z_value);
            this.panelZ.Controls.Add(this.MoveZ_value);
            this.panelZ.Controls.Add(this.Stop_Z);
            this.panelZ.Controls.Add(this.Move_Z);
            this.panelZ.Controls.Add(this.GoTo_Z);
            this.panelZ.Controls.Add(this.panel15);
            this.panelZ.Controls.Add(this.Gohome_Z);
            this.panelZ.Location = new System.Drawing.Point(5, 5);
            this.panelZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelZ.Name = "panelZ";
            this.panelZ.Size = new System.Drawing.Size(540, 228);
            this.panelZ.TabIndex = 23;
            // 
            // Home_Reset_Z
            // 
            this.Home_Reset_Z.Location = new System.Drawing.Point(9, 160);
            this.Home_Reset_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_Z.Name = "Home_Reset_Z";
            this.Home_Reset_Z.Size = new System.Drawing.Size(105, 48);
            this.Home_Reset_Z.TabIndex = 56;
            this.Home_Reset_Z.Text = "Home_Rest";
            this.Home_Reset_Z.UseVisualStyleBackColor = true;
            this.Home_Reset_Z.Click += new System.EventHandler(this.Home_Reset_Z_Click);
            // 
            // GoTo_Z_value
            // 
            this.GoTo_Z_value.Location = new System.Drawing.Point(165, 59);
            this.GoTo_Z_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo_Z_value.Name = "GoTo_Z_value";
            this.GoTo_Z_value.Size = new System.Drawing.Size(96, 25);
            this.GoTo_Z_value.TabIndex = 36;
            // 
            // MoveZ_value
            // 
            this.MoveZ_value.Location = new System.Drawing.Point(3, 59);
            this.MoveZ_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveZ_value.Name = "MoveZ_value";
            this.MoveZ_value.Size = new System.Drawing.Size(149, 25);
            this.MoveZ_value.TabIndex = 30;
            // 
            // Stop_Z
            // 
            this.Stop_Z.Location = new System.Drawing.Point(305, 5);
            this.Stop_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Stop_Z.Name = "Stop_Z";
            this.Stop_Z.Size = new System.Drawing.Size(205, 52);
            this.Stop_Z.TabIndex = 22;
            this.Stop_Z.Text = "Stop";
            this.Stop_Z.UseVisualStyleBackColor = true;
            this.Stop_Z.Click += new System.EventHandler(this.Stop_Z_Click);
            // 
            // Move_Z
            // 
            this.Move_Z.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Move_Z.Location = new System.Drawing.Point(5, 5);
            this.Move_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Move_Z.Name = "Move_Z";
            this.Move_Z.Size = new System.Drawing.Size(149, 50);
            this.Move_Z.TabIndex = 0;
            this.Move_Z.Text = "Move";
            this.Move_Z.UseVisualStyleBackColor = true;
            this.Move_Z.Click += new System.EventHandler(this.Move_Z_Click);
            // 
            // GoTo_Z
            // 
            this.GoTo_Z.Location = new System.Drawing.Point(167, 5);
            this.GoTo_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo_Z.Name = "GoTo_Z";
            this.GoTo_Z.Size = new System.Drawing.Size(100, 50);
            this.GoTo_Z.TabIndex = 32;
            this.GoTo_Z.Text = "GoTo";
            this.GoTo_Z.UseVisualStyleBackColor = true;
            this.GoTo_Z.Click += new System.EventHandler(this.GoTo_Z_Click);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.HardHiZ_Z);
            this.panel15.Controls.Add(this.SoftHiZ_Z);
            this.panel15.Controls.Add(this.HardStop_Z);
            this.panel15.Controls.Add(this.SoftStop_Z);
            this.panel15.Location = new System.Drawing.Point(305, 62);
            this.panel15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(206, 53);
            this.panel15.TabIndex = 31;
            // 
            // HardHiZ_Z
            // 
            this.HardHiZ_Z.AutoSize = true;
            this.HardHiZ_Z.Location = new System.Drawing.Point(5, 28);
            this.HardHiZ_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardHiZ_Z.Name = "HardHiZ_Z";
            this.HardHiZ_Z.Size = new System.Drawing.Size(87, 21);
            this.HardHiZ_Z.TabIndex = 28;
            this.HardHiZ_Z.TabStop = true;
            this.HardHiZ_Z.Text = "HardHiZ";
            this.HardHiZ_Z.UseVisualStyleBackColor = true;
            // 
            // SoftHiZ_Z
            // 
            this.SoftHiZ_Z.AutoSize = true;
            this.SoftHiZ_Z.Location = new System.Drawing.Point(115, 6);
            this.SoftHiZ_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftHiZ_Z.Name = "SoftHiZ_Z";
            this.SoftHiZ_Z.Size = new System.Drawing.Size(79, 21);
            this.SoftHiZ_Z.TabIndex = 27;
            this.SoftHiZ_Z.TabStop = true;
            this.SoftHiZ_Z.Text = "SoftHiZ";
            this.SoftHiZ_Z.UseVisualStyleBackColor = true;
            // 
            // HardStop_Z
            // 
            this.HardStop_Z.AutoSize = true;
            this.HardStop_Z.Location = new System.Drawing.Point(5, 6);
            this.HardStop_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardStop_Z.Name = "HardStop_Z";
            this.HardStop_Z.Size = new System.Drawing.Size(91, 21);
            this.HardStop_Z.TabIndex = 25;
            this.HardStop_Z.TabStop = true;
            this.HardStop_Z.Text = "HardStop";
            this.HardStop_Z.UseVisualStyleBackColor = true;
            // 
            // SoftStop_Z
            // 
            this.SoftStop_Z.AutoSize = true;
            this.SoftStop_Z.Location = new System.Drawing.Point(115, 28);
            this.SoftStop_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftStop_Z.Name = "SoftStop_Z";
            this.SoftStop_Z.Size = new System.Drawing.Size(83, 21);
            this.SoftStop_Z.TabIndex = 26;
            this.SoftStop_Z.TabStop = true;
            this.SoftStop_Z.Text = "SoftStop";
            this.SoftStop_Z.UseVisualStyleBackColor = true;
            // 
            // Gohome_Z
            // 
            this.Gohome_Z.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Gohome_Z.Location = new System.Drawing.Point(7, 102);
            this.Gohome_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gohome_Z.Name = "Gohome_Z";
            this.Gohome_Z.Size = new System.Drawing.Size(107, 48);
            this.Gohome_Z.TabIndex = 29;
            this.Gohome_Z.Text = "Gohome";
            this.Gohome_Z.UseVisualStyleBackColor = true;
            this.Gohome_Z.Click += new System.EventHandler(this.Gohome_Z_Click);
            // 
            // motionU
            // 
            this.motionU.AutoSize = true;
            this.motionU.Location = new System.Drawing.Point(5, 108);
            this.motionU.Name = "motionU";
            this.motionU.Size = new System.Drawing.Size(24, 17);
            this.motionU.TabIndex = 48;
            this.motionU.Text = "??";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 5);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 5;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Red;
            series5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.LabelForeColor = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "X";
            series6.BorderWidth = 5;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.Green;
            series6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.LabelForeColor = System.Drawing.Color.Green;
            series6.Legend = "Legend1";
            series6.Name = "Y";
            series7.BorderWidth = 5;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Color = System.Drawing.Color.Blue;
            series7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series7.LabelForeColor = System.Drawing.Color.Blue;
            series7.Legend = "Legend1";
            series7.Name = "Z";
            series8.BorderWidth = 5;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.Purple;
            series8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series8.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series8.LabelForeColor = System.Drawing.Color.Purple;
            series8.Legend = "Legend1";
            series8.Name = "U";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(1053, 561);
            this.chart1.TabIndex = 49;
            this.chart1.Text = "chart";
            title2.Name = "Title1";
            title2.Text = "速度曲線";
            this.chart1.Titles.Add(title2);
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseClick);
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseDoubleClick);
            // 
            // GetStatus_U
            // 
            this.GetStatus_U.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetStatus_U.Location = new System.Drawing.Point(127, 76);
            this.GetStatus_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetStatus_U.Name = "GetStatus_U";
            this.GetStatus_U.Size = new System.Drawing.Size(120, 45);
            this.GetStatus_U.TabIndex = 40;
            this.GetStatus_U.Text = "GetStatus_U";
            this.GetStatus_U.UseVisualStyleBackColor = true;
            this.GetStatus_U.Click += new System.EventHandler(this.GetStatus_U_Click);
            // 
            // Now_Status_U
            // 
            this.Now_Status_U.AutoSize = true;
            this.Now_Status_U.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Now_Status_U.Location = new System.Drawing.Point(3, 245);
            this.Now_Status_U.Name = "Now_Status_U";
            this.Now_Status_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Status_U.Size = new System.Drawing.Size(16, 47);
            this.Now_Status_U.TabIndex = 36;
            this.Now_Status_U.Text = "0";
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel34.Controls.Add(this.STEPLOSS_B_Flag_U);
            this.panel34.Controls.Add(this.STEPLOSS_A_Flag_U);
            this.panel34.Controls.Add(this.TH_SD_Flag_U);
            this.panel34.Controls.Add(this.OCD_Flag_U);
            this.panel34.Controls.Add(this.TH_WRN_Flag_U);
            this.panel34.Controls.Add(this.motionU);
            this.panel34.Controls.Add(this.WRONG_Flag_U);
            this.panel34.Controls.Add(this.UVLO_Flag_U);
            this.panel34.Controls.Add(this.DIR_Flag_U);
            this.panel34.Controls.Add(this.HIZ_Flag_U);
            this.panel34.Controls.Add(this.BUSY_Flag_U);
            this.panel34.Controls.Add(this.NOTPERF_Flag_U);
            this.panel34.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel34.Location = new System.Drawing.Point(5, 52);
            this.panel34.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(81, 373);
            this.panel34.TabIndex = 31;
            // 
            // STEPLOSS_B_Flag_U
            // 
            this.STEPLOSS_B_Flag_U.AutoSize = true;
            this.STEPLOSS_B_Flag_U.Location = new System.Drawing.Point(5, 342);
            this.STEPLOSS_B_Flag_U.Name = "STEPLOSS_B_Flag_U";
            this.STEPLOSS_B_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_B_Flag_U.TabIndex = 38;
            this.STEPLOSS_B_Flag_U.Text = "Null";
            // 
            // STEPLOSS_A_Flag_U
            // 
            this.STEPLOSS_A_Flag_U.AutoSize = true;
            this.STEPLOSS_A_Flag_U.Location = new System.Drawing.Point(5, 312);
            this.STEPLOSS_A_Flag_U.Name = "STEPLOSS_A_Flag_U";
            this.STEPLOSS_A_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.STEPLOSS_A_Flag_U.TabIndex = 36;
            this.STEPLOSS_A_Flag_U.Text = "Null";
            // 
            // TH_SD_Flag_U
            // 
            this.TH_SD_Flag_U.AutoSize = true;
            this.TH_SD_Flag_U.Location = new System.Drawing.Point(4, 252);
            this.TH_SD_Flag_U.Name = "TH_SD_Flag_U";
            this.TH_SD_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.TH_SD_Flag_U.TabIndex = 34;
            this.TH_SD_Flag_U.Text = "Null";
            // 
            // OCD_Flag_U
            // 
            this.OCD_Flag_U.AutoSize = true;
            this.OCD_Flag_U.Location = new System.Drawing.Point(5, 282);
            this.OCD_Flag_U.Name = "OCD_Flag_U";
            this.OCD_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.OCD_Flag_U.TabIndex = 35;
            this.OCD_Flag_U.Text = "Null";
            // 
            // TH_WRN_Flag_U
            // 
            this.TH_WRN_Flag_U.AutoSize = true;
            this.TH_WRN_Flag_U.Location = new System.Drawing.Point(4, 222);
            this.TH_WRN_Flag_U.Name = "TH_WRN_Flag_U";
            this.TH_WRN_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.TH_WRN_Flag_U.TabIndex = 33;
            this.TH_WRN_Flag_U.Text = "Null";
            // 
            // WRONG_Flag_U
            // 
            this.WRONG_Flag_U.AutoSize = true;
            this.WRONG_Flag_U.Location = new System.Drawing.Point(3, 162);
            this.WRONG_Flag_U.Name = "WRONG_Flag_U";
            this.WRONG_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.WRONG_Flag_U.TabIndex = 30;
            this.WRONG_Flag_U.Text = "Null";
            // 
            // UVLO_Flag_U
            // 
            this.UVLO_Flag_U.AutoSize = true;
            this.UVLO_Flag_U.Location = new System.Drawing.Point(4, 192);
            this.UVLO_Flag_U.Name = "UVLO_Flag_U";
            this.UVLO_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.UVLO_Flag_U.TabIndex = 32;
            this.UVLO_Flag_U.Text = "Null";
            // 
            // DIR_Flag_U
            // 
            this.DIR_Flag_U.AutoSize = true;
            this.DIR_Flag_U.Location = new System.Drawing.Point(3, 78);
            this.DIR_Flag_U.Name = "DIR_Flag_U";
            this.DIR_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.DIR_Flag_U.TabIndex = 29;
            this.DIR_Flag_U.Text = "Null";
            // 
            // HIZ_Flag_U
            // 
            this.HIZ_Flag_U.AutoSize = true;
            this.HIZ_Flag_U.Location = new System.Drawing.Point(3, 14);
            this.HIZ_Flag_U.Name = "HIZ_Flag_U";
            this.HIZ_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.HIZ_Flag_U.TabIndex = 25;
            this.HIZ_Flag_U.Text = "Null";
            // 
            // BUSY_Flag_U
            // 
            this.BUSY_Flag_U.AutoSize = true;
            this.BUSY_Flag_U.Location = new System.Drawing.Point(3, 48);
            this.BUSY_Flag_U.Name = "BUSY_Flag_U";
            this.BUSY_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.BUSY_Flag_U.TabIndex = 26;
            this.BUSY_Flag_U.Text = "Null";
            // 
            // NOTPERF_Flag_U
            // 
            this.NOTPERF_Flag_U.AutoSize = true;
            this.NOTPERF_Flag_U.Location = new System.Drawing.Point(3, 132);
            this.NOTPERF_Flag_U.Name = "NOTPERF_Flag_U";
            this.NOTPERF_Flag_U.Size = new System.Drawing.Size(35, 17);
            this.NOTPERF_Flag_U.TabIndex = 27;
            this.NOTPERF_Flag_U.Text = "Null";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label98.Location = new System.Drawing.Point(3, 34);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(71, 15);
            this.label98.TabIndex = 26;
            this.label98.Text = "當前狀態";
            // 
            // panelU
            // 
            this.panelU.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelU.Controls.Add(this.Home_Reset_U);
            this.panelU.Controls.Add(this.GoTo_U_value);
            this.panelU.Controls.Add(this.MoveU_value);
            this.panelU.Controls.Add(this.Stop_U);
            this.panelU.Controls.Add(this.Move_U);
            this.panelU.Controls.Add(this.GoTo_U);
            this.panelU.Controls.Add(this.panel27);
            this.panelU.Controls.Add(this.Gohome_U);
            this.panelU.Location = new System.Drawing.Point(5, 5);
            this.panelU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelU.Name = "panelU";
            this.panelU.Size = new System.Drawing.Size(540, 228);
            this.panelU.TabIndex = 23;
            // 
            // Home_Reset_U
            // 
            this.Home_Reset_U.Location = new System.Drawing.Point(9, 168);
            this.Home_Reset_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_U.Name = "Home_Reset_U";
            this.Home_Reset_U.Size = new System.Drawing.Size(105, 48);
            this.Home_Reset_U.TabIndex = 56;
            this.Home_Reset_U.Text = "Home_Rest";
            this.Home_Reset_U.UseVisualStyleBackColor = true;
            this.Home_Reset_U.Click += new System.EventHandler(this.Home_Reset_U_Click);
            // 
            // GoTo_U_value
            // 
            this.GoTo_U_value.Location = new System.Drawing.Point(165, 59);
            this.GoTo_U_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo_U_value.Name = "GoTo_U_value";
            this.GoTo_U_value.Size = new System.Drawing.Size(96, 25);
            this.GoTo_U_value.TabIndex = 36;
            // 
            // MoveU_value
            // 
            this.MoveU_value.Location = new System.Drawing.Point(3, 59);
            this.MoveU_value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoveU_value.Name = "MoveU_value";
            this.MoveU_value.Size = new System.Drawing.Size(149, 25);
            this.MoveU_value.TabIndex = 30;
            // 
            // Stop_U
            // 
            this.Stop_U.Location = new System.Drawing.Point(311, 5);
            this.Stop_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Stop_U.Name = "Stop_U";
            this.Stop_U.Size = new System.Drawing.Size(200, 52);
            this.Stop_U.TabIndex = 22;
            this.Stop_U.Text = "Stop";
            this.Stop_U.UseVisualStyleBackColor = true;
            this.Stop_U.Click += new System.EventHandler(this.Stop_U_Click);
            // 
            // Move_U
            // 
            this.Move_U.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Move_U.Location = new System.Drawing.Point(5, 5);
            this.Move_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Move_U.Name = "Move_U";
            this.Move_U.Size = new System.Drawing.Size(149, 50);
            this.Move_U.TabIndex = 0;
            this.Move_U.Text = "Move";
            this.Move_U.UseVisualStyleBackColor = true;
            this.Move_U.Click += new System.EventHandler(this.Move_U_Click);
            // 
            // GoTo_U
            // 
            this.GoTo_U.Location = new System.Drawing.Point(167, 5);
            this.GoTo_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoTo_U.Name = "GoTo_U";
            this.GoTo_U.Size = new System.Drawing.Size(100, 50);
            this.GoTo_U.TabIndex = 32;
            this.GoTo_U.Text = "GoTo";
            this.GoTo_U.UseVisualStyleBackColor = true;
            this.GoTo_U.Click += new System.EventHandler(this.GoTo_U_Click);
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel27.Controls.Add(this.HardHiZ_U);
            this.panel27.Controls.Add(this.SoftHiZ_U);
            this.panel27.Controls.Add(this.HardStop_U);
            this.panel27.Controls.Add(this.SoftStop_U);
            this.panel27.Location = new System.Drawing.Point(311, 68);
            this.panel27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(199, 53);
            this.panel27.TabIndex = 31;
            // 
            // HardHiZ_U
            // 
            this.HardHiZ_U.AutoSize = true;
            this.HardHiZ_U.Location = new System.Drawing.Point(5, 28);
            this.HardHiZ_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardHiZ_U.Name = "HardHiZ_U";
            this.HardHiZ_U.Size = new System.Drawing.Size(87, 21);
            this.HardHiZ_U.TabIndex = 28;
            this.HardHiZ_U.TabStop = true;
            this.HardHiZ_U.Text = "HardHiZ";
            this.HardHiZ_U.UseVisualStyleBackColor = true;
            // 
            // SoftHiZ_U
            // 
            this.SoftHiZ_U.AutoSize = true;
            this.SoftHiZ_U.Location = new System.Drawing.Point(115, 6);
            this.SoftHiZ_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftHiZ_U.Name = "SoftHiZ_U";
            this.SoftHiZ_U.Size = new System.Drawing.Size(79, 21);
            this.SoftHiZ_U.TabIndex = 27;
            this.SoftHiZ_U.TabStop = true;
            this.SoftHiZ_U.Text = "SoftHiZ";
            this.SoftHiZ_U.UseVisualStyleBackColor = true;
            // 
            // HardStop_U
            // 
            this.HardStop_U.AutoSize = true;
            this.HardStop_U.Location = new System.Drawing.Point(5, 6);
            this.HardStop_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardStop_U.Name = "HardStop_U";
            this.HardStop_U.Size = new System.Drawing.Size(91, 21);
            this.HardStop_U.TabIndex = 25;
            this.HardStop_U.TabStop = true;
            this.HardStop_U.Text = "HardStop";
            this.HardStop_U.UseVisualStyleBackColor = true;
            // 
            // SoftStop_U
            // 
            this.SoftStop_U.AutoSize = true;
            this.SoftStop_U.Location = new System.Drawing.Point(115, 28);
            this.SoftStop_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SoftStop_U.Name = "SoftStop_U";
            this.SoftStop_U.Size = new System.Drawing.Size(83, 21);
            this.SoftStop_U.TabIndex = 26;
            this.SoftStop_U.TabStop = true;
            this.SoftStop_U.Text = "SoftStop";
            this.SoftStop_U.UseVisualStyleBackColor = true;
            // 
            // Gohome_U
            // 
            this.Gohome_U.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Gohome_U.Location = new System.Drawing.Point(7, 109);
            this.Gohome_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gohome_U.Name = "Gohome_U";
            this.Gohome_U.Size = new System.Drawing.Size(107, 48);
            this.Gohome_U.TabIndex = 29;
            this.Gohome_U.Text = "Gohome";
            this.Gohome_U.UseVisualStyleBackColor = true;
            this.Gohome_U.Click += new System.EventHandler(this.Gohome_U_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "X軸",
            "Y軸",
            "Z軸",
            "U軸"});
            this.checkedListBox1.Location = new System.Drawing.Point(3, 2);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(87, 124);
            this.checkedListBox1.TabIndex = 53;
            // 
            // Multiple_GoHome
            // 
            this.Multiple_GoHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Multiple_GoHome.Location = new System.Drawing.Point(437, 68);
            this.Multiple_GoHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Multiple_GoHome.Name = "Multiple_GoHome";
            this.Multiple_GoHome.Size = new System.Drawing.Size(101, 52);
            this.Multiple_GoHome.TabIndex = 37;
            this.Multiple_GoHome.Text = "Gohome";
            this.Multiple_GoHome.UseVisualStyleBackColor = true;
            this.Multiple_GoHome.Click += new System.EventHandler(this.Multiple_GoHome_Click);
            // 
            // Multiple_Stop
            // 
            this.Multiple_Stop.Location = new System.Drawing.Point(437, 6);
            this.Multiple_Stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Multiple_Stop.Name = "Multiple_Stop";
            this.Multiple_Stop.Size = new System.Drawing.Size(100, 52);
            this.Multiple_Stop.TabIndex = 37;
            this.Multiple_Stop.Text = "Stop";
            this.Multiple_Stop.UseVisualStyleBackColor = true;
            this.Multiple_Stop.Click += new System.EventHandler(this.Multiple_Stop_Click);
            // 
            // RESET
            // 
            this.RESET.Location = new System.Drawing.Point(315, 139);
            this.RESET.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RESET.Name = "RESET";
            this.RESET.Size = new System.Drawing.Size(223, 48);
            this.RESET.TabIndex = 54;
            this.RESET.Text = "Home_RESET";
            this.RESET.UseVisualStyleBackColor = true;
            this.RESET.Click += new System.EventHandler(this.RESET_Click);
            // 
            // Timer2
            // 
            this.Timer2.Interval = 1000;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // tabControlX
            // 
            this.tabControlX.Controls.Add(this.X);
            this.tabControlX.Controls.Add(this.Y);
            this.tabControlX.Controls.Add(this.Z);
            this.tabControlX.Controls.Add(this.U);
            this.tabControlX.Controls.Add(this.tabPage1);
            this.tabControlX.Controls.Add(this.tabPage2);
            this.tabControlX.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlX.Location = new System.Drawing.Point(5, 34);
            this.tabControlX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlX.Name = "tabControlX";
            this.tabControlX.Padding = new System.Drawing.Point(5, 5);
            this.tabControlX.SelectedIndex = 0;
            this.tabControlX.Size = new System.Drawing.Size(563, 276);
            this.tabControlX.TabIndex = 57;
            // 
            // X
            // 
            this.X.BackColor = System.Drawing.Color.SkyBlue;
            this.X.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.X.Controls.Add(this.panelX);
            this.X.Location = new System.Drawing.Point(4, 30);
            this.X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X.Name = "X";
            this.X.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X.Size = new System.Drawing.Size(555, 242);
            this.X.TabIndex = 0;
            this.X.Text = "X";
            // 
            // Y
            // 
            this.Y.BackColor = System.Drawing.Color.SkyBlue;
            this.Y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Y.Controls.Add(this.panelY);
            this.Y.Location = new System.Drawing.Point(4, 30);
            this.Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y.Name = "Y";
            this.Y.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y.Size = new System.Drawing.Size(555, 242);
            this.Y.TabIndex = 1;
            this.Y.Text = "Y";
            // 
            // Z
            // 
            this.Z.BackColor = System.Drawing.Color.SkyBlue;
            this.Z.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Z.Controls.Add(this.panelZ);
            this.Z.Location = new System.Drawing.Point(4, 30);
            this.Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z.Name = "Z";
            this.Z.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z.Size = new System.Drawing.Size(555, 242);
            this.Z.TabIndex = 2;
            this.Z.Text = "Z";
            // 
            // U
            // 
            this.U.BackColor = System.Drawing.Color.SkyBlue;
            this.U.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.U.Controls.Add(this.panelU);
            this.U.Location = new System.Drawing.Point(4, 30);
            this.U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U.Name = "U";
            this.U.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U.Size = new System.Drawing.Size(555, 242);
            this.U.TabIndex = 3;
            this.U.Text = "U";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SkyBlue;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(555, 242);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "多軸";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.checkedListBox1);
            this.panel4.Controls.Add(this.Multiple_Move);
            this.panel4.Controls.Add(this.Multiple_GoHome);
            this.panel4.Controls.Add(this.Multiple_Stop);
            this.panel4.Controls.Add(this.Multiple_GoTo);
            this.panel4.Controls.Add(this.RESET);
            this.panel4.Location = new System.Drawing.Point(1, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 228);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.Prepare_Y_Value);
            this.panel5.Controls.Add(this.Prepare_U_Value);
            this.panel5.Controls.Add(this.Prepare_Z_Value);
            this.panel5.Controls.Add(this.Prepare_X_Value);
            this.panel5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(96, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(212, 192);
            this.panel5.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "U";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 60;
            this.label11.Text = "Z";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 17);
            this.label12.TabIndex = 61;
            this.label12.Text = "Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 17);
            this.label13.TabIndex = 62;
            this.label13.Text = "X";
            // 
            // Prepare_Y_Value
            // 
            this.Prepare_Y_Value.Location = new System.Drawing.Point(53, 66);
            this.Prepare_Y_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Prepare_Y_Value.Name = "Prepare_Y_Value";
            this.Prepare_Y_Value.Size = new System.Drawing.Size(145, 25);
            this.Prepare_Y_Value.TabIndex = 59;
            this.Prepare_Y_Value.Text = "0";
            this.Prepare_Y_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Prepare_U_Value
            // 
            this.Prepare_U_Value.Location = new System.Drawing.Point(53, 152);
            this.Prepare_U_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Prepare_U_Value.Name = "Prepare_U_Value";
            this.Prepare_U_Value.Size = new System.Drawing.Size(145, 25);
            this.Prepare_U_Value.TabIndex = 60;
            this.Prepare_U_Value.Text = "0";
            this.Prepare_U_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Prepare_Z_Value
            // 
            this.Prepare_Z_Value.Location = new System.Drawing.Point(53, 110);
            this.Prepare_Z_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Prepare_Z_Value.Name = "Prepare_Z_Value";
            this.Prepare_Z_Value.Size = new System.Drawing.Size(145, 25);
            this.Prepare_Z_Value.TabIndex = 61;
            this.Prepare_Z_Value.Text = "0";
            this.Prepare_Z_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Prepare_X_Value
            // 
            this.Prepare_X_Value.Location = new System.Drawing.Point(53, 16);
            this.Prepare_X_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Prepare_X_Value.Name = "Prepare_X_Value";
            this.Prepare_X_Value.Size = new System.Drawing.Size(145, 25);
            this.Prepare_X_Value.TabIndex = 42;
            this.Prepare_X_Value.Text = "0";
            this.Prepare_X_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Multiple_Move
            // 
            this.Multiple_Move.Location = new System.Drawing.Point(315, 64);
            this.Multiple_Move.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Multiple_Move.Name = "Multiple_Move";
            this.Multiple_Move.Size = new System.Drawing.Size(117, 52);
            this.Multiple_Move.TabIndex = 56;
            this.Multiple_Move.Text = "Move";
            this.Multiple_Move.UseVisualStyleBackColor = true;
            this.Multiple_Move.Click += new System.EventHandler(this.Multiple_Move_Click);
            // 
            // Multiple_GoTo
            // 
            this.Multiple_GoTo.Location = new System.Drawing.Point(315, 6);
            this.Multiple_GoTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Multiple_GoTo.Name = "Multiple_GoTo";
            this.Multiple_GoTo.Size = new System.Drawing.Size(117, 52);
            this.Multiple_GoTo.TabIndex = 55;
            this.Multiple_GoTo.Text = "GoTo";
            this.Multiple_GoTo.UseVisualStyleBackColor = true;
            this.Multiple_GoTo.Click += new System.EventHandler(this.Multiple_GoTo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label51);
            this.tabPage2.Controls.Add(this.Home_reset_Speed);
            this.tabPage2.Controls.Add(this.label50);
            this.tabPage2.Controls.Add(this.Home_Reset_step);
            this.tabPage2.Controls.Add(this.groupBox16);
            this.tabPage2.Controls.Add(this.groupBox15);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(555, 242);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "設定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label51.Location = new System.Drawing.Point(149, 175);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(103, 15);
            this.label51.TabIndex = 73;
            this.label51.Text = "復歸移動速度";
            // 
            // Home_reset_Speed
            // 
            this.Home_reset_Speed.Location = new System.Drawing.Point(149, 192);
            this.Home_reset_Speed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_reset_Speed.Name = "Home_reset_Speed";
            this.Home_reset_Speed.Size = new System.Drawing.Size(100, 25);
            this.Home_reset_Speed.TabIndex = 74;
            this.Home_reset_Speed.Text = "20";
            this.Home_reset_Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Home_reset_Speed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Home_reset_Speed_KeyDown);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label50.Location = new System.Drawing.Point(5, 175);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(103, 15);
            this.label50.TabIndex = 35;
            this.label50.Text = "復歸移動步數";
            // 
            // Home_Reset_step
            // 
            this.Home_Reset_step.Location = new System.Drawing.Point(5, 192);
            this.Home_Reset_step.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_step.Name = "Home_Reset_step";
            this.Home_Reset_step.Size = new System.Drawing.Size(100, 25);
            this.Home_Reset_step.TabIndex = 72;
            this.Home_Reset_step.Text = "20";
            this.Home_Reset_step.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Home_Reset_step.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Home_Reset_step_KeyDown);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.panel11);
            this.groupBox16.Controls.Add(this.label36);
            this.groupBox16.Controls.Add(this.panel12);
            this.groupBox16.Controls.Add(this.label41);
            this.groupBox16.Controls.Add(this.panel13);
            this.groupBox16.Controls.Add(this.label44);
            this.groupBox16.Controls.Add(this.panel14);
            this.groupBox16.Controls.Add(this.label45);
            this.groupBox16.Controls.Add(this.label46);
            this.groupBox16.Controls.Add(this.label49);
            this.groupBox16.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox16.Location = new System.Drawing.Point(283, 6);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Size = new System.Drawing.Size(267, 126);
            this.groupBox16.TabIndex = 71;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "復歸方向";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.Home_Reset_X_Dir_R);
            this.panel11.Controls.Add(this.Home_Reset_X_Dir_L);
            this.panel11.Location = new System.Drawing.Point(40, 55);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(38, 58);
            this.panel11.TabIndex = 56;
            // 
            // Home_Reset_X_Dir_R
            // 
            this.Home_Reset_X_Dir_R.AutoSize = true;
            this.Home_Reset_X_Dir_R.Location = new System.Drawing.Point(8, 32);
            this.Home_Reset_X_Dir_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_X_Dir_R.Name = "Home_Reset_X_Dir_R";
            this.Home_Reset_X_Dir_R.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_X_Dir_R.TabIndex = 27;
            this.Home_Reset_X_Dir_R.UseVisualStyleBackColor = true;
            // 
            // Home_Reset_X_Dir_L
            // 
            this.Home_Reset_X_Dir_L.AutoSize = true;
            this.Home_Reset_X_Dir_L.Checked = true;
            this.Home_Reset_X_Dir_L.Location = new System.Drawing.Point(8, 4);
            this.Home_Reset_X_Dir_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_X_Dir_L.Name = "Home_Reset_X_Dir_L";
            this.Home_Reset_X_Dir_L.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_X_Dir_L.TabIndex = 25;
            this.Home_Reset_X_Dir_L.TabStop = true;
            this.Home_Reset_X_Dir_L.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(40, 30);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(23, 23);
            this.label36.TabIndex = 63;
            this.label36.Text = "X";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.Home_Reset_Y_Dir_R);
            this.panel12.Controls.Add(this.Home_Reset_Y_Dir_L);
            this.panel12.Location = new System.Drawing.Point(100, 55);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(38, 58);
            this.panel12.TabIndex = 57;
            // 
            // Home_Reset_Y_Dir_R
            // 
            this.Home_Reset_Y_Dir_R.AutoSize = true;
            this.Home_Reset_Y_Dir_R.Location = new System.Drawing.Point(8, 32);
            this.Home_Reset_Y_Dir_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_Y_Dir_R.Name = "Home_Reset_Y_Dir_R";
            this.Home_Reset_Y_Dir_R.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_Y_Dir_R.TabIndex = 27;
            this.Home_Reset_Y_Dir_R.UseVisualStyleBackColor = true;
            // 
            // Home_Reset_Y_Dir_L
            // 
            this.Home_Reset_Y_Dir_L.AutoSize = true;
            this.Home_Reset_Y_Dir_L.Checked = true;
            this.Home_Reset_Y_Dir_L.Location = new System.Drawing.Point(8, 4);
            this.Home_Reset_Y_Dir_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_Y_Dir_L.Name = "Home_Reset_Y_Dir_L";
            this.Home_Reset_Y_Dir_L.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_Y_Dir_L.TabIndex = 25;
            this.Home_Reset_Y_Dir_L.TabStop = true;
            this.Home_Reset_Y_Dir_L.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(93, 30);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(23, 23);
            this.label41.TabIndex = 62;
            this.label41.Text = "Y";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.Home_Reset_Z_Dir_R);
            this.panel13.Controls.Add(this.Home_Reset_Z_Dir_L);
            this.panel13.Location = new System.Drawing.Point(160, 55);
            this.panel13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(38, 58);
            this.panel13.TabIndex = 57;
            // 
            // Home_Reset_Z_Dir_R
            // 
            this.Home_Reset_Z_Dir_R.AutoSize = true;
            this.Home_Reset_Z_Dir_R.Location = new System.Drawing.Point(8, 32);
            this.Home_Reset_Z_Dir_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_Z_Dir_R.Name = "Home_Reset_Z_Dir_R";
            this.Home_Reset_Z_Dir_R.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_Z_Dir_R.TabIndex = 27;
            this.Home_Reset_Z_Dir_R.UseVisualStyleBackColor = true;
            // 
            // Home_Reset_Z_Dir_L
            // 
            this.Home_Reset_Z_Dir_L.AutoSize = true;
            this.Home_Reset_Z_Dir_L.Checked = true;
            this.Home_Reset_Z_Dir_L.Location = new System.Drawing.Point(8, 4);
            this.Home_Reset_Z_Dir_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_Z_Dir_L.Name = "Home_Reset_Z_Dir_L";
            this.Home_Reset_Z_Dir_L.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_Z_Dir_L.TabIndex = 25;
            this.Home_Reset_Z_Dir_L.TabStop = true;
            this.Home_Reset_Z_Dir_L.UseVisualStyleBackColor = true;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(156, 30);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(23, 23);
            this.label44.TabIndex = 61;
            this.label44.Text = "Z";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.Home_Reset_U_Dir_R);
            this.panel14.Controls.Add(this.Home_Reset_U_Dir_L);
            this.panel14.Location = new System.Drawing.Point(220, 55);
            this.panel14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(38, 58);
            this.panel14.TabIndex = 57;
            // 
            // Home_Reset_U_Dir_R
            // 
            this.Home_Reset_U_Dir_R.AutoSize = true;
            this.Home_Reset_U_Dir_R.Location = new System.Drawing.Point(8, 32);
            this.Home_Reset_U_Dir_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_U_Dir_R.Name = "Home_Reset_U_Dir_R";
            this.Home_Reset_U_Dir_R.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_U_Dir_R.TabIndex = 27;
            this.Home_Reset_U_Dir_R.UseVisualStyleBackColor = true;
            // 
            // Home_Reset_U_Dir_L
            // 
            this.Home_Reset_U_Dir_L.AutoSize = true;
            this.Home_Reset_U_Dir_L.Checked = true;
            this.Home_Reset_U_Dir_L.Location = new System.Drawing.Point(8, 4);
            this.Home_Reset_U_Dir_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Home_Reset_U_Dir_L.Name = "Home_Reset_U_Dir_L";
            this.Home_Reset_U_Dir_L.Size = new System.Drawing.Size(17, 16);
            this.Home_Reset_U_Dir_L.TabIndex = 25;
            this.Home_Reset_U_Dir_L.TabStop = true;
            this.Home_Reset_U_Dir_L.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(216, 29);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(23, 23);
            this.label45.TabIndex = 60;
            this.label45.Text = "U";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(7, 56);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(35, 23);
            this.label46.TabIndex = 58;
            this.label46.Text = "左";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(8, 94);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(35, 23);
            this.label49.TabIndex = 59;
            this.label49.Text = "右";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.panel1);
            this.groupBox15.Controls.Add(this.label32);
            this.groupBox15.Controls.Add(this.panel10);
            this.groupBox15.Controls.Add(this.label19);
            this.groupBox15.Controls.Add(this.panel9);
            this.groupBox15.Controls.Add(this.label15);
            this.groupBox15.Controls.Add(this.panel2);
            this.groupBox15.Controls.Add(this.label9);
            this.groupBox15.Controls.Add(this.label1);
            this.groupBox15.Controls.Add(this.label7);
            this.groupBox15.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox15.Location = new System.Drawing.Point(5, 6);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox15.Size = new System.Drawing.Size(267, 126);
            this.groupBox15.TabIndex = 70;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "原點停止位置";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.HOME_X_R);
            this.panel1.Controls.Add(this.HOME_X_L);
            this.panel1.Location = new System.Drawing.Point(40, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(38, 58);
            this.panel1.TabIndex = 56;
            // 
            // HOME_X_R
            // 
            this.HOME_X_R.AutoSize = true;
            this.HOME_X_R.Location = new System.Drawing.Point(8, 32);
            this.HOME_X_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_X_R.Name = "HOME_X_R";
            this.HOME_X_R.Size = new System.Drawing.Size(17, 16);
            this.HOME_X_R.TabIndex = 27;
            this.HOME_X_R.UseVisualStyleBackColor = true;
            // 
            // HOME_X_L
            // 
            this.HOME_X_L.AutoSize = true;
            this.HOME_X_L.Checked = true;
            this.HOME_X_L.Location = new System.Drawing.Point(8, 4);
            this.HOME_X_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_X_L.Name = "HOME_X_L";
            this.HOME_X_L.Size = new System.Drawing.Size(17, 16);
            this.HOME_X_L.TabIndex = 25;
            this.HOME_X_L.TabStop = true;
            this.HOME_X_L.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(40, 30);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(23, 23);
            this.label32.TabIndex = 63;
            this.label32.Text = "X";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.HOME_Y_R);
            this.panel10.Controls.Add(this.HOME_Y_L);
            this.panel10.Location = new System.Drawing.Point(100, 55);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(38, 58);
            this.panel10.TabIndex = 57;
            // 
            // HOME_Y_R
            // 
            this.HOME_Y_R.AutoSize = true;
            this.HOME_Y_R.Location = new System.Drawing.Point(8, 32);
            this.HOME_Y_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_Y_R.Name = "HOME_Y_R";
            this.HOME_Y_R.Size = new System.Drawing.Size(17, 16);
            this.HOME_Y_R.TabIndex = 27;
            this.HOME_Y_R.UseVisualStyleBackColor = true;
            // 
            // HOME_Y_L
            // 
            this.HOME_Y_L.AutoSize = true;
            this.HOME_Y_L.Checked = true;
            this.HOME_Y_L.Location = new System.Drawing.Point(8, 4);
            this.HOME_Y_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_Y_L.Name = "HOME_Y_L";
            this.HOME_Y_L.Size = new System.Drawing.Size(17, 16);
            this.HOME_Y_L.TabIndex = 25;
            this.HOME_Y_L.TabStop = true;
            this.HOME_Y_L.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(93, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 23);
            this.label19.TabIndex = 62;
            this.label19.Text = "Y";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.HOME_Z_R);
            this.panel9.Controls.Add(this.HOME_Z_L);
            this.panel9.Location = new System.Drawing.Point(160, 55);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(38, 58);
            this.panel9.TabIndex = 57;
            // 
            // HOME_Z_R
            // 
            this.HOME_Z_R.AutoSize = true;
            this.HOME_Z_R.Location = new System.Drawing.Point(8, 32);
            this.HOME_Z_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_Z_R.Name = "HOME_Z_R";
            this.HOME_Z_R.Size = new System.Drawing.Size(17, 16);
            this.HOME_Z_R.TabIndex = 27;
            this.HOME_Z_R.UseVisualStyleBackColor = true;
            // 
            // HOME_Z_L
            // 
            this.HOME_Z_L.AutoSize = true;
            this.HOME_Z_L.Checked = true;
            this.HOME_Z_L.Location = new System.Drawing.Point(8, 4);
            this.HOME_Z_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_Z_L.Name = "HOME_Z_L";
            this.HOME_Z_L.Size = new System.Drawing.Size(17, 16);
            this.HOME_Z_L.TabIndex = 25;
            this.HOME_Z_L.TabStop = true;
            this.HOME_Z_L.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(156, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Z";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.HOME_U_R);
            this.panel2.Controls.Add(this.HOME_U_L);
            this.panel2.Location = new System.Drawing.Point(220, 55);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(38, 58);
            this.panel2.TabIndex = 57;
            // 
            // HOME_U_R
            // 
            this.HOME_U_R.AutoSize = true;
            this.HOME_U_R.Location = new System.Drawing.Point(8, 32);
            this.HOME_U_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_U_R.Name = "HOME_U_R";
            this.HOME_U_R.Size = new System.Drawing.Size(17, 16);
            this.HOME_U_R.TabIndex = 27;
            this.HOME_U_R.UseVisualStyleBackColor = true;
            // 
            // HOME_U_L
            // 
            this.HOME_U_L.AutoSize = true;
            this.HOME_U_L.Checked = true;
            this.HOME_U_L.Location = new System.Drawing.Point(8, 4);
            this.HOME_U_L.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HOME_U_L.Name = "HOME_U_L";
            this.HOME_U_L.Size = new System.Drawing.Size(17, 16);
            this.HOME_U_L.TabIndex = 25;
            this.HOME_U_L.TabStop = true;
            this.HOME_U_L.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 23);
            this.label9.TabIndex = 60;
            this.label9.Text = "U";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 23);
            this.label1.TabIndex = 58;
            this.label1.Text = "左";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 59;
            this.label7.Text = "右";
            // 
            // groupBoxX
            // 
            this.groupBoxX.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxX.Controls.Add(this.panel32);
            this.groupBoxX.Controls.Add(this.label77);
            this.groupBoxX.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBoxX.Location = new System.Drawing.Point(161, 31);
            this.groupBoxX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxX.Name = "groupBoxX";
            this.groupBoxX.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxX.Size = new System.Drawing.Size(99, 439);
            this.groupBoxX.TabIndex = 64;
            this.groupBoxX.TabStop = false;
            this.groupBoxX.Text = "X軸";
            // 
            // X_limit
            // 
            this.X_limit.BackColor = System.Drawing.Color.White;
            this.X_limit.Controls.Add(this.labe1x);
            this.X_limit.Controls.Add(this.label34);
            this.X_limit.Controls.Add(this.X_Lmax);
            this.X_limit.Controls.Add(this.X_home);
            this.X_limit.Controls.Add(this.labelx);
            this.X_limit.Controls.Add(this.X_Lmin);
            this.X_limit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_limit.Location = new System.Drawing.Point(5, 2);
            this.X_limit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X_limit.Name = "X_limit";
            this.X_limit.Padding = new System.Windows.Forms.Padding(5);
            this.X_limit.Size = new System.Drawing.Size(225, 115);
            this.X_limit.TabIndex = 59;
            this.X_limit.TabStop = false;
            this.X_limit.Text = "X_limit";
            // 
            // labe1x
            // 
            this.labe1x.AutoSize = true;
            this.labe1x.Location = new System.Drawing.Point(77, 22);
            this.labe1x.Name = "labe1x";
            this.labe1x.Size = new System.Drawing.Size(22, 19);
            this.labe1x.TabIndex = 61;
            this.labe1x.Text = "H";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label34.Location = new System.Drawing.Point(1, 22);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(25, 17);
            this.label34.TabIndex = 62;
            this.label34.Text = "L-";
            // 
            // X_Lmax
            // 
            this.X_Lmax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.X_Lmax.Image = global::HMI.limit_signal.white;
            this.X_Lmax.Location = new System.Drawing.Point(160, 45);
            this.X_Lmax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X_Lmax.Name = "X_Lmax";
            this.X_Lmax.Padding = new System.Windows.Forms.Padding(5);
            this.X_Lmax.Size = new System.Drawing.Size(60, 60);
            this.X_Lmax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.X_Lmax.TabIndex = 61;
            this.X_Lmax.TabStop = false;
            this.X_Lmax.Click += new System.EventHandler(this.X_Lmax_Click);
            // 
            // X_home
            // 
            this.X_home.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.X_home.Image = global::HMI.limit_signal.white;
            this.X_home.InitialImage = global::HMI.limit_signal.white;
            this.X_home.Location = new System.Drawing.Point(80, 45);
            this.X_home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X_home.Name = "X_home";
            this.X_home.Padding = new System.Windows.Forms.Padding(5);
            this.X_home.Size = new System.Drawing.Size(60, 60);
            this.X_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.X_home.TabIndex = 62;
            this.X_home.TabStop = false;
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(156, 22);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(30, 19);
            this.labelx.TabIndex = 60;
            this.labelx.Text = "L+";
            // 
            // X_Lmin
            // 
            this.X_Lmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.X_Lmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.X_Lmin.Image = global::HMI.limit_signal.white;
            this.X_Lmin.InitialImage = global::HMI.limit_signal.white;
            this.X_Lmin.Location = new System.Drawing.Point(5, 45);
            this.X_Lmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X_Lmin.Name = "X_Lmin";
            this.X_Lmin.Padding = new System.Windows.Forms.Padding(5);
            this.X_Lmin.Size = new System.Drawing.Size(60, 60);
            this.X_Lmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.X_Lmin.TabIndex = 60;
            this.X_Lmin.TabStop = false;
            this.X_Lmin.Click += new System.EventHandler(this.X_Lmin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.panel43);
            this.groupBox1.Controls.Add(this.label176);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(259, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(105, 439);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y軸";
            // 
            // Y_limit
            // 
            this.Y_limit.BackColor = System.Drawing.Color.White;
            this.Y_limit.Controls.Add(this.label86);
            this.Y_limit.Controls.Add(this.label87);
            this.Y_limit.Controls.Add(this.Y_Lmax);
            this.Y_limit.Controls.Add(this.Y_home);
            this.Y_limit.Controls.Add(this.label88);
            this.Y_limit.Controls.Add(this.Y_Lmin);
            this.Y_limit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y_limit.Location = new System.Drawing.Point(5, 122);
            this.Y_limit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y_limit.Name = "Y_limit";
            this.Y_limit.Padding = new System.Windows.Forms.Padding(5);
            this.Y_limit.Size = new System.Drawing.Size(225, 115);
            this.Y_limit.TabIndex = 63;
            this.Y_limit.TabStop = false;
            this.Y_limit.Text = "Y_limit";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(77, 22);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(22, 19);
            this.label86.TabIndex = 61;
            this.label86.Text = "H";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(1, 22);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(26, 19);
            this.label87.TabIndex = 62;
            this.label87.Text = "L-";
            // 
            // Y_Lmax
            // 
            this.Y_Lmax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Y_Lmax.Image = global::HMI.limit_signal.white;
            this.Y_Lmax.Location = new System.Drawing.Point(160, 45);
            this.Y_Lmax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y_Lmax.Name = "Y_Lmax";
            this.Y_Lmax.Padding = new System.Windows.Forms.Padding(5);
            this.Y_Lmax.Size = new System.Drawing.Size(60, 60);
            this.Y_Lmax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Y_Lmax.TabIndex = 61;
            this.Y_Lmax.TabStop = false;
            this.Y_Lmax.Click += new System.EventHandler(this.Y_Lmax_Click);
            // 
            // Y_home
            // 
            this.Y_home.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Y_home.Image = global::HMI.limit_signal.white;
            this.Y_home.Location = new System.Drawing.Point(80, 45);
            this.Y_home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y_home.Name = "Y_home";
            this.Y_home.Padding = new System.Windows.Forms.Padding(5);
            this.Y_home.Size = new System.Drawing.Size(60, 60);
            this.Y_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Y_home.TabIndex = 62;
            this.Y_home.TabStop = false;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(156, 22);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(30, 19);
            this.label88.TabIndex = 60;
            this.label88.Text = "L+";
            // 
            // Y_Lmin
            // 
            this.Y_Lmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Y_Lmin.Image = global::HMI.limit_signal.white;
            this.Y_Lmin.Location = new System.Drawing.Point(5, 45);
            this.Y_Lmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y_Lmin.Name = "Y_Lmin";
            this.Y_Lmin.Padding = new System.Windows.Forms.Padding(5);
            this.Y_Lmin.Size = new System.Drawing.Size(60, 60);
            this.Y_Lmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Y_Lmin.TabIndex = 60;
            this.Y_Lmin.TabStop = false;
            this.Y_Lmin.Click += new System.EventHandler(this.Y_Lmin_Click);
            // 
            // U_limit
            // 
            this.U_limit.BackColor = System.Drawing.Color.White;
            this.U_limit.Controls.Add(this.label38);
            this.U_limit.Controls.Add(this.label39);
            this.U_limit.Controls.Add(this.U_Lmax);
            this.U_limit.Controls.Add(this.U_home);
            this.U_limit.Controls.Add(this.label43);
            this.U_limit.Controls.Add(this.U_Lmin);
            this.U_limit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U_limit.Location = new System.Drawing.Point(9, 362);
            this.U_limit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_limit.Name = "U_limit";
            this.U_limit.Padding = new System.Windows.Forms.Padding(5);
            this.U_limit.Size = new System.Drawing.Size(225, 115);
            this.U_limit.TabIndex = 60;
            this.U_limit.TabStop = false;
            this.U_limit.Text = "U_limit";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(77, 22);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(22, 19);
            this.label38.TabIndex = 61;
            this.label38.Text = "H";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(1, 22);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(26, 19);
            this.label39.TabIndex = 62;
            this.label39.Text = "L-";
            // 
            // U_Lmax
            // 
            this.U_Lmax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.U_Lmax.Image = global::HMI.limit_signal.white;
            this.U_Lmax.Location = new System.Drawing.Point(160, 45);
            this.U_Lmax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_Lmax.Name = "U_Lmax";
            this.U_Lmax.Padding = new System.Windows.Forms.Padding(5);
            this.U_Lmax.Size = new System.Drawing.Size(60, 60);
            this.U_Lmax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.U_Lmax.TabIndex = 61;
            this.U_Lmax.TabStop = false;
            this.U_Lmax.Click += new System.EventHandler(this.U_Lmax_Click);
            // 
            // U_home
            // 
            this.U_home.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.U_home.Image = global::HMI.limit_signal.white;
            this.U_home.Location = new System.Drawing.Point(80, 45);
            this.U_home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_home.Name = "U_home";
            this.U_home.Padding = new System.Windows.Forms.Padding(5);
            this.U_home.Size = new System.Drawing.Size(60, 60);
            this.U_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.U_home.TabIndex = 62;
            this.U_home.TabStop = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(156, 22);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(30, 19);
            this.label43.TabIndex = 60;
            this.label43.Text = "L+";
            // 
            // U_Lmin
            // 
            this.U_Lmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.U_Lmin.Image = global::HMI.limit_signal.white;
            this.U_Lmin.Location = new System.Drawing.Point(5, 45);
            this.U_Lmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_Lmin.Name = "U_Lmin";
            this.U_Lmin.Padding = new System.Windows.Forms.Padding(5);
            this.U_Lmin.Size = new System.Drawing.Size(60, 60);
            this.U_Lmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.U_Lmin.TabIndex = 60;
            this.U_Lmin.TabStop = false;
            this.U_Lmin.Click += new System.EventHandler(this.U_Lmin_Click);
            // 
            // Z_limit
            // 
            this.Z_limit.BackColor = System.Drawing.Color.White;
            this.Z_limit.Controls.Add(this.label80);
            this.Z_limit.Controls.Add(this.label81);
            this.Z_limit.Controls.Add(this.Z_Lmax);
            this.Z_limit.Controls.Add(this.Z_home);
            this.Z_limit.Controls.Add(this.label85);
            this.Z_limit.Controls.Add(this.Z_Lmin);
            this.Z_limit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z_limit.Location = new System.Drawing.Point(5, 242);
            this.Z_limit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z_limit.Name = "Z_limit";
            this.Z_limit.Padding = new System.Windows.Forms.Padding(5);
            this.Z_limit.Size = new System.Drawing.Size(225, 115);
            this.Z_limit.TabIndex = 63;
            this.Z_limit.TabStop = false;
            this.Z_limit.Text = "Z_limit";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(77, 22);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(22, 19);
            this.label80.TabIndex = 61;
            this.label80.Text = "H";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(1, 22);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(26, 19);
            this.label81.TabIndex = 62;
            this.label81.Text = "L-";
            // 
            // Z_Lmax
            // 
            this.Z_Lmax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Z_Lmax.Image = global::HMI.limit_signal.white;
            this.Z_Lmax.Location = new System.Drawing.Point(160, 45);
            this.Z_Lmax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z_Lmax.Name = "Z_Lmax";
            this.Z_Lmax.Padding = new System.Windows.Forms.Padding(5);
            this.Z_Lmax.Size = new System.Drawing.Size(60, 60);
            this.Z_Lmax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Z_Lmax.TabIndex = 61;
            this.Z_Lmax.TabStop = false;
            this.Z_Lmax.Click += new System.EventHandler(this.Z_Lmax_Click);
            // 
            // Z_home
            // 
            this.Z_home.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Z_home.Image = global::HMI.limit_signal.white;
            this.Z_home.Location = new System.Drawing.Point(80, 45);
            this.Z_home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z_home.Name = "Z_home";
            this.Z_home.Padding = new System.Windows.Forms.Padding(5);
            this.Z_home.Size = new System.Drawing.Size(60, 60);
            this.Z_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Z_home.TabIndex = 62;
            this.Z_home.TabStop = false;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(156, 22);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(30, 19);
            this.label85.TabIndex = 60;
            this.label85.Text = "L+";
            // 
            // Z_Lmin
            // 
            this.Z_Lmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Z_Lmin.Image = global::HMI.limit_signal.white;
            this.Z_Lmin.Location = new System.Drawing.Point(5, 45);
            this.Z_Lmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z_Lmin.Name = "Z_Lmin";
            this.Z_Lmin.Padding = new System.Windows.Forms.Padding(5);
            this.Z_Lmin.Size = new System.Drawing.Size(60, 60);
            this.Z_Lmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Z_Lmin.TabIndex = 60;
            this.Z_Lmin.TabStop = false;
            this.Z_Lmin.Click += new System.EventHandler(this.Z_Lmin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.panel40);
            this.groupBox2.Controls.Add(this.label150);
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(363, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(101, 439);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Z軸";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox3.Controls.Add(this.panel34);
            this.groupBox3.Controls.Add(this.label98);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(456, 31);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(101, 439);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "U軸";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(3, 578);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(1056, 401);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Value";
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox9.Controls.Add(this.label37);
            this.groupBox9.Controls.Add(this.panel31);
            this.groupBox9.Controls.Add(this.panel29);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox9.Location = new System.Drawing.Point(820, 31);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(229, 358);
            this.groupBox9.TabIndex = 37;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "U";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label37.Location = new System.Drawing.Point(103, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(39, 15);
            this.label37.TabIndex = 38;
            this.label37.Text = "輸入";
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel31.Controls.Add(this.label22);
            this.panel31.Controls.Add(this.Now_StepMode_U);
            this.panel31.Controls.Add(this.Now_MINSpeed_U);
            this.panel31.Controls.Add(this.Now_MAXSpeed_U);
            this.panel31.Controls.Add(this.Now_Status_U);
            this.panel31.Controls.Add(this.Now_Acc_U);
            this.panel31.Controls.Add(this.Now_ABS_U);
            this.panel31.Controls.Add(this.Now_Speed_U);
            this.panel31.Controls.Add(this.Now_Dec_U);
            this.panel31.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel31.Location = new System.Drawing.Point(9, 51);
            this.panel31.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(89, 296);
            this.panel31.TabIndex = 36;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(29, 105);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.label22.Size = new System.Drawing.Size(47, 47);
            this.label22.TabIndex = 68;
            this.label22.Text = "step/s";
            // 
            // Now_StepMode_U
            // 
            this.Now_StepMode_U.AutoSize = true;
            this.Now_StepMode_U.Location = new System.Drawing.Point(3, 210);
            this.Now_StepMode_U.Name = "Now_StepMode_U";
            this.Now_StepMode_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_StepMode_U.Size = new System.Drawing.Size(35, 47);
            this.Now_StepMode_U.TabIndex = 33;
            this.Now_StepMode_U.Text = "Null";
            // 
            // Now_MINSpeed_U
            // 
            this.Now_MINSpeed_U.AutoSize = true;
            this.Now_MINSpeed_U.Location = new System.Drawing.Point(3, 140);
            this.Now_MINSpeed_U.Name = "Now_MINSpeed_U";
            this.Now_MINSpeed_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MINSpeed_U.Size = new System.Drawing.Size(35, 47);
            this.Now_MINSpeed_U.TabIndex = 30;
            this.Now_MINSpeed_U.Text = "Null";
            // 
            // Now_MAXSpeed_U
            // 
            this.Now_MAXSpeed_U.AutoSize = true;
            this.Now_MAXSpeed_U.Location = new System.Drawing.Point(3, 175);
            this.Now_MAXSpeed_U.Name = "Now_MAXSpeed_U";
            this.Now_MAXSpeed_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_MAXSpeed_U.Size = new System.Drawing.Size(35, 47);
            this.Now_MAXSpeed_U.TabIndex = 32;
            this.Now_MAXSpeed_U.Text = "Null";
            // 
            // Now_Acc_U
            // 
            this.Now_Acc_U.AutoSize = true;
            this.Now_Acc_U.Location = new System.Drawing.Point(3, 35);
            this.Now_Acc_U.Name = "Now_Acc_U";
            this.Now_Acc_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Acc_U.Size = new System.Drawing.Size(35, 47);
            this.Now_Acc_U.TabIndex = 29;
            this.Now_Acc_U.Text = "Null";
            // 
            // Now_ABS_U
            // 
            this.Now_ABS_U.AutoSize = true;
            this.Now_ABS_U.Location = new System.Drawing.Point(3, 0);
            this.Now_ABS_U.Name = "Now_ABS_U";
            this.Now_ABS_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_ABS_U.Size = new System.Drawing.Size(35, 47);
            this.Now_ABS_U.TabIndex = 25;
            this.Now_ABS_U.Text = "Null";
            // 
            // Now_Speed_U
            // 
            this.Now_Speed_U.AutoSize = true;
            this.Now_Speed_U.Location = new System.Drawing.Point(0, 105);
            this.Now_Speed_U.Name = "Now_Speed_U";
            this.Now_Speed_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Speed_U.Size = new System.Drawing.Size(20, 47);
            this.Now_Speed_U.TabIndex = 28;
            this.Now_Speed_U.Text = "0 ";
            // 
            // Now_Dec_U
            // 
            this.Now_Dec_U.AutoSize = true;
            this.Now_Dec_U.Location = new System.Drawing.Point(3, 70);
            this.Now_Dec_U.Name = "Now_Dec_U";
            this.Now_Dec_U.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Now_Dec_U.Size = new System.Drawing.Size(35, 47);
            this.Now_Dec_U.TabIndex = 27;
            this.Now_Dec_U.Text = "Null";
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel29.Controls.Add(this.Out_ABS_U);
            this.panel29.Controls.Add(this.Out_Acc_U);
            this.panel29.Controls.Add(this.Out_MAXSpeed_U);
            this.panel29.Controls.Add(this.Out_StepMode_U);
            this.panel29.Controls.Add(this.Out_Dec_U);
            this.panel29.Controls.Add(this.Out_Speed_U);
            this.panel29.Controls.Add(this.Out_MINSpeed_U);
            this.panel29.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel29.Location = new System.Drawing.Point(107, 51);
            this.panel29.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(115, 296);
            this.panel29.TabIndex = 37;
            // 
            // Out_ABS_U
            // 
            this.Out_ABS_U.Location = new System.Drawing.Point(5, 10);
            this.Out_ABS_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_ABS_U.Name = "Out_ABS_U";
            this.Out_ABS_U.Size = new System.Drawing.Size(100, 25);
            this.Out_ABS_U.TabIndex = 10;
            this.Out_ABS_U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_ABS_U.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_ABS_U_KeyDown);
            // 
            // Out_Acc_U
            // 
            this.Out_Acc_U.Location = new System.Drawing.Point(5, 45);
            this.Out_Acc_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Acc_U.Name = "Out_Acc_U";
            this.Out_Acc_U.Size = new System.Drawing.Size(100, 25);
            this.Out_Acc_U.TabIndex = 12;
            this.Out_Acc_U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Acc_U.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Acc_U_KeyDown);
            // 
            // Out_MAXSpeed_U
            // 
            this.Out_MAXSpeed_U.Location = new System.Drawing.Point(5, 185);
            this.Out_MAXSpeed_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MAXSpeed_U.Name = "Out_MAXSpeed_U";
            this.Out_MAXSpeed_U.Size = new System.Drawing.Size(100, 25);
            this.Out_MAXSpeed_U.TabIndex = 16;
            this.Out_MAXSpeed_U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MAXSpeed_U.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MAXSpeed_U_KeyDown);
            // 
            // Out_StepMode_U
            // 
            this.Out_StepMode_U.Location = new System.Drawing.Point(5, 220);
            this.Out_StepMode_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_StepMode_U.Name = "Out_StepMode_U";
            this.Out_StepMode_U.Size = new System.Drawing.Size(100, 25);
            this.Out_StepMode_U.TabIndex = 17;
            this.Out_StepMode_U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_StepMode_U.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_StepMode_U_KeyDown);
            // 
            // Out_Dec_U
            // 
            this.Out_Dec_U.Location = new System.Drawing.Point(5, 80);
            this.Out_Dec_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Dec_U.Name = "Out_Dec_U";
            this.Out_Dec_U.Size = new System.Drawing.Size(100, 25);
            this.Out_Dec_U.TabIndex = 13;
            this.Out_Dec_U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Dec_U.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Dec_U_KeyDown);
            // 
            // Out_Speed_U
            // 
            this.Out_Speed_U.Location = new System.Drawing.Point(5, 115);
            this.Out_Speed_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_Speed_U.Name = "Out_Speed_U";
            this.Out_Speed_U.Size = new System.Drawing.Size(100, 25);
            this.Out_Speed_U.TabIndex = 21;
            this.Out_Speed_U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_Speed_U.Visible = false;
            this.Out_Speed_U.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_Speed_U_KeyDown);
            // 
            // Out_MINSpeed_U
            // 
            this.Out_MINSpeed_U.Location = new System.Drawing.Point(5, 150);
            this.Out_MINSpeed_U.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Out_MINSpeed_U.Name = "Out_MINSpeed_U";
            this.Out_MINSpeed_U.Size = new System.Drawing.Size(100, 25);
            this.Out_MINSpeed_U.TabIndex = 15;
            this.Out_MINSpeed_U.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Out_MINSpeed_U.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Out_MINSpeed_U_KeyDown);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label57.Location = new System.Drawing.Point(5, 32);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(71, 15);
            this.label57.TabIndex = 35;
            this.label57.Text = "當前數值";
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.panel24);
            this.groupBox8.Controls.Add(this.label47);
            this.groupBox8.Controls.Add(this.panel22);
            this.groupBox8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox8.Location = new System.Drawing.Point(597, 31);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(229, 358);
            this.groupBox8.TabIndex = 37;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Z";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox7.Controls.Add(this.panel19);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label42);
            this.groupBox7.Controls.Add(this.panel18);
            this.groupBox7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox7.Location = new System.Drawing.Point(371, 31);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(229, 358);
            this.groupBox7.TabIndex = 36;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Y";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.panel6);
            this.groupBox6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox6.Location = new System.Drawing.Point(11, 31);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(133, 358);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Name";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.panel8);
            this.groupBox5.Controls.Add(this.panel7);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox5.Location = new System.Drawing.Point(143, 31);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(229, 358);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "X";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox10.Controls.Add(this.groupBox11);
            this.groupBox10.Controls.Add(this.groupBox3);
            this.groupBox10.Controls.Add(this.groupBoxX);
            this.groupBox10.Controls.Add(this.groupBox1);
            this.groupBox10.Controls.Add(this.groupBox2);
            this.groupBox10.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox10.Location = new System.Drawing.Point(1072, 5);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(571, 475);
            this.groupBox10.TabIndex = 37;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "狀態";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox11.Controls.Add(this.panel30);
            this.groupBox11.Controls.Add(this.label48);
            this.groupBox11.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox11.Location = new System.Drawing.Point(11, 31);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(151, 439);
            this.groupBox11.TabIndex = 36;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Name";
            // 
            // action
            // 
            this.action.Controls.Add(this.tabControlX);
            this.action.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.action.Location = new System.Drawing.Point(1067, 485);
            this.action.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.action.Name = "action";
            this.action.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.action.Size = new System.Drawing.Size(575, 316);
            this.action.TabIndex = 68;
            this.action.TabStop = false;
            this.action.Text = "動作";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 30);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(563, 129);
            this.textBox1.TabIndex = 69;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox1);
            this.groupBox12.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox12.Location = new System.Drawing.Point(1067, 808);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Size = new System.Drawing.Size(575, 171);
            this.groupBox12.TabIndex = 69;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "操作說明";
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox13.Controls.Add(this.tabControl1);
            this.groupBox13.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox13.Location = new System.Drawing.Point(1648, 5);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Size = new System.Drawing.Size(264, 551);
            this.groupBox13.TabIndex = 70;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "極限指示";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(5, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(249, 518);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.X_limit);
            this.tabPage3.Controls.Add(this.U_limit);
            this.tabPage3.Controls.Add(this.Y_limit);
            this.tabPage3.Controls.Add(this.Z_limit);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(241, 481);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "燈號";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label52);
            this.tabPage4.Controls.Add(this.Limit_Reset_step);
            this.tabPage4.Controls.Add(this.groupBox20);
            this.tabPage4.Controls.Add(this.groupBox18);
            this.tabPage4.Controls.Add(this.groupBox19);
            this.tabPage4.Controls.Add(this.groupBox17);
            this.tabPage4.Location = new System.Drawing.Point(4, 33);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(241, 481);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "離開極限";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(11, 376);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(173, 23);
            this.label52.TabIndex = 67;
            this.label52.Text = "離開極限步數:";
            // 
            // Limit_Reset_step
            // 
            this.Limit_Reset_step.Location = new System.Drawing.Point(13, 414);
            this.Limit_Reset_step.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Limit_Reset_step.Name = "Limit_Reset_step";
            this.Limit_Reset_step.Size = new System.Drawing.Size(207, 35);
            this.Limit_Reset_step.TabIndex = 66;
            this.Limit_Reset_step.Text = "12800";
            // 
            // groupBox20
            // 
            this.groupBox20.BackColor = System.Drawing.Color.White;
            this.groupBox20.Controls.Add(this.U_Lmax_Reset);
            this.groupBox20.Controls.Add(this.U_Lmin_Reset);
            this.groupBox20.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox20.Location = new System.Drawing.Point(148, 178);
            this.groupBox20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox20.Size = new System.Drawing.Size(72, 162);
            this.groupBox20.TabIndex = 65;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "U";
            // 
            // U_Lmax_Reset
            // 
            this.U_Lmax_Reset.Location = new System.Drawing.Point(8, 31);
            this.U_Lmax_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_Lmax_Reset.Name = "U_Lmax_Reset";
            this.U_Lmax_Reset.Size = new System.Drawing.Size(55, 50);
            this.U_Lmax_Reset.TabIndex = 63;
            this.U_Lmax_Reset.Text = "LU+";
            this.U_Lmax_Reset.UseVisualStyleBackColor = true;
            this.U_Lmax_Reset.Click += new System.EventHandler(this.U_Lmax_Reset_Click);
            // 
            // U_Lmin_Reset
            // 
            this.U_Lmin_Reset.Location = new System.Drawing.Point(8, 101);
            this.U_Lmin_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.U_Lmin_Reset.Name = "U_Lmin_Reset";
            this.U_Lmin_Reset.Size = new System.Drawing.Size(55, 50);
            this.U_Lmin_Reset.TabIndex = 56;
            this.U_Lmin_Reset.Text = "LU-";
            this.U_Lmin_Reset.UseVisualStyleBackColor = true;
            this.U_Lmin_Reset.Click += new System.EventHandler(this.U_Lmin_Reset_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.White;
            this.groupBox18.Controls.Add(this.Z_Lmax_Reset);
            this.groupBox18.Controls.Add(this.Z_Lmin_Reset);
            this.groupBox18.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox18.Location = new System.Drawing.Point(13, 178);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox18.Size = new System.Drawing.Size(72, 162);
            this.groupBox18.TabIndex = 65;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Z";
            // 
            // Z_Lmax_Reset
            // 
            this.Z_Lmax_Reset.Location = new System.Drawing.Point(8, 31);
            this.Z_Lmax_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z_Lmax_Reset.Name = "Z_Lmax_Reset";
            this.Z_Lmax_Reset.Size = new System.Drawing.Size(55, 50);
            this.Z_Lmax_Reset.TabIndex = 63;
            this.Z_Lmax_Reset.Text = "LZ+";
            this.Z_Lmax_Reset.UseVisualStyleBackColor = true;
            this.Z_Lmax_Reset.Click += new System.EventHandler(this.Z_Lmax_Reset_Click);
            // 
            // Z_Lmin_Reset
            // 
            this.Z_Lmin_Reset.Location = new System.Drawing.Point(8, 101);
            this.Z_Lmin_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Z_Lmin_Reset.Name = "Z_Lmin_Reset";
            this.Z_Lmin_Reset.Size = new System.Drawing.Size(55, 50);
            this.Z_Lmin_Reset.TabIndex = 56;
            this.Z_Lmin_Reset.Text = "LZ-";
            this.Z_Lmin_Reset.UseVisualStyleBackColor = true;
            this.Z_Lmin_Reset.Click += new System.EventHandler(this.Z_Lmin_Reset_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.BackColor = System.Drawing.Color.White;
            this.groupBox19.Controls.Add(this.Y_Lmax_Reset);
            this.groupBox19.Controls.Add(this.Y_Lmin_Reset);
            this.groupBox19.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox19.Location = new System.Drawing.Point(148, 9);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox19.Size = new System.Drawing.Size(72, 162);
            this.groupBox19.TabIndex = 65;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Y";
            // 
            // Y_Lmax_Reset
            // 
            this.Y_Lmax_Reset.Location = new System.Drawing.Point(8, 31);
            this.Y_Lmax_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y_Lmax_Reset.Name = "Y_Lmax_Reset";
            this.Y_Lmax_Reset.Size = new System.Drawing.Size(55, 50);
            this.Y_Lmax_Reset.TabIndex = 63;
            this.Y_Lmax_Reset.Text = "LY+";
            this.Y_Lmax_Reset.UseVisualStyleBackColor = true;
            this.Y_Lmax_Reset.Click += new System.EventHandler(this.Y_Lmax_Reset_Click);
            // 
            // Y_Lmin_Reset
            // 
            this.Y_Lmin_Reset.Location = new System.Drawing.Point(8, 101);
            this.Y_Lmin_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Y_Lmin_Reset.Name = "Y_Lmin_Reset";
            this.Y_Lmin_Reset.Size = new System.Drawing.Size(55, 50);
            this.Y_Lmin_Reset.TabIndex = 56;
            this.Y_Lmin_Reset.Text = "LY-";
            this.Y_Lmin_Reset.UseVisualStyleBackColor = true;
            this.Y_Lmin_Reset.Click += new System.EventHandler(this.Y_Lmin_Reset_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.White;
            this.groupBox17.Controls.Add(this.X_Lmax_Reset);
            this.groupBox17.Controls.Add(this.X_Lmin_Reset);
            this.groupBox17.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.Location = new System.Drawing.Point(13, 9);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox17.Size = new System.Drawing.Size(72, 162);
            this.groupBox17.TabIndex = 64;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "X";
            // 
            // X_Lmax_Reset
            // 
            this.X_Lmax_Reset.Location = new System.Drawing.Point(8, 31);
            this.X_Lmax_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X_Lmax_Reset.Name = "X_Lmax_Reset";
            this.X_Lmax_Reset.Size = new System.Drawing.Size(55, 50);
            this.X_Lmax_Reset.TabIndex = 63;
            this.X_Lmax_Reset.Text = "LX+";
            this.X_Lmax_Reset.UseVisualStyleBackColor = true;
            this.X_Lmax_Reset.Click += new System.EventHandler(this.X_Lmax_Reset_Click);
            // 
            // X_Lmin_Reset
            // 
            this.X_Lmin_Reset.Location = new System.Drawing.Point(8, 101);
            this.X_Lmin_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.X_Lmin_Reset.Name = "X_Lmin_Reset";
            this.X_Lmin_Reset.Size = new System.Drawing.Size(55, 50);
            this.X_Lmin_Reset.TabIndex = 56;
            this.X_Lmin_Reset.Text = "LX-";
            this.X_Lmin_Reset.UseVisualStyleBackColor = true;
            this.X_Lmin_Reset.Click += new System.EventHandler(this.X_Lmin_Reset_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox14.Controls.Add(this.GetStatus_X);
            this.groupBox14.Controls.Add(this.GetStatus_Y);
            this.groupBox14.Controls.Add(this.GetStatus_Z);
            this.groupBox14.Controls.Add(this.GetStatus_U);
            this.groupBox14.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox14.Location = new System.Drawing.Point(1653, 578);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Size = new System.Drawing.Size(251, 135);
            this.groupBox14.TabIndex = 71;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "異常狀態解除";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1651, 731);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 248);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // S150
            // 
            this.S150.BackColor = System.Drawing.Color.Red;
            this.S150.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.S150.Location = new System.Drawing.Point(915, 425);
            this.S150.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.S150.Name = "S150";
            this.S150.Size = new System.Drawing.Size(139, 92);
            this.S150.TabIndex = 73;
            this.S150.Text = "緊急開關";
            this.S150.UseVisualStyleBackColor = false;
            this.S150.Click += new System.EventHandler(this.S150_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.S150);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.action);
            this.Controls.Add(this.SETPAN);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.timecount);
            this.Controls.Add(this.SETBTN);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "專題";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelX.ResumeLayout(false);
            this.panelX.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.SETPAN.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.panel43.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panelY.ResumeLayout(false);
            this.panelY.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.panel40.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panelZ.ResumeLayout(false);
            this.panelZ.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.panelU.ResumeLayout(false);
            this.panelU.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.tabControlX.ResumeLayout(false);
            this.X.ResumeLayout(false);
            this.Y.ResumeLayout(false);
            this.Z.ResumeLayout(false);
            this.U.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBoxX.ResumeLayout(false);
            this.groupBoxX.PerformLayout();
            this.X_limit.ResumeLayout(false);
            this.X_limit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.X_Lmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_Lmin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Y_limit.ResumeLayout(false);
            this.Y_limit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Lmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Lmin)).EndInit();
            this.U_limit.ResumeLayout(false);
            this.U_limit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.U_Lmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.U_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.U_Lmin)).EndInit();
            this.Z_limit.ResumeLayout(false);
            this.Z_limit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Z_Lmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_Lmin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.action.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button Move_X;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label ABS_POS1;
        private System.Windows.Forms.Label SPEED1;
        private System.Windows.Forms.Label ACC1;
        private System.Windows.Forms.Label DEC_1;
        private System.Windows.Forms.Label MAX_SPEED1;
        private System.Windows.Forms.Label MIN_SPEED1;
        private System.Windows.Forms.Label STATUS1;
        private System.Windows.Forms.Label STEP_MODE1;
        private System.Windows.Forms.TextBox Out_ABS_X;
        private System.Windows.Forms.TextBox Out_Acc_X;
        private System.Windows.Forms.TextBox Out_Dec_X;
        private System.Windows.Forms.TextBox Out_Speed_X;
        private System.Windows.Forms.TextBox Out_MINSpeed_X;
        private System.Windows.Forms.TextBox Out_MAXSpeed_X;
        private System.Windows.Forms.TextBox Out_StepMode_X;
        private System.Windows.Forms.FlowLayoutPanel SETPAN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comstop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comdata;
        private System.Windows.Forms.Button Confirmbtn;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button SETBTN;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Panel panelX;
        private System.Windows.Forms.Button Gohome;
        private System.Windows.Forms.TextBox Move_value;
        private System.Windows.Forms.Button GoTo;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton SoftStop;
        private System.Windows.Forms.RadioButton HardStop;
        private System.Windows.Forms.RadioButton HardHiZ;
        private System.Windows.Forms.RadioButton SoftHiZ;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label Now_StepMode_X;
        private System.Windows.Forms.Label Now_MINSpeed_X;
        private System.Windows.Forms.Label Now_MAXSpeed_X;
        private System.Windows.Forms.Label Now_Acc_X;
        private System.Windows.Forms.Label Now_ABS_X;
        private System.Windows.Forms.Label Now_Speed_X;
        private System.Windows.Forms.Label Now_Dec_X;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox GoTo_value;
        private System.Windows.Forms.TextBox Run_value;
        private System.Windows.Forms.Label Now_Status_X;
        private System.Windows.Forms.Label timecount;
        private System.Windows.Forms.Label motion;
        private System.Windows.Forms.Label Now_Status_Y;
        private System.Windows.Forms.Panel panelY;
        private System.Windows.Forms.TextBox GoTo_Y_value;
        private System.Windows.Forms.TextBox MoveY_value;
        private System.Windows.Forms.Button Stop_Y;
        private System.Windows.Forms.Button Move_Y;
        private System.Windows.Forms.Button GoTo_Y;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.RadioButton HardHiZ_Y;
        private System.Windows.Forms.RadioButton SoftHiZ_Y;
        private System.Windows.Forms.RadioButton HardStop_Y;
        private System.Windows.Forms.RadioButton SoftStop_Y;
        private System.Windows.Forms.Button Gohome_Y;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label Now_Status_Z;
        private System.Windows.Forms.Panel panelZ;
        private System.Windows.Forms.TextBox GoTo_Z_value;
        private System.Windows.Forms.TextBox MoveZ_value;
        private System.Windows.Forms.Button Stop_Z;
        private System.Windows.Forms.Button Move_Z;
        private System.Windows.Forms.Button GoTo_Z;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.RadioButton HardHiZ_Z;
        private System.Windows.Forms.RadioButton SoftHiZ_Z;
        private System.Windows.Forms.RadioButton HardStop_Z;
        private System.Windows.Forms.RadioButton SoftStop_Z;
        private System.Windows.Forms.Button Gohome_Z;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.TextBox Out_ABS_Z;
        private System.Windows.Forms.TextBox Out_Acc_Z;
        private System.Windows.Forms.TextBox Out_MAXSpeed_Z;
        private System.Windows.Forms.TextBox Out_StepMode_Z;
        private System.Windows.Forms.TextBox Out_Dec_Z;
        private System.Windows.Forms.TextBox Out_Speed_Z;
        private System.Windows.Forms.TextBox Out_MINSpeed_Z;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Label Now_StepMode_Z;
        private System.Windows.Forms.Label Now_MINSpeed_Z;
        private System.Windows.Forms.Label Now_MAXSpeed_Z;
        private System.Windows.Forms.Label Now_Acc_Z;
        private System.Windows.Forms.Label Now_ABS_Z;
        private System.Windows.Forms.Label Now_Speed_Z;
        private System.Windows.Forms.Label Now_Dec_Z;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label motionY;
        private System.Windows.Forms.Label motionZ;
        private System.Windows.Forms.Label motionU;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label Now_Status_U;
        private System.Windows.Forms.Panel panelU;
        private System.Windows.Forms.TextBox GoTo_U_value;
        private System.Windows.Forms.TextBox MoveU_value;
        private System.Windows.Forms.Button Stop_U;
        private System.Windows.Forms.Button Move_U;
        private System.Windows.Forms.Button GoTo_U;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.RadioButton HardHiZ_U;
        private System.Windows.Forms.RadioButton SoftHiZ_U;
        private System.Windows.Forms.RadioButton HardStop_U;
        private System.Windows.Forms.RadioButton SoftStop_U;
        private System.Windows.Forms.Button Gohome_U;
        private System.Windows.Forms.Button Multiple_GoHome;
        private System.Windows.Forms.Button Multiple_Stop;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button RESET;
        private System.Windows.Forms.Button GetStatus_Y;
        private System.Windows.Forms.Button GetStatus_U;
        private System.Windows.Forms.Button GetStatus_Z;
        private System.Windows.Forms.Button GetStatus_X;
        private System.Windows.Forms.Label Now_ABS_Y;
        private System.Windows.Forms.Label Now_Acc_Y;
        private System.Windows.Forms.Label Now_Dec_Y;
        private System.Windows.Forms.Label Now_Speed_Y;
        private System.Windows.Forms.Label Now_MINSpeed_Y;
        private System.Windows.Forms.Label Now_MAXSpeed_Y;
        private System.Windows.Forms.Label Now_StepMode_Y;
        private System.Windows.Forms.TextBox Out_MINSpeed_Y;
        private System.Windows.Forms.TextBox Out_Speed_Y;
        private System.Windows.Forms.TextBox Out_Dec_Y;
        private System.Windows.Forms.TextBox Out_MAXSpeed_Y;
        private System.Windows.Forms.TextBox Out_Acc_Y;
        private System.Windows.Forms.TextBox Out_StepMode_Y;
        private System.Windows.Forms.TextBox Out_ABS_Y;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TabControl tabControlX;
        private System.Windows.Forms.TabPage X;
        private System.Windows.Forms.TabPage Y;
        private System.Windows.Forms.TabPage Z;
        private System.Windows.Forms.TabPage U;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Prepare_Y_Value;
        private System.Windows.Forms.TextBox Prepare_U_Value;
        private System.Windows.Forms.TextBox Prepare_Z_Value;
        private System.Windows.Forms.TextBox Prepare_X_Value;
        private System.Windows.Forms.Button Multiple_Move;
        private System.Windows.Forms.Button Multiple_GoTo;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.Label STEPLOSS_B_Flag_X;
        private System.Windows.Forms.Label STEPLOSS_A_Flag_X;
        private System.Windows.Forms.Label TH_SD_Flag_X;
        private System.Windows.Forms.Label OCD_Flag_X;
        private System.Windows.Forms.Label TH_WRN_Flag_X;
        private System.Windows.Forms.Label WRONG_Flag_X;
        private System.Windows.Forms.Label UVLO_Flag_X;
        private System.Windows.Forms.Label DIR_Flag_X;
        private System.Windows.Forms.Label HIZ_Flag_X;
        private System.Windows.Forms.Label BUSY_Flag_X;
        private System.Windows.Forms.Label NOTPERF_Flag_X;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Panel panel43;
        private System.Windows.Forms.Label STEPLOSS_B_Flag_Y;
        private System.Windows.Forms.Label STEPLOSS_A_Flag_Y;
        private System.Windows.Forms.Label TH_SD_Flag_Y;
        private System.Windows.Forms.Label OCD_Flag_Y;
        private System.Windows.Forms.Label TH_WRN_Flag_Y;
        private System.Windows.Forms.Label WRONG_Flag_Y;
        private System.Windows.Forms.Label UVLO_Flag_Y;
        private System.Windows.Forms.Label DIR_Flag_Y;
        private System.Windows.Forms.Label HIZ_Flag_Y;
        private System.Windows.Forms.Label BUSY_Flag_Y;
        private System.Windows.Forms.Label NOTPERF_Flag_Y;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.Panel panel40;
        private System.Windows.Forms.Label STEPLOSS_B_Flag_Z;
        private System.Windows.Forms.Label STEPLOSS_A_Flag_Z;
        private System.Windows.Forms.Label TH_SD_Flag_Z;
        private System.Windows.Forms.Label OCD_Flag_Z;
        private System.Windows.Forms.Label TH_WRN_Flag_Z;
        private System.Windows.Forms.Label WRONG_Flag_Z;
        private System.Windows.Forms.Label UVLO_Flag_Z;
        private System.Windows.Forms.Label DIR_Flag_Z;
        private System.Windows.Forms.Label HIZ_Flag_Z;
        private System.Windows.Forms.Label BUSY_Flag_Z;
        private System.Windows.Forms.Label NOTPERF_Flag_Z;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Label STEPLOSS_B_Flag_U;
        private System.Windows.Forms.Label STEPLOSS_A_Flag_U;
        private System.Windows.Forms.Label TH_SD_Flag_U;
        private System.Windows.Forms.Label OCD_Flag_U;
        private System.Windows.Forms.Label TH_WRN_Flag_U;
        private System.Windows.Forms.Label WRONG_Flag_U;
        private System.Windows.Forms.Label UVLO_Flag_U;
        private System.Windows.Forms.Label DIR_Flag_U;
        private System.Windows.Forms.Label HIZ_Flag_U;
        private System.Windows.Forms.Label BUSY_Flag_U;
        private System.Windows.Forms.Label NOTPERF_Flag_U;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.GroupBox X_limit;
        private System.Windows.Forms.Label labe1x;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.PictureBox X_Lmax;
        private System.Windows.Forms.PictureBox X_home;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.PictureBox X_Lmin;
        private System.Windows.Forms.GroupBox U_limit;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.PictureBox U_Lmax;
        private System.Windows.Forms.PictureBox U_home;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.PictureBox U_Lmin;
        private System.Windows.Forms.GroupBox Z_limit;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.PictureBox Z_Lmax;
        private System.Windows.Forms.PictureBox Z_home;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.PictureBox Z_Lmin;
        private System.Windows.Forms.GroupBox Y_limit;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.PictureBox Y_Lmax;
        private System.Windows.Forms.PictureBox Y_home;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.PictureBox Y_Lmin;
        private System.Windows.Forms.GroupBox groupBoxX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label Now_StepMode_U;
        private System.Windows.Forms.Label Now_MINSpeed_U;
        private System.Windows.Forms.Label Now_MAXSpeed_U;
        private System.Windows.Forms.Label Now_Acc_U;
        private System.Windows.Forms.Label Now_ABS_U;
        private System.Windows.Forms.Label Now_Speed_U;
        private System.Windows.Forms.Label Now_Dec_U;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.TextBox Out_ABS_U;
        private System.Windows.Forms.TextBox Out_Acc_U;
        private System.Windows.Forms.TextBox Out_MAXSpeed_U;
        private System.Windows.Forms.TextBox Out_StepMode_U;
        private System.Windows.Forms.TextBox Out_Dec_U;
        private System.Windows.Forms.TextBox Out_Speed_U;
        private System.Windows.Forms.TextBox Out_MINSpeed_U;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button Home_Reset_X;
        private System.Windows.Forms.Button Home_Reset_Y;
        private System.Windows.Forms.Button Home_Reset_Z;
        private System.Windows.Forms.Button Home_Reset_U;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox action;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton HOME_X_R;
        private System.Windows.Forms.RadioButton HOME_X_L;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.RadioButton HOME_Y_R;
        private System.Windows.Forms.RadioButton HOME_Y_L;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.RadioButton HOME_Z_R;
        private System.Windows.Forms.RadioButton HOME_Z_L;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton HOME_U_R;
        private System.Windows.Forms.RadioButton HOME_U_L;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.RadioButton Home_Reset_X_Dir_R;
        private System.Windows.Forms.RadioButton Home_Reset_X_Dir_L;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.RadioButton Home_Reset_Y_Dir_R;
        private System.Windows.Forms.RadioButton Home_Reset_Y_Dir_L;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.RadioButton Home_Reset_Z_Dir_R;
        private System.Windows.Forms.RadioButton Home_Reset_Z_Dir_L;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.RadioButton Home_Reset_U_Dir_R;
        private System.Windows.Forms.RadioButton Home_Reset_U_Dir_L;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox Home_Reset_step;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox Home_reset_Speed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox Limit_Reset_step;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button U_Lmax_Reset;
        private System.Windows.Forms.Button U_Lmin_Reset;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button Z_Lmax_Reset;
        private System.Windows.Forms.Button Z_Lmin_Reset;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button Y_Lmax_Reset;
        private System.Windows.Forms.Button Y_Lmin_Reset;
        private System.Windows.Forms.Button X_Lmax_Reset;
        private System.Windows.Forms.Button X_Lmin_Reset;
        private System.Windows.Forms.Button S150;
    }
}

