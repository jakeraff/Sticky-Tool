# Sticky-Tool
![Sticky-Tool icon](https://github.com/nightleyxx/Sticky-Tool/blob/main/Icon/image.png?raw=true)

This is a simple tool for Windows allows you to quickly, easily and silently replace the following System32 executables with any executable of your choice.

sethc.exe (Sticky Keys ... hence the name Sticky Tool)<br>
utilman.exe (Accessibility UI)<br>
narrator.exe (Narrator)<br>
magnify.exe (Magnifier)<br>
osk.exe (On-Screen Keyboard)

Sticky Tool was inspired from the old Sticky Keys trick used to gain Administrator privileges on Windows computers, however, this tool is not for that. Sticky Tool works by adding 'Debugger' registry entries for each executable listed.

Sticky Tool is very useful for IT admins as you can make basic shortcuts like SHIFT x5 display diagnostic information on a PC without logging in, or run a PowerShell script packaged as an executable.

Sticky Tool can also be deployed silently through Microsoft Intune using the command-line parameters listed below.

* '--type <type>' to specify which executable to replace out of the above list (e.g. --type sethc)
* '--replace <file path>' used in conjunction with '--type' to specify the replacement executable (e.g. --replace "C:\test.exe")
* '--register' used in conjunction with '--replace' to register the replacement executable as a program that can be uninstalled via control panel.
* The uninstall string is as follows: 
for /f "tokens=2*" %i in ('REG QUERY "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Sticky-<TYPE>" /v UninstallString') do start "" %j
* '--restore' used in conjunction with '--type' to revert any changes to the chosen System32 executable (e.g. --restore)

Plans for the future include adding automatic Windows Defender exemptions for the user-specified replacement executable as sometimes, Windows Defender flags it as malicious. This isn't an issue for those wanting to deploy it through Intune as you can add Defender exemptions through the Device Restrictions configuration profile, however, it is something to keep in mind for personal use until I add the functionality.

Sticky tool is written entirely in C# and is still in beta, please report any bugs found.
