Installation of HTK 3.4.1
---

The Hidden Markov Model Toolkit (HTK) is a portable toolkit for building and manipulating hidden Markov models.  
HTK is primarily used for speech recognition.


http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/tutorial/download
http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/tutorial/download/comments/compiling-on-ubuntu-10.04


Step 1 - Register with HTK
http://htk.eng.cam.ac.uk/register.shtml

Step 2 - Download HTK Toolkit and Samples
http://htk.eng.cam.ac.uk/download.shtml

Step 3 - Unpack you source files
tar -xvzf HTK-3.4.1.tar.gz

Step 4 - Compile & Install HTK --- 64-bit System configure
If you have a newer version of the gcc compiler (version 4 or above),
you will need to install gcc version 3.4 compatibility modules so that HTK will compile properly.

```
gcc -v
    Thread model: posix
    gcc version 4.8.4 (Ubuntu 4.8.4-2ubuntu1~14.04.3)

sudo apt-get install libx11-dev libasound2-dev
    https://userbase.kde.org/Simon/Installation#HTK_installation_2
```



# Installing HTK 3.4 on Ubuntu 64 bit OS

```
sudo apt-get install libc6-dev-i386
sudo apt-get install libc6-dev
sudo apt-get install gcc-multilib


sudo dpkg -i getlibs-all.deb   [http://ubuntuguide.net/install-adobe-air64-bit-ubuntu-12-04-precise]
sudo getlibs -p libx11-dev
```

```
tar -xvf HTK-3.4.1.tar.gz
cd htk
```

Remove the file "configure" if you are using 64 bit OS. You need not do the following if you are using a 32 bit OS. Now open the configure.ac file using the following command :
http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/tutorial/download/comments/compiling-on-ubuntu-10.04



```
$ grep -- -m32 configure.ac
                CFLAGS="-m32 -ansi -D_SVID_SOURCE -DOSS_AUDIO -D'ARCH=\"$host_cpu\"' $CFLAGS"
```
https://forum.ubuntu-fr.org/viewtopic.php?id=927041


Now find the occurance of  "-m32" in the file remove it and save the file.
delete "-m32" from the previous line

```
sudo gedit configure.ac
```



```
autoconf
./configure
make all
sudo make install
```

[http://aravindev.blogspot.co.uk/2013/08/installing-htk-34-on-ubuntu-64-bit-os.html]






### ERRONEOUS INSTALLATION






```
sudo -s

autoconf
./configure
make all
sudo make install
```

The "new" method installs by default into /usr/local/bin.
```
exit
```


Your installation is complete. In order to check whether the installation was successful, you may run the following command in the terminal. If you get some output that doesn't seem like an error, then your htk is properly configured.

Hvite -V
http://aravindev.blogspot.co.uk/2013/08/installing-htk-34-on-ubuntu-64-bit-os.html



```
***********************************

HCompV -A -T 1 -S trainsets/training-extfiles0 -l lineObservations -I labels.mlf -o lineObservations -m -M models/hmm0.0 hmmdefs/version1-hmm-top-23vec
Calculating Fixed Variance
HMM Prototype: hmmdefs/version1-hmm-top-23vec
Segment Label: lineObservations
Num Streams : 1
UpdatingMeans: Yes
Target Direct: models/hmm0.0
*** stack smashing detected ***:
HCompV terminated


HTK is 32-bit program. Install GCC 3.4 for it to run it on a 64 bit machine. .. otherwise some part works / some gets stack overflow.
```
[http://www.ling.ohio-state.edu/~bromberg/htk_problems.html]



SOLUTION


Installing HTK on 64-bit Architectures
```
grep -- -m32 configure.ac
				CFLAGS="-m32 -ansi -D_SVID_SOURCE -DOSS_AUDIO -D'ARCH=\"$host_cpu\"' $CFLAGS"

change to: >>

                CFLAGS="-m64 -ansi -D_SVID_SOURCE -DOSS_AUDIO -D'ARCH=\"$host_cpu\"' $CFLAGS"
```
[http://markstoehr.com/2014/04/09/Installing-HTK-on-64-bit-architectures/]




```
autoconf
./configure
make all
sudo make install
```

still the same problem


```
*** stack smashing detected ***: HCompV terminated
scripts/train.sh: line 220: 8330: Abort(coredump)
```
