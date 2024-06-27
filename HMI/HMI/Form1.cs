using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
//****************************************************
// _oo0oo_
// o8888888o
// 88" . "88
// (| -_- |)
// 0\ = /0
// ___/`—‘\___
// .’ \\| |// ‘.
// / \\||| : |||// \
// / _||||| -:- |||||- \
// | | \\\ – /// | |
// | \_| ”\—/” |_/ |
// \ .-\__ ‘-‘ ___/-. /
// ___’. .’ /–.–\ `. .’___
// ."" ‘< `.___\_<|>_/___.’ >’ "".
// | | : `- \`.;`\ _ /`;.`/ – ` : | |
// \ \ `_. \_ __\ /__ _/ .-` / /
// =====`-.____`.___ \_____/___.-`___.-‘=====
// `=—=’
//
//
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//
// 佛祖保佑 永無bug
//
//***************************************************
namespace HMI
{
    public partial class Form1 : Form
    {
        /// </說明>
        /// 指令編碼方式 
        /// 
        /// BUFFER[0]:固定校驗碼 0X55
        /// BUFFER[1]:指令 
        ///           0X01  MOVE 
        ///           0X02  GOHOME
        ///           0X03  HARDSTOP
        ///           0X04  SoftStop
        ///           0x05  SoftHiZ
        ///           0x06  HardHiZ
        ///           0x07  GOTO
        ///           0X0A  GETStatus
        ///           0xAA  setpram
        ///           0XBB  GetParam 非即時(ACC,DEC,MAX,MIN,STEPMODE)
        ///           0XCC  GetParam   即時(POS,SPD,Status)
        ///           0X20  L+
        ///           0X21  L-
        ///           0X22  HOME home點復歸
        ///           0X23 解決極限異常
        ///           0x24  Home_reset_Speed 
        /// BUFFER[2]: BOARD 
        ///            0X00 X,Y
        ///            0X01 Z,U
        /// BUFFER[3]:DEVICE
        ///           0X00 X,Z
        ///           0X01 Y,U
        /// 
        /// BUFFER[4]:參數1
        ///           DIR  MOVE,GOTO
        ///           0X00 CCW
        ///           0X01 CW
        ///        
        ///           REG SETPRAM,GETPRAM
        ///           0X00 POS
        ///           0X03 SPD
        ///           0X04 ACC
        ///           0X05 DEC
        ///           0X06 MAX
        ///           0X07 MIN
        ///           0X15 STEPMODE
        ///           0X18 Status
        /// BUFFER[5]:參數2 目前無
        /// 
        /// BUFFER[6]~BUFFER[9]:參數3
        ///                     數值
        /// 
        /// </說明>

        /// </Home 及 limit>
        ///
        /// STM 端有一Home_flag 若為1則為復歸模式，若為0則為一般極限停止模式 ，2為複歸後傳訊息模式。
        /// 初始化時會先詢問是否做Home點復歸。
        /// 若操作中須做復歸則須在馬達停止後勾選對應的馬達並按下Home_RESET即可，復歸完畢後會跳出信息。
        /// Home點復歸方式 
        /// 運轉過程中若觸碰到左右極限則馬達會立即停止並發送代碼使指示燈變為紅色，且該軸將無法操作直到按下該紅色燈號，解決錯誤狀況。
        /// 按下燈號後馬達將往原點方向轉一圈，以脫離極限觸發的位置，脫離後燈號變回綠色 該軸即可正常使用。
        /// </說明>




        Function f = new Function();
        Status s = new Status();

        public static Form1 form1;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
            pictureBox1.Image = limit_signal.A_F;
            #region CHART 初始化


            ChartArea chtArea = new ChartArea("ViewArea");// chart new 出來時就有內建第一個chartarea
            chtArea.AxisX.Minimum = 0; //X軸數值從0開始
            chtArea.AxisX.ScaleView.Size = 50; //設定視窗範圍內一開始顯示多少點
            chtArea.AxisX.Interval = 5;
            chtArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chtArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
            chart1.ChartAreas[0] = chtArea; 
            
            chtArea.CursorX.IsUserEnabled = true;
            chtArea.CursorX.IsUserSelectionEnabled = true;
            chtArea.CursorY.IsUserEnabled = true;
            chtArea.CursorY.IsUserSelectionEnabled = true;
            
         
            System.Windows.Forms.Timer clsTimer = new System.Windows.Forms.Timer();
            clsTimer.Tick += new EventHandler(RefreshChart);
            clsTimer.Interval = 200;
            clsTimer.Start();
            #endregion
           


        }
        #region 變數命名及初值

