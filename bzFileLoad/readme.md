how to detect whether powershell remoting is enabled/disabled on local machine?

Just run Enter-PSSession -ComputerName localhost. If it enters the remote session, PS remoting is enabled.

PS C:\Users\Administrator> Enter-PSSession -ComputerName localhost
[localhost]: PS C:\Users\Administrator\Documents> exit
PS C:\Users\Administrator>

PS C:\Windows\system32> Enter-PSSession -ComputerName localhost
Enter-PSSession : 連線到遠端伺服器 localhost 失敗，傳回下列錯誤訊息: 用戶端無法連線到要求中指定的目的地。 請確定目的地
上的服務正在執行並接受要求。 請參閱在目的地 (最常見的是 IIS 或 WinRM) 上執行 WS-Management 服務的記錄與文件。 如果目的
地是 WinRM 服務，請在目的地執行下列命令來分析和設定 WinRM 服務: "winrm quickconfig". 如需詳細資訊，請參閱 about_Remote_
Troubleshooting 說明主題。
位於 線路:1 字元:1
+ Enter-PSSession -ComputerName localhost
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidArgument: (localhost:String) [Enter-PSSession]，PSRemotingTransportException
    + FullyQualifiedErrorId : CreateRemoteRunspaceFailed

PS C:\Windows\system32>










