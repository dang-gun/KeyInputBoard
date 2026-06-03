using System.ComponentModel;
using System.IO;
using System.IO.Ports;


using Newtonsoft.Json;

using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using KeyInputBoard2.ProgramConfigs;
using KeyInputBoard2.MatchingListFiles;



namespace KeyInputBoard2;

public partial class Form1 : Form
{
    /// <summary>
    /// 시리얼 포트
    /// </summary>
    private SerialPort spPort = new SerialPort();

    /// <summary>
    /// 키 api
    /// </summary>
    private InputSimulator simulator = new InputSimulator();



    /// <summary>
    /// 눌린키 임시 저장
    /// </summary>
    private VirtualKeyCode PressKeyTempSave = 0;


    /// <summary>
    /// 프로그램 설정 관리 모델
    /// </summary>
    private ProgramConfigModel ProgConf;

    /// <summary>
    /// 데이터 로드
    /// </summary>

    private MatchingModel MatchingModel;


    public Form1()
    {
        InitializeComponent();

        //데이터 읽기 이벤트 연결
        this.spPort.DataReceived += SpPort_DataReceived;

        this.ProgConf = new ProgramConfigModel();

        this.MatchingModel = new MatchingModel(this.ProgConf.LastFilePath);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

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

    #region File


    private void tsmiFile_Save_Click(object sender, EventArgs e)
    {
        this.FileSave(this.ProgConf.LastFilePath);
    }

    private void tsmiFile_SaveAs_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Json 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
        saveFileDialog.DefaultExt = "json";
        saveFileDialog.AddExtension = true;
        saveFileDialog.FileName = "KeyInputBoard_MatchingList.json";

        if (DialogResult.OK == saveFileDialog.ShowDialog())
        {
            this.FileSave(saveFileDialog.FileName);
        }
    }


    private void FileSave(string sFilePath)
    {
        //모델을 json 문자열로 변환
        this.MatchingModel.Save(sFilePath);
        //사용한 파일 지정
        this.ProgConf.LastFilePath = sFilePath;
    }


    private void tsmiFile_Load_Click(object sender, EventArgs e)
    {
        this.FileLoad(this.ProgConf.LastFilePath);
    }

    private void tsmiFile_LoadSelect_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Json 파일 (*.json)|*.json|모든 파일 (*.*)|*.*";
        openFileDialog.DefaultExt = "json";
        openFileDialog.AddExtension = true;

