# iOS Build with CSharp Tests

This repository shows a few C# tests that use the page object model and AltTester Unity SDK to test the Unity endless runner sample:
https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901

### Before running the tests on iOS
- in the `ios_tests.sh` script please change the value for `APPIUM_XCODEORGID` with your Team ID (uniquie 10-character string) in Apple dev account
- export `IOS_UDID=<your-device-udid>` then run the script `ios_tests.sh`
- considering that the IProxy does not have a way of setting up `reverse port forwarding`, to be able to connect it is necessary to follow the steps from https://alttester.com/docs/sdk/latest/pages/advanced-usage.html#in-case-of-ios 

### Running the tests on iOS
1. Install the [AltTesterDesktop](https://alttester.com/alttester/#pricing), then open it (you need to accept the Terms and Conditions if the AltTester is opened for the first time).
2. The tests are meant to be run on an iOS device.
The app is provided at https://alttester.com/app/uploads/AltTester/TrashCat/TrashCatiOS2_0_1.ipa.zip and needs to be included unzipped under project.
3. `./ios_tests.sh` in your terminal.

This script will:

- start the app on your device
- run the tests
- stop the app after the test are done

Info about the required setup and how to run these tests can be found here:
https://alttester.com/docs/sdk/latest/pages/alttester-with-appium.html