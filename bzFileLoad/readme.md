
取得有效的執行原則：
Get-ExecutionPolicy

變更執行原則
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned

Enable-PSRemoting -SkipNetworkProfileCheck

#設置特定的域名IP (用逗號隔開)
winrm set winrm/config/client '@{TrustedHosts="104.88.88.88,104.87.87.87"}' 

#設定allow all *
Set-Item WSMan:\localhost\Client\TrustedHosts -Value "*" -Force

<AllowUntrustedCertificate>true</AllowUntrustedCertificate>





PS C:\Vulcan\bzFileLoad> .\Deploy.ps1
New-PSSession : [192.168.31.218] 連線到遠端伺服器 192.168.31.218 失敗，傳回下列錯誤訊息: WinRM 用戶端無法處理該要求。若
驗證配置與 Kerberos 不同，或是用戶端電腦沒有加入網域， 則必須使用 HTTPS 傳輸，或是將目標電腦新增到 TrustedHosts 組態設
定中。 請使用 winrm.cmd 來設定 TrustedHosts。請注意，可能不會驗證在 TrustedHosts 清單中的電腦。 您可以執行下列命令，以
取得相關的詳細資訊: winrm help config。 如需詳細資訊，請參閱 about_Remote_Troubleshooting 說明主題。
位於 C:\Vulcan\bzFileLoad\Deploy.ps1:9 字元:12
+ $session = New-PSSession -ComputerName $VarWebHost -Credential $cred
+            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : OpenError: (System.Manageme....RemoteRunspace:RemoteRunspace) [New-PSSession], PSRemotin
   gTransportException
    + FullyQualifiedErrorId : ServerNotTrusted,PSSessionOpenFailed
開始準備 Blazor 專案部署工作
Invoke-Command : 無法驗證 'Session' 參數上的引數。引數為 Null 或空的。請提供一個不為 Null 或空白的引數，然後嘗試重新執
行該命令。
位於 C:\Vulcan\bzFileLoad\Deploy.ps1:11 字元:25
+ Invoke-Command -Session $session -ArgumentList $VarApplicationPool -C ...
+                         ~~~~~~~~
    + CategoryInfo          : InvalidData: (:) [Invoke-Command]，ParameterBindingValidationException
    + FullyQualifiedErrorId : ParameterArgumentValidationError,Microsoft.PowerShell.Commands.InvokeCommandCommand




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

允許遠端執行

Enable-PSRemoting -force

Set-WSManQuickConfig : <f:WSManFault xmlns:f="http://schemas.microsoft.com/wbem/wsman/1/wsmanfault" Code="2150859113" M
achine="localhost"><f:Message><f:ProviderFault provider="Config provider" path="%systemroot%\system32\WsmSvc.dll"><f:WS
ManFault xmlns:f="http://schemas.microsoft.com/wbem/wsman/1/wsmanfault" Code="2150859113" Machine="DESKTOP-V17TF04"><f:
Message>因為此電腦上的其中一個網路連線類型設定為 [公用]，所以 WinRM 防火牆例外無法作用。 請將網路連線類型變更為 [網域]
或 [私人]，然後再試一次。 </f:Message></f:WSManFault></f:ProviderFault></f:Message></f:WSManFault>
位於 線路:116 字元:17
+                 Set-WSManQuickConfig -force
+                 ~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidOperation: (:) [Set-WSManQuickConfig]，InvalidOperationException
    + FullyQualifiedErrorId : WsManError,Microsoft.WSMan.Management.SetWSManQuickConfigCommand

When I run Enable-PSRemoting, I get an error message "Firewall excetpion will not work since one of the network connection types is public"





