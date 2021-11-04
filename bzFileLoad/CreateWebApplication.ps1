$WebDirectoryName = "MyAppWeb"
$WebHome = "C:\WWW\$WebDirectoryName"
$WebAppPool = "MyAppPool"
$WebSite = "$WebAppPool Web Site"
$WebSitePort = 8080
$WebApplication="MyWebApp"
$WebAppAppPool = "MyWebAppPool"
$WebApplicationHome = "C:\WWW\$WebApplication"

if (!(Test-Path -Path $WebHome)) {
    New-Item -Path "$WebHome" -ItemType Directory
}
if (!(Test-Path -Path $WebApplicationHome)) {
    New-Item -Path "$WebApplicationHome" -ItemType Directory
} 

New-WebAppPool -Name "$WebAppPool" -Force
New-Website -Name "$WebSite" -Port $WebSitePort -PhysicalPath "$WebHome" -ApplicationPool "$WebAppPool"
New-WebAppPool -Name "$WebAppAppPool" -Force
New-WebApplication -Name "$WebApplication" -Site "$WebSite" -PhysicalPath "$WebApplicationHome" -ApplicationPool "$WebAppAppPool" -Force

Get-IISAppPool -Name "$WebAppPool" | select *
Get-Website -Name "$WebSite" | select *
Get-IISAppPool -Name "$WebAppAppPool" | select *
Get-WebApplication -Name "$WebApplication" | select *



