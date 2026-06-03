using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyInputBoard2.MatchingListFiles;

/// <summary>
/// 
/// </summary>
public class MatchingModel
{

    /// <summary>
    /// 매칭 리스트
    /// </summary>
    public List<MatchingDataModel> MatchingList = new List<MatchingDataModel>();


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sLastFilePath"></param>
    public MatchingModel(string sLastFilePath)
    {
        this.Load(sLastFilePath);
    }

    /// <summary>
    /// 지정된 인덱스를 찾아 리턴한다.
    /// </summary>
    /// <param name="nSelectIndex"></param>
    /// <returns></returns>
    public MatchingDataModel? Find(int nSelectIndex)
    { 
        MatchingDataModel? modelReturn = null;
        if (0 <= nSelectIndex)
        {
            modelReturn = this.MatchingList[nSelectIndex];
        }
        else
        {//선택지가 없다.
        }

        return modelReturn;
    }

    /// <summary>
    /// 파일에서 매칭 리스트 읽기
    /// </summary>
    /// <param name="sFilePath"></param>
    public void Load(string sFilePath)
    {
        if(string.Empty == sFilePath)
        {//지정된 경로가 없다.
            return;
        }

        //파일 읽기
        string sJson = File.ReadAllText(sFilePath);
        //json문자열을 모델로 변환
        this.MatchingList
            = JsonConvert.DeserializeObject<List<MatchingDataModel>>(sJson)!;
    }

    /// <summary>
    /// 파일로 매칭 리스트 저장
    /// </summary>
    /// <param name="sFilePath"></param>
    public void Save(string sFilePath)
    {
        //모델을 json 문자열로 변환
        string sJson = JsonConvert.SerializeObject(this.MatchingList);
        //파일로 저장
        File.WriteAllText(sFilePath, sJson);
    }


    /// <summary>
    /// 매칭 리스트에서 선택한 인덱스의 아이템 삭제
    /// </summary>
    /// <param name="nSelectIndex"></param>
    /// <returns>삭제 성공 여부</returns>
    public bool Delete(int nSelectIndex)
    {
        //추가 성공 여부
        bool bReturn = false;

        if (0 <= nSelectIndex)
        {
            //리스트에서 제거
            this.MatchingList.RemoveAt(nSelectIndex);

            bReturn = true;
        }
        else
        {//선택지가 없다.
            MessageBox.Show("선택된 데이터가 없습니다.");
        }


        return bReturn;
    }
}
