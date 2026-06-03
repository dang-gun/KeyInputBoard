using System;
using System.Collections.Generic;
using System.Text;

namespace KeyInputBoard2.ProgramConfigs;

/// <summary>
/// Program.Config
/// </summary>
public class ProgramConfigDataModel
{
    /// <summary>
    /// 마지막으로 사용한 파일 경로
    /// </summary>
    public string LastFilePath { get; set; } = string.Empty;
}
