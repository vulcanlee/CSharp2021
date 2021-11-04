$VarPassword="P@ssword"
$VarAccount="administrator"
$VarWebHost="192.168.31.218"
$VarApplicationPool="DefaultAppPool"
$VarPublishProfile="IISProfile.pubxml"
$VarWebSiteName = "Default Web Site"
$VarWebSitePath = "C:\inetpub\wwwroot"
$VarChangePermissionFolder = "$VarWebSitePath\Uploads", "C:\temp"
$password = ConvertTo-SecureString "$VarPassword" -AsPlainText -Force
$cred= New-Object System.Management.Automation.PSCredential ("$VarAccount", $password )
$session = New-PSSession -ComputerName $VarWebHost -Credential $cred
Invoke-Command -Session $session -ArgumentList $VarApplicationPool, $VarWebSiteName -Command {
    $AppPoolName = $args[0];
    $WebSiteName = $args[1];
    # $AppPool = Get-IISAppPool "$AppPoolName"
    # Write-Output $AppPool| Format-List
    import-module webadministration
    Set-ItemProperty IIS:\AppPools\$AppPoolName -Name processModel.idleTimeout -Value "00:00:00"
    Set-ItemProperty IIS:\AppPools\$AppPoolName -Name processModel.loadUserProfile -Value $true
    Set-ItemProperty IIS:\AppPools\$AppPoolName -Name managedRuntimeVersion -Value ""
    Set-ItemProperty IIS:\AppPools\$AppPoolName -Name startMode -Value 1
    set-itemproperty -Path "IIS:\Sites\$WebSiteName" -Name applicationDefaults.preloadEnabled -value $true
}

Invoke-Command -Session $session -ArgumentList $VarApplicationPool, $VarWebSiteName -Command {
    $AppPoolName = $args[0];
    $WebSiteName = $args[1];

    # Get-ItemProperty "IIS:\AppPools\$AppPoolName" | select *
    # Get-ItemProperty "IIS:\Sites\$WebSiteName" | select *
    # Get-Website -Name "$WebSiteName" | select *
    # Get-WebApplication -Name "$AppPoolName" | select *
    Get-IISSite -Name "$WebSiteName" | select *
    Get-IISAppPool -Name "$AppPoolName" | select *
}

Invoke-Command -Session $session -ArgumentList $VarApplicationPool, $VarWebSiteName,$VarWebSitePath,$VarChangePermissionFolder -Command {
    $AppPoolName = $args[0];
    $WebSiteName = $args[1];
    $VarWebSitePath = $args[2];
    $VarChangePermissionFolder = $args[3];

    $perm = "IIS AppPool\AppPoolName","Read,Modify","ContainerInherit,ObjectInherit","None","Allow"
    foreach ($Folder in $VarChangePermissionFolder)
    {
        $PathName = "$Folder"
        Write-Host $PathName
        if (!(Test-Path -Path $PathName)) {
            New-Item -Path "$PathName" -ItemType Directory
        }
        
        $User = "IIS AppPool\$AppPoolName"  
        $Acl = Get-Acl $PathName  
        $Ar = New-Object  system.security.accesscontrol.filesystemaccessrule($User,"FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")  
        $Acl.SetAccessRule($Ar)  
        Set-Acl $PathName $Acl
        Get-Acl $PathName  | select *   
    }
}