        public static byte[] SendOrder = new byte[10] { 0x55, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; //中間為命令，頭為校驗 55 // 串口接收
        public static byte[] revcmd = new byte[10];
        public static byte[] ASCIIbytes = new byte[4] { 0xAA, 0x00, 0x00, 0x00 };
        public static int Value;
        public static int[] status = new int[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        //判斷當前動作為何
        public int motion_flagX;
        public int motion_flagY;
        public int motion_flagZ;
        public int motion_flagU;
        ///
        ///
        public int[] status_X = new int[15];
        public int[] status_Y = new int[15];
        public int[] status_Z = new int[15];
        public int[] status_U = new int[15];
        /// 
        public int HIZ_X;
        public int HIZ_Y;
        public int HIZ_Z;
        public int HIZ_U;
        /// 
        /// BUSY
        public int BUSY_X;
        public int BUSY_Y;
        public int BUSY_Z;
        public int BUSY_U;
        /// 
        /// last step mode

        //紀錄改變前的Stepmode 以重製ABS_POS
        public int lastStepmode_X;
        public int lastStepmode_Y;
        public int lastStepmode_Z;
        public int lastStepmode_U;
        /// 

        ///燈號
        public int X_Lmin_Flag = 0;
        public int X_Lmax_Flag = 0;
        public int Y_Lmin_Flag = 0;
        public int Y_Lmax_Flag = 0;
        public int Z_Lmin_Flag = 0;
        public int Z_Lmax_Flag = 0;
        public int U_Lmin_Flag = 0;
        public int U_Lmax_Flag = 0;
        /// 

        private int m_nTimeCount = 0;
        public static string mesg_status = "";
        #endregion

        #region 連線
        private void SETBTN_Click(object sender, EventArgs e)
        {

            //SETPAN.Height = 0;
            SETPAN.Visible = true;
           
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            SETPAN.Visible = false;
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {


            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.PortName = "COM" + comname.SelectedItem.ToString();
                serialPort1.BaudRate = Convert.ToInt32(comrate.SelectedItem.ToString());
                switch (comstop.SelectedIndex)
                {
                    case 0:
                        serialPort1.StopBits = System.IO.Ports.StopBits.None;
                        break;
                    case 1:
                        serialPort1.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case 2:
                        serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case 3:
                        serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                }
                serialPort1.DataBits = Convert.ToInt32(comdata.SelectedItem.ToString());
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();            
                    Timer2.Start();
                    LED_initial();
                }
                SETPAN.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

 



        #endregion

        #region 接收
        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                serialPort1.Read(revcmd, 0, 10); //將接收緩衝區輸入revcmd
               
                this.BeginInvoke(new EventHandler(ComService));
                //this.Invoke(new EventHandler(ComService)); //調用事件處理函數//原本是inInvoke  試試看BeginInvoke 能否解決衝突
                serialPort1.DiscardInBuffer();
            }
            catch
            {
                
                MessageBox.Show("請檢查串口1是否打開_DataReceived");

            }
            

        }

        private void ComService(object sender, EventArgs e)
        {

            #region 指令

            if ((revcmd[0] == 0x55))
            {
              
                //set
                if ((revcmd[1] == 0xaa))
                {
                    if ((revcmd[2] == 0x00) & (revcmd[3] == 0x00))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_X.Text = f.Byte2value(revcmd).ToString();
                                break;
                            case 0x02:
                                break;
                            case 0x04:
                                Now_Acc_X.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x05:
                                Now_Dec_X.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x03:
                                Now_Speed_X.Text = f.Byte2value(revcmd).ToString() ;
                                break;
                            case 0x06:
                                Now_MAXSpeed_X.Text = f.Byte2value(revcmd).ToString()+"step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_X.Text = f.Byte2value(revcmd).ToString() + "step/s";
                                break;
                            case 0x15:
                                lastStepmode_X =Convert.ToInt32(Now_StepMode_X.Text);
                                Now_StepMode_X.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                StepModeChangeABS(0, 0, Convert.ToInt32(Now_ABS_X.Text)/lastStepmode_X*Convert.ToInt32(Now_StepMode_X.Text));
                                break;
                            case 0x18:
                                Now_Status_X.Text = f.Byte2value(revcmd).ToString();
                                break;
                        }
                    }
                    else if ((revcmd[2] == 0x00) & (revcmd[3] == 0x01))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_Y.Text = f.Byte2value(revcmd).ToString();
                                break;

                            case 0x04:
                                Now_Acc_Y.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x05:
                                Now_Dec_Y.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x03:
                                Now_Speed_Y.Text = f.Byte2value(revcmd).ToString();
                                break;
                            case 0x06:
                                Now_MAXSpeed_Y.Text = f.Byte2value(revcmd).ToString() + "step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_Y.Text = f.Byte2value(revcmd).ToString() + "step/s";
                                break;
                            case 0x15:
                                lastStepmode_Y = Convert.ToInt32(Now_StepMode_Y.Text);
                                Now_StepMode_Y.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                StepModeChangeABS(0, 1, Convert.ToInt32(Now_ABS_Y.Text) / lastStepmode_Y * Convert.ToInt32(Now_StepMode_Y.Text));
                                break;
                            case 0x18:
                                Now_Status_Y.Text = f.Byte2value(revcmd).ToString();
                                break;
                        }
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x00))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_Z.Text = f.Byte2value(revcmd).ToString();
                                break;

                            case 0x04:
                                Now_Acc_Z.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x05:
                                Now_Dec_Z.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x03:
                                Now_Speed_Z.Text = f.Byte2value(revcmd).ToString() ;
                                break;
                            case 0x06:
                                Now_MAXSpeed_Z.Text = f.Byte2value(revcmd).ToString() + "step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_Z.Text = f.Byte2value(revcmd).ToString() + "step/s";
                                break;
                            case 0x15:
                                lastStepmode_Z = Convert.ToInt32(Now_StepMode_Z.Text);
                                Now_StepMode_Z.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                StepModeChangeABS(1, 0, Convert.ToInt32(Now_ABS_Z.Text) / lastStepmode_Z * Convert.ToInt32(Now_StepMode_Z.Text));
                                break;
                            case 0x18:
                                Now_Status_Z.Text = f.Byte2value(revcmd).ToString();
                                break;
                        }
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x01))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_U.Text = f.Byte2value(revcmd).ToString();
                                break;
                            case 0x04:
                                Now_Acc_U.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x05:
                                Now_Dec_U.Text = f.Byte2value(revcmd).ToString() + "step/s²";
                                break;
                            case 0x03:
                                Now_Speed_U.Text = f.Byte2value(revcmd).ToString() ;
                                break;
                            case 0x06:
                                Now_MAXSpeed_U.Text = f.Byte2value(revcmd).ToString() + "step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_U.Text = f.Byte2value(revcmd).ToString() + "step/s";
                                break;
                            case 0x15:
                                lastStepmode_U = Convert.ToInt32(Now_StepMode_U.Text);
                                Now_StepMode_U.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                StepModeChangeABS(1, 1, Convert.ToInt32(Now_ABS_U.Text) / lastStepmode_U * Convert.ToInt32(Now_StepMode_U.Text));
                                break;
                            case 0x18:
                                Now_Status_U.Text = f.Byte2value(revcmd).ToString();
                                break;
                        }
                    }


               
                }
                //get
                else if (((revcmd[1] == 0xcc) || (revcmd[1] == 0xbb)))
                {
                    if ((revcmd[2] == 0x00) & (revcmd[3] == 0x00))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_X.Text = f.Byte2value(revcmd).ToString();
                                break;
                            case 0x02:
                                break;
                            case 0x04:
                                Now_Acc_X.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x05:
                                Now_Dec_X.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x03:
                                if (motion_flagX == 0)
                                    Now_Speed_X.Text = "0" ;
                                else
                                    Now_Speed_X.Text = f.Byte2value(revcmd).ToString() ;
                                break;
                            case 0x06:
                                Now_MAXSpeed_X.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_X.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x15:
                                Now_StepMode_X.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                break;
                            case 0x18:
                                Now_Status_X.Text = f.Byte2value(revcmd).ToString();
                                status_X = s.Status_analysis(Now_Status_X.Text);

                                #region 狀態判別
                                if (status_X[0] == 0)
                                {
                                    HIZ_X = 0;
                                    HIZ_Flag_X.Text = " N High Z";
                                    Out_StepMode_X.Enabled = false;
                                }
                                else if (status_X[0] == 1)
                                {
                                    HIZ_X = 1;
                                    HIZ_Flag_X.Text = "High Z";
                                    Out_StepMode_X.Enabled = true;
                                }

                                if (status_X[1] == 0)
                                {
                                    BUSY_X = 0;
                                    BUSY_Flag_X.Text = "忙碌中";
                                }
                                else if (status_X[1] == 1)
                                {
                                    BUSY_X = 1;
                                    BUSY_Flag_X.Text = "動作完成";
                                }

                                if (status_X[4] == 0)
                                {
                                    DIR_Flag_X.Text = "逆時針";
                                }
                                else if (status_X[4] == 1)
                                {
                                    DIR_Flag_X.Text = "順時針";
                                }

                                if (status_X[5] == 0 && status_X[6] == 0)
                                {
                                    motion.Text = "停止";
                                    motion_flagX = 0;
                                }
                                else if (status_X[6] == 0 && status_X[5] == 1)
                                {
                                    motion.Text = "加速中";
                                    motion_flagX = 1;
                                }
                                else if (status_X[6] == 1 && status_X[5] == 0)
                                {
                                    motion.Text = "減速中";
                                    motion_flagX = 2;
                                }
                                else if (status_X[6] == 1 && status_X[5] == 1)
                                {
                                    motion.Text = "定速";
                                    motion_flagX = 3;
                                }

                                if (status_X[7] == 0)
                                {
                                    NOTPERF_Flag_X.Text = "正常";
                                }
                                else if (status_X[7] == 1)
                                {
                                    NOTPERF_Flag_X.Text = "不正常";
                                }

                                if (status_X[8] == 0)
                                {
                                    WRONG_Flag_X.Text = "正常";
                                }
                                else if (status_X[8] == 1)
                                {
                                    WRONG_Flag_X.Text = "不正常";
                                }

                                if (status_X[9] == 0)
                                {
                                    UVLO_Flag_X.Text = "不正常";
                                }
                                else if (status_X[9] == 1)
                                {
                                    UVLO_Flag_X.Text = "正常";
                                }

                                if (status_X[10] == 0)
                                {
                                    TH_WRN_Flag_X.Text = "不正常";
                                }
                                else if (status_X[10] == 1)
                                {
                                    TH_WRN_Flag_X.Text = "正常";
                                }

                                if (status_X[11] == 0)
                                {
                                    TH_SD_Flag_X.Text = "不正常";
                                }
                                else if (status_X[11] == 1)
                                {
                                    TH_SD_Flag_X.Text = "正常";
                                }

                                if (status_X[12] == 0)
                                {
                                   OCD_Flag_X.Text = "不正常";
                                }
                                else if (status_X[12] == 1)
                                {
                                    OCD_Flag_X.Text = "正常";
                                }

                                if (status_X[13] == 0)
                                {
                                    STEPLOSS_A_Flag_X.Text = "不正常";
                                }
                                else if (status_X[13] == 1)
                                {
                                    STEPLOSS_A_Flag_X.Text = "正常";
                                }

                                if (status_X[14] == 0)
                                {
                                    STEPLOSS_B_Flag_X.Text = "不正常";
                                }
                                else if (status_X[14] == 1)
                                {
                                    STEPLOSS_B_Flag_X.Text = "正常";
                                }

                                if (motion_flagX == 0)
                                {
                                    Out_ABS_X.Enabled = true;
                                    Out_Acc_X.Enabled = true;
                                    Out_Dec_X.Enabled = true;
                                    Out_MINSpeed_X.Enabled = true;
                                }
                                else
                                {
                                    Out_ABS_X.Enabled = false;
                                    Out_Acc_X.Enabled = false;
                                    Out_Dec_X.Enabled = false;
                                    Out_MINSpeed_X.Enabled = false;
                                }

                                #endregion

                                break;
                        }
                    }

                    else if ((revcmd[2] == 0x00) & (revcmd[3] == 0x01))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_Y.Text = f.Byte2value(revcmd).ToString();
                                break;
                            case 0x04:
                                Now_Acc_Y.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x05:
                                Now_Dec_Y.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x03:
                                if (motion_flagY == 0x00)
                                    Now_Speed_Y.Text = "0";
                                else
                                    Now_Speed_Y.Text = f.Byte2value(revcmd).ToString() ;
                                break;
                            case 0x06:
                                Now_MAXSpeed_Y.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_Y.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x15:
                                Now_StepMode_Y.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                break;
                            case 0x18:
                                Now_Status_Y.Text = f.Byte2value(revcmd).ToString();
                                
                                status_Y = s.Status_analysis(Now_Status_Y.Text);

                                #region 狀態判別
                                if (status_Y[0] == 0)
                                {
                                    HIZ_Y = 0;
                                    HIZ_Flag_Y.Text = " N High Z";
                                    Out_StepMode_Y.Enabled = false;
                                }
                                else if (status_Y[0] == 1)
                                {
                                    HIZ_Y = 1;
                                    HIZ_Flag_Y.Text = "  High Z";
                                    Out_StepMode_Y.Enabled = true;
                                }

                                if (status_Y[1] == 0)
                                {  //負邏輯
                                    BUSY_Y = 0;
                                    BUSY_Flag_Y.Text = "忙碌中";
                                }
                                else if (status_Y[1] == 1)
                                {
                                    BUSY_Y = 1;
                                    BUSY_Flag_Y.Text = "動作完成";
                                }

                                if (status_Y[4] == 0)
                                {
                                    DIR_Flag_Y.Text = "逆時針";
                                }
                                else if (status_Y[4] == 1)
                                {
                                    DIR_Flag_Y.Text = "順時針";
                                }

                                if (status_Y[5] == 0 && status_Y[6] == 0)
                                {
                                    motionY.Text = "停止";
                                    motion_flagY = 0;
                                }
                                else if (status_Y[6] == 0 && status_Y[5] == 1)
                                {
                                    motionY.Text = "加速中";
                                    motion_flagY = 1;
                                }

                                else if (status_Y[6] == 1 && status_Y[5] == 0)
                                {
                                    motionY.Text = "減速中";
                                    motion_flagY = 2;
                                }

                                else if (status_Y[6] == 1 && status_Y[5] == 1)
                                {
                                    motionY.Text = "定速";
                                    motion_flagY = 3;
                                }

                                if (status_Y[7] == 0)
                                {
                                    NOTPERF_Flag_Y.Text = "正常";
                                }
                                else if (status_Y[7] == 1)
                                {
                                    NOTPERF_Flag_Y.Text = "不正常";
                                }

                                if (status_Y[8] == 0)
                                {
                                    WRONG_Flag_Y.Text = "正常";
                                }
                                else if (status_Y[8] == 1)
                                {
                                    WRONG_Flag_Y.Text = "不正常";
                                }

                                if (status_Y[9] == 0)
                                {
                                    UVLO_Flag_Y.Text = "不正常";
                                }
                                else if (status_Y[9] == 1)
                                {
                                    UVLO_Flag_Y.Text = "正常";
                                }

                                if (status_Y[10] == 0)
                                {
                                    TH_WRN_Flag_Y.Text = "不正常";
                                }
                                else if (status_Y[10] == 1)
                                {
                                    TH_WRN_Flag_Y.Text = "正常";
                                }

                                if (status_Y[11] == 0)
                                {
                                    TH_SD_Flag_Y.Text = "不正常";
                                }
                                else if (status_Y[11] == 1)
                                {
                                    TH_SD_Flag_Y.Text = "正常";
                                }

                                if (status_Y[12] == 0)
                                {
                                    OCD_Flag_Y.Text = "不正常";
                                }
                                else if (status_Y[12] == 1)
                                {
                                    OCD_Flag_Y.Text = "正常";
                                }

                                if (status_Y[13] == 0)
                                {
                                    STEPLOSS_A_Flag_Y.Text = "不正常";
                                }
                                else if (status_Y[13] == 1)
                                {
                                    STEPLOSS_A_Flag_Y.Text = "正常";
                                }

                                if (status_Y[14] == 0)
                                {
                                    STEPLOSS_B_Flag_Y.Text = "不正常";
                                }
                                else if (status_Y[14] == 1)
                                {
                                    STEPLOSS_B_Flag_Y.Text = "正常";
                                }

                                if (motion_flagY == 0)
                                {
                                    Out_ABS_Y.Enabled = true;
                                    Out_Acc_Y.Enabled = true;
                                    Out_Dec_Y.Enabled = true;
                                    Out_MINSpeed_Y.Enabled = true;
                                }
                                else
                                {
                                    Out_ABS_Y.Enabled = false;
                                    Out_Acc_Y.Enabled = false;
                                    Out_Dec_Y.Enabled = false;
                                    Out_MINSpeed_Y.Enabled = false;
                                }

                                #endregion

                                break;
                        }
                    }

                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x00))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_Z.Text = f.Byte2value(revcmd).ToString();
                                break;
                            case 0x04:
                                Now_Acc_Z.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x05:
                                Now_Dec_Z.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x03:
                                if (motion_flagZ == 0x00)
                                    Now_Speed_Z.Text = "0";
                                else
                                    Now_Speed_Z.Text = f.Byte2value(revcmd).ToString() ;
                                break;
                            case 0x06:
                                Now_MAXSpeed_Z.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_Z.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x15:
                                Now_StepMode_Z.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                break;
                            case 0x18:
                                Now_Status_Z.Text = f.Byte2value(revcmd).ToString();
                                status_Z = s.Status_analysis(Now_Status_Z.Text);

                                #region 狀態判別
                                if (status_Z[0] == 0)
                                {
                                    HIZ_Z = 0;
                                    HIZ_Flag_Z.Text = " N High Z";
                                    Out_StepMode_Z.Enabled = false;
                                }
                                else if (status_Z[0] == 1)
                                {
                                    HIZ_Z = 1;
                                    HIZ_Flag_Z.Text = "  High Z";
                                    Out_StepMode_Z.Enabled = true;
                                }

                                if (status_Z[1] == 0)
                                {  //負邏輯
                                    BUSY_Z = 0;
                                    BUSY_Flag_Z.Text = "忙碌中";
                                }
                                else if (status_Z[1] == 1)
                                {
                                    BUSY_Z = 1;
                                    BUSY_Flag_Z.Text = "動作完成";
                                }

                                if (status_Z[4] == 0)
                                {
                                    DIR_Flag_Z.Text = "逆時針";
                                }
                                else if (status_Z[4] == 1)
                                {
                                    DIR_Flag_Z.Text = "順時針";
                                }

                                if (status_Z[5] == 0 && status_Z[6] == 0)
                                {
                                    motionZ.Text = "停止";
                                    motion_flagZ = 0;
                                }
                                else if (status_Z[6] == 0 && status_Z[5] == 1)
                                {
                                    motionZ.Text = "加速中";
                                    motion_flagZ = 1;
                                }

                                else if (status_Z[6] == 1 && status_Z[5] == 0)
                                {
                                    motionZ.Text = "減速中";
                                    motion_flagZ = 2;
                                }

                                else if (status_Z[6] == 1 && status_Z[5] == 1)
                                {
                                    motionZ.Text = "定速";
                                    motion_flagZ = 3;
                                }

                                if (status_Z[7] == 0)
                                {
                                    NOTPERF_Flag_Z.Text = "正常";
                                }
                                else if (status_Z[7] == 1)
                                {
                                    NOTPERF_Flag_Z.Text = "不正常";
                                }

                                if (status_Z[8] == 0)
                                {
                                    WRONG_Flag_Z.Text = "正常";
                                }
                                else if (status_Z[8] == 1)
                                {
                                    WRONG_Flag_Z.Text = "不正常";
                                }

                                if (status_Z[9] == 0)
                                {
                                    UVLO_Flag_Z.Text = "不正常";
                                }
                                else if (status_Z[9] == 1)
                                {
                                    UVLO_Flag_Z.Text = "正常";
                                }

                                if (status_Z[10] == 0)
                                {
                                    TH_WRN_Flag_Z.Text = "不正常";
                                }
                                else if (status_Z[10] == 1)
                                {
                                    TH_WRN_Flag_Z.Text = "正常";
                                }

                                if (status_Z[11] == 0)
                                {
                                    TH_SD_Flag_Z.Text = "不正常";
                                }
                                else if (status_Z[11] == 1)
                                {
                                    TH_SD_Flag_Z.Text = "正常";
                                }

                                if (status_Z[12] == 0)
                                {
                                    OCD_Flag_Z.Text = "不正常";
                                }
                                else if (status_Z[12] == 1)
                                {
                                    OCD_Flag_Z.Text = "正常";
                                }

                                if (status_Z[13] == 0)
                                {
                                    STEPLOSS_A_Flag_Z.Text = "不正常";
                                }
                                else if (status_Z[13] == 1)
                                {
                                    STEPLOSS_A_Flag_Z.Text = "正常";
                                }

                                if (status_Z[14] == 0)
                                {
                                    STEPLOSS_B_Flag_Z.Text = "不正常";
                                }
                                else if (status_Z[14] == 1)
                                {
                                    STEPLOSS_B_Flag_Z.Text = "正常";
                                }

                                if (motion_flagZ == 0)
                                {
                                    Out_ABS_Z.Enabled = true;
                                    Out_Acc_Z.Enabled = true;
                                    Out_Dec_Z.Enabled = true;
                                    Out_MINSpeed_Z.Enabled = true;
                                }
                                else
                                {
                                    Out_ABS_Z.Enabled = false;
                                    Out_Acc_Z.Enabled = false;
                                    Out_Dec_Z.Enabled = false;
                                    Out_MINSpeed_Z.Enabled = false;
                                }

                                #endregion

                                break;
                        }
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x01))
                    {
                        switch (revcmd[4])
                        {
                            case 0:
                                Now_ABS_U.Text = f.Byte2value(revcmd).ToString();
                                break;
                            case 0x04:
                                Now_Acc_U.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x05:
                                Now_Dec_U.Text = f.Byte2value(revcmd).ToString() + " step/s²";
                                break;
                            case 0x03:
                                if (motion_flagU == 0x00)
                                    Now_Speed_U.Text = "0" ;
                                else
                                    Now_Speed_U.Text = f.Byte2value(revcmd).ToString() ;
                                break;
                            case 0x06:
                                Now_MAXSpeed_U.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x07:
                                Now_MINSpeed_U.Text = f.Byte2value(revcmd).ToString() + " step/s";
                                break;
                            case 0x15:
                                Now_StepMode_U.Text = Math.Pow(2, f.Byte2value(revcmd)).ToString();
                                break;
                            case 0x18:
                                Now_Status_U.Text = f.Byte2value(revcmd).ToString();
                                
                                status_U = s.Status_analysis(Now_Status_U.Text);

                                #region 狀態判別
                                if (status_U[0] == 0)
                                {
                                    HIZ_U = 0;
                                    HIZ_Flag_U.Text = " N High Z";
                                    Out_StepMode_U.Enabled = false;
                                }
                                else if (status_U[0] == 1)
                                {
                                    HIZ_U = 1;
                                    HIZ_Flag_U.Text = "High Z";
                                    Out_StepMode_U.Enabled = true;
                                }

                                if (status_U[1] == 0)
                                {
                                    BUSY_U = 0;
                                    BUSY_Flag_U.Text = "忙碌中";
                                }
                                else if (status_U[1] == 1)
                                {
                                    BUSY_U = 1;
                                    BUSY_Flag_U.Text = "動作完成";
                                }

                                if (status_U[4] == 0)
                                {
                                    DIR_Flag_U.Text = "逆時針";
                                }
                                else if (status_U[4] == 1)
                                {
                                    DIR_Flag_U.Text = "順時針";
                                }

                                if (status_U[5] == 0 && status_U[6] == 0)
                                {
                                    motionU.Text = "停止";
                                    motion_flagU = 0;
                                }
                                else if (status_U[6] == 0 && status_U[5] == 1)
                                {
                                    motionU.Text = "加速中";
                                    motion_flagU = 1;
                                }

                                else if (status_U[6] == 1 && status_U[5] == 0)
                                {
                                    motionU.Text = "減速中";
                                    motion_flagU = 2;
                                }

                                else if (status_U[6] == 1 && status_U[5] == 1)
                                {
                                    motionU.Text = "定速";
                                    motion_flagU = 3;
                                }

                                if (status_U[7] == 0)
                                {
                                    NOTPERF_Flag_U.Text = "正常";
                                }
                                else if (status_U[7] == 1)
                                {
                                    NOTPERF_Flag_U.Text = "不正常";
                                }

                                if (status_U[8] == 0)
                                {
                                    WRONG_Flag_U.Text = "正常";
                                }
                                else if (status_U[8] == 1)
                                {
                                    WRONG_Flag_U.Text = "不正常";
                                }

                                if (status_U[9] == 0)
                                {
                                    UVLO_Flag_U.Text = "不正常";
                                }
                                else if (status_U[9] == 1)
                                {
                                    UVLO_Flag_U.Text = "正常";
                                }

                                if (status_U[10] == 0)
                                {
                                    TH_WRN_Flag_U.Text = "不正常";
                                }
                                else if (status_U[10] == 1)
                                {
                                    TH_WRN_Flag_U.Text = "正常";
                                }

                                if (status_U[11] == 0)
                                {
                                    TH_SD_Flag_U.Text = "不正常";
                                }
                                else if (status_U[11] == 1)
                                {
                                    TH_SD_Flag_U.Text = "正常";
                                }

                                if (status_U[12] == 0)
                                {
                                    OCD_Flag_U.Text = "不正常";
                                }
                                else if (status_U[12] == 1)
                                {
                                    OCD_Flag_U.Text = "正常";
                                }

                                if (status_U[13] == 0)
                                {
                                    STEPLOSS_A_Flag_U.Text = "不正常";
                                }
                                else if (status_U[13] == 1)
                                {
                                    STEPLOSS_A_Flag_U.Text = "正常";
                                }

                                if (status_U[14] == 0)
                                {
                                    STEPLOSS_B_Flag_U.Text = "不正常";
                                }
                                else if (status_U[14] == 1)
                                {
                                    STEPLOSS_B_Flag_U.Text = "正常";
                                }

                                if (motion_flagU == 0)
                                {
                                    Out_ABS_U.Enabled = true;
                                    Out_Acc_U.Enabled = true;
                                    Out_Dec_U.Enabled = true;
                                    Out_MINSpeed_U.Enabled = true;
                                }
                                else
                                {
                                    Out_ABS_U.Enabled = false;
                                    Out_Acc_U.Enabled = false;
                                    Out_Dec_U.Enabled = false;
                                    Out_MINSpeed_U.Enabled = false;
                                }

                                #endregion

                                break;

                        }
                       
                    }

                }
                

                //get status
                else if ((revcmd[1] == 0xa))
                {
                    mesg_status = "";
                    if ((revcmd[2] == 0x00) & (revcmd[3] == 0x00))
                    {

                        #region 程式
                        status = s.Status_analysis(f.Byte2value(revcmd).ToString());
                        //Array.Copy(s.Status_analysis(f.byte2value(revcmd).ToString()),status,15);

                        if (status[0] == 1)
                        {
                            mesg_status += "HIZ:high impedance state\n";
                        }
                        else
                        {
                            mesg_status += "HIZ:not high impedance state\n";
                        }

                        if (status[1] == 1)
                        {
                            mesg_status += "Busy: command has been completed \n";
                        }
                        else
                        {
                            mesg_status += "Busy: command hasn't been completed \n"; ;
                        }

                        if (status[7] == 1)
                        {
                            mesg_status += " NOTPERF_CMD:  command received by SPI cannot be performed \n";
                        }


                        if (status[8] == 1)
                        {
                            mesg_status += "WRONG_CMD: command received by SPI  does not exist at all. \n";
                        }




                        if (status[9] == 0)
                        {
                            mesg_status += " UVLO: undervoltage lockout \n";
                        }



                        if (status[10] == 0)
                        {
                            mesg_status += "TH_WRN: thermal warning \n";
                        }



                        if (status[11] == 0)
                        {
                            mesg_status += "TH_SD: thermal shutdown \n";
                        }



                        if (status[12] == 0)
                        {
                            mesg_status += "OCD: overcurrent detection \n";
                        }


                        if (status[13] == 0)
                        {
                            mesg_status += "STEP_LOSS_A:  a stall is detected on bridge A   \n";
                        }



                        if (status[14] == 0)
                        {
                            mesg_status += "STEP_LOSS_B:  a stall is detected on  bridge B  \n";
                        }

                        MessageBox.Show($"X軸狀態:\n{mesg_status} 請解決問題後繼續操作");
                        #endregion

                    }

                    else if ((revcmd[2] == 0x00) & (revcmd[3] == 0x01))
                    {
                        #region 程式
                        status = s.Status_analysis(f.Byte2value(revcmd).ToString());
                        Array.Copy(s.Status_analysis(f.Byte2value(revcmd).ToString()), status, 15);

                        if (status[0] == 1)
                        {
                            mesg_status += "HIZ:high impedance state\n";
                        }
                        else
                        {
                            mesg_status += "HIZ:not high impedance state\n";
                        }

                        if (status[1] == 1)
                        {
                            mesg_status += "Busy: command has been completed \n";
                        }
                        else
                        {
                            mesg_status += "Busy: command hasn't been completed \n"; ;
                        }




                        if (status[7] == 1)
                        {
                            mesg_status += " NOTPERF_CMD:  command received by SPI cannot be performed \n";
                        }


                        if (status[8] == 1)
                        {
                            mesg_status += "WRONG_CMD: command received by SPI  does not exist at all. \n";
                        }




                        if (status[9] == 0)
                        {
                            mesg_status += " UVLO: undervoltage lockout \n";
                        }



                        if (status[10] == 0)
                        {
                            mesg_status += "TH_WRN: thermal warning \n";
                        }



                        if (status[11] == 0)
                        {
                            mesg_status += "TH_SD: thermal shutdown \n";
                        }



                        if (status[12] == 0)
                        {
                            mesg_status += "OCD: overcurrent detection \n";
                        }


                        if (status[13] == 0)
                        {
                            mesg_status += "STEP_LOSS_A:  a stall is detected on bridge A   \n";
                        }



                        if (status[14] == 0)
                        {
                            mesg_status += "STEP_LOSS_B:  a stall is detected on  bridge B  \n";
                        }

                        MessageBox.Show($"Y軸狀態:\n{mesg_status} 請解決問題後繼續操作");
                        #endregion
                    }

                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x00))
                    {
                        #region 程式
                        status = s.Status_analysis(f.Byte2value(revcmd).ToString());
                        Array.Copy(s.Status_analysis(f.Byte2value(revcmd).ToString()), status, 15);

                        if (status[0] == 1)
                        {
                            mesg_status += "HIZ:high impedance state\n";
                        }
                        else
                        {
                            mesg_status += "HIZ:not high impedance state\n";
                        }

                        if (status[1] == 1)
                        {
                            mesg_status += "Busy: command has been completed \n";
                        }
                        else
                        {
                            mesg_status += "Busy: command hasn't been completed \n"; ;
                        }




                        if (status[7] == 1)
                        {
                            mesg_status += " NOTPERF_CMD:  command received by SPI cannot be performed \n";
                        }


                        if (status[8] == 1)
                        {
                            mesg_status += "WRONG_CMD: command received by SPI  does not exist at all. \n";
                        }




                        if (status[9] == 0)
                        {
                            mesg_status += " UVLO: undervoltage lockout \n";
                        }



                        if (status[10] == 0)
                        {
                            mesg_status += "TH_WRN: thermal warning \n";
                        }



                        if (status[11] == 0)
                        {
                            mesg_status += "TH_SD: thermal shutdown \n";
                        }



                        if (status[12] == 0)
                        {
                            mesg_status += "OCD: overcurrent detection \n";
                        }


                        if (status[13] == 0)
                        {
                            mesg_status += "STEP_LOSS_A:  a stall is detected on bridge A   \n";
                        }



                        if (status[14] == 0)
                        {
                            mesg_status += "STEP_LOSS_B:  a stall is detected on  bridge B  \n";
                        }

                        MessageBox.Show($"Z軸狀態:\n{mesg_status} 請解決問題後繼續操作");
                        #endregion
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x01))
                    {

                        #region 程式
                        status = s.Status_analysis(f.Byte2value(revcmd).ToString());
                        Array.Copy(s.Status_analysis(f.Byte2value(revcmd).ToString()), status, 15);

                        if (status[0] == 1)
                        {
                            mesg_status += "HIZ:high impedance state\n";
                        }
                        else
                        {
                            mesg_status += "HIZ:not high impedance state\n";
                        }

                        if (status[1] == 1)
                        {
                            mesg_status += "Busy: command has been completed \n";
                        }
                        else
                        {
                            mesg_status += "Busy: command hasn't been completed \n"; ;
                        }




                        if (status[7] == 1)
                        {
                            mesg_status += " NOTPERF_CMD:  command received by SPI cannot be performed \n";
                        }


                        if (status[8] == 1)
                        {
                            mesg_status += "WRONG_CMD: command received by SPI  does not exist at all. \n";
                        }




                        if (status[9] == 0)
                        {
                            mesg_status += " UVLO: undervoltage lockout \n";
                        }



                        if (status[10] == 0)
                        {
                            mesg_status += "TH_WRN: thermal warning \n";
                        }



                        if (status[11] == 0)
                        {
                            mesg_status += "TH_SD: thermal shutdown \n";
                        }



                        if (status[12] == 0)
                        {
                            mesg_status += "OCD: overcurrent detection \n";
                        }


                        if (status[13] == 0)
                        {
                            mesg_status += "STEP_LOSS_A:  a stall is detected on bridge A   \n";
                        }



                        if (status[14] == 0)
                        {
                            mesg_status += "STEP_LOSS_B:  a stall is detected on  bridge B  \n";
                        }

                        MessageBox.Show($"U軸狀態:\n{mesg_status} 請解決問題後繼續操作");
                        #endregion

                    }
                }
                //L+
                else if ((revcmd[1] == 0x20))
                {

                    if ((revcmd[2] == 0x00) & (revcmd[3] == 0x00))
                    {
                        X_Lmax.Image = limit_signal.red;
                        X_Lmax_Flag = 1;
                        panelX.Enabled = false;
                        
                    }
                    
                    else if ((revcmd[2] == 0x00) & (revcmd[3] == 0x01))
                    {
                        Y_Lmax.Image = limit_signal.red;
                        Y_Lmax_Flag = 1;
                        panelY.Enabled = false;
                       
                    }

                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x00))
                    {
                        Z_Lmax.Image = limit_signal.red;
                        Z_Lmax_Flag = 1;
                        panelZ.Enabled = false;
                        
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x01))
                    {
                        U_Lmax.Image = limit_signal.red;
                        U_Lmax_Flag = 1;
                        panelU.Enabled = false;
                        

                    }

                }
                //L-
                else if ((revcmd[1] == 0x21))
                {

                    if ((revcmd[2] == 0x00) & (revcmd[3] == 0x00))
                    {
                        X_Lmin.Image = limit_signal.red;
                        X_Lmin_Flag = 1;
                        panelX.Enabled = false;
                        
                    }

                    else if ((revcmd[2] == 0x00) & (revcmd[3] == 0x01))
                    {
                        Y_Lmin.Image = limit_signal.red;
                        Y_Lmin_Flag = 1;
                        panelY.Enabled = false;
                        
                    }

                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x00))
                    {
                        Z_Lmin.Image = limit_signal.red;
                        Z_Lmin_Flag = 1;
                        panelZ.Enabled = false;
                        
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x01))
                    {
                        U_Lmin.Image = limit_signal.red;
                        U_Lmin_Flag = 1;
                        panelU.Enabled = false;
                        
                    }

                }
                //Home
                else if ((revcmd[1] == 0x22))
                {

                    if ((revcmd[2] == 0x00) & (revcmd[3] == 0x00))
                    {
                        MessageBox.Show("X軸復歸完成");
                    }

                    else if ((revcmd[2] == 0x00) & (revcmd[3] == 0x01))
                    {
                        MessageBox.Show("Y軸復歸完成");
                    }

                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x00))
                    {
                        MessageBox.Show("Z軸復歸完成");
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x01))
                    {
                        MessageBox.Show("U軸復歸完成");
                    }

                }
                //解決極限異常
                else if ((revcmd[1] == 0x23)) 
                {
                    if ((revcmd[2] == 0x00) & (revcmd[3] == 0x00))
                    {
                        if(revcmd[4]==0x1)
                        {   X_Lmax_Reset.Enabled = false;
                            X_Lmax.Image = limit_signal.green;
                            X_Lmax_Flag = 0;
                            MessageBox.Show("X+ 極限異常已解決");
                            
                        }
                        else if(revcmd[4]==0x0)
                        {
                            X_Lmin.Image = limit_signal.green;
                            X_Lmin_Flag = 0;
                            X_Lmin_Reset.Enabled = false;
                            MessageBox.Show("X- 極限異常已解決");
                        }

                        
                        panelX.Enabled = true;
                       
                    }

                    else if ((revcmd[2] == 0x00) & (revcmd[3] == 0x01))
                    {

                        if (revcmd[4] == 0x1)
                        {
                            Y_Lmax.Image = limit_signal.green;
                            Y_Lmax_Flag = 0;
                            Y_Lmax_Reset.Enabled = false;
                            MessageBox.Show("Y+ 極限異常已解決");
                        }
                        else if (revcmd[4] == 0x0)
                        {
                            Y_Lmin.Image = limit_signal.green;
                            Y_Lmin_Flag = 0;
                            Y_Lmin_Reset.Enabled = false;
                            MessageBox.Show("Y- 極限異常已解決");
                        }
                     
                        panelY.Enabled = true;
                        
                    }

                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x00))
                    {

                        if (revcmd[4] == 0x1)
                        {
                            Z_Lmax.Image = limit_signal.green;
                            Z_Lmax_Flag = 0;
                            Z_Lmax_Reset.Enabled = false;
                            MessageBox.Show("Z+ 極限異常已解決");
                        }
                        else if (revcmd[4] == 0x0)
                        {
                            Z_Lmin.Image = limit_signal.green;
                            Z_Lmin_Flag = 0;
                            Z_Lmin_Reset.Enabled = false;
                            MessageBox.Show("Z- 極限異常已解決");
                        }
                        
                        panelZ.Enabled = true;
                       
                    }
                    else if ((revcmd[2] == 0x01) & (revcmd[3] == 0x01))
                    {

                        if (revcmd[4] == 0x1)
                        {
                            U_Lmax.Image = limit_signal.green;
                            U_Lmax_Flag = 0;
                            U_Lmax_Reset.Enabled = false;
                            MessageBox.Show("U+ 極限異常已解決");
                        }
                        else if (revcmd[4] == 0x0)
                        {
                            U_Lmin.Image = limit_signal.green;
                            U_Lmin_Flag = 0;
                            U_Lmin_Reset.Enabled = false;
                            MessageBox.Show("U- 極限異常已解決");
                        }
                       
                        panelU.Enabled = true;
                        

                    }
                }
                serialPort1.DiscardInBuffer();

            }
            #endregion
        }

        #endregion

        #region 指令X
        private void Move_X_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                //if (serialPort1.IsOpen)
                //{
                //    serialPort1.Close();
                //}
                //serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
              
                Value = Convert.ToInt32(Move_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x01;//指令 步數或圈數 
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達

                if (Value >= 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                #endregion

                if((X_Lmin_Flag == 1 && SendOrder[4] == 0x00)|| (X_Lmax_Flag == 1 && SendOrder[4] ==0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    if (X_Lmin_Flag == 1 || X_Lmax_Flag == 1)
                    {
                        SendOrder[1] = 0x23;
                        if(SendOrder[4]==0x00)
                        {
                            SendOrder[4] =0x01;
                        }else
                        {
                            SendOrder[4] = 0x00;
                        }



                    }
                    
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Move");
            }
            #endregion
        }

        private void Gohome_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
                
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x02;//指令
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Gohome");
            }
            #endregion

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
               
                SendOrder[0] = 0x55;

                #region 停止方式
                if (HardStop.Checked)
                {
                    SendOrder[1] = 0x03;//指令
                }
                else if (SoftStop.Checked)
                {
                    SendOrder[1] = 0x04;//指令
                }
                else if (SoftHiZ.Checked)
                {
                    SendOrder[1] = 0x05;//指令
                }
                else if (HardHiZ.Checked)
                {
                    SendOrder[1] = 0x06;//指令
                }
                #endregion


                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達

                SendOrder[4] = 0x00; //參數1 無
                SendOrder[5] = 0x0;//參數2 無

                #region 參數3 資料 無
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Stop");
            }
            #endregion

        }

        private void GoTo_Click(object sender, EventArgs e)
        {

            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
                
                Value = Convert.ToInt32(GoTo_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x07;//指令 步數或圈數 
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達

                if (Value > 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);


                #endregion
                if ((X_Lmin_Flag == 1 && SendOrder[4] == 0x00) || (X_Lmax_Flag == 1 && SendOrder[4] == 0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GoTo");
            }
            #endregion


        }

        
        private void Run_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
              
                Value = Convert.ToInt32(Run_value.Text);

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x09;//指令 步數或圈數 
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達
                if (Value > 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向之後寫
                }
                else
                {
                    SendOrder[4] = 0x01; //參數1 方向之後寫
                    Value *= (-1);
                }


                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                //SendOrder[6] = 0x00;
                //SendOrder[7] = 0x00;
                //SendOrder[8] = 0x00;
                //SendOrder[9] = 0x00;
                #endregion

                
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Run");
            }
            #endregion

        }

        private void GetStatus_X_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
               
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x0a;//指令
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GetStatus");
            }
            #endregion
        }


        private void Home_Reset_X_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x22;//指令
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達

                if (Home_Reset_X_Dir_L.Checked == true)
                {
                    SendOrder[4] = 0x00;
                }
                else if (Home_Reset_X_Dir_R.Checked == true)
                {
                    SendOrder[4] = 0x01;
                }


                if (HOME_X_L.Checked==true)
                {
                    SendOrder[5] = 0x00;
                }else if(HOME_X_R.Checked == true)
                {
                    SendOrder[5] = 0x01;
                }

                Value = Convert.ToInt32(Home_Reset_step.Text);

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Gohome");
            }
            #endregion

        }





        #endregion

        #region setparm X

        private void Out_ABS_X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {

                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x00; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    if (Value >= 0)
                    {
                        SendOrder[5] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[5] = 0x00; //參數1 方向
                        Value *= -1;
                    }


                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

            
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_ABS");
                }
                #endregion
            }
        }

       

        private void Out_Acc_X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                    
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x04; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Acc_X.Text);

                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

     
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Acc");
                }
                #endregion
            }
        }

        private void Out_Dec_X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                   
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x05; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Dec_X.Text);

                   
                   
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

               
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Dec");
                }
                #endregion
            }
        }

        private void Out_Speed_X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                 
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x03; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Speed_X.Text);

                   
                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                   
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Speed");
                }
                #endregion
            }
        }

        private void Out_MINSpeed_X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                 
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x07; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MINSpeed_X.Text);

                 
                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Min");
                }
                #endregion
            }
        }

        private void Out_MAXSpeed_X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                 
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x06; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MAXSpeed_X.Text);

              
                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

 
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Max");
                }
                #endregion
            }
        }

        private void Out_StepMode_X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                   
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x15; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_StepMode_X.Text);

               
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion


                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_StepMode");
                }
                #endregion
            }
        }


        #endregion
      


        #region 指令Y
        private void Move_Y_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
              
                Value = Convert.ToInt32(MoveY_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x01;//指令 步數或圈數 
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x01;//馬達

                if (Value > 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                #endregion
                if ((Y_Lmin_Flag == 1 && SendOrder[4] == 0x00) || (Y_Lmax_Flag == 1 && SendOrder[4] == 0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    if (Y_Lmin_Flag == 1 || Y_Lmax_Flag == 1)
                    {
                        SendOrder[1] = 0x23;
                        if (SendOrder[4] == 0x00)
                        {
                            SendOrder[4] = 0x01;
                        }
                        else
                        {
                            SendOrder[4] = 0x00;
                        }
                    }
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Move");
            }
            #endregion
        }

        private void GoTo_Y_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
              
                Value = Convert.ToInt32(GoTo_Y_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x07;//指令 步數或圈數 
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x01;//馬達

                if (Value > 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                #endregion
                if ((Y_Lmin_Flag == 1 && SendOrder[4] == 0x00) || (Y_Lmax_Flag == 1 && SendOrder[4] == 0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GoTo");
            }
            #endregion
        }

        private void Stop_Y_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
             
                SendOrder[0] = 0x55;

                #region 停止方式
                if (HardStop_Y.Checked)
                {
                    SendOrder[1] = 0x03;//指令
                }
                else if (SoftStop_Y.Checked)
                {
                    SendOrder[1] = 0x04;//指令
                }
                else if (SoftHiZ_Y.Checked)
                {
                    SendOrder[1] = 0x05;//指令
                }
                else if (HardHiZ_Y.Checked)
                {
                    SendOrder[1] = 0x06;//指令
                }
                #endregion


                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x01;//馬達

                SendOrder[4] = 0x00; //參數1 無
                SendOrder[5] = 0x0;//參數2 無

                #region 參數3 資料 無
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Stop");
            }
            #endregion
        }

        private void Gohome_Y_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
            
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x02;//指令
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x01;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Gohome");
            }
            #endregion
        }

        private void GetStatus_Y_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
             
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x0a;//指令
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x01;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GetStatus");
            }
            #endregion
        }
        private void Home_Reset_Y_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x22;//指令
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x01;//馬達

                if (Home_Reset_Y_Dir_L.Checked == true)
                {
                    SendOrder[4] = 0x00;
                }
                else if (Home_Reset_Y_Dir_R.Checked == true)
                {
                    SendOrder[4] = 0x01;
                }

                if (HOME_Y_L.Checked == true)
                {
                    SendOrder[5] = 0x00;
                }
                else if (HOME_Y_R.Checked == true)
                {
                    SendOrder[5] = 0x01;
                }

                Value = Convert.ToInt32(Home_Reset_step.Text);

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Gohome");
            }
            #endregion

        }

        #endregion

        # region set Y
        private void Out_ABS_Y_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {

                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
            
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x00; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_ABS_Y.Text);
                    if (Value >= 0)
                    {
                        SendOrder[5] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[5] = 0x00; //參數1 方向
                        Value *= -1;
                    }

                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_ABS");
                }
                #endregion
            }
        }



        private void Out_Acc_Y_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
               
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x04; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Acc_Y.Text);


                    // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Acc");
                }
                #endregion
            }
        }

        private void Out_Dec_Y_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                  
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x05; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Dec_Y.Text);

                    // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Dec");
                }
                #endregion
            }
        }

        private void Out_Speed_Y_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                    
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x03; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Speed_Y.Text);


                    // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Speed");
                }
                #endregion
            }
        }

        private void Out_MINSpeed_Y_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                    
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x07; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MINSpeed_Y.Text);


                    // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Min");
                }
                #endregion
            }
        }

        private void Out_MAXSpeed_Y_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                 
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x06; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MAXSpeed_Y.Text);


                    // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Max");
                }
                #endregion
            }
        }

        private void Out_StepMode_Y_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                    
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x15; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_StepMode_Y.Text);



                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_StepMode");
                }
                #endregion
            }
        }








        #endregion

        #region 指令Z

        private void Move_Z_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
        
                Value = Convert.ToInt32(MoveZ_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x01;//指令 步數或圈數 
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x00;//馬達

                if (Value > 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                #endregion
                if ((Z_Lmin_Flag == 1 && SendOrder[4] == 0x00) || (Z_Lmax_Flag == 1 && SendOrder[4] == 0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    if (Z_Lmin_Flag == 1 || Z_Lmax_Flag == 1)
                    {
                        SendOrder[1] = 0x23;
                        if (SendOrder[4] == 0x00)
                        {
                            SendOrder[4] = 0x01;
                        }
                        else
                        {
                            SendOrder[4] = 0x00;
                        }
                    }
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Move");
            }
            #endregion
        }

        private void GoTo_Z_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
          
                Value = Convert.ToInt32(GoTo_Z_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x07;//指令 步數或圈數 
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x00;//馬達

                if (Value > 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
;
                #endregion
                if ((Z_Lmin_Flag == 1 && SendOrder[4] == 0x00) || (Z_Lmax_Flag == 1 && SendOrder[4] == 0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GoTo");
            }
            #endregion
        }

        private void Stop_Z_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
          
                SendOrder[0] = 0x55;

                #region 停止方式
                if (HardStop_Z.Checked)
                {
                    SendOrder[1] = 0x03;//指令
                }
                else if (SoftStop_Z.Checked)
                {
                    SendOrder[1] = 0x04;//指令
                }
                else if (SoftHiZ_Z.Checked)
                {
                    SendOrder[1] = 0x05;//指令
                }
                else if (HardHiZ_Z.Checked)
                {
                    SendOrder[1] = 0x06;//指令
                }
                #endregion


                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x00;//馬達

                SendOrder[4] = 0x00; //參數1 無
                SendOrder[5] = 0x0;//參數2 無

                #region 參數3 資料 無
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Stop");
            }
            #endregion
        }

        private void Gohome_Z_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
          
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x02;//指令
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x00;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Gohome");
            }
            #endregion
        }
        private void GetStatus_Z_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
        
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x0a;//指令
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x00;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GetStatus");
            }
            #endregion
        }
        private void Home_Reset_Z_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x22;//指令
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x00;//馬達

                if (Home_Reset_Z_Dir_L.Checked == true)
                {
                    SendOrder[4] = 0x00;
                }
                else if (Home_Reset_Z_Dir_R.Checked == true)
                {
                    SendOrder[4] = 0x01;
                }

                if (HOME_Z_L.Checked == true)
                {
                    SendOrder[5] = 0x00;
                }
                else if (HOME_Z_R.Checked == true)
                {
                    SendOrder[5] = 0x01;
                }

                Value = Convert.ToInt32(Home_Reset_step.Text);

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Gohome");
            }
            #endregion

        }
        #endregion

        #region SET z

        private void Out_ABS_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {

                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
          
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x00; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_ABS_Z.Text);
                    if (Value >= 0)
                    {
                        SendOrder[5] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[5] = 0x00; //參數1 方向
                        Value *= -1;
                    }

                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_ABS");
                }
                #endregion
            }
        }

        private void Out_Acc_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
          
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x04; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Acc_Z.Text);


                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Acc");
                }
                #endregion
            }
        }

        private void Out_Dec_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
               
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x05; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Dec_Z.Text);


                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Dec");
                }
                #endregion
            }
        }

        private void Out_Speed_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
      
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x03; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Speed_Z.Text);

                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Speed");
                }
                #endregion
            }
        }

        private void Out_MINSpeed_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
               
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x07; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MINSpeed_Z.Text);

                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Min");
                }
                #endregion
            }
        }

        private void Out_MAXSpeed_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
     
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x06; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MAXSpeed_Z.Text);


                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Max");
                }
                #endregion
            }
        }

        private void Out_StepMode_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
         
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x15; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_StepMode_Z.Text);

                    
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_StepMode");
                }
                #endregion
            }
        }
        #endregion

        #region 指令 U

        private void Move_U_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
 
                Value = Convert.ToInt32(MoveU_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x01;//指令 步數或圈數 
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x01;//馬達

                if (Value > 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                #endregion
                if ((U_Lmin_Flag == 1 && SendOrder[4] == 0x00) || (U_Lmax_Flag == 1 && SendOrder[4] == 0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    if (U_Lmin_Flag == 1 || U_Lmax_Flag == 1)
                    {
                        if (SendOrder[4] == 0x00)
                        {
                            SendOrder[4] = 0x01;
                        }
                        else
                        {
                            SendOrder[4] = 0x00;
                        }
                        SendOrder[1] = 0x23;
                    }
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Move");
            }
            #endregion
        }

        private void GoTo_U_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
                
                Value = Convert.ToInt32(GoTo_U_value.Text);
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x07;//指令 步數或圈數 
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x01;//馬達

                if (Value > 0)
                {
                    SendOrder[4] = 0x01; //參數1 方向
                }
                else if (Value < 0)
                {
                    SendOrder[4] = 0x00; //參數1 方向
                    Value *= -1;
                }

                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                #endregion
                if ((U_Lmin_Flag == 1 && SendOrder[4] == 0x00) || (U_Lmax_Flag == 1 && SendOrder[4] == 0x01))
                {
                    MessageBox.Show("移動方向錯誤請修正以免撞機");
                }
                else
                {
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GoTo");
            }
            #endregion
        }

        private void Stop_U_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
              
                SendOrder[0] = 0x55;

                #region 停止方式
                if (HardStop_U.Checked)
                {
                    SendOrder[1] = 0x03;//指令
                }
                else if (SoftStop_U.Checked)
                {
                    SendOrder[1] = 0x04;//指令
                }
                else if (SoftHiZ_U.Checked)
                {
                    SendOrder[1] = 0x05;//指令
                }
                else if (HardHiZ_U.Checked)
                {
                    SendOrder[1] = 0x06;//指令
                }
                #endregion


                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x01;//馬達

                SendOrder[4] = 0x00; //參數1 無
                SendOrder[5] = 0x0;//參數2 無

                #region 參數3 資料 無
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Stop");
            }
            #endregion
        }

        private void Gohome_U_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
             
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x02;//指令
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x01;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Gohome");
            }
            #endregion
        }

        private void GetStatus_U_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x0a;//指令
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x01;//馬達

                SendOrder[4] = 0x00; //參數1 方向
                SendOrder[5] = 0x00;//參數2 無

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_GetStatus");
            }
            #endregion
        }


        private void Home_Reset_U_Click(object sender, EventArgs e)
                {
                    #region 動作
                    try
                    {
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Close();
                        }
                        serialPort1.Open(); //打開串口
                        serialPort1.DiscardInBuffer();//清空緩衝區數據

                        SendOrder[0] = 0x55;

                        SendOrder[1] = 0x22;//指令
                        SendOrder[2] = 0x01;//版子
                        SendOrder[3] = 0x01;//馬達

                        if (Home_Reset_U_Dir_L.Checked == true)
                        {
                            SendOrder[4] = 0x00;
                        }
                        else if (Home_Reset_U_Dir_R.Checked == true)
                        {
                            SendOrder[4] = 0x01;
                        }

                        if (HOME_U_L.Checked == true)
                        {
                            SendOrder[5] = 0x00;
                        }
                        else if (HOME_U_R.Checked == true)
                        {
                            SendOrder[5] = 0x01;
                        }

                        Value = Convert.ToInt32(Home_Reset_step.Text);

                        #region 參數3 資料

                        SendOrder[6] = (byte)(Value & 0xff);
                        SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                        SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                        SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                        #endregion
                        serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                    }
                    catch
                    {
                        MessageBox.Show("請檢查串口1是否打開_Gohome");
                    }
                    #endregion

                }
        #endregion

        #region set U
        private void Out_ABS_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {

                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                  
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x00; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_ABS_U.Text);
                    if (Value >= 0)
                    {
                        SendOrder[5] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[5] = 0x00; //參數1 方向
                        Value *= -1;
                    }

                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_ABS");
                }
                #endregion
            }
        }

        private void Out_Acc_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
               
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x04; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Acc_U.Text);

                  
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Acc");
                }
                #endregion
            }
        }

        private void Out_Dec_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x05; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Dec_U.Text);

                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_DecU");
                }
                #endregion
            }
        }

        private void Out_Speed_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                    
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x03; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_Speed_U.Text);


                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Speed");
                }
                #endregion
            }
        }

        private void Out_MINSpeed_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                 
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x07; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MINSpeed_U.Text);

                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Min");
                }
                #endregion
            }
        }

        private void Out_MAXSpeed_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
       
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x06; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_MAXSpeed_U.Text);

                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Max");
                }
                #endregion
            }
        }

        private void Out_StepMode_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據
                
                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0xaa;//指令
                    SendOrder[2] = 0x01;//版子
                    SendOrder[3] = 0x01;//馬達

                    SendOrder[4] = 0x15; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Out_StepMode_U.Text);

                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

              
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_StepMode");
                }
                #endregion
            }
        }

        #endregion

        #region CHART
        private void RefreshChart(object sender, EventArgs e)
        {
            // 新增一個點至Series中
            int[] sort = new int[4] { 0, 0, 0, 0 };


            chart1.Series[0].Points.AddXY(m_nTimeCount, Convert.ToInt32(Now_Speed_X.Text));
            chart1.Series[1].Points.AddXY(m_nTimeCount, Convert.ToInt32(Now_Speed_Y.Text));
            chart1.Series[2].Points.AddXY(m_nTimeCount, Convert.ToInt32(Now_Speed_Z.Text));
            chart1.Series[3].Points.AddXY(m_nTimeCount, Convert.ToInt32(Now_Speed_U.Text));

            sort[0] = Convert.ToInt32(Now_Speed_X.Text);
            sort[1] = Convert.ToInt32(Now_Speed_Y.Text);
            sort[2] = Convert.ToInt32(Now_Speed_Z.Text);
            sort[3] = Convert.ToInt32(Now_Speed_U.Text);

           
            if (sort.Max() < 305)
                chart1.ChartAreas[0].AxisY.Maximum = 310;
            else
                chart1.ChartAreas[0].AxisY.Maximum = (int)(sort.Max() / 0.7)-(int)(sort.Max() / 0.7)%5;


            if (m_nTimeCount > 10)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = m_nTimeCount - 10; //將視窗焦點維持在最新的點那邊
            }
            m_nTimeCount++;


        }
        private void Chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (chart1.Series["X"].IsValueShownAsLabel == false)
            {
                chart1.Series["X"].IsValueShownAsLabel = true;
                chart1.Series["Y"].IsValueShownAsLabel = true;
                chart1.Series["Z"].IsValueShownAsLabel = true;
                chart1.Series["U"].IsValueShownAsLabel = true;
            }

            else
            {
                chart1.Series["X"].IsValueShownAsLabel = false;
                chart1.Series["Y"].IsValueShownAsLabel = false;
                chart1.Series["Z"].IsValueShownAsLabel = false;
                chart1.Series["U"].IsValueShownAsLabel = false;
            }
        }

        private void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0; //X軸數值從0開始
            chart1.ChartAreas[0].AxisX.ScaleView.Size = 50; //設定視窗範圍內一開始顯示多少點
            chart1.ChartAreas[0].AxisX.Interval = 5;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
           
        }

        #endregion

        #region 同步
        /// <summary>
        /// gohome ok1
        /// stop   ok
        /// reset 
        /// Move ok
        /// GOTO ok
        /// 
        /// </summary>
     
     
        private void Multiple_GoHome_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x2;//指令

                if (checkedListBox1.GetItemChecked(0))
                {
                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x00;
                    SendOrder[4] = 0x00; //參數1 無
                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = 0x00;
                    SendOrder[7] = 0x00;
                    SendOrder[8] = 0x00;
                    SendOrder[9] = 0x00;

                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(1))
                {
                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x01;
                    SendOrder[4] = 0x00; //參數1 無
                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = 0x00;
                    SendOrder[7] = 0x00;
                    SendOrder[8] = 0x00;
                    SendOrder[9] = 0x00;

                    #endregion


                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                //if(checkedListBox1.GetItemChecked(0) || checkedListBox1.GetItemChecked(1))
                //    ACTion(0);
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(2))
                {
                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x00;

                    SendOrder[4] = 0x00; //參數1 無
                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = 0x00;
                    SendOrder[7] = 0x00;
                    SendOrder[8] = 0x00;
                    SendOrder[9] = 0x00;

                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(3))
                {
                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x01;
                    SendOrder[4] = 0x00; //參數1 無
                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = 0x00;
                    SendOrder[7] = 0x00;
                    SendOrder[8] = 0x00;
                    SendOrder[9] = 0x00;

                    #endregion


                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);

                //if (checkedListBox1.GetItemChecked(2) || checkedListBox1.GetItemChecked(3))
                //    ACTion(1);
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
            #endregion
        }

        private void Multiple_Stop_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
             
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x04;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x00; 
                SendOrder[5] = 0x00;

                if (checkedListBox1.GetItemChecked(0))
                {

                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x00;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(1))
                {

                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x01;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(2))
                {

                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x00;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(3))
                {

                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x01;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);


                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

               

            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
            #endregion
        }

        private void RESET_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據
         
                SendOrder[0] = 0x55;

                SendOrder[1] = 0x22;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x00; 
                SendOrder[5] = 0x00;

                Value = Convert.ToInt32(Home_Reset_step.Text);

                #region 參數3 資料

                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion

                if (checkedListBox1.GetItemChecked(0))
                {

                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x00;
                    if (Home_Reset_X_Dir_L.Checked == true)
                    {
                        SendOrder[4] = 0x00;
                    }
                    else if (Home_Reset_X_Dir_R.Checked == true)
                    {
                        SendOrder[4] = 0x01;
                    }
                    if (HOME_X_L.Checked == true)
                    {
                        SendOrder[5] = 0x00;
                    }
                    else if (HOME_X_R.Checked == true)
                    {
                        SendOrder[5] = 0x01;
                    }
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(1))
                {

                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x01;
                    if (Home_Reset_Y_Dir_L.Checked == true)
                    {
                        SendOrder[4] = 0x00;
                    }
                    else if (Home_Reset_Y_Dir_R.Checked == true)
                    {
                        SendOrder[4] = 0x01;
                    }
                    if (HOME_Y_L.Checked == true)
                    {
                        SendOrder[5] = 0x00;
                    }
                    else if (HOME_Y_R.Checked == true)
                    {
                        SendOrder[5] = 0x01;
                    }
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(2))
                {

                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x00;
                    if (Home_Reset_Z_Dir_L.Checked == true)
                    {
                        SendOrder[4] = 0x00;
                    }
                    else if (Home_Reset_Z_Dir_R.Checked == true)
                    {
                        SendOrder[4] = 0x01;
                    }
                    if (HOME_Z_L.Checked == true)
                    {
                        SendOrder[5] = 0x00;
                    }
                    else if (HOME_Z_R.Checked == true)
                    {
                        SendOrder[5] = 0x01;
                    }
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(3))
                {

                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x01;
                    if (Home_Reset_U_Dir_L.Checked == true)
                    {
                        SendOrder[4] = 0x00;
                    }
                    else if (Home_Reset_U_Dir_R.Checked == true)
                    {
                        SendOrder[4] = 0x01;
                    }
                    if (HOME_U_L.Checked == true)
                    {
                        SendOrder[5] = 0x00;
                    }
                    else if (HOME_U_R.Checked == true)
                    {
                        SendOrder[5] = 0x01;
                    }
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                }
                Thread.Sleep(1);

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion

              
                
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
            flag_value = 0;
            #endregion
        }

        private void Multiple_Move_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x01;//指令

                if (checkedListBox1.GetItemChecked(0)) 
                {
                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x00;

                    Value = Convert.ToInt32(Prepare_X_Value.Text);

                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        Value *= -1;
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(1))
                {
                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x01;

                    Value = Convert.ToInt32( Prepare_Y_Value.Text);

                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        Value *= -1;
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion


                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
              
                //if (checkedListBox1.GetItemChecked(0) || checkedListBox1.GetItemChecked(1))
                     //ACTion(0);
                Thread.Sleep(1);
                
                if (checkedListBox1.GetItemChecked(2))
                {
                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x00;

                    Value = Convert.ToInt32(Prepare_Z_Value.Text);
                 
                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        Value *= -1;
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(3))
                {
                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x01;

                    Value = Convert.ToInt32(Prepare_U_Value.Text);
                   
                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        Value *= -1;
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion


                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }

                
                //if (checkedListBox1.GetItemChecked(2) || checkedListBox1.GetItemChecked(3))
                //ACTion(1);
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
            #endregion
            
        }

        private void Multiple_GoTo_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x7;//指令

                if (checkedListBox1.GetItemChecked(0))
                {
                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x00;

                    Value = Convert.ToInt32(Prepare_X_Value.Text);

                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(1))
                {
                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x01;

                    Value = Convert.ToInt32(Prepare_Y_Value.Text);

                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion


                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(2))
                {
                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x00;

                    Value = Convert.ToInt32(Prepare_Z_Value.Text);

                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
                if (checkedListBox1.GetItemChecked(3))
                {
                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x01;

                    Value = Convert.ToInt32(Prepare_U_Value.Text);

                    if (Value >= 0)
                    {
                        SendOrder[4] = 0x01; //參數1 方向
                    }
                    else if (Value < 0)
                    {
                        SendOrder[4] = 0x00; //參數1 方向
                    }

                    SendOrder[5] = 0x00;//參數2 無
                    #region 參數3 資料

                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);

                    #endregion


                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                Thread.Sleep(1);
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
            #endregion
        }


        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gohome_before_Formclose();
            Thread.Sleep(5);
            serialPort1.Close();
            Timer1.Stop();
            Timer2.Stop();
            serialPort1.Dispose();
            Timer1.Dispose();
            Timer2.Dispose();

        }
        void Gohome_before_Formclose() 
        {
            #region 
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x2;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x00;
                SendOrder[5] = 0x00;


                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                Thread.Sleep(5);

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x01;
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區


                Thread.Sleep(5);


                SendOrder[2] = 0x01;
                SendOrder[3] = 0x00;
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                Thread.Sleep(5);

                SendOrder[2] = 0x01;
                SendOrder[3] = 0x01;
                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                Thread.Sleep(5);

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion



            }
            catch
            {
                MessageBox.Show("關閉程式");
            }
            #endregion


        }


        void StepModeChangeABS(int board,int device,int ABS) 
        {
            #region 動作
            try
            {

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;


                SendOrder[1] = 0xaa;//指令
                SendOrder[2] = (byte)board;//版子
                SendOrder[3] = (byte)device;//馬達

                SendOrder[4] = 0x00; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                SendOrder[5] = 0x00;//參數2 無

                Value = ABS;


                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion

                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_ABS");
            }
            #endregion
        }
        void LED_initial()
        {
            #region 燈號初始化
            X_Lmin.Image = limit_signal.green;
            X_home.Image = limit_signal.green;
            X_Lmax.Image = limit_signal.green;


            Y_Lmin.Image = limit_signal.green;
            Y_home.Image = limit_signal.green;
            Y_Lmax.Image = limit_signal.green;



            Z_Lmin.Image = limit_signal.green;
            Z_home.Image = limit_signal.green;
            Z_Lmax.Image = limit_signal.green;




            U_Lmin.Image = limit_signal.green;
            U_home.Image = limit_signal.green;
            U_Lmax.Image = limit_signal.green;



            #endregion

            #region 按鈕初始化
            X_Lmax_Reset.Enabled = false;
            X_Lmin_Reset.Enabled = false;
            Y_Lmax_Reset.Enabled = false;
            Y_Lmin_Reset.Enabled = false;
            Z_Lmax_Reset.Enabled = false;
            Z_Lmin_Reset.Enabled = false;
            U_Lmax_Reset.Enabled = false;
            U_Lmin_Reset.Enabled = false;
            #endregion
        }



        #region getparm timer
        int tcount = 0;
        int flag_value = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ( X_Lmin_Flag == 1||X_Lmax_Flag == 1)
            {
                GoTo.Enabled = false;
            }else
            {

                X_Lmax_Reset.Enabled = false;
                X_Lmin_Reset.Enabled = false;
                GoTo.Enabled = true;
            }

            if (Y_Lmin_Flag == 1 || Y_Lmax_Flag == 1)
            {
                Y_Lmax_Reset.Enabled = false;
                Y_Lmin_Reset.Enabled = false;
                GoTo_Y.Enabled = false;
            }
            else
            {
                GoTo_Y.Enabled = true;
            }

            if (Z_Lmin_Flag == 1 || Z_Lmax_Flag == 1)
            {
                GoTo_Z.Enabled = false;
            }
            else
            {
                Z_Lmax_Reset.Enabled = false;
                Z_Lmin_Reset.Enabled = false;
                GoTo_Z.Enabled = true;
            }

            if (U_Lmin_Flag == 1 || U_Lmax_Flag == 1)
            {
                GoTo_U.Enabled = false;
            }
            else
            {
                U_Lmax_Reset.Enabled = false;
                U_Lmin_Reset.Enabled = false;
                GoTo_U.Enabled = true;
            }

            #region 動作
            try
            {
                if (flag_value == 0)
                {
                    flag_value = 1;
                }
                else if (flag_value == 1)
                {
                    SendOrder[0] = 0x55;

                    SendOrder[1] = 0xcc;//指令 get 
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x00;
                    SendOrder[5] = 0x00;//參數2 無

                    #region 參數3 資料


                    SendOrder[6] = 0x00;
                    SendOrder[7] = 0x00;
                    SendOrder[8] = 0x00;
                    SendOrder[9] = 0x00;
                    #endregion
                }



                serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開_Timer1");
            }
            #endregion
            timecount.Text = tcount.ToString();
            tcount++;
        }





        int timer2count = 0;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            serialPort1.DiscardOutBuffer();//清空緩衝區數據
            serialPort1.DiscardInBuffer();//清空緩衝區數據

            SendOrder[0] = 0x55;

            SendOrder[1] = 0xbb;//指令 get   // 讀取不會一職變動的職

            if (timer2count == 0)
            {
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x00;//馬達
            }
            if (timer2count == 1)
            {
                SendOrder[2] = 0x00;//版子
                SendOrder[3] = 0x01;//馬達
            }
            if (timer2count == 2)
            {
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x00;//馬達
            }
            if (timer2count == 3)
            {
                SendOrder[2] = 0x01;//版子
                SendOrder[3] = 0x01;//馬達
            }
            if (timer2count == 4)
            {
                Timer2.Stop();
               MessageBox.Show("初始化結束","初始化");

               Timer1.Start();
         
            }
            //  Move_X.Text = timer2count.ToString();
            SendOrder[4] = 0x00;
            SendOrder[5] = 0x00;//參數2 無
          
            #region 參數3 資料

            SendOrder[6] = 0x00;
            SendOrder[7] = 0x00;
            SendOrder[8] = 0x00;
            SendOrder[9] = 0x00;
            #endregion

            
            if (timer2count != 4) 
            { 
            serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
            //timer2count=0;
            }
            timer2count++;
        
        }



        #endregion

        #region Limit
        /*
        void Initial_Home_Reset()
        {
            #region 
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x22;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x00;
                SendOrder[5] = 0x00;


                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x00;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                Thread.Sleep(5);

                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x01;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區


                Thread.Sleep(5);


                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x00;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                Thread.Sleep(5);
                
                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x01;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                
                Thread.Sleep(5);

                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion


               
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
            #endregion
        }
        */
        private void X_Lmin_Click(object sender, EventArgs e)
        {
            if (X_Lmin_Flag == 1)
            {
                X_Lmin.Image = limit_signal.green;
                X_Lmin_Reset.Enabled = true;
                panelX.Enabled = true;
                MessageBox.Show("請進行極限復歸", "X-");
            }
            else
            {
                MessageBox.Show("無異常","X-");
            }
           
        }

        private void X_Lmax_Click(object sender, EventArgs e)
        {
            if (X_Lmax_Flag == 1)
            {
                X_Lmax.Image = limit_signal.green;
                X_Lmax_Reset.Enabled = true;
                panelX.Enabled = true;
                MessageBox.Show("請進行極限復歸", "X+");
            }
            else
            {
                MessageBox.Show("無異常", "X+");
            }
        }

        private void Y_Lmin_Click(object sender, EventArgs e)
        {
            if (Y_Lmin_Flag == 1)
            {
                Y_Lmin.Image = limit_signal.green;
                Y_Lmin_Reset.Enabled = true;
                panelY.Enabled = true;
                MessageBox.Show("請進行極限復歸", "Y-");
            }
            else
            {
                MessageBox.Show("無異常", "Y-");
            }
        }

        private void Y_Lmax_Click(object sender, EventArgs e)
        {
            if (Y_Lmax_Flag == 1)
            {
                Y_Lmax.Image = limit_signal.green;
                Y_Lmax_Reset.Enabled = true;
                panelY.Enabled = true;
                MessageBox.Show("請進行極限復歸", "Y-");
            }
            else
            {
                MessageBox.Show("無異常", "Y+");
            }
        }

        private void Z_Lmin_Click(object sender, EventArgs e)
        {
            if (Z_Lmin_Flag == 1)
            {
                Z_Lmin.Image = limit_signal.green;
                Z_Lmin_Reset.Enabled = true;
                panelZ.Enabled = true;
                MessageBox.Show("請進行極限復歸", "Z-");
            }
            else
            {
                MessageBox.Show("無異常", "Z-");
            }
        }

        private void Z_Lmax_Click(object sender, EventArgs e)
        {
            if (Z_Lmax_Flag == 1)
            {
                Z_Lmax.Image = limit_signal.green;
                Z_Lmax_Reset.Enabled = true;
                panelZ.Enabled = true;
                MessageBox.Show("請進行極限復歸", "Z+");
            }
            else
            {
                MessageBox.Show("無異常", "Z+");
            }
        }

        private void U_Lmin_Click(object sender, EventArgs e)
        {
            if (U_Lmin_Flag == 1)
            {
                U_Lmin.Image = limit_signal.green;
                U_Lmin_Reset.Enabled = true;
                panelU.Enabled = true;
                MessageBox.Show("請進行極限復歸", "U-");
            }
            else
            {
                MessageBox.Show("無異常", "U-");
            }
        }

        private void U_Lmax_Click(object sender, EventArgs e)
        {
            if (U_Lmax_Flag == 1)
            {
                U_Lmax.Image = limit_signal.green;
                U_Lmax_Reset.Enabled = true;
                panelU.Enabled = true;
                MessageBox.Show("請進行極限復歸", "U+");
            }
            else
            {
                MessageBox.Show("無異常", "U+");
            }
        }












        #endregion

        private void Home_reset_Speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region 動作
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.Open(); //打開串口
                    serialPort1.DiscardInBuffer();//清空緩衝區數據

                    SendOrder[0] = 0x55;


                    SendOrder[1] = 0x24;//指令
                    SendOrder[2] = 0x00;//版子
                    SendOrder[3] = 0x00;//馬達

                    SendOrder[4] = 0x00; //參數1 暫存器ID  Abs:00,mark:02,speed:03,acc:04,dec:05,maxspeed:06,minspeed:07,step_mode:0x15
                    SendOrder[5] = 0x00;//參數2 無

                    Value = Convert.ToInt32(Home_reset_Speed.Text);

                    // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                    #region 參數3 資料 


                    SendOrder[6] = (byte)(Value & 0xff);
                    SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                    SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                    SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                    #endregion

                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區
                }
                catch
                {
                    MessageBox.Show("請檢查串口1是否打開_Dec");
                }
                #endregion
            }
        }

        private void Home_Reset_step_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void X_Lmax_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x01;//0- 1+
                SendOrder[5] = 0x00;

                Value = Convert.ToInt32(Limit_Reset_step.Text);

                // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
        
        }

        private void X_Lmin_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x00;//0- 1+
                SendOrder[5] = 0x00;

                Value = Convert.ToInt32(Limit_Reset_step.Text);

                // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);
            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }

        }

        private void Y_Lmax_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x01;

                SendOrder[4] = 0x01;//0- 1+
                SendOrder[5] = 0x00;

                Value = Convert.ToInt32(Limit_Reset_step.Text);

                // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion

                serialPort1.Write(SendOrder, 0, 10);


            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }

        }

        private void Y_Lmin_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x01;

                SendOrder[4] = 0x00;//0- 1+
                SendOrder[5] = 0x00;


                Value = Convert.ToInt32(Limit_Reset_step.Text);

                // Now_ABS_X.Text = (Value.ToString("X").Substring(0, 2));
                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);


            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
        }

        private void Z_Lmax_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x01;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x01;//0- 1+
                SendOrder[5] = 0x00;

                Value = Convert.ToInt32(Limit_Reset_step.Text);
                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion
                serialPort1.Write(SendOrder, 0, 10);


            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
        }

        private void Z_Lmin_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x01;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x00;//0- 1+
                SendOrder[5] = 0x00;

                Value = Convert.ToInt32(Limit_Reset_step.Text);
                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);

            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
        }

        private void U_Lmax_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x01;
                SendOrder[3] = 0x01;

                SendOrder[4] = 0x01;//0- 1+
                SendOrder[5] = 0x00;


                Value = Convert.ToInt32(Limit_Reset_step.Text);
                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);


            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
        }

        private void U_Lmin_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x23;//指令

                SendOrder[2] = 0x01;
                SendOrder[3] = 0x01;

                SendOrder[4] = 0x00;//0- 1+
                SendOrder[5] = 0x00;


                Value = Convert.ToInt32(Limit_Reset_step.Text);
                #region 參數3 資料 


                SendOrder[6] = (byte)(Value & 0xff);
                SendOrder[7] = (byte)((Value & 0xff00) >> 8);
                SendOrder[8] = (byte)((Value & 0xff0000) >> 16);
                SendOrder[9] = (byte)((Value & 0xff000000) >> 24);
                #endregion
                serialPort1.Write(SendOrder, 0, 10);


            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
        }

        private void S150_Click(object sender, EventArgs e)
        {
            #region 動作
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1.Open(); //打開串口
                serialPort1.DiscardInBuffer();//清空緩衝區數據

                SendOrder[0] = 0x55;

                SendOrder[1] = 0x04;//指令

                SendOrder[2] = 0x00;
                SendOrder[3] = 0x00;

                SendOrder[4] = 0x00;
                SendOrder[5] = 0x00;

              
                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x00;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                
                Thread.Sleep(1);
                
                

                    SendOrder[2] = 0x00;
                    SendOrder[3] = 0x01;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                
                Thread.Sleep(1);
              

                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x00;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

               
                Thread.Sleep(1);
                

                    SendOrder[2] = 0x01;
                    SendOrder[3] = 0x01;
                    serialPort1.Write(SendOrder, 0, 10);//寫入串口緩衝區

                
                Thread.Sleep(1);


                #region 參數3 資料
                SendOrder[6] = 0x00;
                SendOrder[7] = 0x00;
                SendOrder[8] = 0x00;
                SendOrder[9] = 0x00;
                #endregion



            }
            catch
            {
                MessageBox.Show("請檢查串口1是否打開");
            }
            #endregion
        }
    }

}