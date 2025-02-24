# Unity Quest 3D Project

## Setup Instructions

### Meta Quest software setup

1. Download the Meta Quest
   app [here](https://www.oculus.com/download_app/?id=1582076955407037&srsltid=AfmBOops1knJgWN7ZhhdRGRMHZ9LR83JrWQqLwQbV-3IgtqTaksmp3-4)
2. Create a Meta Quest account (existing or new) and log in to the app
3. Make sure Meta Quest and PC are on the same Wi-Fi network
4. Connect the Quest with a USB-C cable to the PC
5. Setup the Quest headset in the Meta app
6. Download the Meta Quest Developer Hub
   app [here](https://developers.meta.com/horizon/downloads/package/oculus-developer-hub-win/)
7. Turn on developer mode on for the Meta Quest
   3 [(official documentation)](https://developers.meta.com/horizon/documentation/native/android/mobile-device-setup/)
8. Enable ADB over Wi-Fi for the headset in the Developer hub app --> Device Manager --> Device Actions --> ADB over
   Wi-Fi
9. Allow unknown sources
    - Meta Quest Link app --> Settings --> General --> Enable "Unknown Sources"

### Unity Setup

1. Download Unity Hub [here](https://unity.com/download)
2. Download the latest LTS for Unity and download Android (SDK, NDK Tools and OpenJDK)
3. Create a new Universal 3D project
4. Install XR Plugin Management:
    - Edit --> Project Settings --> XR Plugin Management --> Install XR Plugin Management
5. Add all Meta and Oculus profiles (**Do this for both Android and Windows**)
    - Edit --> Project Settings --> Project Validation --> Edit --> Add enabled interaction profiles:
        - Add all Meta and Oculus profiles under the '+' button
    - Edit --> Project Settings --> Project Validation --> Fix all button
6. Install XR interaction Toolkit package
    - Window --> Package Manager --> Unity registry --> Search "XR interaction Toolkit" and install
    - After install, import Starter Assets under "Samples" button
    - Edit --> Project Settings --> XR Plugin Management --> OpenXR --> Select "Meta Quest Support"
7. Fix project validation
    - Edit --> Project Settings --> Project Validation --> Fix all
8. Open DemoScene in Unity Scene viewer
    - Project window --> Assets --> Samples --> XR Interaction Toolkit --> 3.0.7 --> Double click Starter Assets -->
      Open "DemoScene"
9. Switch build platform to Android
    - File --> Build Profiles --> Android --> Switch platform
10. Add current Scene to Scene list
    - File --> Build Profiles --> Android --> Open Scene list --> Uncheck "Scenes/SampleScene" --> Add Open Scenes
11. Set the device to run the project on
    - File --> Build Profiles --> Android --> Refresh --> Run Device --> Select Meta Quest device
12. Build and deploy the app on the Quest
    - File --> Build Profiles --> Android --> Build
    - File --> Build Profiles --> Android --> Check Development Build box --> Patch
13. Launch the app on the Quest
    - Library --> Unknown Sources --> Open the project
    - Enjoy :D

### Problems we faced during the make of the project

**When attempting to uninstall our game on the Meta Quest 3 by navigating to Library --> Unknown Sources --> Three Dots --> Uninstall, the game did not uninstall as expected. This appears to be a common issue within the Meta community.** </br>

After researching the problem on the Meta forums, we found a solution:
1.	Open Meta Developer Hub
2.	Go to the Device section
3.	Run the following command: ```adb uninstall <package>```

This successfully removes the game from the device so we could patch our game to the Meta Quest 3 again. </br>

**Pushing ball against the ground made game crash or physics go crazy.** </br>

This problem is solved by adding script to the ball that checks if the ball is grabbed or not. </br>
If the ball is grabbed it turns off the bounce material otherwise it has the bounce material and the ball is able to bounce. </br>



