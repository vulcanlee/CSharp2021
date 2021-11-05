$VarPassword="P@ssword"
$VarAccount="administrator"
$VarWebHost="192.168.31.218"
$VarApplicationPool="DefaultAppPool"
$VarPublishProfile="IISProfile.pubxml";
$VarWebSite="Default Web Site"
$password = ConvertTo-SecureString "$VarPassword" -AsPlainText -Force
$cred= New-Object System.Management.Automation.PSCredential ("$VarAccount", $password )
$session = New-PSSession -ComputerName $VarWebHost -Credential $cred
Write-Output "開始準備 Blazor 專案部署工作"
Invoke-Command -Session $session -ArgumentList $VarApplicationPool -Command {
    $AppPoolName = $args[0]
    $processes = Get-WmiObject -Class win32_process -filter "name='w3wp.exe'" |
            ?{ ($_.CommandLine).Split("`"")[1] -eq $AppPoolName } |
            %{ $_.ProcessId }
    Write-Output $processes
    foreach ($process in $processes) {
        Write-Output "發現 Process $process" 
        taskkill /PID $process /F /t 
    }

    $MaxLoop = 40
    $CurrentIdx = 0
    while($CurrentIdx -lt $MaxLoop)
    {
        $appPool = Get-IISAppPool -Name "$AppPoolName"
        $state = $appPool.State
        if($state -eq "Stopping")
        {
            Write-Output "請稍後，等候啟動應用程式集區 停止中 $CurrentIdx $state"
        }
        else
        {
            break
        }
        $CurrentIdx++
        Start-Sleep -Seconds 2
    }
}

Write-Output "開始進行 Blazor 專案部署工作"
dotnet publish /p:Password=P@ssword /p:PublishProfile=$VarPublishProfile /p:AllowUntrustedCertificate=True

Write-Output "Blazor 專案部署完成，重新啟動應用程式集區"
Invoke-Command -Session $session -ArgumentList $VarApplicationPool, $VarWebSite -Command {
    $AppPoolName = $args[0]
    $VarWebSite = $args[1]

    Start-WebAppPool $AppPoolName
    
    # Write-Output $AppPoolName
    # $StatusAppPool = Get-WebAppPoolState -Name "$AppPoolName" 
    # $APStatus = $StatusAppPool.Value
    # Write-Output $APStatus

    # Write-Output "------------------------"
    # Write-Output $VarWebSite
    # #$StatusWebSite = Get-Website -Name "$VarWebSite" | Format-List
    # $WStatus=$StatusWebSite = Get-Website -Name "$VarWebSite"
    # $StatusWebSite = $WStatus.state
    # Write-Output $StatusWebSite

    Write-Output "要完成了，請等候 3 秒鐘"
    Start-Sleep -Seconds 3
    reStart-WebAppPool $AppPoolName
 }

 Remove-psSession –session $session
 #Get-PSSession | Remove-PSSession    
 #Get-Website -Name "Default Web Site" | Select-Object -Property State | Write-Output


