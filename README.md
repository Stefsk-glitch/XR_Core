# XR Core

Download the Oculus Meta app: https://www.oculus.com/download_app/?id=1582076955407037&srsltid=AfmBOops1knJgWN7ZhhdRGRMHZ9LR83JrWQqLwQbV-3IgtqTaksmp3-4 </br>

Make hotspot so the Meta Quest 3 can connect to the network </br>

Connect the Meta Quest 3 with cable to the computer </br>

Download the Meta Quest Developer Hub app:  https://developers.meta.com/horizon/downloads/package/oculus-developer-hub-win/ </br>

Turn on developer mode on for the Meta Quest 3 </br>

Go into the Meta Quest Developer Hub app and go to Device Manager and enable the ADB over Wi-Fi setting so the Meta Quest 3 can be used wireless </br>

Download Unity Hub: https://unity.com/download </br>

Download the lastest LTS for Unity and download Android (SDK, NDK Tools and OpenJDK) with this download </br>

Make a Universal 3D project </br>

Go to Edit --> Project Settings... --> XR Plugin Management and press on Install XR Plugin Mangement </br>

Click on Open XR </br>

**Do this for android and windows** </br>
Go to Project Validation in the list click on the Edit button. After this add enabled interaction profiles by clicking on the + button and add all Meta and Oculus profiles. </br> 
Go back to Project Validation and press the fix all button </br>

Go to Window --> Package Manager --> Unity registry and install the XR interaction Toolkit </br>

After that click on the Samples button and click on the Import button for the Starter Assets </br>

Go back to Project Validation and press fix button for the warning </br>

In project unfold the 3.0.7 folder and keep unfolding the folders until the folder Start Assets and double click on the Demo Scene to open the demo project </br>

Go to File --> Build Profiles and then click on Android, switch platform, click on the button Open Scene List, click on the button Add Open Scences and afterwards uncheck the Scences/SampleScene </br> 

Below Android you can select the Run Device by clicking on refresh and then selecting the device in the list </br>

Go to Edit --> Project Setting... --> XR Plug-in Management --> OpenXR under the OpenXR Feature Groups select Meta Quest Support </br>

Click on Patch to get the Demo Scene into the library of the Meta Quest 3 </br>







