CSHARP COMPILER 
----



# https://codewithintent.com/how-to-run-c-application-in-ubuntu/
```
 sudo apt-get install mono-gmcs

The following packages were automatically installed and are no longer required:
  linux-image-3.13.0-65-generic linux-image-3.13.0-66-generic
  linux-image-3.13.0-67-generic linux-image-3.13.0-68-generic
  linux-image-3.13.0-70-generic linux-image-3.13.0-71-generic
  linux-image-3.13.0-73-generic linux-image-3.13.0-74-generic
  linux-image-3.13.0-76-generic linux-image-3.13.0-77-generic
  linux-image-3.13.0-79-generic linux-image-3.13.0-83-generic
  linux-image-extra-3.13.0-65-generic linux-image-extra-3.13.0-66-generic
  linux-image-extra-3.13.0-67-generic linux-image-extra-3.13.0-68-generic
  linux-image-extra-3.13.0-70-generic linux-image-extra-3.13.0-71-generic
  linux-image-extra-3.13.0-73-generic linux-image-extra-3.13.0-74-generic
  linux-image-extra-3.13.0-76-generic linux-image-extra-3.13.0-77-generic
  linux-image-extra-3.13.0-79-generic linux-image-extra-3.13.0-83-generic
Use 'apt-get autoremove' to remove them.
The following extra packages will be installed:
  binfmt-support cli-common libmono-corlib4.5-cil libmono-csharp4.0c-cil
  libmono-i18n-west4.0-cil libmono-i18n4.0-cil libmono-microsoft-csharp4.0-cil
  libmono-posix4.0-cil libmono-security4.0-cil
  libmono-system-configuration4.0-cil libmono-system-core4.0-cil
  libmono-system-security4.0-cil libmono-system-xml4.0-cil
  libmono-system4.0-cil mono-4.0-gac mono-gac mono-mcs mono-runtime
  mono-runtime-common mono-runtime-sgen
Suggested packages:
  libmono-i18n4.0-all libgamin0
The following NEW packages will be installed
  binfmt-support cli-common libmono-corlib4.5-cil libmono-csharp4.0c-cil
  libmono-i18n-west4.0-cil libmono-i18n4.0-cil libmono-microsoft-csharp4.0-cil
  libmono-posix4.0-cil libmono-security4.0-cil
  libmono-system-configuration4.0-cil libmono-system-core4.0-cil
  libmono-system-security4.0-cil libmono-system-xml4.0-cil
  libmono-system4.0-cil mono-4.0-gac mono-gac mono-gmcs mono-mcs mono-runtime
  mono-runtime-common mono-runtime-sgen
0 to upgrade, 21 to newly install, 0 to remove and 157 not to upgrade.
Need to get 8,194 kB of archives.
After this operation, 37.1 MB of additional disk space will be used.
Do you want to continue? [Y/n]
```



http://stackoverflow.com/questions/35617920/csharp-error-on-ubuntu-14-04
c#: warning CS8001: SDK path could not be resolved Compilation succeeded - 1 warning(s)


The warning your given can be shown in many cases. It is however most likely
that it is the System.Drawing.dll.




```
$ sudo apt-get install libmono-winforms2.0-cil
[sudo] password for map479-admin:
Reading package lists... Done
Building dependency tree       
Reading state information... Done
The following packages were automatically installed and are no longer required:
  linux-image-3.13.0-65-generic linux-image-3.13.0-66-generic
  linux-image-3.13.0-67-generic linux-image-3.13.0-68-generic
  linux-image-3.13.0-70-generic linux-image-3.13.0-71-generic
  linux-image-3.13.0-73-generic linux-image-3.13.0-74-generic
  linux-image-3.13.0-76-generic linux-image-3.13.0-77-generic
  linux-image-3.13.0-79-generic linux-image-3.13.0-83-generic
  linux-image-extra-3.13.0-65-generic linux-image-extra-3.13.0-66-generic
  linux-image-extra-3.13.0-67-generic linux-image-extra-3.13.0-68-generic
  linux-image-extra-3.13.0-70-generic linux-image-extra-3.13.0-71-generic
  linux-image-extra-3.13.0-73-generic linux-image-extra-3.13.0-74-generic
  linux-image-extra-3.13.0-76-generic linux-image-extra-3.13.0-77-generic
  linux-image-extra-3.13.0-79-generic linux-image-extra-3.13.0-83-generic
Use 'apt-get autoremove' to remove them.
The following extra packages will be installed:
  libgdiplus libmono-accessibility2.0-cil libmono-corlib2.0-cil
  libmono-data-tds2.0-cil libmono-i18n-west2.0-cil libmono-messaging2.0-cil
  libmono-posix2.0-cil libmono-security2.0-cil libmono-sharpzip2.84-cil
  libmono-sqlite2.0-cil libmono-system-data-linq2.0-cil
  libmono-system-data2.0-cil libmono-system-messaging2.0-cil
  libmono-system-runtime2.0-cil libmono-system-web2.0-cil
  libmono-system2.0-cil libmono-wcf3.0a-cil libmono-webbrowser2.0-cil
  libmono2.0-cil
Suggested packages:
  libmono-i18n2.0-cil libgamin0
Recommended packages:
  libgluezilla
The following NEW packages will be installed
  libgdiplus libmono-accessibility2.0-cil libmono-corlib2.0-cil
  libmono-data-tds2.0-cil libmono-i18n-west2.0-cil libmono-messaging2.0-cil
  libmono-posix2.0-cil libmono-security2.0-cil libmono-sharpzip2.84-cil
  libmono-sqlite2.0-cil libmono-system-data-linq2.0-cil
  libmono-system-data2.0-cil libmono-system-messaging2.0-cil
  libmono-system-runtime2.0-cil libmono-system-web2.0-cil
  libmono-system2.0-cil libmono-wcf3.0a-cil libmono-webbrowser2.0-cil
  libmono-winforms2.0-cil libmono2.0-cil
0 to upgrade, 20 to newly install, 0 to remove and 162 not to upgrade.
Need to get 5,360 kB of archives.
After this operation, 21.9 MB of additional disk space will be used.
Do you want to continue? [Y/n]
```
