Running the java tests

Install the JDK
Install the Wacom Signature SDK

Start a dos prompt
C:\test\java>set path="\Program Files\Java\jdk1.6.0_30\bin";%path%

For 32bit java on Win7-64:
C:\test\java>set path="\Program Files (x86)\Java\jdk1.6.0_30\bin";%path%


Run a 32bit test on Win7-32 or Win7-64:
C:\Test\java>Run-Java.bat CaptureImage.java

Run a 64bit test on Win7-64:
C:\Test\java>Run-Java.x64.bat CaptureImage.java


