
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;


using Newtonsoft.Json;



namespace KeyInputBoard2.ProgramConfigs;

/// <summary>
/// Program.Config
/// </summary>
public class ProgramConfigModel
{
    /// <summary>
    /// 설정 파일 경로
    /// </summary>
    private readonly string ConfigFilePath = "ProgramConfig.json";

    /// <summary>
    /// 프로그램 설정 저장
    /// </summary>
    private ProgramConfigDataModel? ProgramConf = null;


    /// <summary>
    /// 마지막으로 사용한 파일 경로
    /// </summary>
    public string LastFilePath 
    {
        get
        {
            return this.LastFilePath_Ori;
        }
        set
        {
            this.LastFilePath_Ori = value;
            this.Save();
        }
    }
    /// <summary>
    /// 마지막으로 사용한 파일 경로 원본값
    /// </summary>
    private string LastFilePath_Ori = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public ProgramConfigModel()
    {
        //프로그램 설정 데이터 읽기
        this.Load();
    }

    /// <summary>
    /// 설정파일 읽기
    /// </summary>
    public void Load()
    {
        //프로그램 설정 데이터 읽기
        if (File.Exists(this.ConfigFilePath))
        {
            string sJson = File.ReadAllText(this.ConfigFilePath);
            this.ProgramConf = JsonConvert.DeserializeObject<ProgramConfigDataModel>(sJson)!;
            this.LastFilePath = this.ProgramConf.LastFilePath;
        }
        else
        {
            if (null == ProgramConf)
            {
                this.ProgramConf = new ProgramConfigDataModel();
            }
        }
    }

    /// <summary>
    /// 설정 파일 저장
    /// </summary>
    public void Save()
    {
        //프로그램 설정 데이터 저장
        string sJson = JsonConvert.SerializeObject(this.ProgramConf, Formatting.Indented);
        File.WriteAllText(this.ConfigFilePath, sJson);
    }
}
