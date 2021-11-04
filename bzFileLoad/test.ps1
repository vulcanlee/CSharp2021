$VarPassword="P@ssword"
$VarAccount="administrator"
$VarWebHost="192.168.31.218"
$VarApplicationPool="DefaultAppPool"
$VarPublishProfile="IISProfile.pubxml";
$VarWebSite="Default Web Site"
$password = ConvertTo-SecureString "$VarPassword" -AsPlainText -Force
$cred= New-Object System.Management.Automation.PSCredential ("$VarAccount", $password )
$session = New-PSSession -ComputerName $VarWebHost -Credential $cred

Invoke-Command -Session $session -ArgumentList $VarApplicationPool, $VarWebSite -Command {
    $AppPoolName = $args[0]
    $VarWebSite = $args[1]

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
 }
    
 #Get-Website -Name "Default Web Site" | Select-Object -Property State | Write-Output


