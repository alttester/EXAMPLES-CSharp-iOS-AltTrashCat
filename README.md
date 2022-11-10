# iOS Build with CSharp Tests

This repository shows a few C# tests that use the page object model and AltTester Unity SDK to test the Unity endless runner sample:
https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901

### Before running the tests on iOS
- in the `ios_tests.sh` script please change the value for `APPIUM_XCODEORGID` with your Team ID (uniquie 10-character string) in Apple dev account
- export `IOS_UDID=<your-device-udid>` then run the script `ios_tests.sh`

### Running the tests on iOS
The tests are meant to be run on an iOS device.
The app is provided at https://altom.com/app/uploads/AltTester/TrashCat/TrashCat.ipa.zip and needs to be included unzipped under project.
`./ios_tests.sh`

This script will:

- start the app on your device
- run the tests
- stop the app after the test are done

Info about the required setup and how to run these tests can be found here:
https://altom.com/alttester/docs/sdk/pages/alttester-with-appium.html#