using System.IO;
using System.IO.Ports;


using InputSimulatorStandard;
using InputSimulatorStandard.Native;


namespace KeyInputBoard2;

public partial class Form1 : Form
{
    private SerialPort spPort = new SerialPort();

    /// <summary>
    /// 키 api
    /// </summary>
    private InputSimulator simulator = new InputSimulator();



    /// <summary>
    /// 눌린키 임시 저장
    /// </summary>
    private VirtualKeyCode PressKeyTempSave = 0;


    public Form1()
    {
        InitializeComponent();

        //데이터 읽기 이벤트 연결
        this.spPort.DataReceived += SpPort_DataReceived;

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        //포트가 열려있나?
        if (true == this.spPort.IsOpen)
        {
            //포트를 닫는다.
            this.spPort.Close();
        }
    }


    private void SpPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string sData = this.spPort.ReadExisting();
        sData = sData.Replace("\r\n", string.Empty);
        this.Log_Add("DataReceived : " + sData);

        //일치하는 데이터가 있는지 확인
        List<MatchingModel> matchList =
            this.listMatching
                .Where(m => "BtnKey:" + m.Pin == sData)
                .ToList();


        //조합키 리스트
        List<VirtualKeyCode> listModifierKeyCodes = null;

        //일치하는 리스트 실행
        foreach (MatchingModel itemM in matchList)
        {
            listModifierKeyCodes = new List<VirtualKeyCode>();

            //조합키
            if (true == itemM.Action_Shift)
            {
                listModifierKeyCodes.Add(VirtualKeyCode.LSHIFT);
            }
            if (true == itemM.Action_Ctrl)
            {
                listModifierKeyCodes.Add(VirtualKeyCode.CONTROL);
            }
            if (true == itemM.Action_Alt)
            {
                listModifierKeyCodes.Add(VirtualKeyCode.LMENU);
            }


            //키
            if (0 != itemM.Action_VKCode)
            {//데이터가 있다.
             //newKeyCodes = (VirtualKeyCode)itemM.Action_Key;
                simulator.Keyboard
                    .ModifiedKeyStroke(
                        listModifierKeyCodes.ToArray()
                        , itemM.Action_VKCode);

            }
        }

        //sData.Replace("", string.Empty);
        //if (sData == "BtnKey:2")
        //{
        //    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.F1);
        //    //simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.F9);


        //}
    }



    #region File

    #endregion

    #region Dev
    /// <summary>
    /// Log > Test Log Add 1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tsmiDev_Log_TestLogAdd1_Click(object sender, EventArgs e)
    {
        this.Log_Add("테스트 로그");
    }
    #endregion


#region 리스트 관리

        /// <summary>
        /// 매칭 리스트
        /// </summary>
        List<MatchingModel> listMatching = new List<MatchingModel>();


        #endregion

    /// <summary>
    /// 로그 표시
    /// </summary>
    /// <param name="sMsg"></param>
    private void Log_Add(string sMsg)
    {
        if (true == InvokeRequired)
        {//다른 쓰래드다.
            this.Invoke(new MethodInvoker(
                delegate ()
                {
                    this.Log_AddUi(sMsg);
                }));
        }
        else
        {//같은 쓰래드다.
            this.Log_AddUi(sMsg);
        }
    }

    private void Log_AddUi(string sMsg)
    {
        this.lvLog.SelectedItems.Clear();

        ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
        item.SubItems.Add(sMsg);
        this.lvLog.Items.Add(item);

        this.lvLog.Items[this.lvLog.Items.Count - 1].Selected = true;
    }

    
}
