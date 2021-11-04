$whb_installer_url = "https://download.visualstudio.microsoft.com/download/pr/df452763-4b7d-490a-bc03-bd1003d3ff4c/665ee1786528809f33e791558b69cf51/dotnet-hosting-5.0.11-win.exe"
$wd_installer_url = "https://download.microsoft.com/download/0/1/D/01DC28EA-638C-4A22-A57B-4CEF97755C6C/WebDeploy_amd64_en-US.msi"

$temp_path = "C:\temp\"
if (!(Test-Path -Path $temp_path)) {
    New-Item -Path "$temp_path" -ItemType Directory
}

#
# Reference: https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-3.1
#
# Quick way to download the Windows Hosting Bundle and Web Deploy installers which may
# then be executed on the VM ...
#

#
# Set path where installer files will be downloaded ...
#

if( ![System.IO.Directory]::Exists( $temp_path ) )
{
   Write-Output "Path not found ($temp_path), create the directory and try again"
   Break
}


#
# Download the Windows Hosting Bundle Installer for ASP.NET Core 3.1 Runtime (v3.1.0)
#
# The installer URL was obtained from:
# https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.0-windows-hosting-bundle-installer
#

$whb_installer_file = $temp_path + [System.IO.Path]::GetFileName( $whb_installer_url )
Try
{
   Invoke-WebRequest -Uri $whb_installer_url -OutFile $whb_installer_file

   Write-Output ""
   Write-Output "Windows Hosting Bundle Installer downloaded"
   Write-Output "- Execute the $whb_installer_file to install the ASP.Net Core Runtime"
   Write-Output ""
   Start-Process -FilePath $whb_installer_file -ArgumentList '/install /quiet' -Wait
}
Catch
{
   Write-Output ( $_.Exception.ToString() )
   Break
}

#
# Download Web Deploy v3.6
#
# The installer URL was obtained from:
# https://www.iis.net/downloads/microsoft/web-deploy
# x86 installer: https://download.microsoft.com/download/0/1/D/01DC28EA-638C-4A22-A57B-4CEF97755C6C/WebDeploy_x86_en-US.msi
# x64 installer: https://download.microsoft.com/download/0/1/D/01DC28EA-638C-4A22-A57B-4CEF97755C6C/WebDeploy_amd64_en-US.msi
#

$wd_installer_file = $temp_path + [System.IO.Path]::GetFileName( $wd_installer_url )
Try
{
   Invoke-WebRequest -Uri $wd_installer_url -OutFile $wd_installer_file

   Write-Output "Web Deploy installer downloaded"
   Write-Output "- Execute $wd_installer_file and choose the [Complete] option to install all components"
   Write-Output ""
   Start-Process -FilePath $wd_installer_file -ArgumentList 'ADDLOCAL=ALL /qn /norestart LicenseAccepted="0"'  -Wait
}
Catch
{
   Write-Output ( $_.Exception.ToString() )
   Break
}
