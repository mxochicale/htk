Installation of HTK-3.5.beta-3.tar.gz
---

#### INSTALLATION AND TESTING


```
$~/htk_source/htk/sources$
tar zxf HTK-3.5.beta-3.tar.gz
ls
cd htk
ls
HTKLib/
ls
make -f MakefileCPU
ls
cd ../HTKTools/
ls
make -f MakefileCPU
cd ../HLMLib/
ls
make -f MakefileCPU
cd ../HLMTools/
make -f MakefileCPU
cd ../HTKLVRec/
make -f MakefileCPU
ls
cd ..
ls
cd samples/
ls
cd HTKDemo/
ls
mkdir -p proto tests hmms.hmm0 hmms.hmm1 hmms.hmm2 hmms.hmm3 hmms.tmp
export PATH=/home/map479-admin/htk_source/htk/HTKTools:/home/map479-admin/htk_source/htk/HLMTools:$PATH
ls
./runDemo
ls configs/
./runDemo monPlainM4S1
./runDemo configs/monPlainM4S1.dcf
ls
rmdir hmms.hmm?
mkdir -p hmms/hmm.0 hmms/hmm.1 hmms/hmm.2 hmms/hmm.3
./runDemo configs/monPlainM4S1.dcf
mkdir test
./runDemo configs/monPlainM4S1.dcf
ls configs/
./runDemo configs/triTiedStateS1.dcf
mkdir -p hmms/tmp
./runDemo configs/triTiedStateS1.dcf
 ```


#### HTKDemo


 ```
$~/htk_source/htk/samples/HTKDemo$
tar zxf HTK-3.5.beta-3.tar.gz
ls
cd htk
ls
cd HTKLib/
ls
make -f MakefileCPU
ls
cd ../HTKTools/
ls
make -f MakefileCPU
cd ../HLMLib/
ls
make -f MakefileCPU
cd ../HLMTools/
make -f MakefileCPU
cd ../HTKLVRec/
make -f MakefileCPU
ls
cd ..
ls
cd samples/
ls
cd HTKDemo/
ls
mkdir -p proto tests hmms.hmm0 hmms.hmm1 hmms.hmm2 hmms.hmm3 hmms.tmp
export PATH=/home/map479-admin/htk_source/htk/HTKTools:/home/map479-admin/htk_source/htk/HLMTools:$PATH
ls
./runDemo
ls configs/
./runDemo monPlainM4S1
./runDemo configs/monPlainM4S1.dcf
ls
rmdir hmms.hmm?
mkdir -p hmms/hmm.0 hmms/hmm.1 hmms/hmm.2 hmms/hmm.3
./runDemo configs/monPlainM4S1.dcf
mkdir test
./runDemo configs/monPlainM4S1.dcf
ls configs/
./runDemo configs/triTiedStateS1.dcf
mkdir -p hmms/tmp
./runDemo configs/triTiedStateS1.dcf

```
