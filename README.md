# Sticky-Tool
![Sticky-Tool icon](https://github.com/nightleyxx/Sticky-Tool/blob/main/Icon/OIG.ico?raw=true)

This is a simple tool for Windows allows you to quickly, easily and silently replace the following System32 executables with any executable of your choice.

sethc.exe (Sticky Keys ... hence the name Sticky Tool)
utilman.exe (Accessibility UI)
narrator.exe (Narrator)
magnify.exe (Magnifier)
osk.exe (On-Screen Keyboard)

Sticky Tool was inspired from the old Sticky Keys trick used to gain Administrator privileges on Windows computers, however, this tool is not for that. Sticky Tool works by adding 'Debugger' registry entries for each executable listed.

Sticky Tool is very useful for IT admins as you can make basic shortcuts like SHIFT x5 display diagnostic information on a PC without logging in, or run a PowerShell script packaged as an executable.

Sticky Tool can also be deployed silently through Microsoft Intune using the command-line parameters listed below.

* '--type <type>' to specify which executable to replace out of the above list (e.g. --type sethc)
* '--replace <file path>' used in conjunction with '--type' to specify the replacement executable (e.g. --replace "C:\test.exe")
* '--restore' used in conjunction with '--type' to remove the modified sticky keys executable and restores the original

Plans for the future include automatically adding Windows Defender exemptions for the user-specified replacement executable as sometimes, Windows Defender flags it as malicious. This isn't an issue for those wanting to deploy it through Intune as you can add Defender exemptions through the Device Restrictions configuration profile, however, it is something to keep in mind for personal use until I add the functionality.

Sticky tool is written entirely in C# and is still in beta, please report any bugs found.
