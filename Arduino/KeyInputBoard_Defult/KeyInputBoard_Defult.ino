#include <ButtonClickCheck.h>

//버튼 리스트
ButtonClickCheck BtnList[] = 
{
  ButtonClickCheck(1, HIGH),
  ButtonClickCheck(2, HIGH),
  ButtonClickCheck(3, HIGH)
};

//핀 리스트 개수
int nBtnCount = 0;

void setup()
{
  Serial.begin(9600);
  
  //버튼 리스트 개수
  nBtnCount = sizeof(BtnList) / sizeof(ButtonClickCheck);
  //Serial.println("count:" + (String)nBtnCount );
  
  //버튼 풀업 설정
  for(int i = 0; i < nBtnCount; ++i )
  {
    pinMode(BtnList[i].Pin, INPUT_PULLUP);
    Serial.println("Pin:" + (String)BtnList[i].Pin );
  }
  
}

void loop()
{
  if(Serial.available())
  {
    char temp[20];
    byte leng = Serial.readBytesUntil('\n', temp, 20);
    String sResult = ((String)temp).substring(0, leng);

    if("GetInfo" == sResult)
    {//인포 요청
      Serial.println("KeyInputBoard");
    }
  }
  else
  {
    //Serial.println((String)digitalRead(Button02));
    
    for(int i = 0; i < nBtnCount; ++i )
    {
      if(3 == BtnList[i].ClickCheck())
      {//첫클릭
        //컴퓨터에 신호를 준다.
        Serial.println("BtnKey:" + (String)BtnList[i].Pin );
        //Serial.println("count:" + (String)nPinListCount);
      }
    }
    
    //Serial.println(" ");
  }
   
  
  delay(50);
}