        if (DialogResult.OK == openFileDialog.ShowDialog())
        {
            this.FileLoad(openFileDialog.FileName);
        }
    }

    /// <summary>
    /// 파일에서 매칭 리스트 읽기
    /// </summary>
    /// <param name="sFilePath"></param>
    private void FileLoad(string sFilePath)
    {
        this.MatchingModel.Load(sFilePath);

        this.lvMatching.Items.Clear();
        this.MatchingList_UI_AddList(this.MatchingModel.MatchingList);
    }
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



    private void SpPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string sData = this.spPort.ReadExisting();
        sData = sData.Replace("\r\n", string.Empty);
        this.Log_Add("DataReceived : " + sData);

        //일치하는 데이터가 있는지 확인
        List<MatchingDataModel> matchList =
            this.MatchingModel.MatchingList
                .Where(m => "BtnKey:" + m.Pin == sData)
                .ToList();


        //조합키 리스트
        List<VirtualKeyCode> listModifierKeyCodes = null!;

        //일치하는 리스트 실행
        foreach (MatchingDataModel itemM in matchList)
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



    private void Form1_Shown(object sender, EventArgs e)
    {
        //닫기 요청
        btnStop_Click(null!, null!);

        //포트 다시 읽기
        btnPortRefresh_Click(null!, null!);
    }



    #region 시리얼 포트 관련
    /// <summary>
    /// 포트 정보 새로고침
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnPortRefresh_Click(object sender, EventArgs e)
    {
        //기존 리스트 초기화
        this.comboboxPorts.Items.Clear();

        //포트 이름 받기
        string[] sPortList = SerialPort.GetPortNames();


        if (0 < sPortList.Length)
        {
            this.comboboxPorts.Items.AddRange(sPortList);
        }
        else
        {//검색된 포트가 없다.
        }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        //닫기 요청
        btnStop_Click(null!, null!);

        try
        {
            //아두이노 보드가 연결된 포트의 이름
            this.spPort.PortName = comboboxPorts.Text;
            //아두이노 보드 통신속도
            this.spPort.BaudRate = 9600;


            //지정한 포트 열기
            this.spPort.Open();

            comboboxPorts.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            this.Log_Add("포트 감시 시작");
        }
        catch (Exception ex)
        {
            this.Log_Add("btnStart_Click : " + ex.ToString());
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        if (true == this.spPort.IsOpen)
        {//이미 열려 있다.

            this.spPort.Close();
            this.Log_Add("포트 감시 종료");
        }

        comboboxPorts.Enabled = true;
        btnStart.Enabled = true;
        btnStop.Enabled = false;
    }
    #endregion


    /// <summary>
    /// 멀티스레드를 판별하여 로그를 추가한다.
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

    /// <summary>
    /// 로그를 UI에 표시한다.
    /// </summary>
    /// <param name="sMsg"></param>
    private void Log_AddUi(string sMsg)
    {
        this.lvLog.SelectedItems.Clear();

        ListViewItem item = new ListViewItem(DateTime.Now.ToString("HH:mm:ss"));
        item.SubItems.Add(sMsg);
        this.lvLog.Items.Add(item);

        this.lvLog.Items[this.lvLog.Items.Count - 1].Selected = true;
    }



    #region 리스트 관리


    /// <summary>
    /// 눌린키 임시 저장
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        string sPressKey = e.KeyCode.ToString();
        this.PressKeyTempSave = (VirtualKeyCode)e.KeyCode;
        //sPressKey = (this.PressKeyTempSave).ToString();


        //txtKey.Text = sPressKey;
        txtKey.Text = sPressKey;
    }

    /// <summary>
    /// 선택된 인덱스의 정보를 UI에 표시한다.
    /// </summary>
    /// <param name="nSelectIdex"></param>
    /// <returns></returns>
    private bool MatchingList_Select(int nSelectIdex)
    {
        if (0 <= nSelectIdex)
        {
            MatchingDataModel findM = this.MatchingModel.MatchingList[nSelectIdex];

            //내용 채우기
            txtItemPin.Text = findM.Pin;
            txtKey.Text = findM.Action_Key;
            PressKeyTempSave = findM.Action_VKCode;
            cbShift.Checked = findM.Action_Shift;
            cbCtrl.Checked = findM.Action_Ctrl;
            cbAlt.Checked = findM.Action_Alt;
            txtComment.Text = findM.Comment;
        }
        else
        {
            //내용 지우기
            txtItemPin.Text = string.Empty;
            txtKey.Text = string.Empty;
            PressKeyTempSave = 0;
            cbShift.Checked = false;
            cbCtrl.Checked = false;
            cbAlt.Checked = false;
            txtComment.Text = string.Empty;
        }


        return true;
    }

    /// <summary>
    /// 매칭용 데이터 추가
    /// </summary>
    /// <param name="matchingModel"></param>
    /// <returns></returns>
    private bool MatchingList_Add(MatchingDataModel matchingModel)
    {
        //추가 성공 여부
        bool bReturn = false;

        MatchingDataModel? findM
            = this.MatchingModel.MatchingList
                .Where(m => m.Pin == matchingModel.Pin)
                .FirstOrDefault();

        if (null == findM)
        {
            //리스트에 추가
            this.MatchingModel.MatchingList.Add(matchingModel);

            //리스트 뷰에 추가
            MatchingList_UI_Add(matchingModel);

            bReturn = true;
        }
        else
        {
            MessageBox.Show("이미 있는 '핀'입니다.");
        }

        return bReturn;
    }

    /// <summary>
    /// 리스트 뷰에 리스트로 추가
    /// </summary>
    /// <param name="matchingModel"></param>
    private void MatchingList_UI_AddList(List<MatchingDataModel> listMatchingModel)
    {
        foreach (MatchingDataModel itemM in listMatchingModel)
        {
            //리스트 뷰에 추가
            MatchingList_UI_Add(itemM);
        }
    }

    /// <summary>
    /// 리스트 뷰에 추가
    /// </summary>
    /// <param name="matchingModel"></param>
    private void MatchingList_UI_Add(MatchingDataModel matchingModel)
    {
        //리스트 뷰에 추가
        ListViewItem newLVI
            = new ListViewItem(matchingModel.ToArray());
        lvMatching.Items.Add(newLVI);
    }

    private bool MatchingList_Edit(int nSelectIndex, MatchingDataModel editMatchingModel)
    {
        //추가 성공 여부
        bool bReturn = false;

        //리스트 갱신
        MatchingDataModel? itemM = this.MatchingModel.Find(nSelectIndex);

        if (null != itemM)
        {//선택된 데이터가 있다.
            
            itemM.Pin = editMatchingModel.Pin;
            itemM.Action_Key = editMatchingModel.Action_Key;
            itemM.Action_Shift = editMatchingModel.Action_Shift;
            itemM.Action_Ctrl = editMatchingModel.Action_Ctrl;
            itemM.Action_Alt = editMatchingModel.Action_Alt;
            itemM.Comment = editMatchingModel.Comment;

            //UI 갱신
            ListViewItem findLVItem = lvMatching.Items[nSelectIndex];
            string[] arrItemM = itemM.ToArray();
            //findLVItem.SubItems[0].Text = arrItemM[0];
            findLVItem.SubItems[1].Text = arrItemM[1];
            findLVItem.SubItems[2].Text = arrItemM[2];

            bReturn = true;
        }
        else
        {//선택이 없다.
            MessageBox.Show("선택된 데이터가 없습니다.");
        }

        return bReturn;
    }

    private bool MatchingList_Delete(int nSelectIndex)
    {
        //추가 성공 여부
        bool bReturn = false;

        if (0 <= nSelectIndex)
        {
            //리스트에서 제거
            if (true == this.MatchingModel.Delete(nSelectIndex))
            {//삭제 성공

                bReturn = true;

                //ui 에서 제거
                lvMatching.Items[nSelectIndex].Remove();
            }
            else
            {
                MessageBox.Show("삭제에 실패했습니다.");
            }

            
        }
        else
        {//선택지가 없다.
            MessageBox.Show("선택된 데이터가 없습니다.");
        }

        return bReturn;
    }
    #endregion

    #region 리스트 UI

    /// <summary>
    /// 입력UI 비우기
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnNew_Click(object sender, EventArgs e)
    {
        //내용 지우기
        MatchingList_Select(-1);
    }


    /// <summary>
    /// 리스트에 추가
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnAdd_Click(object sender, EventArgs e)
    {
        MatchingDataModel newM = new MatchingDataModel();
        newM.Pin = this.txtItemPin.Text;

        newM.Action_Key = txtKey.Text;
        newM.Action_VKCode = PressKeyTempSave;
        newM.Action_Shift = cbShift.Checked;
        newM.Action_Ctrl = cbCtrl.Checked;
        newM.Action_Alt = cbAlt.Checked;

        newM.Comment = this.txtComment.Text;

        if (true == this.MatchingList_Add(newM))
        {//성공
         //내용 지우기
            MatchingList_Select(-1);
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        MatchingDataModel newM = new MatchingDataModel();
        newM.Pin = this.txtItemPin.Text;

        newM.Action_Key = txtKey.Text;
        newM.Action_VKCode = PressKeyTempSave;
        newM.Action_Shift = cbShift.Checked;
        newM.Action_Ctrl = cbCtrl.Checked;
        newM.Action_Alt = cbAlt.Checked;

        newM.Comment = this.txtComment.Text;

        if (true == this.MatchingList_Edit(lvMatching.SelectedIndices[0], newM))
        {//성공
         //내용 지우기
            MatchingList_Select(-1);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (true == this.MatchingList_Delete(lvMatching.SelectedIndices[0]))
        {//성공
         //내용 지우기
            MatchingList_Select(-1);
        }
    }

    private void lvMatching_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (0 < lvMatching.SelectedIndices.Count)
        {
            MatchingList_Select(lvMatching.SelectedIndices[0]);
        }
        else
        {
            MatchingList_Select(-1);
        }
    }

    #endregion




    
}
