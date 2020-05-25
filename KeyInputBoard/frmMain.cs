using InputSimulatorStandard;
using InputSimulatorStandard.Native;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyInputBoard
{
    public partial class frmMain : Form
    {
        private SerialPort spPort = new SerialPort();

        /// <summary>
        /// 키 api
        /// </summary>
        InputSimulator simulator = new InputSimulator();


        /// <summary>
        /// 눌린키 임시 저장
        /// </summary>
        private VirtualKeyCode PressKeyTempSave = 0;

        public frmMain()
        {
            InitializeComponent();

            //데이터 읽기 이벤트 연결
            this.spPort.DataReceived += SpPort_DataReceived;

            
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
                if(true == itemM.Action_Shift)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //포트가 열려있나?
            if (true == this.spPort.IsOpen)
            {
                //포트를 닫는다.
                this.spPort.Close();
            }
        }

        #region 메뉴 - File
        private void tsmiFile_Save_Click(object sender, EventArgs e)
        {
            //모델을 json 문자열로 변환
            string sJson = JsonConvert.SerializeObject(this.listMatching);
            //파일로 저장
            File.WriteAllText(@"KeyInputBoard_MatchingList.json", sJson);
        }

        private void tsmiFile_Load_Click(object sender, EventArgs e)
        {
            //파일 읽기
            string sJson = File.ReadAllText(@"KeyInputBoard_MatchingList.json");
            //json문자열을 모델로 변환
            this.listMatching 
                = JsonConvert.DeserializeObject<List<MatchingModel>>(sJson);

            this.MatchingList_UI_AddList(this.listMatching);
        }
        #endregion

        /// <summary>
        /// 포트 정보 새로고침
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPortRefresh_Click(object sender, EventArgs e)
        {
            //기존 리스트 초기화
            comboboxPorts.Items.Clear();

            //포트 이름 받기
            string[] sPortList = SerialPort.GetPortNames();


            if(0 < sPortList.Length)
            {
                comboboxPorts.Items.AddRange(sPortList);
            }
            else
            {//검색된 포트가 없다.
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //닫기 요청
            btnStop_Click(null, null);

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
            catch(Exception ex)
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

        /// <summary>
        /// 폼이 그려질때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Shown(object sender, EventArgs e)
        {
            //닫기 요청
            btnStop_Click(null, null);

            //포트 다시 읽기
            btnPortRefresh_Click(null, null);

        }


        private void KeyPorc(string sData)
        {
            Debug.WriteLine("신호 : " + sData);

            switch (sData)
            {
                case "BtnKey:2":
                    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.F1);
                    break;
            }
        }

        #region 리스트 컨트롤
        /// <summary>
        /// 리스트에 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            MatchingModel newM = new MatchingModel();
            newM.Pin = this.txtItemPin.Text;

            newM.Action_Key = txtKey.Text;
            newM.Action_VKCode = PressKeyTempSave;
            newM.Action_Shift = cbShift.Checked;
            newM.Action_Ctrl = cbCtrl.Checked;
            newM.Action_Alt = cbAlt.Checked;

            newM.Explanation = this.txtExplanation.Text;

            if(true == this.MatchingList_Add(newM))
            {//성공
                //내용 지우기
                MatchingList_Select(-1);
            }
        }

        private void btnItemEdit_Click(object sender, EventArgs e)
        {
            MatchingModel newM = new MatchingModel();
            newM.Pin = this.txtItemPin.Text;

            newM.Action_Key = txtKey.Text;
            newM.Action_VKCode = PressKeyTempSave;
            newM.Action_Shift = cbShift.Checked;
            newM.Action_Ctrl = cbCtrl.Checked;
            newM.Action_Alt = cbAlt.Checked;

            newM.Explanation = this.txtExplanation.Text;

            if (true == this.MatchingList_Edit(lvMatching.SelectedIndices[0], newM))
            {//성공
                //내용 지우기
                MatchingList_Select(-1);
            }
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            if (true == this.MatchingList_Delete(lvMatching.SelectedIndices[0]))
            {//성공
                //내용 지우기
                MatchingList_Select(-1);
            }
        }

        /// <summary>
        /// 리스트에서 아이템 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvMatching_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(0 < lvMatching.SelectedIndices.Count)
            {
                MatchingList_Select(lvMatching.SelectedIndices[0]);
            }
            else
            {
                MatchingList_Select(-1);
            }
        }
        #endregion

        #region 리스트 관리

        /// <summary>
        /// 매칭 리스트
        /// </summary>
        List<MatchingModel> listMatching = new List<MatchingModel>();

        /// <summary>
        /// 선택된 인덱스의 정보를 UI에 표시한다.
        /// </summary>
        /// <param name="nSelectIdex"></param>
        /// <returns></returns>
        private bool MatchingList_Select(int nSelectIdex)
        {
            if(0 <= nSelectIdex)
            {
                MatchingModel findM = this.listMatching[nSelectIdex];

                //내용 체우기
                txtItemPin.Text = findM.Pin;
                txtKey.Text = findM.Action_Key;
                PressKeyTempSave = findM.Action_VKCode;
                cbShift.Checked = findM.Action_Shift;
                cbCtrl.Checked = findM.Action_Ctrl;
                cbAlt.Checked = findM.Action_Alt;
                txtExplanation.Text = findM.Explanation;

                //핀 수정 못하게 막기
                txtItemPin.Enabled = false;
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
                txtExplanation.Text = string.Empty;

                //핀 수정 풀기
                txtItemPin.Enabled = true;
            }
            

            return true;
        }

        /// <summary>
        /// 매칭용 데이터 추가
        /// </summary>
        /// <param name="matchingModel"></param>
        /// <returns></returns>
        private bool MatchingList_Add(MatchingModel matchingModel)
        {
            //추가 성공 여부
            bool bReturn = false;

            MatchingModel findM
                = this.listMatching
                    .Where(m => m.Pin == matchingModel.Pin)
                    .FirstOrDefault();

            if (null == findM)
            {
                //리스트에 추가
                listMatching.Add(matchingModel);

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
        private void MatchingList_UI_AddList(List<MatchingModel> listMatchingModel)
        {
            foreach (MatchingModel itemM in listMatchingModel)
            {
                //리스트 뷰에 추가
                MatchingList_UI_Add(itemM);
            }
        }

        /// <summary>
        /// 리스트 뷰에 추가
        /// </summary>
        /// <param name="matchingModel"></param>
        private void MatchingList_UI_Add(MatchingModel matchingModel)
        {
            //리스트 뷰에 추가
            ListViewItem newLVI
                = new ListViewItem(matchingModel.ToArray());
            lvMatching.Items.Add(newLVI);
        }

        private bool MatchingList_Edit(int nSelectIndex, MatchingModel editMatchingModel)
        {
            //추가 성공 여부
            bool bReturn = false;

            if(0 <= nSelectIndex)
            {
                //리스트 갱신
                MatchingModel itemM = this.listMatching[nSelectIndex];
                itemM.Pin = editMatchingModel.Pin;
                itemM.Action_Key = editMatchingModel.Action_Key;
                itemM.Action_Shift = editMatchingModel.Action_Shift;
                itemM.Action_Ctrl = editMatchingModel.Action_Ctrl;
                itemM.Action_Alt = editMatchingModel.Action_Alt;
                itemM.Explanation = editMatchingModel.Explanation;

                //UI 갱신
                ListViewItem findLVItem = lvMatching.Items[nSelectIndex];
                string[] arrItemM = itemM.ToArray();
                //findLVItem.SubItems[0].Text = arrItemM[0];
                findLVItem.SubItems[1].Text = arrItemM[1];
                findLVItem.SubItems[2].Text = arrItemM[2];

                bReturn = true;
            }
            else
            {//선택지가 없다.
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
                this.listMatching.RemoveAt(nSelectIndex);

                //ui 에서 제거
                lvMatching.Items[nSelectIndex].Remove();
            }
            else
            {//선택지가 없다.
                MessageBox.Show("선택된 데이터가 없습니다.");
            }

            return bReturn;
        }

        #endregion

        /// <summary>
        /// 데이터 UI에 반영
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDataLoad_Click(object sender, EventArgs e)
        {
            lvMatching.Items.Clear();

            foreach(MatchingModel itemM in this.listMatching)
            {
                MatchingList_Add(itemM);
            }
        }

        private void txtKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string sPressKey = e.KeyCode.ToString();
            this.PressKeyTempSave = (VirtualKeyCode)e.KeyCode;
            //sPressKey = (this.PressKeyTempSave).ToString();


            //txtKey.Text = sPressKey;
            txtKey.Text = sPressKey;
        }

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
                        this.lvLog.SelectedItems.Clear();
                        this.lvLog.Items.Add(sMsg);
                        this.lvLog.Items[this.lvLog.Items.Count - 1].Selected = true;
                    }));
            }
            else
            {//같은 쓰래드다.
                this.lvLog.SelectedItems.Clear();
                this.lvLog.Items.Add(sMsg);
                this.lvLog.Items[this.lvLog.Items.Count - 1].Selected = true;
            }

            
        }

        
    }
}
