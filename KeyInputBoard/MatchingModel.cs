using InputSimulatorStandard.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyInputBoard
{
    public class MatchingModel
    {
        /// <summary>
        /// 사용할 핀
        /// </summary>
        public string Pin { get; set; }


        /// <summary>
        /// 액션 - 키
        /// </summary>
        public string Action_Key { get; set; }
        /// <summary>
        /// 액션 - 키코드
        /// </summary>
        public VirtualKeyCode Action_VKCode { get; set; }
        /// <summary>
        /// 액션 - 시프트
        /// </summary>
        public bool Action_Shift { get; set; }
        /// <summary>
        /// 액션 - 컨트롤
        /// </summary>
        public bool Action_Ctrl { get; set; }
        /// <summary>
        /// 액션 - 알트
        /// </summary>
        public bool Action_Alt { get; set; }

        /// <summary>
        /// 설명
        /// </summary>
        public string Explanation { get; set; }

        public MatchingModel()
        {
            this.Pin = string.Empty;
            
            this.Action_Key = string.Empty;
            this.Action_VKCode = 0;
            this.Action_Shift = false;
            this.Action_Ctrl = false;
            this.Action_Alt = false;

            this.Explanation = string.Empty;
        }

        public string[] ToArray()
        {
            List<string> listReturn = new List<string>();

            listReturn.Add(this.Pin);



            string sAction = string.Empty;
            
            //키 정보 넣기
            sAction = Action_Key;
            
            //시프트 키 정보 넣기
            if(true == this.Action_Shift)
            {
                if (string.Empty != sAction)
                {
                    sAction += " + ";
                }

                sAction += "Shift";
            }

            //컨트롤 키 정보 넣기
            if (true == this.Action_Ctrl)
            {
                if (string.Empty != sAction)
                {
                    sAction += " + ";
                }

                sAction += "Ctrl";
            }

            //시프트 키 정보 넣기
            if (true == this.Action_Alt)
            {
                if (string.Empty != sAction)
                {
                    sAction += " + ";
                }

                sAction += "Alt";
            }

            //키 정보 추가
            listReturn.Add(sAction);


            //설명 추가
            listReturn.Add(this.Explanation);

            return listReturn.ToArray();
        }
    }
}
